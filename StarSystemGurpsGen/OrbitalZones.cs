using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen{
    public class Range{
        public decimal lowerBound { get; set; }
        public decimal upperBound { get; set; }

        public Range(decimal low, decimal high){
            this.lowerBound = low;
            this.upperBound = high;
        }


        //copy constructor
        public Range(Range incoming){
            this.lowerBound = incoming.lowerBound;
            this.upperBound = incoming.upperBound;
        }

        public decimal getLength(){
            return this.upperBound - this.lowerBound;
        }

        public bool withinRange(decimal orbit){
            if (lowerBound <= orbit && orbit >= upperBound){
                return true;
            }

            return false;
        }


    }

    public class forbiddenZone : Range{
        public int primaryStar { get; set; }
        public int secondaryStar { get; set; }

        public forbiddenZone(decimal lower,decimal upper,int primary,int secondary): base(lower, upper){
            this.primaryStar = primary;
            this.secondaryStar = secondary;
        }

        public forbiddenZone(Range incoming, int primary, int secondary): base(incoming)
        {
            this.primaryStar = primary;
            this.secondaryStar = secondary;
        }
    }

    public class cleanZone : Range{
        public int ownershipFlag { get; set; }

         public cleanZone(decimal lower,decimal upper,int ownership): base(lower, upper){
            this.ownershipFlag = ownership;
        }

         public cleanZone(Range incoming, int ownership): base(incoming)
         {
             this.ownershipFlag = ownership;
         }
    }

    public class systemZones{
        //flags
        readonly static public int NOVALIDORBIT = -1;

        public List<cleanZone> formationZones { get; protected set; }
        public List<forbiddenZone> forbiddenZones { get; protected set; }
        public int starID { get; set; }
        protected Range creationRange { get; set; }

        public systemZones(int starID){
            formationZones = new List<cleanZone>();
            forbiddenZones = new List<forbiddenZone>();
            this.starID = starID;
        }
        //member functions
        public void updateCreationRange(Range creationRange){
            this.creationRange = creationRange;
        }

        //create functions
        public void createForbiddenZone(decimal lower, decimal upper, int primary, int secondary){
            this.forbiddenZones.Add(new forbiddenZone(lower, upper, primary, secondary));
        }

        public void createForbiddenZone(Range forbiddenRange, int primary, int secondary){
            this.forbiddenZones.Add(new forbiddenZone(forbiddenRange, primary, secondary));
        }

        public void createCleanZones(Range fullCreationRange) {
            updateCreationRange(fullCreationRange);
            decimal currentPos = this.creationRange.lowerBound;

            //default values
            int ownershipFlag = this.starID;

            if (this.forbiddenZones.Count == 0){
                this.formationZones.Add(new cleanZone(this.creationRange, this.starID));
                return;
            }

            foreach (forbiddenZone o in this.forbiddenZones){
                if (currentPos < o.lowerBound && this.creationRange.upperBound <= o.lowerBound){
                    //CASE 1: Both the current position and outer radius are before the forbidden zone
                    // This clean zone is from currentPos to the outer radius. Is the end of our generation
                    this.formationZones.Add(new cleanZone(currentPos, this.creationRange.upperBound, ownershipFlag));
                    return;
                }

                if (currentPos < o.lowerBound && this.creationRange.upperBound > o.upperBound){
                    //CASE 2: The current position is below the forbidden zone, and the outer radius is beyond it
                    // This clean zone is from current position to the lower bound of the forbidden zone
                    // We then move the pointer to the end of the higher bound.
                    this.formationZones.Add(new cleanZone(currentPos, o.lowerBound, ownershipFlag));
                    if (o.primaryStar != this.starID) return; //return now if you lose primary status.
                    ownershipFlag = this.updateOwnership(ownershipFlag, o.primaryStar, o.secondaryStar);
                    currentPos = o.upperBound;
                }

                if (currentPos < o.lowerBound && o.lowerBound < this.creationRange.upperBound &&
                    this.creationRange.upperBound <= o.upperBound)
                {
                    //CASE 3: The current position is below the forbidden zone, and the outer radius is within it.
                    // The clean zone is from the current position to the lower bound of the forbidden zone
                    // We then return, no more clear zones.
                    this.formationZones.Add(new cleanZone(currentPos, o.lowerBound, ownershipFlag));
                    return;
                }

                if (currentPos >= o.lowerBound && o.upperBound < this.creationRange.upperBound){
                    //CASE 4: The current position is within a forbidden zone, and the outer radius is beyond it.
                    //Move forward the pointers, but don't add a clean zone
                    currentPos = o.upperBound;
                    ownershipFlag = this.updateOwnership(ownershipFlag, o.primaryStar, o.secondaryStar);
                }

            }

            if (currentPos < this.creationRange.upperBound){
                // CASE 5: current position is under the upperBound. Add it, and return.
                this.formationZones.Add(new cleanZone(currentPos, this.creationRange.upperBound, ownershipFlag));
                return;
            }

           
        }

        public void createCleanZones(decimal inner, decimal outer){
           this.createCleanZones(new Range(inner, outer));
        }

        //get minimal and maximal functions.
        public decimal getMinimalCleanZone(){
            if (this.formationZones.Count == 0) return systemZones.NOVALIDORBIT;
            return this.formationZones[0].lowerBound;
        }

        public decimal getMaximalCleanZone(){
            if (this.formationZones.Count == 0) return systemZones.NOVALIDORBIT;
            return this.formationZones[this.formationZones.Count - 1].upperBound;
        }


        //check within range functions. 
        public bool isWithinForbiddenZone(decimal orbit){
            foreach (forbiddenZone o in forbiddenZones){
                if (o.withinRange(orbit) == true) return true;
            }
            return false;
        }

        public bool isWithinCleanZone(decimal orbit){
            foreach (cleanZone o in formationZones){
                if (o.withinRange(orbit) == true) return true;
            }
            return false;
        }

        //check -range- function.
        public decimal verifyRange(Range checkRange)
        {
            decimal rangeAvail = 1m;
            decimal currentPos = checkRange.lowerBound;

            foreach (forbiddenZone o in this.forbiddenZones){
                if ((currentPos != checkRange.upperBound) && (currentPos < o.lowerBound) && 
                    (o.upperBound < checkRange.upperBound)){
                    //CASE 1: Forbidden Zone is beyond the lower and higher bounds
                    rangeAvail = rangeAvail - ((o.upperBound - o.lowerBound) / checkRange.getLength());
                    currentPos = o.upperBound;
                }

                if ((currentPos != checkRange.upperBound) && (currentPos > o.lowerBound) &&
                    (currentPos < checkRange.upperBound) && (checkRange.upperBound > o.upperBound)) { 
                    //CASE 2: Current Position is within the forbidden zone, but lower than the upper bound
                    rangeAvail = rangeAvail - ((o.upperBound - currentPos) / checkRange.getLength());
                    currentPos = o.upperBound;
                }


                if ((currentPos != checkRange.upperBound) && (currentPos < o.lowerBound) &&
                    (checkRange.upperBound < o.upperBound) && (checkRange.upperBound > o.lowerBound)){
                    //CASE 3: Upper bound is within a forbidden Zone.
                    rangeAvail = rangeAvail - ((checkRange.upperBound - o.lowerBound) / checkRange.getLength());
                    currentPos = checkRange.upperBound; 

                }

                //Case 4: both are within a forbidden zone
                if ((currentPos != checkRange.upperBound) && (o.lowerBound < currentPos) &&
                    (checkRange.upperBound < o.upperBound)) {

                        rangeAvail = rangeAvail - ((checkRange.upperBound - currentPos) / checkRange.getLength());
                        currentPos = checkRange.upperBound;
                
                }
                //Case 5: Both are entirely clear of the forbidden zone, but to the right
                // has no if block
                if ((currentPos != checkRange.upperBound) && (currentPos < o.lowerBound) &&
                    (checkRange.upperBound <= o.lowerBound))
                    currentPos = checkRange.upperBound;
            }

            return rangeAvail;
        }

        public decimal verifyRange(decimal lower, decimal upper){
            return this.verifyRange(new Range(lower, upper));
        }

        //range pick equations
        public decimal pickInRange(Range validRange){
            decimal rangeIncrement = (decimal)Math.Pow(10, 6);
            decimal currentPos = validRange.lowerBound;
            do {
                if (!this.isWithinForbiddenZone(currentPos)) return currentPos;
                currentPos += validRange.getLength() / rangeIncrement;
            }  while (currentPos <= validRange.upperBound);

            return systemZones.NOVALIDORBIT;
        }

        public decimal pickInRange(decimal lower, decimal higher){
            return this.pickInRange(new Range(lower, higher));
        }

        //orbital help functionality
        //only call if you are about to enter a FZ. Or this will return nonsense.
        public decimal getNextCleanOrbit(decimal orbit){
            foreach (cleanZone o in formationZones){
                if (orbit < o.lowerBound) return o.lowerBound;
            }

            return systemZones.NOVALIDORBIT;
        }
        //sorting functions
        public void sortForbiddenZones(){
            forbiddenZones.Sort((x, y) => x.lowerBound.CompareTo(y.lowerBound));
        }

        public void sortCleanZones(){
            formationZones.Sort((x, y) => x.lowerBound.CompareTo(y.lowerBound));
        }

        //determination functions
        public bool isAnyValidFormationZone(){
            if (this.formationZones.Count > 0) return true;
            return false;
        }
        
        //helpful functions
        protected int updateOwnership(int current, int primary, int secondary){
            
            if ((current == Star.IS_PRIMARY) && (primary == Star.IS_PRIMARY) &&
                (secondary == Star.IS_SECONDARY)) return Satelite.ORBIT_PRISEC;

            if ((current == Star.IS_PRIMARY) && (primary == Star.IS_PRIMARY) &&
                (secondary == Star.IS_TRINARY)) return Satelite.ORBIT_PRITRI;

            if ((current == Star.IS_SECONDARY) && (primary == Star.IS_SECONDARY) &&
                (secondary == Star.IS_SECCOMP)) return Satelite.ORBIT_SECCOM;

            if ((current == Star.IS_SECONDARY) && (primary == Star.IS_SECONDARY) &&
                (secondary == Star.IS_TRINARY)) return Satelite.ORBIT_SECTRI;

            if ((current == Star.IS_TRINARY) && (primary == Star.IS_TRINARY) &&
                (secondary == Star.IS_TRICOMP)) return Satelite.ORBIT_TRICOM;
            
            if ((current == Satelite.ORBIT_PRISEC) &&
                ((primary == Star.IS_PRIMARY) || (primary == Star.IS_SECONDARY)) &&
                (secondary == Star.IS_TRINARY)) return Satelite.ORBIT_PRISECTRI;


            return Satelite.BADPARENT;
         }
    }

}