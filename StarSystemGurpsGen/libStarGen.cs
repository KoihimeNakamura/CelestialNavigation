using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    /// <summary>
    /// This contains a series of helper functions to generate a Star System.
    /// </summary>
    public static class libStarGen
    {
        /// <summary>
        /// This generates a random name for a star system
        /// </summary>
        /// <param name="prefix">The prefix for the generator</param>
        /// <param name="ourDice">Dice used in rolling</param>
        /// <returns>A random name for a star system</returns>
        public static string genRandomSysName(string prefix, Dice ourDice)
        {
            return (prefix + Math.Round(ourDice.rollRange(0, 1) * 1000000000, 0));
        }

        /// <summary>
        ///  This function generates a random age per GURPS Space 4e rules. 
        /// </summary>
        /// <param name="ourDice">The dice this rolls</param>
        /// <returns>The system age</returns>
        public static double genSystemAge(Dice ourDice)
        {

            //get first roll
            int roll;
            roll = ourDice.gurpsRoll();

            if (OptionCont.getSystemAge() != -1)
                return OptionCont.getSystemAge();

            if (roll == 3)
                return 0.01;
            if (roll >= 4 && roll <= 6)
                return (.1 + (ourDice.rng(1, 6, -1) * .3) + (ourDice.rng(1, 6, -1) * .05));
            if (roll >= 7 && roll <= 10)
                return (2 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));
            if (roll >= 11 && roll <= 14)
                return (5.6 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));
            if (roll >= 15 && roll <= 17)
                return (8 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));
            if (roll == 18)
                return (10 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1));

            return 13.8;
        }

        /// <summary>
        /// This function generates and populates our stars. 
        /// </summary>
        /// <param name="ourBag">The Dice object used for our PRNG</param>
        /// <param name="ourSystem">The solar system we are creating stars for</param>
        public static void createStars(Dice ourBag, StarSystem ourSystem)
        {
            int numStars = 0;

            //determine the number of stars
            if (OptionCont.getNumberOfStars() != -1)
            {
                numStars = OptionCont.getNumberOfStars();
            }
            else
            {
                // We take the roll, add 2 if it's in an open cluster,subtract 1 if not, then divide it by 5.
                // This matches the roll probablity to the table.
                numStars = (int)(Math.Floor((ourBag.gurpsRoll() + (OptionCont.inOpenCluster ? 2 : -1)) / 5.0));
                
                //fix a few possible logic bugs.
                if (numStars < 1) numStars = 1;
                if (numStars > 3) numStars = 3;
            }

            //creating the stars.
            for (int i = 0; i < numStars; i++)
            {
                if (i == 0)
                {
                    ourSystem.addStar(Star.IS_PRIMARY, Star.IS_PRIMARY, i);

                    //manually set the first star's mass and push it to the max mass setting
                    ourSystem.sysStars[0].updateMass(libStarGen.rollStellarMass(ourBag));
                    ourSystem.maxMass = ourSystem.sysStars[0].currMass;

                    //generate the star
                    libStarGen.generateAStar(ourSystem.sysStars[i], ourBag, ourSystem.maxMass, ourSystem.sysName);

                }
                if (i == 1)
                {
                    ourSystem.addStar(Star.IS_SECONDARY, Star.IS_PRIMARY, i);
                    //generate the star
                    libStarGen.generateAStar(ourSystem.sysStars[i], ourBag, ourSystem.maxMass, ourSystem.sysName);
                }
                if (i == 2)
                {
                    ourSystem.addStar(Star.IS_TRINARY, Star.IS_PRIMARY, i);
                    //generate the star
                    libStarGen.generateAStar(ourSystem.sysStars[i], ourBag, ourSystem.maxMass, ourSystem.sysName);
                }
            }

            //now generate orbitals
            if (ourSystem.countStars() > 1)
            {
                libStarGen.placeOurStars(ourSystem, ourBag);
            }

        }

        /// <summary>
        /// This function rolls for mass on a star.
        /// </summary>
        /// <param name="velvetBag">The dice object</param>
        /// <param name="maxMass">the maximum mass. Has a default value of 0.0, indicating no max mass (may be left out)</param>
        /// <returns>The rolled mass of a star</returns>
        public static double rollStellarMass(Dice velvetBag, double maxMass = 0.0)
        {
            int rollA, rollB; //roll integers
            double tmpRoll; //test value.

            if (maxMass == 0.0)
            {
                if (!OptionCont.stellarMassRangeSet)
                    return Star.getMassByRoll(velvetBag.gurpsRoll(), velvetBag.gurpsRoll());
                else
                    return velvetBag.rollInRange(OptionCont.minStellarMass, OptionCont.maxStellarMass);
            }

            else
            {
                int currPos = Star.getStellarMassPos(maxMass);

                //error bound checking. The entire program is kinda predicated aroudn the idea you won't have this happen.
                //IF IT DOES, then do the simple method.
                if (currPos == -1)
                {
                    do
                    {
                        tmpRoll = Star.getMassByRoll(velvetBag.gurpsRoll(), velvetBag.gurpsRoll());
                    } while (tmpRoll > maxMass);

                    return tmpRoll;
                }

                //else, roll for the new index.
                rollA = velvetBag.gurpsRoll();
                rollB = velvetBag.rng(rollA, 6);


                //get the new index
                if (currPos - rollB <= 0) currPos = 0;
                else currPos = currPos - rollB;

                return Star.getMassByIndex(currPos);
            }

         

        }

        /// <summary>
        /// This function fills in the details of the star.
        /// </summary>
        /// <param name="s">The star to be filled in</param>
        /// <param name="ourDice">The dice object used</param>
        /// <param name="maxMass">Max mass of the system</param>
        /// <param name="sysName">The name of the system</param>
        public static void generateAStar(Star s, Dice ourDice, double maxMass, string sysName)
        {
            //check mass first - if unset, set it.
            if (s.currMass == 0)
            {
                if (s.orderID == Star.IS_PRIMARY)
                {
                    s.updateMass(libStarGen.rollStellarMass(ourDice));
                    maxMass = s.currMass;
                }
                
                else 
                    s.updateMass(libStarGen.rollStellarMass(ourDice, maxMass));
            }

            //if we are in the white dwarf branch, reroll mass.
            if (s.evoLine.findCurrentAgeGroup(s.starAge) == StarAgeLine.RET_COLLASPEDSTAR)
                s.updateMass(ourDice.rollInRange(0.9, 1.4),true);

            //set the generic name
            s.name = Star.genGenericName(sysName, s.orderID); 

            //initalize the luminosity first, then update it given the current age, status and mass.
            s.setLumin();
            s.currLumin = Star.getCurrLumin(s.evoLine, s.starAge, s.currMass);
         
            //determine the temperature
            s.effTemp = Star.getInitTemp(s.currMass);
            s.effTemp = Star.getCurrentTemp(s.evoLine, s.currLumin, s.starAge, s.currMass, ourDice);
            

            //DERIVED STATS: RADIUS, Spectral Type
            s.radius = Star.getRadius(s.currMass, s.effTemp, s.currLumin, s.evoLine.findCurrentAgeGroup(s.starAge));
            s.setSpectralType();
            s.starColor = Star.setColor(ourDice, s.effTemp);

            //set flare status.
            libStarGen.setFlareStatus(s, ourDice);

           //end this here. We will hand orbital mechanics elsewhere.

        }

        /// <summary>
        /// This sets the flare status of a star
        /// </summary>
        /// <param name="s">The star we're setting for</param>
        /// <param name="ourDice">The dice object we use.</param>
        public static void setFlareStatus(Star s, Dice ourDice)
        {
            int roll = ourDice.gurpsRoll();
            int limit = 12;
            double massLimit = .45;

            if (OptionCont.anyStarFlareStar) massLimit = 11;
            if (OptionCont.moreFlareStarChance) limit = 9;

            if (roll >= limit && s.currMass <= massLimit) s.isFlareStar = true;
     

        }

        /// <summary>
        /// A short hand copy for a comparison
        /// </summary>
        /// <param name="var">The variable being compared</param>
        /// <param name="min">Minimum threshold</param>
        /// <param name="max">Maximum Threshold</param>
        /// <param name="canEqual">If it can equal the bounds. Set to true by default.</param>
        /// <returns></returns>
        public static bool inbetween(int var, int min, int max, bool canEqual = true)
        {
            if (canEqual)
                return ((var >= min) && (var <= max));
            else
                return ((var > min) && (var < max));
        }

        public static void gasGiantFlag(Star myStar, int roll){
            int noGasGiant = 10;
            int conGaGiant = 12;
            int eccGaGiant = 14;
            int epiGaGiant = 18;

            if (roll <= noGasGiant)
                myStar.gasGiantFlag = Star.GASGIANT_NONE;
            if (roll > noGasGiant && roll <= conGaGiant)
                myStar.gasGiantFlag = Star.GASGIANT_CONVENTIONAL;
            if (roll > conGaGiant && roll <= eccGaGiant)
                myStar.gasGiantFlag = Star.GASGIANT_ECCENTRIC;
            if (roll > eccGaGiant && roll <= epiGaGiant)
                myStar.gasGiantFlag = Star.GASGIANT_EPISTELLAR;
        }

        public static double getOrbitalRatio(Dice myDice)
        {
            double ratio = 0;

            int roll = myDice.gurpsRoll();
            
            if (roll == 3 || roll == 4)
            {
                ratio = 1.4 + (myDice.rng(1, 5) * .01);
            }

            if (roll == 5 || roll == 6)
            {
                ratio = 1.5 + (myDice.rng(1, 10, -5) * .01);
            }
            
            if (roll == 7 || roll == 8)
            {
                ratio = 1.6 + (myDice.rng(1, 10, -5) * .01);
            }
            
            if (roll == 9 || roll == 10 || roll == 11 || roll == 12)
            {
                ratio = 1.7 + (myDice.rng(1, 10, -5) * .01);
            }

            if (roll == 13 || roll == 14)
            {
                ratio = 1.8 + (myDice.rng(1, 10, -5) * .01);
            }

            if (roll == 15 || roll == 16)
            {
                ratio = 1.9 + (myDice.rng(1, 10, -5) * .01);
            }

            if (roll == 17 || roll == 18)
            {
                ratio = 2.0 + (myDice.rng(1, 10, -5) * .01);
            }

            return ratio;
        }

        public static double determineDistance(double planetDistance, double[,] distChart, int planetParent, int starID)
        {
            double dist = 0;
            int parent = 0;
            int target = 0;

            //get the parent flag
            if (planetParent == Star.IS_PRIMARY) parent = 0;
            if (planetParent == Star.IS_SECONDARY) parent = 1;
            if (planetParent == Star.IS_TRINARY) parent = 2;
            if (planetParent == Star.IS_SECCOMP) parent = 3;
            if (planetParent == Star.IS_TRICOMP) parent = 4;

            if (planetParent == Satellite.ORBIT_PRISEC) parent = 0;
            if (planetParent == Satellite.ORBIT_SECCOM) parent = 1;
            if (planetParent == Satellite.ORBIT_TRICOM) parent = 2;
            if (planetParent == Satellite.ORBIT_PRISECTRI) parent = 0;
            if (planetParent == Satellite.ORBIT_PRITRI) parent = 0;

            if (starID == Star.IS_PRIMARY) target = 0;
            if (planetParent == Star.IS_SECONDARY) target = 1;
            if (planetParent == Star.IS_TRINARY) target = 2;
            if (planetParent == Star.IS_SECCOMP) target = 3;
            if (planetParent == Star.IS_TRICOMP) target = 4;

            dist = Math.Abs(distChart[parent, target] + planetDistance);

            return dist;

        }

        //also determines RVM! (because I might as well.)
        public static void determineGeologicValues(Satellite s, Dice ourBag, double sysAge, bool isGasGiantMoon)
        {
            //volcanic set first.
            double addVal = (s.gravity / sysAge) * 40;

            if (s.majorMoons.Count == 1) addVal = addVal + 5;
            if (s.majorMoons.Count == 2) addVal = addVal + 10;

            if (s.SatelliteType == Satellite.SUBTYPE_SULFUR) addVal = addVal + 60;
            if (isGasGiantMoon) addVal = addVal + 5;

            int roll = ourBag.gurpsRoll();

            addVal = addVal + roll;

            if (addVal <= 16.5) s.volActivity = Satellite.GEOLOGIC_NONE;
            if (addVal > 16.5 && addVal <= 20.5) s.volActivity = Satellite.GEOLOGIC_LIGHT;
            if (addVal > 20.5 && addVal <= 26.5) s.volActivity = Satellite.GEOLOGIC_MODERATE;
            if (addVal > 26.5 && addVal <= 70.5) s.volActivity = Satellite.GEOLOGIC_HEAVY;
            if (addVal > 70.5) s.volActivity = Satellite.GEOLOGIC_EXTREME;

            roll = ourBag.gurpsRoll();
            if (s.volActivity == Satellite.GEOLOGIC_HEAVY && s.SatelliteType == Satellite.SUBTYPE_GARDEN && roll <= 8)
            {
                roll = ourBag.rng(6);
                if (roll <= 3) s.addAtmCategory(Satellite.ATM_MARG_POLLUTANTS);
                if (roll >= 4) s.addAtmCategory(Satellite.ATM_MARG_SULFUR);
            }

            roll = ourBag.gurpsRoll();
            if (s.volActivity == Satellite.GEOLOGIC_EXTREME && s.SatelliteType == Satellite.SUBTYPE_GARDEN && roll <= 14)
            {
                roll = ourBag.rng(6);
                if (roll <= 3) s.addAtmCategory(Satellite.ATM_MARG_POLLUTANTS);
                if (roll >= 4) s.addAtmCategory(Satellite.ATM_MARG_SULFUR);
            }

            //tectonic next
            roll = ourBag.gurpsRoll();

            //negative mods
            if (s.hydCoverage == 0) roll = roll - 4;
            if (s.hydCoverage > 0 && s.hydCoverage < .5) roll = roll - 2;
            if (s.volActivity == Satellite.GEOLOGIC_NONE) roll = roll - 8;
            if (s.volActivity == Satellite.GEOLOGIC_LIGHT) roll = roll - 4;

            //postive mods
            if (s.volActivity == Satellite.GEOLOGIC_HEAVY) roll = roll + 4;
            if (s.volActivity == Satellite.GEOLOGIC_EXTREME) roll = roll + 8;
            if (s.majorMoons.Count == 1) roll = roll + 2;
            if (s.majorMoons.Count > 1) roll = roll + 4;

            //nullers.
            if (s.SatelliteSize == Satellite.SIZE_TINY) roll = 0;
            if (s.SatelliteSize == Satellite.SIZE_SMALL) roll = 0;


            if (roll <= 6.5) s.tecActivity = Satellite.GEOLOGIC_NONE;
            if (roll > 6.5 && roll <= 10.5) s.tecActivity = Satellite.GEOLOGIC_LIGHT;
            if (roll > 10.5 && roll <= 14.5) s.tecActivity = Satellite.GEOLOGIC_MODERATE;
            if (roll > 14.5 && roll <= 18.5) s.tecActivity = Satellite.GEOLOGIC_HEAVY;
            if (roll > 18.5) s.tecActivity = Satellite.GEOLOGIC_EXTREME;

            //update RVM
            if (!OptionCont.highRVMVal) roll = ourBag.gurpsRoll();
            if (OptionCont.highRVMVal) roll = ourBag.rng(1, 8, 8);

            if (s.volActivity == Satellite.GEOLOGIC_NONE) roll = roll - 2;
            if (s.volActivity == Satellite.GEOLOGIC_LIGHT) roll = roll - 1;
            if (s.volActivity == Satellite.GEOLOGIC_HEAVY) roll = roll + 1;
            if (s.volActivity == Satellite.GEOLOGIC_EXTREME) roll = roll + 2;

            if (s.baseType == Satellite.BASETYPE_ASTEROIDBELT)
            {
                if (s.SatelliteSize == Satellite.SIZE_TINY) roll = roll - 1;
                if (s.SatelliteSize == Satellite.SIZE_MEDIUM) roll = roll + 2;
                if (s.SatelliteSize == Satellite.SIZE_LARGE) roll = roll + 4;
            }

            //set stable activity here:
            if (OptionCont.stableActivity)
            {
                s.volActivity = Satellite.GEOLOGIC_MODERATE;
                s.tecActivity = Satellite.GEOLOGIC_MODERATE;
            }

            s.populateRVM(roll);

        }

        public static void updateTidalLock(Satellite s, Dice ourBag)
        {
            int atmDesc = s.getAtmCategory();

            if (atmDesc == Satellite.ATM_PRES_NONE || atmDesc == Satellite.ATM_PRES_TRACE)
            {
                s.updateAtmPres(0.00);
                s.hydCoverage = 0.0;
                s.dayFaceMod = 1.2;
                s.nightFaceMod = .1;
            }

            if (atmDesc == Satellite.ATM_PRES_VERYTHIN)
            {
                s.updateAtmPres(0.01);
                s.hydCoverage = 0.0;
                s.dayFaceMod = 1.2;
                s.nightFaceMod = .1;
            }

            if (atmDesc == Satellite.ATM_PRES_THIN)
            {
                s.updateAtmPres(ourBag.rollRange(.01, .49));

                s.hydCoverage = s.hydCoverage - .5;
                if (s.hydCoverage < 0) s.hydCoverage = 0.0;

                s.dayFaceMod = 1.16;
                s.nightFaceMod = .67;
            }

            if (atmDesc == Satellite.ATM_PRES_STANDARD)
            {
                s.hydCoverage = s.hydCoverage - .25;
                if (s.hydCoverage < 0) s.hydCoverage = 0.0;

                s.dayFaceMod = 1.12;
                s.nightFaceMod = .80;
            }

            if (atmDesc == Satellite.ATM_PRES_DENSE)
            {
                s.hydCoverage = s.hydCoverage - .1;
                if (s.hydCoverage < 0) s.hydCoverage = 0.0;
                s.dayFaceMod = 1.09;
                s.nightFaceMod = .88;
            }

            if (atmDesc == Satellite.ATM_PRES_VERYDENSE)
            {
                s.dayFaceMod = 1.05;
                s.nightFaceMod = .95;
            }

            if (atmDesc == Satellite.ATM_PRES_SUPERDENSE)
            {
                s.dayFaceMod = 1.0;
                s.nightFaceMod = 1.0;
            }
        }

        public static void calcEccentricity(Dice ourDice, Star s)
        {
            int modifiers = 0; //reset the thing.

            if (OptionCont.lessStellarEccent)
            {
                //now we generate eccentricities
                if (s.orbitalSep == Star.ORBSEP_VERYCLOSE) modifiers = modifiers - 10; //Very Close
                if (s.orbitalSep == Star.ORBSEP_CLOSE) modifiers = modifiers - 6; //Close
                if (s.orbitalSep == Star.ORBSEP_MODERATE) modifiers = modifiers - 2; //Moderate  
            }
            else
            {
                if (s.orbitalSep == Star.ORBSEP_VERYCLOSE) modifiers = modifiers - 6; //Very Close
                if (s.orbitalSep == Star.ORBSEP_CLOSE) modifiers = modifiers - 4; //Close
                if (s.orbitalSep == Star.ORBSEP_MODERATE) modifiers = modifiers - 2; //Moderate  
            }
            

            int roll = ourDice.gurpsRoll(modifiers);
            Star.generateEccentricity(roll, s);

            if (OptionCont.forceVeryLowStellarEccent)
            {
                if (s.orbitalEccent > .2) s.orbitalEccent = .1;
                if (s.orbitalEccent > .1 && s.orbitalEccent < .2) s.orbitalEccent = .05;

            }

        }

        public static void updateGasGiantSize(Satellite s, int roll)
        {
            if (roll <= 10) s.updateSize(Satellite.SIZE_SMALL);
            if (roll >= 11 && roll <= 16) s.updateSize(Satellite.SIZE_MEDIUM);
            if (roll >= 17) s.updateSize(Satellite.SIZE_LARGE);
        }

        public static void populateOrbits(Star s, Dice myDice)
        {

            double maxRatio = 2.0;
            //double minRatio = 1.4;
            double minDistance = .15;
            bool firstGasGiant = true;

            if (s.containsGasGiants()) firstGasGiant = false;
             
            for (int i = 0; i < s.sysPlanets.Count; i++)
            {
                int roll = myDice.gurpsRoll();
                
                //set gas giants first.
                if (s.gasGiantFlag != Star.GASGIANT_NONE)
                {
                    //BEFORE SNOW LINE: Only Eccentric, Epistellar
                    if (s.sysPlanets[i].orbitalRadius < Star.snowLine(s.initLumin))
                    {
                        if (roll <= 8 && s.gasGiantFlag == Star.GASGIANT_ECCENTRIC)
                        {
                            s.sysPlanets[i].updateType(Satellite.BASETYPE_GASGIANT);
                            libStarGen.updateGasGiantSize(s.sysPlanets[i],myDice.gurpsRoll() + 4);
                        }

                        if (roll <= 6 && s.gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                        {
                            s.sysPlanets[i].updateType(Satellite.BASETYPE_GASGIANT);
                            libStarGen.updateGasGiantSize(s.sysPlanets[i], myDice.gurpsRoll() + 4);
                        }
                    }

                    //AFTER SNOW LINE: All three
                    if (s.sysPlanets[i].orbitalRadius >= Star.snowLine(s.initLumin))
                    {
                        if (roll <= 15 && s.gasGiantFlag == Star.GASGIANT_CONVENTIONAL)
                        {
                            s.sysPlanets[i].updateType(Satellite.BASETYPE_GASGIANT);
                            if (firstGasGiant)
                            {
                                libStarGen.updateGasGiantSize(s.sysPlanets[i], myDice.gurpsRoll() + 4);
                                firstGasGiant = false;
                            }
                            else
                                libStarGen.updateGasGiantSize(s.sysPlanets[i], myDice.gurpsRoll());
                        }

                        if (roll <= 14 && (s.gasGiantFlag == Star.GASGIANT_ECCENTRIC || s.gasGiantFlag == Star.GASGIANT_EPISTELLAR))
                        {
                            s.sysPlanets[i].updateType(Satellite.BASETYPE_GASGIANT);
                            if (firstGasGiant)
                            {
                                libStarGen.updateGasGiantSize(s.sysPlanets[i], myDice.gurpsRoll() + 4);
                                firstGasGiant = false;
                            }
                            else
                                libStarGen.updateGasGiantSize(s.sysPlanets[i], myDice.gurpsRoll());
                        }
                    }


                }

                //Done with the gas giant. Let's go start seeign what else it could be.

                //We can get mods now.
                if (s.sysPlanets[i].baseType != Satellite.BASETYPE_GASGIANT)
                {
                    //INNER AND OUTER RADIUS
                    int mod = 0;

                    if (s.sysPlanets[i].orbitalRadius - minDistance <= Star.innerRadius(s.initLumin,s.initMass) ||
                        s.sysPlanets[i].orbitalRadius / Star.innerRadius(s.initLumin, s.initMass) <= maxRatio)
                    {
                        mod = mod - 3;
                    }

                    if (s.sysPlanets[i].orbitalRadius + minDistance >= Star.outerRadius(s.initMass) ||
                        Star.outerRadius(s.initMass) / s.sysPlanets[i].orbitalRadius <= maxRatio)
                    {
                        mod = mod - 3;
                    }

                    //FORBIDDDEN ZONE
                    if (s.getClosestDistToForbiddenZone(s.sysPlanets[i].orbitalRadius) <= minDistance || s.getClosestForbiddenZoneRatio(s.sysPlanets[i].orbitalRadius) < maxRatio)
                    {
                        mod = mod - 6;
                    }

                    //GAS GIANT LOCATION
                    if (s.isPrevSatelliteGasGiant(s.sysPlanets[i].orbitalRadius))
                    {
                        mod = mod - 6;
                    }
                    if (s.isNextSatelliteGasGiant(s.sysPlanets[i].orbitalRadius))
                    {
                        mod = mod - 3;
                    }

                    //now let's get the orbit type.
                    mod = mod + myDice.gurpsRoll();
                    
                    if (mod <= 3)
                        s.sysPlanets[i].updateType(Satellite.BASETYPE_EMPTY);

                    if (mod >= 4 && mod <= 6)
                    {
                        s.sysPlanets[i].updateType(Satellite.BASETYPE_ASTEROIDBELT);

                        //Expanded Asteroid Belt options
                        if (OptionCont.expandAsteroidBelt)
                        {
                            roll = myDice.gurpsRoll();
                            if (roll <= 6) s.sysPlanets[i].updateSize(Satellite.SIZE_TINY);
                            if (roll >= 7 && roll <= 13) s.sysPlanets[i].updateSize(Satellite.SIZE_SMALL);
                            if (roll >= 14 && roll <= 15) s.sysPlanets[i].updateSize(Satellite.SIZE_MEDIUM);
                            if (roll >= 16) s.sysPlanets[i].updateSize(Satellite.SIZE_LARGE);
                        }
                    }

                    if (mod >= 7 && mod <= 8)
                        s.sysPlanets[i].updateTypeSize(Satellite.BASETYPE_TERRESTIAL, Satellite.SIZE_TINY);

                    if (mod >= 9 && mod <= 11)
                        s.sysPlanets[i].updateTypeSize(Satellite.BASETYPE_TERRESTIAL, Satellite.SIZE_SMALL);

                    if (mod >= 12 && mod <= 15)
                        s.sysPlanets[i].updateTypeSize(Satellite.BASETYPE_TERRESTIAL, Satellite.SIZE_MEDIUM);

                    if (mod >= 16)
                        s.sysPlanets[i].updateTypeSize(Satellite.BASETYPE_TERRESTIAL, Satellite.SIZE_LARGE);
                }

            
            }
        }

        /// <summary>
        /// This places our stars around the primary, as well as creating the secondary stars if called for
        /// </summary>
        /// <param name="ourSystem">The star system to be added to.</param>
        /// <param name="velvetBag">Our dice object.</param>
        public static void placeOurStars(StarSystem ourSystem, Dice velvetBag)
        {
            int roll = 0;

                //initiate the variables we need to ensure distances are kept
                double minOrbitalDistance = 0.0, maxOrbitalDistance = 600.0, tempVal = 0.0;
                int starLimit = ourSystem.sysStars.Count;
                for (int i = 1; i < starLimit; i++)
                {
                    int modifiers = 0;
                    minOrbitalDistance = ourSystem.sysStars[i - 1].orbitalRadius;

                    //set the min and max conditions for the first star here.
                    if (ourSystem.sysStars[i].parentID == 0 || ourSystem.sysStars[i].parentID == Star.IS_PRIMARY)
                    {
                        //apply modifiers
                        if (ourSystem.sysStars[i].selfID == Star.IS_TRINARY) modifiers = modifiers + 6;
                        if (OptionCont.forceGardenFavorable && ourSystem.sysStars[i].parentID == Star.IS_PRIMARY) modifiers = modifiers + 4;

                        if (minOrbitalDistance == 600.0)
                        {
                            //in this situation, orbital 3 or so can't be safely placed because the range is 0. 
                            // so we autogenerate it.
                            tempVal = velvetBag.rollRange(25, 25);
                            ourSystem.sysStars[i].orbitalSep = 5;
                            ourSystem.sysStars[ourSystem.star2index].orbitalRadius = ourSystem.sysStars[ourSystem.star2index].orbitalRadius - tempVal;
                            ourSystem.sysStars[i].orbitalRadius = 600 + tempVal;
                            ourSystem.sysStars[i].distFromPrimary = ourSystem.sysStars[i].orbitalRadius;
                            minOrbitalDistance = ourSystem.sysStars[i].orbitalRadius;
                        }
                        else
                        {
                            do
                            {
                                double lowerBound = 0.0;
                                double higherBound = 0.0;

                                //roll the dice and generate the orbital radius
                                do
                                {
                                    roll = velvetBag.gurpsRoll(modifiers);
                                    if (roll <= 6) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_VERYCLOSE;
                                    if (roll >= 7 && roll <= 9) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_CLOSE;
                                    if (roll >= 10 && roll <= 11) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_MODERATE;
                                    if (roll >= 12 && roll <= 14) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_WIDE;
                                    if (roll >= 15) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_DISTANT;
                                    tempVal = velvetBag.rng(2, 6) * libStarGen.getSepModifier(ourSystem.sysStars[i].orbitalSep);
                                } while (tempVal <= minOrbitalDistance);

                                //if (ourSystem.sysStars[i].selfID == 2) tempVal = this.velvetBag.six(1, 7) * ourSystem.sysStars[i].getSepModifier(); 
                                lowerBound = tempVal - .5 * libStarGen.getSepModifier(ourSystem.sysStars[i].orbitalSep);
                                higherBound = .5 * libStarGen.getSepModifier(ourSystem.sysStars[i].orbitalSep) + tempVal;


                                //set for constraints
                                if (lowerBound < minOrbitalDistance) lowerBound = minOrbitalDistance;
                                if (higherBound > maxOrbitalDistance) higherBound = maxOrbitalDistance;

                                ourSystem.sysStars[i].orbitalRadius = tempVal;
                                ourSystem.sysStars[i].distFromPrimary = ourSystem.sysStars[i].orbitalRadius;

                            } while (ourSystem.sysStars[i].orbitalRadius <= minOrbitalDistance);

                            //let's see if it has a subcompanion
                            if (ourSystem.sysStars[i].orbitalSep == Star.ORBSEP_DISTANT)
                            {
                                roll = velvetBag.gurpsRoll();
                                if (roll >= 11)
                                {
                                    //generate the subcompanion
                                    int order = 0;

                                    if (ourSystem.sysStars[i].selfID == Star.IS_SECONDARY) order = Star.IS_SECCOMP;
                                    if (ourSystem.sysStars[i].selfID == Star.IS_TRINARY) order = Star.IS_TRICOMP;

                                    //add the star
                                    ourSystem.addStar(order, ourSystem.sysStars[i].selfID, (i + 1));

                                    ourSystem.sysStars[starLimit].name = Star.genGenericName(ourSystem.sysName, (i + 1));

                                    //set the name, then generate the star
                                    ourSystem.sysStars[starLimit].parentName = ourSystem.sysStars[i].name;
                                    libStarGen.generateAStar(ourSystem.sysStars[starLimit], velvetBag, ourSystem.sysStars[i].currMass, ourSystem.sysName);
                                    starLimit++; //increment the total number of stars we have generated
                                }

                            }
                        }
                    }
                    else
                    {
                        minOrbitalDistance = 0;
                        maxOrbitalDistance = ourSystem.sysStars[ourSystem.getStellarParentID(ourSystem.sysStars[i].parentID)].orbitalRadius;
                        //roll for seperation
                        do
                        {
                            double lowerBound = 0.0;
                            double higherBound = 0.0;
                            //roll the dice

                            roll = velvetBag.gurpsRoll(-6);
                            if (roll <= 6) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_VERYCLOSE;
                            if (roll >= 7 && roll <= 9) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_CLOSE;
                            if (roll >= 10 && roll <= 11) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_MODERATE;
                            if (roll >= 12 && roll <= 14) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_WIDE;
                            if (roll >= 15) ourSystem.sysStars[i].orbitalSep = Star.ORBSEP_DISTANT;

                            //set the subcompanion orbital
                            tempVal = velvetBag.rng(2, 6) * libStarGen.getSepModifier(ourSystem.sysStars[i].orbitalSep);
                            lowerBound = tempVal - .5 * libStarGen.getSepModifier(ourSystem.sysStars[i].orbitalSep);
                            higherBound = .5 * libStarGen.getSepModifier(ourSystem.sysStars[i].orbitalSep) + tempVal;

                            if (higherBound > maxOrbitalDistance) higherBound = maxOrbitalDistance;

                            ourSystem.sysStars[i].orbitalRadius = tempVal;
                            ourSystem.sysStars[i].distFromPrimary = ourSystem.sysStars[i].orbitalRadius + maxOrbitalDistance;

                        } while (ourSystem.sysStars[i].orbitalRadius > maxOrbitalDistance);
                    }

                    libStarGen.calcEccentricity(velvetBag, ourSystem.sysStars[i]);

                    int parent = ourSystem.getStellarParentID(ourSystem.sysStars[i].parentID);
                    ourSystem.sysStars[i].orbitalPeriod = Star.calcOrbitalPeriod(ourSystem.sysStars[parent].currMass, ourSystem.sysStars[i].currMass, ourSystem.sysStars[i].orbitalRadius);
                }
        }

        /// <summary>
        /// This function draws a table up of each star's distance from each other and from the primary
        /// </summary>
        /// <param name="stars">The stars in this solar system</param>
        /// <returns>Returns a multidimensional array of distances (in doubles)</returns>
        public static double[,] genDistChart(List<Star> stars)
        {
            //first get distances of each star to the primary.
            //Dictionary<int, Dictionary<int,double> distChart = new Dictionary<int, Dictionary<int,double> = new Dictionary<int,double>>();
            var distTable = new Dictionary<int, Dictionary<int, double>>();
            int[] satIDFlags = new int[5] { Star.IS_PRIMARY, Star.IS_SECONDARY, Star.IS_TRINARY, Star.IS_SECCOMP, Star.IS_TRICOMP };
            double[,] distChart = new double[5, 5];

            //INDEX CHART
            /* 0 is Primary
             * 1 is Secondary
             * 2 is Trinary
             * 3 is Secondary-Companion
             * 4 is Trinary-Companion */


            //ROW ONE: Star from which you are comparing [Current]
            //ROW TWO: Star for which you want. [Target]
            for (int i = 0; i < stars.Count; i++)
            {
                for (int j = 0; j < stars.Count; j++)
                {
                    distChart[i, j] = 0.0;

                    if (i == 0)
                    {
                        if (stars[j].orderID == Star.IS_SECONDARY) distChart[i, 1] = stars[j].distFromPrimary * -1.0;
                        if (stars[j].orderID == Star.IS_TRINARY) distChart[i, 2] = stars[j].distFromPrimary * -1.0;
                        if (stars[j].orderID == Star.IS_SECCOMP) distChart[i, 3] = stars[j].distFromPrimary * -1.0;
                        if (stars[j].orderID == Star.IS_TRICOMP) distChart[i, 4] = stars[j].distFromPrimary * -1.0;
                    }


                    if (stars[i].orderID == Star.IS_SECONDARY)
                    {
                        distChart[1, 0] = distChart[0, 0] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECONDARY) distChart[1, 1] = distChart[0, 1] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRINARY) distChart[1, 2] = distChart[0, 2] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECCOMP) distChart[1, 3] = distChart[0, 3] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRICOMP) distChart[1, 4] = distChart[0, 4] + stars[i].distFromPrimary;
                    }

                    if (stars[i].orderID == Star.IS_TRINARY)
                    {
                        distChart[2, 0] = distChart[0, 0] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECONDARY) distChart[2, 1] = distChart[0, 1] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRINARY) distChart[2, 2] = distChart[0, 2] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECCOMP) distChart[2, 3] = distChart[0, 3] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRICOMP) distChart[2, 4] = distChart[0, 4] + stars[i].distFromPrimary;
                    }

                    if (stars[i].orderID == Star.IS_SECCOMP)
                    {
                        distChart[3, 0] = distChart[0, 0] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECONDARY) distChart[3, 1] = distChart[0, 1] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRINARY) distChart[3, 2] = distChart[0, 2] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECCOMP) distChart[3, 3] = distChart[0, 3] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRICOMP) distChart[3, 4] = distChart[0, 4] + stars[i].distFromPrimary;
                    }


                    if (stars[i].orderID == Star.IS_TRICOMP)
                    {
                        distChart[4, 0] = distChart[0, 0] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECONDARY) distChart[4, 1] = distChart[0, 1] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRINARY) distChart[4, 2] = distChart[0, 2] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_SECCOMP) distChart[4, 3] = distChart[0, 3] + stars[i].distFromPrimary;
                        if (stars[j].orderID == Star.IS_TRICOMP) distChart[4, 4] = distChart[0, 4] + stars[i].distFromPrimary;
                    }

                }

            }

            return distChart;

        }

        public static void initateHabitableZones(double[,] distanceChart, List<Star> stars, List<Range> habitableZone)
        {
            double lowerBound = 0, upperBound = 0;
            double maxDistance = 755;
            double currDistance = 0;
            double currTemp = 0;
            double detDst;

            do
            {
                currTemp = 0;
                foreach (Star s in stars)
                {

                    int currStar = 0;
                    //first, find the current star.
                    if (s.orderID == Star.IS_PRIMARY) currStar = 0;
                    if (s.orderID == Star.IS_SECONDARY) currStar = 1;
                    if (s.orderID == Star.IS_TRINARY) currStar = 2;
                    if (s.orderID == Star.IS_SECCOMP) currStar = 3;
                    if (s.orderID == Star.IS_TRICOMP) currStar = 4;

                    detDst = Math.Abs(distanceChart[0, currStar] + currDistance);
                    currTemp = currTemp + Math.Pow((278.0 * Math.Pow(s.currLumin, .25)) / Math.Sqrt(detDst), 4);
                }
                currTemp = Math.Pow(currTemp, .25);

                if (currTemp == 320)
                {
                    upperBound = currDistance;
                }

                if (currTemp == 240)
                {
                    lowerBound = currDistance;
                    habitableZone.Add(new Range(lowerBound, upperBound));
                    lowerBound = 0;
                    upperBound = 0;
                }
                currDistance = currDistance + (.00001);
            } while (currDistance <= maxDistance);

        }



        public static void createPlanets(StarSystem ourSystem, List<Satellite> ourPlanets, Dice velvetBag)
        {
            double[,] distanceTable = genDistChart(ourSystem.sysStars);

            foreach (Satellite s in ourPlanets)
            {

                if (s.baseType == Satellite.BASETYPE_ASTEROIDBELT || s.baseType == Satellite.BASETYPE_EMPTY)
                {
                    if (s.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                        determineGeologicValues(s, velvetBag, ourSystem.sysAge, false);

                    continue;
                }

                double temp = 0.0;
                int parent = ourSystem.getValidParent(s.parentID);

                //set physical properties
                s.genGenericName(ourSystem.sysStars[parent].name, ourSystem.sysName);
                s.genWorldType(ourSystem.maxMass, ourSystem.sysAge, velvetBag);

                s.genDensity(velvetBag);
                s.genDiameter(velvetBag);
                s.setClimateData(ourSystem.maxMass, velvetBag);
                s.detSurfaceTemp(0);
                if (!(s.baseType == Satellite.BASETYPE_GASGIANT)) s.calcAtmPres();

                s.createMoons(ourSystem.sysName, velvetBag, OptionCont.moonOrbitFlag);

                s.getPlanetEccentricity(ourSystem.sysStars[parent].gasGiantFlag, Star.snowLine(ourSystem.sysStars[parent].initLumin), velvetBag);
                s.generateOrbitalPeriod(ourSystem.sysStars[parent].currMass);
                s.createAxialTilt(velvetBag);

                foreach (Star sun in ourSystem.sysStars)
                {
                    double dist = determineDistance(s.orbitalRadius, distanceTable, s.parentID, sun.selfID);

                    temp = (.46 * sun.currMass * s.diameter) / Math.Pow(s.orbitalRadius, 3);
                    int tide = 0;

                    //add the correct flag.
                    if (sun.selfID == Star.IS_PRIMARY) tide = Satellite.TIDE_PRIMARYSTAR;
                    if (sun.selfID == Star.IS_SECONDARY) tide = Satellite.TIDE_SECONDARYSTAR;
                    if (sun.selfID == Star.IS_TRINARY) tide = Satellite.TIDE_TRINARYSTAR;
                    if (sun.selfID == Star.IS_SECCOMP) tide = Satellite.TIDE_SECCOMPSTAR;
                    if (sun.selfID == Star.IS_TRICOMP) tide = Satellite.TIDE_TRICOMPSTAR;

                    s.tideForce.Add(tide, temp);
                }

                if (s.majorMoons.Count > 0)
                {
                    foreach (Satellite moon in s.majorMoons)
                    {

                        double lunarTides = 0.0;
                        double different = 0;

                        moon.genGenericName(s.name, ourSystem.sysName);
                        //establish physical properties
                        moon.genWorldType(ourSystem.maxMass, ourSystem.sysAge, velvetBag);
                        if (s.baseType == Satellite.BASETYPE_GASGIANT)
                        {
                            //first, differentation test.
                            double dFactor = moon.getDifferentationFactor(s.mass, velvetBag);
                            if (dFactor > 100)
                            {
                                if (moon.SatelliteType == Satellite.SUBTYPE_ICE) moon.updateType(Satellite.SUBTYPE_SULFUR);
                                different = -.15;
                            }
                            if (dFactor > 80 && dFactor <= 100)
                            {
                                if (moon.SatelliteType == Satellite.SUBTYPE_ICE) moon.updateType(Satellite.SUBTYPE_SULFUR);
                                different = -.1;
                            }
                            if (dFactor > 50 && dFactor <= 80)
                            {
                                different = -.05;
                                moon.updateDescListing(Satellite.DESC_SUBSURFOCEAN);
                            }
                            if (dFactor > 30 && dFactor <= 50)
                            {
                                moon.updateDescListing(Satellite.DESC_SUBSURFOCEAN);
                            }
                        }

                        moon.genDensity(velvetBag);
                        moon.genDiameter(velvetBag);
                        moon.setClimateData(ourSystem.maxMass, velvetBag);
                        moon.detSurfaceTemp(different);
                        moon.calcAtmPres();

                        if (s.baseType == Satellite.BASETYPE_GASGIANT)
                        {
                            //radiation test
                            if (moon.atmPres > .2)
                            {
                                moon.updateDescListing(Satellite.DESC_RAD_HIGHBACK);
                            }
                            else
                            {
                                moon.updateDescListing(Satellite.DESC_RAD_LETHALBACK);
                            }
                        }

                        //orbital period
                        moon.generateOrbitalPeriod(s.mass);

                        //update parent. 
                        temp = (2230000 * moon.mass * s.diameter) / Math.Pow(moon.orbitalRadius, 3);
                        s.tideForce.Add((Satellite.TIDE_MOON_BASE + (moon.selfID + 1)), temp);

                        //moon tides
                        lunarTides = (2230000 * s.mass * moon.diameter) / Math.Pow(moon.orbitalRadius, 3);

                        lunarTides = (lunarTides * ourSystem.sysAge) / moon.mass;
                        moon.tideForce.Add(Satellite.TIDE_PARPLANET, lunarTides);
                        moon.tideTotal = moon.totalTidalForce(ourSystem.sysAge);

                        if (moon.tideTotal >= 50 && velvetBag.gurpsRoll() > 17)
                        {
                            moon.isResonant = true;
                        }
                        else if (moon.tideTotal >= 50)
                        {
                            moon.isTideLocked = true;
                        }

                        moon.generateOrbitalVelocity(velvetBag);
                        if (moon.isTideLocked && !moon.isResonant)
                        {
                            updateTidalLock(moon, velvetBag);
                        }
                        if (moon.isResonant)
                        {
                            moon.siderealPeriod = (moon.orbitalPeriod * 2.0 / 3.0);
                            moon.rotationalPeriod = moon.siderealPeriod;
                        }


                        if (velvetBag.gurpsRoll() >= 17)
                        {
                            moon.retrogradeMotion = true;
                        }

                        if (moon.orbitalPeriod == moon.siderealPeriod)
                            moon.rotationalPeriod = 0;

                        else //calculate solar day from sidereal
                        {
                            double sidereal;
                            if (moon.retrogradeMotion) sidereal = -1 * moon.siderealPeriod;
                            else sidereal = moon.siderealPeriod;

                            moon.rotationalPeriod = (s.orbitalPeriod * sidereal) / (s.orbitalPeriod - sidereal);
                            moon.orbitalCycle = (moon.orbitalPeriod * s.rotationalPeriod) / (moon.orbitalPeriod - s.rotationalPeriod);
                        }
                        moon.createAxialTilt(velvetBag);
                        determineGeologicValues(moon, velvetBag, ourSystem.sysAge, s.baseType == Satellite.BASETYPE_GASGIANT ? true : false);
                    }
                }

                //tides calculated already.
                s.tideTotal = s.totalTidalForce(ourSystem.sysAge);
                if (s.tideTotal >= 50 && s.orbitalEccent > .1)
                {
                    s.isResonant = true;
                }
                else if (s.tideTotal >= 50)
                {
                    s.isTideLocked = true;
                }

                s.generateOrbitalVelocity(velvetBag);

                if (s.isTideLocked && !s.isResonant)
                {
                    updateTidalLock(s, velvetBag);
                }
                if (s.isResonant)
                {
                    s.siderealPeriod = (s.orbitalPeriod * 2.0 / 3.0);
                    s.rotationalPeriod = s.siderealPeriod;
                }

                if (velvetBag.gurpsRoll() >= 13)
                {
                    s.retrogradeMotion = true;
                }
                if (s.orbitalPeriod == s.siderealPeriod)
                {
                    s.rotationalPeriod = 0;
                }

                else
                {
                    double sidereal;
                    if (s.retrogradeMotion) sidereal = -1 * s.siderealPeriod;
                    else sidereal = s.siderealPeriod;

                    s.rotationalPeriod = (s.orbitalPeriod * sidereal) / (s.orbitalPeriod - sidereal);
                }
                s.createAxialTilt(velvetBag);
                determineGeologicValues(s, velvetBag, ourSystem.sysAge, false);
            }
        }

        //describes the seperation flag. Used to describe it.
        public static String getSeperationStr(int orbitalSep)
        {
            if (orbitalSep == Star.ORBSEP_NONE) return "None";
            if (orbitalSep == Star.ORBSEP_CONTACT) return "Contact";
            if (orbitalSep == Star.ORBSEP_VERYCLOSE) return "Very Close";
            if (orbitalSep == Star.ORBSEP_CLOSE) return "Close";
            if (orbitalSep == Star.ORBSEP_MODERATE) return "Moderate";
            if (orbitalSep == Star.ORBSEP_DISTANT) return "Distant";
            if (orbitalSep == Star.ORBSEP_WIDE) return "Wide";

            return "ERROR";
        }


        public static double getSepModifier(int flag)
        {
            if (flag == Star.ORBSEP_NONE) return 0;
            if (flag == Star.ORBSEP_CONTACT) return 0.00001;
            if (flag == Star.ORBSEP_VERYCLOSE) return 0.05;
            if (flag == Star.ORBSEP_CLOSE) return 0.5;
            if (flag == Star.ORBSEP_MODERATE) return 2;
            if (flag == Star.ORBSEP_DISTANT) return 10;
            if (flag == Star.ORBSEP_WIDE) return 50;

            return -1;
        }

    }


}
