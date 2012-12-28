using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    class OrbitalZones
    {

        //zone type flags
        //search type flags
        public static int DIR_LEFT = 901;
        public static int DIR_RIGHT = 902;

        //Internal flags (return conditions) 
        public static int NOGOODORBITS = 5;
        public static int LIMITEDORBITS = 6;
        public static int MOSTLYSAFEORBITS = 7;
        public static int ENDOFORBITAL = -1;
        public static int OWNERPRIMARY = -10; //says that the owner is NOT this star.
        public static int OWNERSELF = 10; //says the owner is this star.

        //variables
        public List<OrbitalPair> forZones { get; set; }
        protected List<OrbitalPair> cleanZones { get; set; }
        public bool noValidFormationZone { get; protected set; }
        public int starID { get; set; } //star ID
        protected decimal innerRadius { get; set; }
        protected decimal outerRadius { get; set; }

        //calculated variables. Simplifies code.
        protected decimal minimumRadius { get; set; }
        protected decimal maximumRadius { get; set; }


        public OrbitalZones(int currStar){
            this.starID = currStar;
            noValidFormationZone = true; //set this to true normally
            forZones = new List<OrbitalPair>();
            cleanZones = new List<OrbitalPair>();
        }

        //once we get all our forbidden zones set, we can create our clean zones
        public void initalizeCleanZones(decimal innerRadius, decimal outerRadius, int numStars)
        {
            //set some object fields
            this.innerRadius = innerRadius;
            this.outerRadius = outerRadius;

            //I really like having optional parameters for specialized cases.

            //actul processing for clean zones
            decimal currPos = innerRadius;
            int currOwnership = OrbitalZones.OWNERSELF;
            bool currPrimary = true;

            if (numStars == 1){
                noValidFormationZone = false;
                cleanZones.Add(new OrbitalPair(innerRadius, outerRadius, true, 0, OrbitalPair.IS_GOODZONE));
                return;
            }



            foreach (OrbitalPair o in this.forZones){
                //Console.WriteLine("New forbidden loop");
                if (currPos < o.lowerBound && outerRadius <= o.lowerBound)
                {
                    //Console.WriteLine("Case 1");
                    //optimal case: the forbidden zone is beyond the outer radius (or equal).
                    this.noValidFormationZone = false;
                    cleanZones.Add(new OrbitalPair(currPos, outerRadius, currPrimary, currOwnership, OrbitalPair.IS_GOODZONE));
                    return;
                }

                if (currPos < o.lowerBound && outerRadius > o.higherBound)
                {
                    //Console.WriteLine("Case 2");
                    this.noValidFormationZone = false;
                    cleanZones.Add(new OrbitalPair(currPos, o.lowerBound, currPrimary, currOwnership, OrbitalPair.IS_GOODZONE));

                    //reset details
                    currPrimary = o.isPrimary; //reset the next zone for the primary concerns
                    currOwnership = getOwnership(currOwnership, o.partnerStar, o.isPrimary);
                    currPos = o.higherBound;                    
                }

                if (currPos < o.lowerBound && outerRadius < o.higherBound)
                {
                    //Console.WriteLine("Case 3");
                    this.noValidFormationZone = false;
                    cleanZones.Add(new OrbitalPair(currPos, o.lowerBound, currPrimary, currOwnership, OrbitalPair.IS_GOODZONE));
                    return; //No more clean zones.
                }

                if (currPos > o.lowerBound && o.higherBound < outerRadius)
                {
                    //Console.WriteLine("Case 4");
                    //move forward the position pointer
                    
                    currPos = o.higherBound;
                    currPrimary = o.isPrimary;
                    currOwnership = getOwnership(currOwnership, o.partnerStar, o.isPrimary);
                }
                
            }

            if (currPos < outerRadius){
                //Console.WriteLine("CASE 5");
                cleanZones.Add(new OrbitalPair(currPos, outerRadius, currPrimary, currOwnership, OrbitalPair.IS_GOODZONE));
                this.noValidFormationZone = false;
                return;
            }

        }

        public void setMaxMin()
        {
            this.minimumRadius = cleanZones[0].lowerBound;
            this.maximumRadius = cleanZones[cleanZones.Count - 1].higherBound;

           // Console.WriteLine("Min is {0}, Max is {1}", this.minimumRadius, this.maximumRadius);
           // Console.WriteLine();
        }
        public bool checkOrbit(decimal orbit, bool checkOnlyForbidden = false){
            
            if (checkOnlyForbidden)
            {
                foreach (OrbitalPair o in forZones)
                {
                    if (o.lowerBound <= orbit && orbit <= o.higherBound) return false;
                }

                return true;
            }

            if (!checkOnlyForbidden){
                foreach (OrbitalPair o in cleanZones){
                    if (o.lowerBound <= orbit && orbit <= o.higherBound) return true;
                }
            }



            return false;
        }

        // This detects adjacency to forbidden zones. Flag is for direction. It's part of the two adjacency functions
        public bool adjForbiddenZone(decimal orbit)
        {
            //WE DEFINE ADJACENCY AS: Within 1.4 to 2.0 orbits OR within .15 AU (In this case. See notes in next
            // function for the OTHER case). Mostly because forbidden zones do not belogn to observable orbits
            if (forZones.Count == 0) return false; //.. do I need to explain why?

            foreach (OrbitalPair fz in forZones){
                if ((orbit < fz.lowerBound) && (orbit * 1.4m >= fz.lowerBound && fz.lowerBound <= orbit * 2.0m))
                {
                    return true;
                }
                if ((orbit > fz.higherBound) && ((orbit / 1.4m < fz.higherBound && fz.higherBound >= orbit / 2.0m) || (orbit - .15m < fz.higherBound)))
                {
                    return true;
                }
            }

            return false;
        }

        //adjacency to either the outer and inner radius
        public bool adjRadius(decimal orbit)
        {
            if (orbit * 1.4m >= this.outerRadius && this.outerRadius <= orbit * 2.0m) return true;
            if ((orbit / 1.4m < this.innerRadius && this.innerRadius >= orbit / 2.0m) || orbit - .15m <= this.innerRadius) return true;

            return false;
        }

        public decimal getNextOrbit(decimal curPos, int flag, Dice ourBag){
            //constants
            decimal tmpVal, rollVal;

            decimal minOrbitalMultiple = 1.4m;
            decimal minOrbitalSep = .15m;
            


            if (flag == OrbitalZones.DIR_LEFT){
                do{
                    if ((curPos / minOrbitalMultiple) < this.minimumRadius || (curPos - minOrbitalSep) < this.minimumRadius)
                        return OrbitalZones.ENDOFORBITAL;  //no more orbitals to the left.

                    rollVal = ourBag.rollRange(1.4m, .6m);
                    tmpVal = curPos / rollVal;
                    //Console.WriteLine("Prev Orbit: {0} AU, roll Val: {1} AU, new Orbit: {2} AU", curPos, rollVal, tmpVal);
                    
                    if (curPos - .15m < tmpVal)  tmpVal = curPos - .15m;
                    
                    curPos = tmpVal;
                } while (!checkOrbit(tmpVal));
               
                return tmpVal;
                    
                
            }

            if (flag == OrbitalZones.DIR_RIGHT){
                do{
                    if ((curPos * minOrbitalMultiple) > this.maximumRadius)
                        return OrbitalZones.ENDOFORBITAL;     //no more orbitals to the right

                    rollVal = ourBag.rollRange(1.4m, .6m);
                    tmpVal = curPos * rollVal;
                    //Console.WriteLine("Prev Orbit: {0} AU, roll Val: {1} AU, new Orbit: {2} AU", curPos, rollVal, tmpVal);
                    
                    if (curPos + .15m > tmpVal) tmpVal = .15m + curPos;
                    
                    curPos = tmpVal;
                } while (!checkOrbit(tmpVal));
                
                return tmpVal;
           }
            
            return OrbitalZones.ENDOFORBITAL;
        }


        public int checkRange(decimal lower, decimal higher, int numStars, bool isEpistellarCheck = false){
            decimal rangeTotal = higher - lower;
            
            //this case pretty much only exists to handle the epistellar check.
            if (isEpistellarCheck)
            {
                if (numStars > 1)
                {
                    if (higher < forZones[0].higherBound && lower > forZones[0].lowerBound) return OrbitalZones.NOGOODORBITS;
                    if (forZones[0].lowerBound < lower && higher > forZones[0].higherBound)
                    {
                        if ((forZones[0].higherBound - lower) >= (.5m * rangeTotal)) return OrbitalZones.LIMITEDORBITS;
                        if ((forZones[0].higherBound - lower) < (.5m * rangeTotal)) return OrbitalZones.MOSTLYSAFEORBITS;
                    }
                    if (forZones[0].lowerBound > lower && higher < forZones[0].higherBound)
                    {
                        if ((higher - forZones[0].lowerBound) >= (.5m * rangeTotal)) return OrbitalZones.LIMITEDORBITS;
                        if ((higher - forZones[0].lowerBound) < (.5m * rangeTotal)) return OrbitalZones.MOSTLYSAFEORBITS;
                    }
                    if (higher < forZones[0].lowerBound) return OrbitalZones.MOSTLYSAFEORBITS;
                }
                else
                {
                    return OrbitalZones.MOSTLYSAFEORBITS;
                }
            }

            foreach (OrbitalPair o in cleanZones){
                if (higher < o.higherBound && lower > o.lowerBound) return OrbitalZones.MOSTLYSAFEORBITS;
                if (o.lowerBound < lower && higher > o.higherBound){
                    if ((o.higherBound - lower) >= (.5m * rangeTotal)) return OrbitalZones.MOSTLYSAFEORBITS;
                    if ((o.higherBound - lower) < (.5m * rangeTotal)) return OrbitalZones.LIMITEDORBITS;
                }
                if (o.lowerBound > lower && higher < o.higherBound){
                    if ((higher - o.lowerBound) >= (.5m * rangeTotal)) return OrbitalZones.MOSTLYSAFEORBITS;
                    if ((higher - o.lowerBound) < (.5m * rangeTotal)) return OrbitalZones.LIMITEDORBITS;
                }
            }

            return OrbitalZones.NOGOODORBITS;

        }

        public int getOwnership(int starA, int partnerStar, bool primaryFlag)
        {
            if (primaryFlag)
            {
                //set if orbiting primary
                if ((starA == 0) && (partnerStar == 1)) return Satelite.ORBIT_PRISEC;
                if ((starA == 0) && (partnerStar == 2)) return Satelite.ORBIT_PRITRI;
                //orbiting either second or trinary
                if ((starA == 1)) return Satelite.ORBIT_SECCOM;
                if ((starA == 2)) return Satelite.ORBIT_TRICOM;

                //combination orbit.
                if ((starA == Satelite.ORBIT_PRISEC) && (partnerStar == 2)) return Satelite.ORBIT_PRISECTRI;
                if ((starA == Satelite.ORBIT_PRITRI) && (partnerStar == 1)) return Satelite.ORBIT_PRISECTRI;
            }
            return OrbitalZones.OWNERPRIMARY;
        }
        
        public void sortForbiddenZones(){
            forZones.Sort((x, y) => x.lowerBound.CompareTo(y.lowerBound));
        }

        public void sortCleanZones(){
         
            cleanZones.Sort((x, y) => x.lowerBound.CompareTo(y.lowerBound));
        }

        public bool noViableZone(decimal innerRadius, decimal outerRadius)
        {
            decimal currInner = innerRadius;
            foreach (OrbitalPair o in forZones){
                if (currInner > o.lowerBound) currInner = o.higherBound; //basically set the new inner limitation if we run across a forbidden zone

            }

            if (currInner > outerRadius) return true;

            return false;

        }

        public override String ToString()
        {
            String ret;
              ret = "Orbital Zones for star " + (this.starID + 1 ) + "\n";
              ret = ret + "Forbidden Zones:" + "\n";
              foreach (OrbitalPair p in forZones){
                  ret = ret + p + '\n';
              }
              ret = ret + '\n';
              ret = ret + "Clean Zones:" + "\n";
              foreach (OrbitalPair p in cleanZones)
              {
                  ret = ret + p + '\n';
              }

            return ret;
        }

    }

    class OrbitalPair{

        //flags
        public static int IS_FORBIDDEN = 892;
        public static int IS_GOODZONE = 893;

        public decimal lowerBound { get; set; }
        public decimal higherBound { get; set; }
        public bool isPrimary { get; set; }
        public int partnerStar { get; set; }
        public int typeOfZone { get; set; }

        public OrbitalPair(decimal lower, decimal higher, bool isPrimary, int partnerStar, int typeOfZone) {
            this.lowerBound = lower;
            this.higherBound = higher;
            this.isPrimary = isPrimary;
            this.partnerStar = partnerStar;
            this.typeOfZone = typeOfZone;
           
        }

        public String getDescZone(){
            if (this.typeOfZone == OrbitalPair.IS_FORBIDDEN) return "Forbidden Zone";
            if (this.typeOfZone == OrbitalPair.IS_GOODZONE) return "Clear Zone";

            return "INVALID";

        }

        public override String ToString(){
            String ret;
            ret = "This orbital pair is at lower " + this.lowerBound + " AU to higher " + this.higherBound + " AU. \n";
            ret = ret + "Primary setting is " + isPrimary +  " with the partner star ID of " + partnerStar; 
            ret = ret + "\nZone Type is " + getDescZone();

            return ret;
        }

    }

}
