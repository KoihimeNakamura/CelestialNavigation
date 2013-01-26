using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
   partial class Star : Orbital  {

        readonly public static int IS_PRIMARY = 9000; //flag for orbitals
        readonly public static int IS_SECONDARY = 9001;
        readonly public static int IS_TRINARY = 9002;
        readonly public static int IS_SECCOMP = 9011;
        readonly public static int IS_TRICOMP = 9012;

        readonly public static int GASGIANT_NONE = 700;
        readonly public static int GASGIANT_CONVENTIONAL = 701;
        readonly public static int GASGIANT_ECCENTRIC = 702;
        readonly public static int GASGIANT_EPISTELLAR = 703;


        //properties of the star
        public double mass { get; protected set; }
        public double initMass { get; protected set; }
        public double radius { get; protected set; }
        public double currLumin { get; protected set; }
        public double initLumin { get; protected set; }
        protected double maxLumin { get; set; }
        public double age { get; protected set; } //age of the star. Used to determine the age of the system
        public double effTemp { get; set; }
        public String specType { get; set; }
        public bool isFlareStar { get; set; }
        public int orbitalSep { get; set; }
        public double mainLimit { get; set; }
        public double subLimit { get; set; }
        public double giantLimit { get; set; }
        public double totalLifeSpan { get; set; }
        public String parentName { get; set; }
        public int gasGiantFlag { get; set; }

        public List<Orbital> ourOrbitals { get; set; }
        public formationHelper zonesOfInterest { get; protected set; }
        public int orderID { get; set; }
       


         public Star(double age, int parent, int self) : base(parent, self) {
             this.age = age;
             this.orbitalRadius = 0.0;
             this.gasGiantFlag = 0; //set to none automatically. We will set it correctly later.


             ourOrbitals = new List<Orbital>(); //You'd think I'd remember to do that here.

         }

         public Star(double age, int parent, int self, int order, string baseName)
             : base(parent, self){
             this.age = age;
             this.orbitalRadius = 0.0;
             this.gasGiantFlag = Star.GASGIANT_NONE; //set to none automatically. We will set it correctly later.
             this.orderID = order;
             this.genGenericName(baseName);

             zonesOfInterest = new formationHelper(order);
             ourOrbitals = new List<Orbital>(); //You'd think I'd remember to do that here.
         }

         // orbitals functions
         public void sortOrbitals(){
             ourOrbitals.Sort((x, y) => x.orbitalRadius.CompareTo(y.orbitalRadius));
         }

         public void addSatelite(Orbital s){
             this.ourOrbitals.Add(s);
         }

        //testing function
         public bool testInitlizationZones()
         {
             if (this.zonesOfInterest == null) return false;
             return true;
         }

         public void initalizeZonesOfInterest(){
             zonesOfInterest = new formationHelper(orderID);
         }

         public void printAllOrbitals()
         {
             Console.WriteLine("This star's orbital array contains: ");
             foreach (Orbital o in ourOrbitals)
                 Console.WriteLine("{0}", o);
             Console.WriteLine();

         }

         public void updateMass(double mass){
             if (mass == 0) throw new ArgumentException("Argument is 0 masses.");
             this.mass = mass;

             if (this.determineStatus() != 4)    this.initMass = mass;
           
         }

         public void setInitMass(double mass)
         {
             this.initMass = mass;
         }

         public void purgeSwallowedOrbits(){
              ourOrbitals.RemoveAll(orbital => orbital.orbitalRadius <= this.getCollapsedSpace());
              this.sortOrbitals();

         }

                
         //other functions
         public void addOrder(int orderID)
         {
             this.orderID = orderID;
         }

         public void genGenericName(String parentName)
         {
             base.genGenericName();
             char[] starNames = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
             this.name = parentName + "-" + starNames[this.selfID]   ;
         }

         public void setRadius()
         {
             //we don't need any input, actually
             if (this.determineStatus() != 4){
                 this.radius = ((155000 * Math.Sqrt(this.currLumin)) / Math.Pow(this.effTemp, 2));
             }
             else  this.radius = (.0001118 * Math.Pow(this.mass, (1 / 3)));
         }


         public double getRadiusAU(){ return this.radius; }
         public double getRadiusKM() { return this.radius * Orbital.AUtoKM;}
        
         public String getStatusDesc()
         {
             if (this.determineStatus() == 0) return "Main Sequence";
             if (this.determineStatus() == 1) return "Main Sequence";
             if (this.determineStatus() == 2) return "Subgiant Branch";
             if (this.determineStatus() == 3) return "Asymptotic Giant Branch";
             if (this.determineStatus() == 4) return "White Dwarf";

             return "INVALID STATUS";
         }

         /*
          * gasGiantArrangement
          *  0 - None
          *  1 - Conventional
          *  2 - Eccentric
          *  3 - Epistellar
          */
        public String getSeperationStr()
        {
            switch (this.orbitalSep)
            {
                case 0: return "None";
                case 1: return "Very Close";
                case 2: return "Close";
                case 3: return "Moderate";
                case 4: return "Wide";
                case 5: return "Distant";
                case 99: return "Contact"; //used for certain cases.
                default: return "!!!!!";
            }
        }

        public double getSepModifier()
        {
            switch (this.orbitalSep)
            {
                case 1: return .05;
                case 2: return .5;
                case 3: return 2;
                case 4: return 10;
                case 5: return 50;
            }

            return 0;
        }

        //method that generically sets luminosity
        public void setLumin()
        {
            double tmpDbl;
            if (this.determineStatus() == 0)
            {
                //set min and current = same, due to time.
                tmpDbl = getMinLumin();
                this.initLumin = tmpDbl;
                this.currLumin = tmpDbl;
            }

            if (this.determineStatus() == 1)
            {
                //set min and then current
                tmpDbl = getMinLumin();
                this.initLumin = tmpDbl;
                this.currLumin = (tmpDbl + ((this.age / this.mainLimit) * (this.getMaxLumin() - tmpDbl)));
            }

            if (this.determineStatus() == 2)
            {
                //set min
                tmpDbl = getMinLumin();
                this.initLumin = tmpDbl;

                //set current
                tmpDbl = getMaxLumin();
                this.currLumin = tmpDbl;
            }

            if (this.determineStatus() == 3)
            {
                //set min
                tmpDbl = getMinLumin();
                this.initLumin = tmpDbl;

                //set current
                tmpDbl = getMaxLumin();
                this.currLumin = tmpDbl * 10000;
                this.maxLumin = this.currLumin;

            }

            if (this.determineStatus() == 4)
            {
                //set min
                tmpDbl = getMinLumin();
                this.initLumin = tmpDbl;

                //set max current
                tmpDbl = getMaxLumin();
                this.maxLumin = tmpDbl * 10000;
                //FOR WHITEDWARVES, GENERATE MAIN ELSEWHERE.
            }

        }
        /** Figured out what status it is.
         * 
         * @return The star's status
         */
        public int determineStatus()
        {
            if (this.mass >= .1 && this.mass <= .45) return 0;
            if (this.age < this.mainLimit) return 1;
            if (this.age < this.mainLimit + this.subLimit) return 2;
            if (this.age < this.mainLimit + this.subLimit + this.giantLimit) return 3;
            if (this.age > this.mainLimit + this.subLimit + this.giantLimit) return 4;
            return -1;
        }
        /** This updates luminosity. **/
        public void updateLumin(double lumin){
            int currStatus = this.determineStatus();
            switch (currStatus){
                case 0:
                    this.initLumin = lumin;
                    this.currLumin = lumin;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    this.currLumin = lumin;
                    break;
                default:
                    this.currLumin = lumin;
                    break;

            }
        }
        /** This sets the effective surface temperature from the equation. 
         * 
         */
        public void setTemperature()
        {
            double tmpDbl;
            //corrected 12 Dec 2012: Missing sign. Not the most accurate, but the table isn't super accurate either.
            tmpDbl = -2604.2 * Math.Pow(this.mass, 6) + 14710 * Math.Pow(this.mass, 5) - 29246 * Math.Pow(this.mass, 4);
            tmpDbl += 22255 * Math.Pow(this.mass, 3) - 2083 * Math.Pow(this.mass, 2) - 449.86 * this.mass + 3214.2;
            tmpDbl = Math.Round(tmpDbl, 2);
            this.effTemp = tmpDbl;
        }

        /** This gets the effective maximum luminosity of the star. The mass must be .45 to 2
         * 
         * @return Returns the maximum luminosity.
         */

        private double getMaxLumin()
        {
            double tmpDbl;
            //this will determine the maximum luminosity for a star
            if (this.mass < .45 || this.mass > 2.0) return -1;
            tmpDbl = (4.989914231 * Math.Pow(this.mass, 4)) - (17.79087942 * Math.Pow(this.mass, 3)) + (28.85126179 * Math.Pow(this.mass, 2));
            tmpDbl = tmpDbl - (18.49923946 * this.mass) + 4.052052039;
            tmpDbl = Math.Round(tmpDbl, 4);
            return tmpDbl;
        }

        /** This gets the minimum luminosity of the star. Mass is .1 to 2 solar masses (will not return anything valid beyond that)
         * 
         * @return Returns the minimum luminosity (also the luminosity at startup.)
         */

        //temp makign it public.
        private double getMinLumin()
        {

       
            double tmpDbl = 0.0, minMass, massRange, minLumin, luminRange;
            if (this.mass >= Star.minLuminTable[33][0]) return 16;
            for (int i = 0; i < Star.minLuminTable.Length; i++){
                if (this.mass >= Star.minLuminTable[i][0] && this.mass < Star.minLuminTable[i + 1][0]){
                    //get the minimum mass and mass Range
                    minMass = Star.minLuminTable[i][0];
                    massRange = this.mass - minMass;

                    //get the minimum lumin and range
                    minLumin = Star.minLuminTable[i][1];
                    luminRange = Star.minLuminTable[i + 1][1] - Star.minLuminTable[i][1];

                    return (minLumin + (massRange / ((Star.minLuminTable[i + 1][0] - minMass)) * luminRange));

                }
            }
            return tmpDbl;
        }

        /** Sets the limit of time it's in the first stage of formation. Also sets an absurdly high limit if it's under .45 mass (it doesn't really matter though, since
         *  it shouldn't call this to set it's stage)
         */
        public void setMainLimit()
        {
            double tmpDbl;
            //determines the main sequence limit
            if (this.mass < .45) this.mainLimit = 1300.0; //set for an extremely high number.
            tmpDbl = (39.5535698038 * Math.Pow(this.mass, 4)) - (247.56796104217 * Math.Pow(this.mass, 3));
            tmpDbl += (580.40142164746 * Math.Pow(this.mass, 2)) - (610.07037160674 * this.mass) + 247.75169730288;
            tmpDbl = Math.Round(tmpDbl, 3);
            this.mainLimit = tmpDbl;
        }

        /** Sets the limit of time it's in the subgiant stage of formation.
         * 
         */
        public void setSubLimit()
        {
            double tmpDbl;
            //determines the sub span limit
            tmpDbl = (1.9998950042437 * Math.Pow(this.mass, 4)) - (14.088628035713 * Math.Pow(this.mass, 3)) 
                     + (37.565459826918 * Math.Pow(this.mass, 2)) - (45.463378074726 * this.mass) + 21.565798170783;
            tmpDbl = Math.Round(tmpDbl, 3);
            this.subLimit = tmpDbl;
        }

        /** Sets the limit of time in the giant stage of formation.
         * 
         */
        public void setGiantLimit()
        {
            double tmpDbl;
            //determines the giant limit
            tmpDbl = (4.533 * Math.Pow(this.mass, 6)) - (42.472 * Math.Pow(this.mass, 5)) + (164.88 * Math.Pow(this.mass, 4)) -
                (340.31 * Math.Pow(this.mass, 3)) + (395.58 * Math.Pow(this.mass, 2)) - (247.54 * this.mass) + 66.283;

            tmpDbl = Math.Round(tmpDbl, 3);
            this.giantLimit = tmpDbl;
        }

        /** Returnsthe string description of the population type. Useful in display cases
         * 
         * @return Description of the population type
         */
        public String getStarPopType()
        {
            if (age == 0) return "Extreme Population I";
            if (age < 2) return "Young Population I";
            if (age < 5) return "Intermediate Population I";
            if (age < 8) return "Old Population I";
            if (age < 10.75) return "Intermediate Population I";
            if (age < 13.7) return "Extreme Population II";
            return "Invalid";
        }

        /** Sets the life span. Needed for various strings.
         * 
         */

        public void totalLifeSpanUp()
        {
            //debug stuff
            /*
            Console.WriteLine();
            Console.WriteLine("Main limit is {0}, sub limit is {1}, giant limit is {2}", this.mainLimit, this.subLimit, this.giantLimit);
            Console.WriteLine();
             */
            this.totalLifeSpan = this.mainLimit + this.subLimit + this.giantLimit;
        }

        public override String ToString()
        {

            String desc;
            String spacing = "      ";

            String lumType = "";
            //Console.WriteLine("Status is {0}", this.determineStatus());

            if (this.determineStatus() == 0 || this.determineStatus() == 1) lumType = "V";
            if (this.determineStatus() == 2) lumType = "IV";
            if (this.determineStatus() == 3) lumType = "III";
            if (this.determineStatus() == 4) lumType = "VI";


            if (this.isFlareStar) lumType += "e";

            //Console.WriteLine("LumType is {0}", lumType);
            desc = this.name + " ";

            if (this.parentID != Star.IS_PRIMARY && this.parentID != 0) desc += " (subcompanion) : ";
            if (this.parentID == 0 && this.selfID == 0) desc += " (primary) : ";
            if (this.parentID == 0 && this.selfID == 1) desc += " (secondary) : ";
            if (this.parentID == 0 && this.selfID == 2) desc += " (trinary) : ";


            desc += this.specType + " " + lumType + " star, " + this.mass + " solar masses, ";
            //+ Math.Round(this.currLumin, 4) + " solar luminosity";
            if (this.currLumin < 0.0001) desc = desc + "negliable solar luminosity";
            else desc = desc + Math.Round(this.currLumin, 4) + " solar luminosity";
            desc += Environment.NewLine + spacing + Math.Round(this.effTemp, 2) + "K effective temperature, " + Math.Round(this.radius, 4) + " AU radius";
            desc += Environment.NewLine + spacing + this.getStarPopType() + " (" + this.age + " Gyr), total lifespan " + Math.Round(this.totalLifeSpan, 2) + " Gyr";

            //describe what's left
            if (this.determineStatus() == 1)
            {
                desc += Environment.NewLine + spacing + "There is " + Math.Round((this.mainLimit - this.age), 3) + " Gyr left on the main sequence.";

            }

            if (this.determineStatus() == 2)
            {
                desc += Environment.NewLine + spacing + "There is " + Math.Round((this.subLimit - (this.age + this.mainLimit)), 3) + " Gyr left on the subgiant sequence.";
            }

            if (this.determineStatus() == 3)
            {
                desc += Environment.NewLine + spacing + "There is " + Math.Round((this.giantLimit - (this.age + this.mainLimit + this.subLimit)), 3) + " Gyr left on the giant sequence.";
            }
            desc += Environment.NewLine + spacing + "Stage: " + this.getStatusDesc() + ".";
            desc += Environment.NewLine + spacing + "Main Sequence Length: " + Math.Round(this.mainLimit, 3) + " Gyr.";

            if (this.isFlareStar)
                desc += Environment.NewLine + spacing + "NOTE: This is a flare star.";

            //orbital details
            if (this.parentID != Star.IS_PRIMARY)
            {
                desc += Environment.NewLine + spacing + "This orbits " + this.parentName + " at a radius of ";
                desc += Math.Round(this.orbitalRadius, 4) + " AU; (" + this.getSeperationStr() + ")";
                desc += Environment.NewLine + spacing;
                desc += "Period: " + Math.Round(this.orbitalPeriod, 4) + " yr; Eccentricity: " + this.orbitalEccent;
                if (this.orbitalEccent != 0) desc += Environment.NewLine + spacing + "(Peripasis is " + Math.Round(this.getPeriapsis(), 4) + " AU, apapsis " + Math.Round(this.getApapsis(), 4) + " AU)";
            }

            return desc;
        }


        //planetary formation functions
        /** Determines the inner limit of the zone where planets can form around the star
         * 
         * @return the inner limit that planets can form around the star
         */
        public double innerRadius()
        {
            
              double lumFactor = Math.Sqrt(this.currLumin);
                if (.1 * this.initMass > .01 * lumFactor)
                        return .1 * this.initMass;
                else
                       return Math.Round(.01 * lumFactor, 3);
         }

        public double getCollapsedSpace(){
             return .01* Math.Sqrt(this.maxLumin);
        }


        /** The outer limit of the zone where planets can form around the star
         * 
         * @return The outer limit of the zone where planets can form around the star
         */
        public double outerRadius()
        {
            //Console.WriteLine("OUTER RADIUS INVOKED");
            //Console.WriteLine("Init Mass: {0}, outerRadius is {1}", this.initMass, 40m * this.initMass);
            //Console.ReadLine();
            return Math.Round((40 * this.initMass),3);
        }

        /** The snowLine, or the inner limit of conventional gas giant orbits.
         * 
         * @return the snowLine.
         */
        public double snowLine()
        {
            return (4.85 * Math.Sqrt(this.initLumin));
        }

        /** The inner forbidden zone between a companion star and it's primary.<br>
         * It's defined as 1/3rd the minimum distance between the stars. (1/3*periapsis())
         * 
         * @return the inner forbidden zone limit.
         */
        public double getInnerForbiddenZone()
        {
            return Math.Round((this.getPeriapsis() / 3),3);
        }

        /** The outer limit of the forbidden zone between a companion star and it's primary<br>
         * It's defined as 3 times the maximum distance between the stars. (3*apapsis());
         * 
         * @return the outer forbidden zone limit
         */
        public double getOuterForbiddenZone()
        {
            return Math.Round(3 * this.getApapsis(),3);
        }

        public void updateStar(double mass, Dice ourDice)
        {
            int NUMPLACESLUM = 5; //This saves me time.

            this.updateMass(mass);
            //CASE 1: MASS is between .1 and .45 solar masses
            if (mass >= .1 && mass < .45)
            {
                //see if it's a flare star.
                if (ourDice.gurpsRoll() >= 12) this.isFlareStar = true;

                this.specType = Star.getStellarTypeFromMass(mass); //get the spectral type

                //Get the temperature and query user about changes
                this.setTemperature();

                //Set luminosity and query user about changes && in the case of status 0 stars, the current luminosity IS the initial luminosity. (Set from user input)
                this.setLumin();
                this.updateLumin(Math.Round(this.currLumin, NUMPLACESLUM));


                //we have no clue what the actual lifespan is.
                this.mainLimit = 1300.0; // also used to tell the object this should be status 0.
                this.totalLifeSpanUp(); //update the list
            }

            if (mass >= .45 && mass < .95)
            {
                //see if it's a flare star.
                if (mass <= .525)
                {
                    if (ourDice.gurpsRoll() >= 12) this.isFlareStar = true;
                }
                //The luminosity type can be auto determined. No point in doing it here, really.

                //now that we've done that, we set the SPECTRAL type, and status. 
                this.specType = Star.getStellarTypeFromMass(mass);
                this.setMainLimit(); //required before we attempt to set luminosity (because this also sets status, now)

                //now we set luminosity! :D (Unlike in under .45 masses, inital luminosity is locked.)
                this.setLumin();
                //Console.WriteLine("Status is {0} and minLum is {1}", this.determineStatus(), this.getMinLumin());
                this.updateLumin(Math.Round(this.currLumin, NUMPLACESLUM));

                //set temperature.
                this.setTemperature();
                this.totalLifeSpanUp();
            }

            if (mass >= .95 && mass <= 2)
            {
                //Now we can generate with all fields

                //set limits for all age fields
                this.setMainLimit();
                this.setSubLimit();
                this.setGiantLimit();
                this.totalLifeSpanUp(); //when we actually have all three, we can just total them up. Like sane people.

                if (this.determineStatus() == 1)
                {
                    //process as if they're 
                    this.specType = Star.getStellarTypeFromMass(mass);

                    //now we set luminosity! :D
                    this.setLumin();
                    this.updateLumin(Math.Round(this.currLumin, NUMPLACESLUM));

                    //set temperature.
                    this.setTemperature();
                }

                //subgiant status
                if (this.determineStatus() == 2)
                {
                    this.setLumin(); //autogenerate luminosity
                    this.updateLumin(Math.Round(this.currLumin, NUMPLACESLUM)); //for a subgiant stage, current luminosity is = max luminosity

                    //set temperature and then get the stellar type
                    this.setTemperature(); //First step, read from table
                    this.effTemp = (this.effTemp - (this.age - this.mainLimit) * (this.effTemp - 4800));

                    this.specType = Star.getStellarTypeFromTemp(this.effTemp);
                }

                //giant stage
                if (this.determineStatus() == 3)
                {
                    this.setLumin(); //autogenerate luminosity
                    this.updateLumin(Math.Round(this.currLumin, NUMPLACESLUM));

                    //set temperature and get spectral type
                    this.effTemp = 3000 + (ourDice.rng(2,6, -2) * 200);
                    this.specType = Star.getStellarTypeFromTemp(this.effTemp);
                }

                //White dwarf stage
                if (this.determineStatus() == 4)
                {
                    //white dwarves are a bit of a special case.
                    this.specType = "DC";

                    this.setLumin(); //autogenerate luminosity

                    //reset to accommodate for the fact it's a dead star now. :/
                    this.updateMass(.9 + (ourDice.rng(2, 6, -2) * .05));
                    this.updateLumin(.00003 * ourDice.rng(6));

                    //not that accurate, not that wrong though..
                    double whiteDwarfSpan = this.age - this.mainLimit;
                    if (whiteDwarfSpan < 1.0) this.effTemp = 10000;
                    if (1.0 <= whiteDwarfSpan && whiteDwarfSpan < 2.5) this.effTemp = 5000;
                    if (whiteDwarfSpan >= 2.5) this.effTemp = 3796;

                }

            }


            this.setRadius(); //before we leave, set the radius

        }

        public void updateTemp(double effTemp){
            if (this.determineStatus() == 2 || this.determineStatus() == 3){
                this.effTemp = effTemp;
                this.specType = Star.getStellarTypeFromTemp(this.effTemp);
            }
            if (this.determineStatus() == 1) this.effTemp = effTemp;
        }

       //return ranges.
        public Range getEpistellarRange(){
            return new Range(.1 * this.innerRadius(), 1.8 * this.innerRadius());
        }

        public Range getEccentricRange(){
            return new Range(.125 * this.snowLine(), .75 * this.snowLine());
        }

        public Range getConventionalRange(){
            return new Range(this.snowLine(), 1.5 * this.snowLine());
        }

        public Range fullCreationRange()
        {
            return new Range(this.innerRadius(), this.outerRadius());
        }


       //passthrough functions
        public void createForbiddenZone(Range incoming, int primary, int secondary){
            this.zonesOfInterest.createForbiddenZone(incoming, primary, secondary);
        }

        public void createCleanZones(){
            this.zonesOfInterest.createCleanZones(this.innerRadius(), this.outerRadius());
        }

        public void sortForbidden(){
            this.zonesOfInterest.sortForbiddenZones();
        }

        public void sortClean(){
            this.zonesOfInterest.sortCleanZones();
        }

       public double verifyRange(Range incoming){
           return this.zonesOfInterest.verifyRange(incoming);
        }

       public double pickInRange(Range incoming){
           return this.zonesOfInterest.pickInRange(incoming);
       }

       public bool verifyCleanOrbit(double incoming){
           return this.zonesOfInterest.isWithinCleanZone(incoming);
       }

       public bool verifyForbiddenOrbit(double incoming){
           return this.zonesOfInterest.isWithinForbiddenZone(incoming);
       }

       public double getNextCleanOrbit(double orbit){
           return this.zonesOfInterest.getNextCleanOrbit(orbit);
       }

       public double getMinCleanOrbit(){
           return this.zonesOfInterest.getMinimalCleanZone();
       }

       public double getMaxCleanOrbit(){
           return this.zonesOfInterest.getMaximalCleanZone();
       }

       public double getRangeWidth(double orbit)
       {
           return this.zonesOfInterest.getRangeWidth(orbit);
       }
       
       public int getOwnership(double orbital)
       {
           return this.zonesOfInterest.getOwnership(orbital);
       }

       public int getAdjacencyMod(double orbital)
       {
           return this.zonesOfInterest.getAdjacencyMod(orbital);
       }

       //simplification range
       public double pickInCurrentRange(double orbit, double minLimit)
       {
           double retValue;

           if (this.zonesOfInterest.getRangeWidth(orbit) < minLimit)
           {
               do
               {
                   retValue = this.zonesOfInterest.pickInRange(this.zonesOfInterest.getRange(orbit));
               } while (retValue == orbit);
           }
           else
           {
               do
               {
                   retValue = this.zonesOfInterest.pickInRange(this.zonesOfInterest.getRange(orbit));
               } while (retValue < orbit + minLimit);
           }


           return retValue;  
           //return this.zonesOfInterest.pickInRange(this.zonesOfInterest.getRange(orbit));
       }

       //gas giant checks (all passthrough, but simplify  the call.
        public double checkEpiRange(){
            return this.zonesOfInterest.verifyRange(this.getEpistellarRange());
        }

        public double checkEccRange(){
            return this.zonesOfInterest.verifyRange(this.getEccentricRange());
        }

        public double checkConRange(){
            return this.zonesOfInterest.verifyRange(this.getConventionalRange());
        }

       //get distance to maximum and minimum:
        public double getRatioToMax(double src)
        {
            return Program.GetRatio(src, this.zonesOfInterest.getMaximalCleanZone());
        }

        public double getRatioFromMin(double src)
        {
            return Program.GetRatio(this.zonesOfInterest.getMinimalCleanZone(), src);
        }

    }


    /// <summary>
    ///  I'm not sure I need this.
    /// </summary>
    public static class listRemoveCLR{
        public static void FastRemoveAll<T>(this BindingList<T> list, Func<T, bool> predicate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
                if (predicate(list[i]))
                    list.RemoveAt(i);
        }
    }
}
