using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public partial class Star : Orbital
    {
        ///<summary>
        /// this function gets the space swallowed up when a star balloons into a giant phase
        /// 
        /// <returns>The swallowed space</returns>
        /// </summary>
        
        protected virtual double getSwallowedSpace()
        {
            return .01 * Math.Sqrt(this.maxLumin);
        }


       /// <summary>
       /// This function is used to safely roll on the table (contains some error bound checking.)
       /// </summary>
       /// <param name="rollA">First roll</param>
       /// <param name="rollB">Second roll</param>
       /// <exception cref="System.ArgumentException">Throws an ArgumentException if this is out of bounds (below 0 and above 18)</exception>
       /// <returns>The table entry</returns>
       public static double getMassByRoll(int rollA, int rollB)
       {
          if (rollA > 18 || rollA < 0 || rollB > 18 || rollB < 0)
                throw new System.ArgumentException("One of the passed dice roll is beyond limits");

            return Star.starMassTableByRoll[rollA][rollB];
        }

       /// <summary>
       /// Returns the mass from the array <see cref="Star.starMassTableByIndex"/> given an index.
       /// </summary>
       /// <param name="index">The index to retrieve </param>
       /// <exception cref="System.ArgumentException">Throws an ArgumentException if this is out of bounds (below 0 and above the length.)</exception>
       /// <returns>The mass</returns>
       public static double getMassByIndex(int index)
       {
           if (index < 0 && index > Star.starMassTableByIndex.Length)
               throw new System.ArgumentException("The passed index is beyond limits");

           return Star.starMassTableByIndex[index];
       }

       /// <summary>
       /// This function gets the current index in the mass table by the current mass
       /// </summary>
       /// <param name="mass">The mass we're looking for</param>
       /// <returns>The index</returns>
       public static int getStellarMassPos(double mass)
       {
           for (int i = 0; i < Star.starMassTableByIndex.Length; i++)
           {
               if (mass == Star.starMassTableByIndex[i])
                   return i;

               if (i != Star.starMassTableByIndex.Length - 1 && mass < Star.starMassTableByIndex[i] && mass > Star.starMassTableByIndex[i + 1])
                   return i;

               if (i == Star.starMassTableByIndex.Length - 1)
                   return i;      
           }

           return -1;
       }


       public static double WhiteDwarfTemp(double mass, double age)
        {
            double currTemp = 0.0;

            if (mass > 1.2 && mass <= 1.4)
               currTemp = 60000;

            if (mass > 1.0 && mass <= 1.2)
                currTemp = 55000;

            if (mass > .6 && mass <= 1.0)
                currTemp = 45000;

            if (mass >= .3 && mass <= .6)
                currTemp = 30000;

            if (mass < .3)
                currTemp = 25000;

            if (age <= .3)
                currTemp = currTemp * .85;

            if (age > .3 && age <= 2.0)
                currTemp = currTemp * .65;

            if (age > 2.0 && age <= 2.5)
                currTemp = currTemp * .45;

            if (age > 2.5 && age <= 3.5)
                currTemp = currTemp * .3;

            if (age > 3.5 && age <= 5)
                currTemp = currTemp * .25;

            if (age > 5 && age <= 7)
                currTemp = currTemp * .1;

            if (age > 7 && age <= 11)
                currTemp = currTemp * .02;

            if (age > 11)
                currTemp = 20;

            return currTemp;
        }

        public static string getStellarTypeFromMass(double mass)
        {
            if (mass <= .125) return "M7";
            if (.125 < mass && mass <= .175) return "M6";
            if (.175 < mass && mass <= .225) return "M5";
            if (.225 < mass && mass <= .325) return "M4";
            if (.325 < mass && mass <= .375) return "M3";
            if (.375 < mass && mass <= .425) return "M2";
            if (.425 < mass && mass <= .475) return "M1";
            if (.475 < mass && mass <= .525) return "M0";
            if (.525 < mass && mass <= .575) return "K8";
            if (.575 < mass && mass <= .625) return "K6";
            if (.625 < mass && mass <= .675) return "K5";
            if (.675 < mass && mass <= .725) return "K4";
            if (.725 < mass && mass <= .775) return "K2";
            if (.775 < mass && mass <= .825) return "K0";
            if (.825 < mass && mass <= .875) return "G8";
            if (.875 < mass && mass <= .925) return "G6";
            if (.925 < mass && mass <= .975) return "G4";
            if (.975 < mass && mass <= 1.025) return "G2";
            if (1.025 < mass && mass <= 1.075) return "G1";
            if (1.075 < mass && mass <= 1.125) return "G0";
            if (1.175 < mass && mass <= 1.20) return "F9";
            if (1.20 < mass && mass <= 1.225) return "F8";
            if (1.225 < mass && mass <= 1.275) return "F7";
            if (1.275 < mass && mass <= 1.325) return "F6";
            if (1.325 < mass && mass <= 1.375) return "F5";
            if (1.375 < mass && mass <= 1.425) return "F4";
            if (1.425 < mass && mass <= 1.475) return "F3";
            if (1.475 < mass && mass <= 1.55) return "F2";
            if (1.55 < mass && mass <= 1.65) return "F0";
            if (1.65 < mass && mass <= 1.75) return "A9";
            if (1.75 < mass && mass <= 1.85) return "A7";
            if (1.85 < mass && mass <= 1.95) return "A6";
            if (1.95 < mass && mass <= 2.0) return "A5";

            return "X0";
        }

        public static String getStellarTypeFromTemp(double temp)
        {
            if (temp < 3150) return "M7";
            if (3150 <= temp && temp < 3175) return "M6";
            if (3175 <= temp && temp < 3250) return "M5";
            if (3250 <= temp && temp < 3350) return "M4";
            if (3350 <= temp && temp < 3450) return "M3";
            if (3450 <= temp && temp < 3550) return "M2";
            if (3550 <= temp && temp < 3700) return "M1";
            if (3700 <= temp && temp < 3900) return "M0";
            if (3900 <= temp && temp < 4100) return "K8";
            if (4100 <= temp && temp < 4300) return "K6";
            if (4300 <= temp && temp < 4500) return "K5";
            if (4500 <= temp && temp < 4750) return "K4";
            if (4750 <= temp && temp < 5050) return "K2";
            if (5050 <= temp && temp < 5300) return "K0";
            if (5300 <= temp && temp < 5450) return "G8";
            if (5450 <= temp && temp < 5600) return "G6";
            if (5600 <= temp && temp < 5750) return "G4";
            if (5750 <= temp && temp < 5850) return "G2";
            if (5850 <= temp && temp < 5950) return "G1";
            if (5950 <= temp && temp < 6050) return "G0";
            if (6050 <= temp && temp < 6150) return "F9";
            if (6150 <= temp && temp < 6350) return "F8";
            if (6350 <= temp && temp < 6450) return "F7";
            if (6450 <= temp && temp < 6550) return "F6";
            if (6550 <= temp && temp < 6650) return "F5";
            if (6650 <= temp && temp < 6750) return "F4";
            if (6750 <= temp && temp < 6950) return "F3";
            if (6950 <= temp && temp < 7150) return "F2";
            if (7150 <= temp && temp < 7400) return "F0";
            if (7400 <= temp && temp < 7650) return "A9";
            if (7650 <= temp && temp < 7900) return "A7";
            if (7900 <= temp && temp < 8100) return "A6";
            if (8100 <= temp && temp < 8300) return "A5";

            return "X0";
        }

        protected virtual double getMinLumin()
        {
            double tmpDbl = 0.0, minMass, massRange, minLumin, luminRange;
            
            if (this.currMass >= Star.minLuminTable[33][0]) return 16; 
            //basic change: if it's above the mass, just throw a high mass star

            for (int i = 0; i < Star.minLuminTable.Length; i++)
            {
                if (this.currMass >= Star.minLuminTable[i][0] && this.currMass < Star.minLuminTable[i + 1][0])
                {
                    //get the minimum mass and mass Range
                    minMass = Star.minLuminTable[i][0];
                    massRange = this.currMass - minMass;

                    //get the minimum lumin and range
                    minLumin = Star.minLuminTable[i][1];
                    luminRange = Star.minLuminTable[i + 1][1] - Star.minLuminTable[i][1];

                    return (minLumin + (massRange / ((Star.minLuminTable[i + 1][0] - minMass)) * luminRange));

                }
            }
            return tmpDbl;
        }

        public static double getMinLumin(double mass)
        {
            double tmpDbl = 0.0, minMass, massRange, minLumin, luminRange;

            if (mass >= Star.minLuminTable[33][0]) return 16;
            //basic change: if it's above the mass, just throw a high mass star

            for (int i = 0; i < Star.minLuminTable.Length; i++)
            {
                if (mass >= Star.minLuminTable[i][0] && mass < Star.minLuminTable[i + 1][0])
                {
                    //get the minimum mass and mass Range
                    minMass = Star.minLuminTable[i][0];
                    massRange = mass - minMass;

                    //get the minimum lumin and range
                    minLumin = Star.minLuminTable[i][1];
                    luminRange = Star.minLuminTable[i + 1][1] - Star.minLuminTable[i][1];

                    return (minLumin + (massRange / ((Star.minLuminTable[i + 1][0] - minMass)) * luminRange));

                }
            }
            return tmpDbl;
        }

        protected static double getMaxLumin(double currMass)
        {
            double tmpDbl;
            //this will determine the maximum luminosity for a star
            if (currMass < .45 || currMass > 2.0) return -1;
            tmpDbl = (4.989914231 * Math.Pow(currMass, 4)) - (17.79087942 * Math.Pow(currMass, 3)) + (28.85126179 * Math.Pow(currMass, 2));
            tmpDbl = tmpDbl - (18.49923946 * currMass) + 4.052052039;
            tmpDbl = Math.Round(tmpDbl, 4);
            return tmpDbl;
        }

        public static double getInitTemp(double currMass)
        {
            double tmpDbl;
            //corrected 12 Dec 2012: Missing sign. Not the most accurate, but the table isn't super accurate either.
            tmpDbl = -2604.2 * Math.Pow(currMass, 6) + 14710 * Math.Pow(currMass, 5) - 29246 * Math.Pow(currMass, 4);
            tmpDbl += 22255 * Math.Pow(currMass, 3) - 2083 * Math.Pow(currMass, 2) - (449.86 * currMass) + 3214.2;
            tmpDbl = Math.Round(tmpDbl, 2);

            return tmpDbl;
        }

        public static double getRadius(double mass, double effTemp, double currLumin, int currentAgeGroup)
        {
            if (currentAgeGroup != StarAgeLine.RET_DWARFBRANCH)
                return ((155000 * Math.Sqrt(currLumin)) / Math.Pow(effTemp, 2));
            else
                return (.0001118 * Math.Pow(mass, (1 / 3)));  
        }


        //these set age markers
        public static double findMainLimit(double currMass)
        {
            double tmpDbl;
            //determines the main sequence limit
            if (currMass < .45) return 1300.0; //set for an extremely high number.
            tmpDbl = (39.5535698038 * Math.Pow(currMass, 4)) - (247.56796104217 * Math.Pow(currMass, 3));
            tmpDbl += (580.40142164746 * Math.Pow(currMass, 2)) - (610.07037160674 * currMass) + 247.75169730288;
            tmpDbl = Math.Round(tmpDbl, 3);

            return tmpDbl;
            
        }

        public static double findSubLimit(double currMass)
        {
            double tmpDbl;
            //determines the sub span limit
            tmpDbl = (1.9998950042437 * Math.Pow(currMass, 4)) - (14.088628035713 * Math.Pow(currMass, 3))
                     + (37.565459826918 * Math.Pow(currMass, 2)) - (45.463378074726 * currMass) + 21.565798170783;
            tmpDbl = Math.Round(tmpDbl, 3);

            return tmpDbl;
        }

        public static double calcOrbitalPeriod(double orbitMass, double srcMass, double orbitalRadius)
        {
            return Math.Sqrt(Math.Pow(orbitalRadius, 3) / (orbitMass + srcMass));
        }

        public static String getColor(double temp)
        {
            string color = "";

            if (temp >= 33000) return "blue";
            if (temp >= 10000 && temp < 33000) return "Blue-white";
            if (temp >= 7500 && temp < 10000) return "Whitish Blue";
            if (temp >= 6000 && temp < 7500) return "White";
            if (temp >= 5200 && temp < 6000) return "Yellow";
            if (temp >= 4250 && temp < 5200) return "Yellowish Orange";
            if (temp >= 3700 && temp < 4250) return "Orange";
            if (temp >= 2000 && temp < 3700) return "Orangish Red";
            if (temp >= 1300 && temp < 2000) return "Red";
            if (temp >= 700 && temp < 1300) return "Purplish Red";
            if (temp >= 100 && temp < 700) return "Brown";
            if (temp < 100) return "Black";

            return color;
        }

        /**
         */
        public static double findGiantLimit(double currMass)
        {
            double tmpDbl;
            //determines the giant limit
            tmpDbl = (4.533 * Math.Pow(currMass, 6)) - (42.472 * Math.Pow(currMass, 5)) + (164.88 * Math.Pow(currMass, 4)) -
                (340.31 * Math.Pow(currMass, 3)) + (395.58 * Math.Pow(currMass, 2)) - (247.54 * currMass) + 66.283;

            tmpDbl = Math.Round(tmpDbl, 3);

            return tmpDbl;
        }

        //generates the formation numbers
        public static double innerRadius(double initLumin, double initMass)
        {
            double lumFactor = Math.Sqrt(initLumin);
            if (.1 * initMass > .01 * lumFactor)
                return .1 * initMass;
            else
                return Math.Round(.01 * lumFactor, 3);

        }
        

        public static double outerRadius(double initMass)
        {
            return Math.Round((40 * initMass), 3);
        }

        public static double snowLine(double initLumin)
        {
            return (4.85 * Math.Sqrt(initLumin));
        }

        public virtual Range generateFormationRange()
        {
            return (new Range(Star.innerRadius(this.initLumin,this.initMass),Star.outerRadius(this.initMass)));
        }


        //forbidden zone calcs
        public virtual double getInnerForbiddenZone()
        {
            return Math.Round((Orbital.getPeriapsis(this.orbitalEccent,this.orbitalRadius) / 3), 3);
        }

        public virtual double getOuterForbiddenZone()
        {
            return Math.Round(3 * Orbital.getApapsis(this.orbitalEccent,this.orbitalRadius), 3);
        }

        public virtual Range getEpistellarRange()
        {
            return new Range(.1 * Star.innerRadius(this.initLumin, this.initMass), 1.8 * Star.innerRadius(this.initLumin, this.initMass));
        }

        public virtual Range getEccentricRange()
        {
            return new Range(.125 * Star.snowLine(this.initLumin), .75 * Star.snowLine(this.initLumin));
        }

        public virtual Range getConventionalRange()
        {
            return new Range(Star.snowLine(this.initLumin), 1.5 * Star.snowLine(this.initLumin));
        }

        //gas giant checks (all passthrough, but simplify  the call.
        public double checkEpiRange()
        {
            return this.zonesOfInterest.verifyRange(this.getEpistellarRange());
        }

        public double checkEccRange()
        {
            return this.zonesOfInterest.verifyRange(this.getEccentricRange());
        }

        public double checkConRange()
        {
            return this.zonesOfInterest.verifyRange(this.getConventionalRange());
        }

        public static String descGasGiantFlag(int flag)
        {
            if (flag == GASGIANT_CONVENTIONAL) return "Conventional Gas Giant";
            if (flag == GASGIANT_ECCENTRIC) return "Eccentric Gas Giant";
            if (flag == GASGIANT_EPISTELLAR) return "Epistellar Gas Giant";
            if (flag == GASGIANT_NONE) return "No Gas Giant";
            
            return "GAS GIANT ERROR";
        }

        public static string getDescOrderFlag(int flag)
        {
            if (flag == Star.IS_PRIMARY)
                return "Primary star";
            if (flag == Star.IS_SECONDARY)
                return "Secondary star";
            if (flag == Star.IS_TRINARY)
                return "Trinary star";
            if (flag == Star.IS_SECCOMP)
                return "Secondary Companion star";
            if (flag == Star.IS_TRICOMP)
                return "Trinary Companion star";
            if (flag == Satellite.ORBIT_PRISEC)
                return "Primary and Secondary stars";
            if (flag == Satellite.ORBIT_SECCOM)
                return "Secondary and Companion stars";
            if (flag == Satellite.ORBIT_TRICOM)
                return "Trinary and Companion stars";
            if (flag == Satellite.ORBIT_PLANET)
                return "Parent Planet";

            return "???";
        }

        //general function
        public static double GetRatio(double x, double y)
        {
            return y / x;
        }
    }
}
