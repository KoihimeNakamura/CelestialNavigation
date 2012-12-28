using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    class Star : Orbital  {

        readonly public static int IS_PRIMARY = 9000; //flag for orbitals
        readonly public static int IS_SECONDARY = 9001;
        readonly public static int IS_TRINARY = 9002;
        readonly public static int IS_SECCOMP = 9011;
        readonly public static int IS_TRICOMP = 9012;

        //properties of the star
        public decimal mass { get; protected set; }
        public decimal initMass { get; protected set; }
        public decimal radius { get; protected set; }
        public decimal currLumin { get; protected set; }
        public decimal initLumin { get; protected set; }
        protected decimal maxLumin { get; set; }
        public decimal age { get; protected set; } //age of the star. Used to determine the age of the system
        public decimal effTemp { get; set; }
        public String specType { get; set; }
        public bool isFlareStar { get; set; }
        public int orbitalSep { get; set; }
        public decimal mainLimit { get; set; }
        public decimal subLimit { get; set; }
        public decimal giantLimit { get; set; }
        public decimal totalLifeSpan { get; set; }
        public String parentName { get; set; }
        public int gasGiantFlag { get; set; }
        public List<Orbital> ourOrbitals { get; set; }
        public int orderID { get; set; }


        public Star(decimal age, int parent, int self) : base(parent, self) {
            this.age = age;
            this.orbitalRadius = 0.0m;
            this.gasGiantFlag = 0; //set to none automatically. We will set it correctly later.

            ourOrbitals = new List<Orbital>(); //You'd think I'd remember to do that here.

        }

        public Star(decimal age, int parent, int self, int order, string baseName)
            : base(parent, self)
        {
            this.age = age;
            this.orbitalRadius = 0.0m;
            this.gasGiantFlag = 0; //set to none automatically. We will set it correctly later.
            this.orderID = order;
            this.genGenericName(baseName);

            ourOrbitals = new List<Orbital>(); //You'd think I'd remember to do that here.
        }

        // orbitals functions
        public void sortOrbitals(){
            ourOrbitals.Sort((x, y) => x.orbitalRadius.CompareTo(y.orbitalRadius));
        }

        public void addSatelite(Orbital s){
            this.ourOrbitals.Add(s);
        }

        public void printAllOrbitals()
        {
            Console.WriteLine("This star's orbital array contains: ");
            foreach (Orbital o in ourOrbitals)
                Console.WriteLine("{0}", o);
            Console.WriteLine();

        }

        public void updateMass(decimal mass){
            if (this.determineStatus() == 4){
                this.mass = mass;
                
            }
            else {
                this.mass = mass;
                this.initMass = mass; 
            }
        }

        public void setInitMass(decimal mass)
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
                this.radius = ((155000m * (decimal)Math.Sqrt((double)this.currLumin)) / (decimal) Math.Pow((double) this.effTemp, 2));
            }
            else  this.radius = (.0001118m * (decimal)Math.Pow((double)this.mass, (1 / 3)));
        }


        public decimal getRadiusAU(){ return this.radius; }
        public decimal getRadiusKM() { return this.radius * Orbital.AUtoKM;}
        
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

        public decimal getSepModifier()
        {
            switch (this.orbitalSep)
            {
                case 1: return .05m;
                case 2: return .5m;
                case 3: return 2m;
                case 4: return 10m;
                case 5: return 50m;
            }

            return 0;
        }

        //method that generically sets luminosity
        public void setLumin()
        {
            decimal tmpDbl;
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
            if (this.mass >= .1m && this.mass <= .45m) return 0;
            if (this.age < this.mainLimit) return 1;
            if (this.age < this.mainLimit + this.subLimit) return 2;
            if (this.age < this.mainLimit + this.subLimit + this.giantLimit) return 3;
            if (this.age > this.mainLimit + this.subLimit + this.giantLimit) return 4;
            return -1;
        }
        /** This updates luminosity. **/
        public void updateLumin(decimal lumin){
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
            decimal tmpDbl;
            //corrected 12 Dec 2012: Missing sign. Not the most accurate, but the table isn't super accurate either.
            tmpDbl = -2604.2m * xToYPower(this.mass, 6) + 14710m * xToYPower(this.mass, 5) - 29246m * xToYPower(this.mass, 4);
            tmpDbl += 22255m * xToYPower(this.mass, 3) - 2083m * xToYPower(this.mass, 2) - 449.86m * this.mass + 3214.2m;
            tmpDbl = Math.Round(tmpDbl, 2);
            this.effTemp = tmpDbl;
        }

        /** This gets the effective maximum luminosity of the star. The mass must be .45 to 2
         * 
         * @return Returns the maximum luminosity.
         */

        private decimal getMaxLumin()
        {
            decimal tmpDbl;
            //this will determine the maximum luminosity for a star
            if (this.mass < .45m || this.mass > 2.0m) return -1m;
            tmpDbl = (4.989914231m * xToYPower(this.mass, 4)) - (17.79087942m * xToYPower(this.mass, 3)) + (28.85126179m * xToYPower(this.mass, 2));
            tmpDbl = tmpDbl - (18.49923946m * this.mass) + 4.052052039m;
            tmpDbl = Math.Round(tmpDbl, 4);
            return tmpDbl;
        }

        /** This gets the minimum luminosity of the star. Mass is .1 to 2 solar masses (will not return anything valid beyond that)
         * 
         * @return Returns the minimum luminosity (also the luminosity at startup.)
         */

        //temp makign it public.
        private decimal getMinLumin()
        {

            //init this table. I think I'm goign to cry.
            decimal[][] minLuminTable = new decimal[34][];
            minLuminTable[0] = new decimal[2]{.1m,.0012m};
            minLuminTable[1] = new decimal[2]{.15m,.0036m};
            minLuminTable[2] = new decimal[2] { .2m, .0079m };
            minLuminTable[3] = new decimal[2] { .25m, .015m };
            minLuminTable[4] = new decimal[2] { .3m, .024m };
            minLuminTable[5] = new decimal[2] { .35m, .037m };
            minLuminTable[6] = new decimal[2] { .4m, .054m };
            minLuminTable[7] = new decimal[2] { .45m, .07m };
            minLuminTable[8] = new decimal[2] { .5m, .09m };
            minLuminTable[9] = new decimal[2] { .55m, .11m };
            minLuminTable[10] = new decimal[2] { .6m, .13m };
            minLuminTable[11] = new decimal[2] { .65m, .15m };
            minLuminTable[12] = new decimal[2] { .7m, .12m };
            minLuminTable[13] = new decimal[2] { .75m, .23m };
            minLuminTable[14] = new decimal[2] { .8m, .28m };
            minLuminTable[15] = new decimal[2] { .85m, .36m };
            minLuminTable[16] = new decimal[2] { .9m, .45m };
            minLuminTable[17] = new decimal[2] { .95m, .56m };
            minLuminTable[18] = new decimal[2] { 1m, .68m };
            minLuminTable[19] = new decimal[2] { 1.05m, .87m };
            minLuminTable[20] = new decimal[2] { 1.1m, 1.1m };
            minLuminTable[21] = new decimal[2] { 1.15m, 1.4m };
            minLuminTable[22] = new decimal[2] { 1.2m, 1.7m };
            minLuminTable[23] = new decimal[2] { 1.25m, 2.1m };
            minLuminTable[24] = new decimal[2] { 1.3m, 2.5m };
            minLuminTable[25] = new decimal[2] { 1.35m, 3.1m };
            minLuminTable[26] = new decimal[2] { 1.4m, 3.7m };
            minLuminTable[27] = new decimal[2] { 1.45m, 4.3m };
            minLuminTable[28] = new decimal[2] { 1.5m, 5.1m };
            minLuminTable[29] = new decimal[2] { 1.6m, 6.7m };
            minLuminTable[30] = new decimal[2] { 1.7m, 8.6m };
            minLuminTable[31] = new decimal[2] { 1.8m, 11m };
            minLuminTable[32] = new decimal[2] { 1.9m, 13m };
            minLuminTable[33] = new decimal[2] { 2m, 16m };
            
            

            decimal tmpDbl = 0.0m, minMass, massRange, minLumin, luminRange;
            for (int i = 0; i < minLuminTable.Length; i++){
                if (this.mass >= minLuminTable[i][0] && this.mass < minLuminTable[i + 1][0]){
                    //get the minimum mass and mass Range
                    minMass = minLuminTable[i][0];
                    massRange = this.mass - minMass;

                    //get the minimum lumin and range
                    minLumin = minLuminTable[i][1];
                    luminRange = minLuminTable[i + 1][1] - minLuminTable[i][1];

                    return (minLumin + (massRange / ((minLuminTable[i + 1][0] - minMass)) * luminRange ));

                }
            }
            return tmpDbl;
        }

        /** Sets the limit of time it's in the first stage of formation. Also sets an absurdly high limit if it's under .45 mass (it doesn't really matter though, since
         *  it shouldn't call this to set it's stage)
         */
        public void setMainLimit()
        {
            decimal tmpDbl;
            //determines the main sequence limit
            if (this.mass < .45m) this.mainLimit = 1300.0m; //set for an extremely high number.
            tmpDbl = (39.5535698038m * xToYPower(this.mass, 4)) - (247.56796104217m * xToYPower(this.mass, 3));
            tmpDbl += (580.40142164746m * xToYPower(this.mass, 2)) - (610.07037160674m * this.mass) + 247.75169730288m;
            tmpDbl = Math.Round(tmpDbl, 3);
            this.mainLimit = tmpDbl;
        }

        /** Sets the limit of time it's in the subgiant stage of formation.
         * 
         */
        public void setSubLimit()
        {
            decimal tmpDbl;
            //determines the sub span limit
            tmpDbl = (1.9998950042437m * xToYPower(this.mass, 4)) - (14.088628035713m * xToYPower(this.mass, 3)) 
                     + (37.565459826918m * xToYPower(this.mass, 2)) - (45.463378074726m * this.mass) + 21.565798170783m;
            tmpDbl = Math.Round(tmpDbl, 3);
            this.subLimit = tmpDbl;
        }

        /** Sets the limit of time in the giant stage of formation.
         * 
         */
        public void setGiantLimit()
        {
            decimal tmpDbl;
            //determines the giant limit
            tmpDbl = (4.533m * xToYPower(this.mass, 6)) - (42.472m * xToYPower(this.mass, 5)) + (164.88m * xToYPower(this.mass, 4)) -
                (340.31m * xToYPower(this.mass, 3)) + (395.58m * xToYPower(this.mass, 2)) - (247.54m * this.mass) + 66.283m;

            tmpDbl = Math.Round(tmpDbl, 3);
            this.giantLimit = tmpDbl;
        }

        /** Returnsthe string description of the population type. Useful in display cases
         * 
         * @return Description of the population type
         */
        public String getStarPopType()
        {
            if (age == 0m) return "Extreme Population I";
            if (age < 2m) return "Young Population I";
            if (age < 5m) return "Intermediate Population I";
            if (age < 8m) return "Old Population I";
            if (age < 10.75m) return "Intermediate Population I";
            if (age < 13.7m) return "Extreme Population II";
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
            

            desc += this.specType + " " + lumType + " star, " + this.mass + " solar masses, " + Math.Round(this.currLumin,4) + " solar luminosity";
            desc += '\n' + spacing + Math.Round(this.effTemp,2) + "K effective temperature, " + Math.Round(this.radius,4) + " AU radius";
            desc += '\n' + spacing + this.getStarPopType() + " (" + this.age + " Gyr), total lifespan " + Math.Round(this.totalLifeSpan,2) + " Gyr";

            //describe what's left
            if (this.determineStatus() == 1)
            {
                desc += '\n' + spacing + "There is " + Math.Round((this.mainLimit - this.age),3) + " Gyr left on the main sequence.";

            }

            if (this.determineStatus() == 2)
            {
                desc += '\n' + spacing + "There is " + Math.Round((this.subLimit - (this.age + this.mainLimit)), 3) + " Gyr left on the subgiant sequence.";
            }

            if (this.determineStatus() == 3)
            {
                desc += '\n' + spacing + "There is " + Math.Round((this.giantLimit - (this.age + this.mainLimit + this.subLimit)),3) + " Gyr left on the giant sequence.";
            }
            desc += '\n' + spacing + "Stage: " + this.getStatusDesc() + ".";

            if (this.isFlareStar)
                desc += '\n' + spacing + "NOTE: This is a flare star.";

            //orbital details
            if (this.parentID != Star.IS_PRIMARY)
            {
                desc += '\n' + spacing + "This orbits " + this.parentName + " at a radius of ";
                desc += Math.Round(this.orbitalRadius,4) + " AU; (" + this.getSeperationStr() + ")";
                desc += "\n" + spacing;
                desc += "Period: " + Math.Round(this.orbitalPeriod,4) + " yr; Eccentricity: " + this.orbitalEccent;
                if (this.orbitalEccent != 0) desc += "\n" + spacing +  "(Peripasis is " + Math.Round(this.getPeriapsis(),4) + " AU, apapsis " + Math.Round(this.getApapsis(),4) + " AU)";
            }

            return desc;
        }


        //planetary formation functions
        /** Determines the inner limit of the zone where planets can form around the star
         * 
         * @return the inner limit that planets can form around the star
         */
        public decimal innerRadius()
        {
            
                if (.1m * this.initMass > .01m * (decimal)Math.Sqrt((double)this.currLumin)) return .1m * this.initMass;
                else return Math.Round((.01m * (decimal)Math.Sqrt((double)this.currLumin)),3);
         }

        protected decimal getCollapsedSpace(){
             return .01m* (decimal)Math.Sqrt((double)this.maxLumin);
        }


        /** The outer limit of the zone where planets can form around the star
         * 
         * @return The outer limit of the zone where planets can form around the star
         */
        public decimal outerRadius()
        {
            Console.WriteLine("OUTER RADIUS INVOKED");
            Console.WriteLine("Init Mass: {0}, outerRadius is {1}", this.initMass, 40m * this.initMass);
            Console.ReadLine();
            return Math.Round((40m * this.initMass),3);
        }

        /** The snowLine, or the inner limit of conventional gas giant orbits.
         * 
         * @return the snowLine.
         */
        public decimal snowLine()
        {
            return (4.85m * (decimal)Math.Sqrt((double)this.initLumin));
        }

        /** The inner forbidden zone between a companion star and it's primary.<br>
         * It's defined as 1/3rd the minimum distance between the stars. (1/3*periapsis())
         * 
         * @return the inner forbidden zone limit.
         */
        public decimal getInnerForbiddenZone()
        {
            return Math.Round((this.getPeriapsis() / 3m),3);
        }

        /** The outer limit of the forbidden zone between a companion star and it's primary<br>
         * It's defined as 3 times the maximum distance between the stars. (3*apapsis());
         * 
         * @return the outer forbidden zone limit
         */
        public decimal getOuterForbiddenZone()
        {
            return Math.Round(3m * this.getApapsis(),3);
        }
    
    }
}
