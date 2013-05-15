using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class formationHelper
    {
        //flags
        readonly static public int NOVALIDORBIT = -1;
        readonly static public int DIRLEFT = 1;
        readonly static public int DIRRIGHT = 2;

        public List<cleanZone> formationZones { get; protected set; }
        public List<forbiddenZone> forbiddenZones { get; protected set; }
        public int starID { get; set; }
        protected Range creationRange { get; set; }

        public formationHelper(int starID)
        {
            formationZones = new List<cleanZone>();
            forbiddenZones = new List<forbiddenZone>();
            this.starID = starID;
        }
        //member functions
        public void updateCreationRange(Range creationRange)
        {
            this.creationRange = creationRange;
        }

        //create functions
        public void createForbiddenZone(double lower, double upper, int primary, int secondary)
        {
            this.forbiddenZones.Add(new forbiddenZone(lower, upper, primary, secondary));
        }

        public void createForbiddenZone(Range forbiddenRange, int primary, int secondary)
        {
            this.forbiddenZones.Add(new forbiddenZone(forbiddenRange, primary, secondary));
        }

        public void createForbiddenZone(forbiddenZone incoming)
        {
            this.forbiddenZones.Add(new forbiddenZone(incoming));
        }

        public void createCleanZones(Range fullCreationRange)
        {
            updateCreationRange(fullCreationRange);
            double currentPos = this.creationRange.lowerBound;

            //default values
            int ownershipFlag = this.starID;
            int orbitDesc = this.starID;

            if (this.forbiddenZones.Count == 0)
            {
                this.formationZones.Add(new cleanZone(this.creationRange, this.starID, this.starID));
                return;
            }

            foreach (forbiddenZone o in this.forbiddenZones)
            {
                if (currentPos < o.lowerBound && this.creationRange.upperBound <= o.lowerBound)
                {
                    //CASE 1: Both the current position and outer radius are before the forbidden zone
                    // This clean zone is from currentPos to the outer radius. Is the end of our generation
                    this.formationZones.Add(new cleanZone(currentPos, this.creationRange.upperBound, this.starID, this.starID));
                    return;
                }

                if (currentPos < o.lowerBound && this.creationRange.upperBound > o.upperBound)
                {
                    //CASE 2: The current position is below the forbidden zone, and the outer radius is beyond it
                    // This clean zone is from current position to the lower bound of the forbidden zone
                    // We then move the pointer to the end of the higher bound.
                    this.formationZones.Add(new cleanZone(currentPos, o.lowerBound, ownershipFlag, orbitDesc));
                    if (o.primaryStar != this.starID) return; //return now if you lose primary status.
                    ownershipFlag = o.primaryStar;
                    orbitDesc = this.getNewOrbitDesc(orbitDesc, o.primaryStar, o.secondaryStar);
                    //ownershipFlag = 99;
                    currentPos = o.upperBound;
                }

                if (currentPos < o.lowerBound && o.lowerBound < this.creationRange.upperBound &&
                    this.creationRange.upperBound <= o.upperBound)
                {
                    //CASE 3: The current position is below the forbidden zone, and the outer radius is within it.
                    // The clean zone is from the current position to the lower bound of the forbidden zone
                    // We then return, no more clear zones.
                    this.formationZones.Add(new cleanZone(currentPos, o.lowerBound, ownershipFlag, orbitDesc));
                    return;
                }

                if (currentPos >= o.lowerBound && o.upperBound < this.creationRange.upperBound)
                {
                    //CASE 4: The current position is within a forbidden zone, and the outer radius is beyond it.
                    //Move forward the pointers, but don't add a clean zone
                    currentPos = o.upperBound;
                    ownershipFlag = o.primaryStar;
                    orbitDesc = this.getNewOrbitDesc(orbitDesc, o.primaryStar, o.secondaryStar);
                    //ownershipFlag = 99;
                }

            }

            if (currentPos < this.creationRange.upperBound)
            {
                // CASE 5: current position is under the upperBound. Add it, and return.
                this.formationZones.Add(new cleanZone(currentPos, this.creationRange.upperBound, ownershipFlag, orbitDesc));
                return;
            }


        }

        public int getNewOrbitDesc(int prevOrbit, int primaryFZ, int secondaryFZ)
        {
            if (prevOrbit == Star.IS_PRIMARY)
            {
                if (primaryFZ == Star.IS_PRIMARY && secondaryFZ == Star.IS_SECONDARY)
                    return Satellite.ORBIT_PRISEC;

            }

            if (prevOrbit == Star.IS_SECONDARY)
            {
                if (primaryFZ == Star.IS_SECONDARY && secondaryFZ == Star.IS_SECCOMP)
                    return Satellite.ORBIT_SECCOM;

                if (primaryFZ == Star.IS_SECCOMP && secondaryFZ == Star.IS_SECONDARY)
                    return Satellite.ORBIT_SECCOM;

                if (primaryFZ == Star.IS_SECONDARY && secondaryFZ == Star.IS_PRIMARY)
                    return Satellite.ORBIT_PRISEC;
                
            }

            Console.WriteLine("PrevOrbit: {0} , Primary Star: {1}, Secondary Star: {2}", prevOrbit, primaryFZ, secondaryFZ);

            if (prevOrbit == Star.IS_TRINARY) 
            {
                if (primaryFZ == Star.IS_TRINARY && secondaryFZ == Star.IS_TRICOMP)
                    return Satellite.ORBIT_TRICOM;
            }

            if (prevOrbit == Satellite.ORBIT_PRISEC || prevOrbit == Satellite.ORBIT_SECCOM || prevOrbit == Satellite.ORBIT_TRICOM)
                return prevOrbit;

            return Satellite.ERROR_ORBIT;

            
        }

        public void createCleanZones(double inner, double outer)
        {
            this.createCleanZones(new Range(inner, outer));
        }

        //get minimal and maximal functions.
        public double getMinimalCleanZone()
        {
            if (this.formationZones.Count == 0) return formationHelper.NOVALIDORBIT;
            return this.formationZones[0].lowerBound;
        }

        public double getMaximalCleanZone()
        {
            if (this.formationZones.Count == 0) return formationHelper.NOVALIDORBIT;
            return this.formationZones[this.formationZones.Count - 1].upperBound;
        }

        //gets the range for this
        public Range getRange(double orbit)
        {
            foreach (cleanZone o in formationZones)
            {
                if (o.withinRange(orbit) == true) return new Range(o.lowerBound, o.upperBound);
            }

            foreach (forbiddenZone o in forbiddenZones)
            {
                if (o.withinRange(orbit) == true) return new Range(o.lowerBound, o.upperBound);
            }

            return new Range(0, 0);
        }

        public int getOwnership(double orbital)
        {
            foreach (cleanZone o in formationZones)
            {
                if (o.withinRange(orbital) == true) return o.orbitDesc;
            }

            return -9999; //INVALID DATA.
        }

        //check within range functions. 
        public bool isWithinForbiddenZone(double orbit)
        {
            foreach (forbiddenZone o in forbiddenZones)
            {
                if (o.withinRange(orbit) == true) return true;
            }
            return false;
        }

        public bool isWithinCleanZone(double orbit)
        {
            foreach (cleanZone o in formationZones)
            {
                if (o.withinRange(orbit) == true) return true;
            }

            //Epistellar check.
            if (orbit < creationRange.lowerBound && (!isWithinForbiddenZone(orbit)))
                return true;

            return false;
        }

        
        //check range width
        public double getRangeWidth(double orbit)
        {
            foreach (cleanZone o in formationZones)
            {
                if (o.withinRange(orbit) == true) return o.length;
            }

            foreach (forbiddenZone o in forbiddenZones)
            {
                if (o.withinRange(orbit) == true) return o.length;
            }

            return 0.0;
        }

        //check -range- function.
        public double verifyRange(Range checkRange)
        {
            double rangeAvail = 1;
            double currentPos = checkRange.lowerBound;

            //escape hatch for this condition

            if (this.forbiddenZones.Count == 0)
                return 1;

            //The bug here appears to be if it's ENTIRELY in a clean zone.
            //Which is.. wat? Still, fixed.  
            foreach (cleanZone o in this.formationZones)
            {
                if (checkRange.lowerBound >= o.lowerBound && checkRange.upperBound <= o.upperBound)
                    return 1;
            }

            foreach (forbiddenZone o in this.forbiddenZones)
            {
                //CASE 1: The forbidden zone is between here and the end
                if ((currentPos < checkRange.upperBound) && (currentPos < o.lowerBound)
                    && (o.upperBound <= checkRange.upperBound))
                {
                    rangeAvail = rangeAvail - ((o.upperBound - o.lowerBound) / checkRange.length);
                    if (rangeAvail == 0) return rangeAvail;

                    currentPos = o.upperBound;
                }

                //CASE 2: This is within a forbidden zone
                if ((checkRange.lowerBound >= o.lowerBound) && (checkRange.upperBound <= o.upperBound))
                    return 0;

                //CASE 3: Current Position is within a forbidden zone and it cotnains the end.
                if ((currentPos < checkRange.upperBound) && (currentPos > o.lowerBound)
                    && (checkRange.upperBound <= o.upperBound))
                {
                    rangeAvail = rangeAvail - ((o.upperBound - currentPos) / checkRange.length);
                    if (rangeAvail == 0) return rangeAvail;

                    currentPos = checkRange.upperBound;
                }

                //CASE 4: Current Position is within a forbidden zone and it does not contain the end.
                if ((currentPos < checkRange.upperBound) && (currentPos > o.lowerBound)
                    && (checkRange.upperBound > o.upperBound))
                {
                    rangeAvail = rangeAvail - ((o.upperBound - currentPos) / checkRange.length);
                    if (rangeAvail == 0) return rangeAvail;

                    currentPos = o.upperBound;
                }

                //CASE 5: The end is within a forbidden zone but the current position is not
                if ((currentPos < checkRange.upperBound) && (currentPos < o.lowerBound)
                    && (checkRange.upperBound >= o.lowerBound) && (checkRange.upperBound < o.upperBound))
                {
                    rangeAvail = rangeAvail - ((checkRange.upperBound - o.lowerBound) / checkRange.length);
                    if (rangeAvail == 0) return rangeAvail;

                    currentPos = checkRange.upperBound;
                }

                //CASE 6: No IF condition if the forbidden zone is entirely to the left or right.



            }

            if (rangeAvail >= 0 && rangeAvail <= 1) return rangeAvail;
            else throw new Exception("RangeAvail is " + rangeAvail + " and exceeds 0-100%.");
        }



        public double verifyRange(double lower, double upper)
        {
            return this.verifyRange(new Range(lower, upper));
        }

        public double getClosestDistFromForbiddenZone(double orbit)
        {
            double dist = 9990;
            double var = 0;
            
            if (this.forbiddenZones.Count == 0)
                return -1;

            foreach (forbiddenZone o in this.forbiddenZones)
            {
                var = Math.Abs(orbit - o.lowerBound);
                if (var < dist) dist = var;

                var = Math.Abs(orbit - o.upperBound);
                if (var < dist) dist = var;
                
            }

            return dist;
        }

        public double getClosestForbiddenZoneRatio(double orbit)
        {
            double ratio = 9999;
            double var = 0;

            if (this.forbiddenZones.Count == 0)
                return -1;

            foreach (forbiddenZone o in this.forbiddenZones)
            {
                
                //lower Bound check
                if (o.lowerBound > orbit)
                    var = o.lowerBound / orbit;
                else
                    var = orbit / o.lowerBound;

                if (var > ratio) ratio = var;


                //upper Bound check
                if (o.upperBound > orbit)
                    var = o.upperBound / orbit;
                else
                    var = orbit / o.upperBound;

                if (var > ratio) ratio = var;
            }

            return ratio;
        }

        //range pick equations
        public double pickInRange(Range validRange)
        {
            double rangeIncrement = (double)Math.Pow(10, 6);
            double currentPos = validRange.lowerBound;
            do
            {
                if (!this.isWithinForbiddenZone(currentPos)) return currentPos;
                currentPos += validRange.length / rangeIncrement;
            } while (currentPos <= validRange.upperBound);

            return formationHelper.NOVALIDORBIT;
        }

        public double pickInRange(double lower, double higher)
        {
            return this.pickInRange(new Range(lower, higher));
        }

        //orbital help functionality
        //only call if you are about to enter a FZ. Or this will return nonsense.
        public double getNextCleanOrbit(double orbit, int flag)
        {
            foreach (cleanZone o in formationZones)
            {
                if (o.withinRange(orbit)) return orbit;

                if (o.lowerBound > orbit && flag == DIRRIGHT) return o.lowerBound; 
                if (o.upperBound < orbit && flag == DIRLEFT) return o.upperBound;
            }

            return formationHelper.NOVALIDORBIT; 
        }

        //get adjacency functions
        public int getAdjacencyMod(double orbital)
        {
            int mod = 0;
            bool IRorbitChecked = false;
            bool ORorbitChecked = false;
            foreach (forbiddenZone o in forbiddenZones)
            {
                //forbidden zone left.
                if ((orbital / 1.4 <= o.upperBound && orbital / 2.0 >= o.upperBound) || o.upperBound <= orbital - .15)
                {
                    mod = mod - 6;
                }

                //inner radius
                if ((orbital / 1.4 <= creationRange.lowerBound && orbital / 2.0 >= creationRange.lowerBound) ||
                    (orbital - .15 <= creationRange.lowerBound) && !(IRorbitChecked))
                {
                    mod = mod - 3;
                    IRorbitChecked = true;
                }

                //outer radius
                if ((orbital * 1.4 >= creationRange.upperBound && orbital * 2.0 <= creationRange.upperBound) && (!ORorbitChecked))
                {
                    mod = mod - 3;
                    ORorbitChecked = true;
                }

                //forbidden zone right
                if ((orbital * 1.4 >= o.lowerBound && orbital * 2.0 <= o.lowerBound))
                {
                    mod = mod - 6;
                }
            }

            return mod;
        }

        //sorting functions
        public void sortForbiddenZones()
        {
            forbiddenZones.Sort((x, y) => x.lowerBound.CompareTo(y.lowerBound));
        }

        public void sortCleanZones()
        {
            formationZones.Sort((x, y) => x.lowerBound.CompareTo(y.lowerBound));
        }

        //determination functions
        public bool isAnyValidFormationZone()
        {
            if (this.formationZones.Count > 0) return true;
            return false;
        }

        //helpful functions
         protected int updateOwnership(int current, int primary, int secondary)
               {
                    

                   return Satellite.ERROR_ORBIT;
               } 

        public override String ToString()
        {
            String desc;
            String nL = Environment.NewLine + "    ";

            desc = "These system zones contain: ";
            foreach (forbiddenZone o in forbiddenZones)
            {
                desc += nL + "" + o;
            }

            foreach (cleanZone o in formationZones)
            {
                desc += nL + "" + o;
            }

            return desc;
        }

    }
}
