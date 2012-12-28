using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StarSystemGurpsGen
{
    class Program
    {
        static void Main(string[] args) 
        {
            var ourStars = new List<Star>();
            String sysName;
            Dice ourBag = new Dice(); //Yeah, I know. I could have just used a Random object (NextDouble), but..
            int numStars, roll;
            decimal sysAge, maxMass = 2.0m; 
            bool forceGarden = false, openCluster = false;

            Console.WriteLine("Welcome to the Space 4e GURPS Star System generator!");
            Console.WriteLine();

            //STEP 1 - Name
            Console.WriteLine("STEP 1: Generate a name and age for the system.");
            Console.Write("Please enter a name: ");
            sysName = Console.ReadLine();
            if (string.IsNullOrEmpty(sysName)) sysName = "DEFAULT";
            Console.WriteLine("The set name for the system is {0}",sysName);
            Console.WriteLine();

            //STEP 1 - Age
            Console.WriteLine("Generating age now. This is between 0 Gyr (brand new) to 13.7 Gyr (limit of the\n observable universe)");
            Console.WriteLine();
            sysAge = generateStellarAge(ourBag.probablity(10000), ourBag);
            sysAge = (decimal) Math.Round(sysAge, 2);
            Console.WriteLine("The age of the system is {0} Gyr.", sysAge);
            Console.ReadLine();

            
            //STEP 2: Some creation options.
            Console.WriteLine("Now, we need to answer some questions for options");
            Console.WriteLine();
            Console.WriteLine("For the next two questions any of the following: [yes,y,true,t] will answer true.");
            Console.WriteLine("You may just hit enter if you do not wish to enable them");
            Console.WriteLine("This will apply for any input this program asks you to do)");
            Console.WriteLine();
            Console.Write("Is this system located in an open cluster: ");
            openCluster = returnTrueOrFalse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Are you forcing optimal conditions for the creation of a garden world?: ");
            forceGarden = returnTrueOrFalse(Console.ReadLine());

            //Read back to the user the options.
            Console.WriteLine();
            Console.WriteLine("Option 1: Located in an Open Cluster? {0}", openCluster);
            Console.WriteLine("Option 2: Force optimal conditions for the creation of a garden world? {0}", forceGarden);
            Console.WriteLine();

            //Console.WriteLine("Initiating roll");
            //STEP 3 : Generate # of stars
            roll = ourBag.gurpsRoll() - 1;
            if (openCluster) roll = roll + 3;
            numStars = (int) Math.Floor(roll / 5.0);
            if (numStars == 0) numStars = 1; //trap a logic bug that prevented some rolls from generating 0 stars.

            if (numStars > 1) Console.WriteLine("This system has {0} stars.", numStars);
            else Console.WriteLine("This system has {0} star.", numStars);

            for (int i = 0; i < numStars; i++){
                //if it's the primary star, add it now.
                if (i == 0) ourStars.Add(new Star(sysAge, Star.IS_PRIMARY, i,Star.IS_PRIMARY,sysName));
                else{
                    ourStars.Add(new Star(sysAge, 0, i));
                    if (i == 1) ourStars[i].addOrder(Star.IS_SECONDARY);
                    if (i == 2) ourStars[i].addOrder(Star.IS_TRINARY);
                    ourStars[i].genGenericName(sysName);
                    ourStars[i].parentName = ourStars[0].name;
                }
                //generate the actual star, and if it's the primary, set the new maximum mass possible
                ourStars[i] = generateAStar(ourStars[i], ourBag, maxMass,forceGarden);
                if (i == 0){ maxMass = ourStars[i].initMass;  }
            }

            Console.WriteLine("CALCULATING ORBITALS");
            Console.WriteLine();
            //STEP 4 Generate orbital radii for the stars. We only do this if we generate 2 or more stars
            if (numStars > 1){

                //set the min and max conditions for the first star here.
                decimal minOrbitalDistance = 0.0m;
                decimal maxOrbitalDistance = 600.0m;
                decimal tempVal = 0.0m;

                for (int i = 1; i < numStars; i++){
                    int modifiers = 0;
                    minOrbitalDistance = ourStars[i - 1].orbitalRadius;
                                     
                    //is not a subcompanion.
                    Console.WriteLine("Generating orbital details for star {0}.", (i + 1));
                    if (ourStars[i].parentID == 0 || ourStars[i].parentID == Star.IS_PRIMARY){
                        //apply modifiers
                        if (ourStars[i].selfID == 2) modifiers = modifiers + 6;
                        if (forceGarden && ourStars[i].parentID != 1) modifiers = modifiers + 4;

                        if (minOrbitalDistance == 600.0m) {
                            //in this situation, orbital 3 or so can't be safely placed because the range is 0. 
                            // so we autogenerate it.
                            Console.WriteLine("Auto generating radius. It's beyond the minimum. This is for star {0}", (i + 1));
                            tempVal = ourBag.rollRange(25, 25);
                            ourStars[i].orbitalSep = 5;
                            ourStars[i - 1].orbitalRadius = ourStars[i - 1].orbitalRadius - tempVal;
                            ourStars[i].orbitalRadius = 600m + tempVal;
                            minOrbitalDistance = ourStars[i].orbitalRadius;
                        }
                        else  {
                            do  {
                                decimal lowerBound = 0.0m;
                                decimal higherBound = 0.0m;
                                //roll the dice

                                roll = ourBag.gurpsRoll(modifiers);
                                if (roll <= 6) ourStars[i].orbitalSep = 1;
                                if (roll >= 7 && roll <= 9) ourStars[i].orbitalSep = 2;
                                if (roll >= 10 && roll <= 11) ourStars[i].orbitalSep = 3;
                                if (roll >= 12 && roll <= 14) ourStars[i].orbitalSep = 4;
                                if (roll >= 15) ourStars[i].orbitalSep = 5;

                                //generate the orbital radius
                                do
                                {
                                    tempVal = ourBag.six(2) * ourStars[i].getSepModifier();
                                } while (tempVal <= minOrbitalDistance);

                                //if (ourStars[i].selfID == 2) tempVal = ourBag.six(1, 7) * ourStars[i].getSepModifier(); 
                                lowerBound = tempVal - .5m * ourStars[i].getSepModifier() ;
                                higherBound = .5m * ourStars[i].getSepModifier() + tempVal;


                                //set for constraints
                                if (lowerBound < minOrbitalDistance) lowerBound = minOrbitalDistance;
                                if (higherBound > maxOrbitalDistance) higherBound = maxOrbitalDistance;
                                                                

                                tempVal = getVariableFromInput("orbital radius", "AU", "" + ourStars[i].getSepModifier() + " AU", tempVal, lowerBound, higherBound);

                                ourStars[i].orbitalRadius = tempVal;
                            } while (ourStars[i].orbitalRadius <= minOrbitalDistance || ourStars[i].orbitalRadius > maxOrbitalDistance);

                            //let's see if it has a subcompanion
                            if (ourStars[i].orbitalSep == 5)   {
                                roll = ourBag.gurpsRoll();
                                if (roll >= 11)    {

                                    //generate the subcompanion
                                    Console.WriteLine("Star {0} has a subcompanion!", (i + 1));
                                    ourStars.Add(new Star(sysAge, i, numStars));
                                    ourStars[numStars].genGenericName(sysName);
                                    if (i == 1) ourStars[numStars].addOrder(Star.IS_SECCOMP);
                                    if (i == 2) ourStars[numStars].addOrder(Star.IS_TRICOMP);
                                    //set the name, then generate the star
                                    if (i == 1) ourStars[numStars].parentName = ourStars[i].name;
                                    ourStars[numStars] = generateAStar(ourStars[numStars], ourBag, ourStars[i].mass, false);
                                    numStars++; //increment the total number of stars we have generated
                                }

                            }
                        }
                    }
                    else  {
                        minOrbitalDistance = 0m;
                        maxOrbitalDistance = ourStars[ourStars[i].parentID].orbitalRadius;
                        //roll for seperation
                        do {
                            decimal lowerBound = 0.0m;
                            decimal higherBound = 0.0m;
                            //roll the dice

                            roll = ourBag.gurpsRoll(-6);
                            if (roll <= 6) ourStars[i].orbitalSep = 1;
                            if (roll >= 7 && roll <= 9) ourStars[i].orbitalSep = 2;
                            if (roll >= 10 && roll <= 11) ourStars[i].orbitalSep = 3;
                            if (roll >= 12 && roll <= 14) ourStars[i].orbitalSep = 4;
                            if (roll >= 15) ourStars[i].orbitalSep = 5;

                            //set the subcompanion orbital
                            tempVal = ourBag.six(2) * ourStars[i].getSepModifier();
                            lowerBound = tempVal - .5m * ourStars[i].getSepModifier();
                            higherBound = .5m * ourStars[i].getSepModifier() + tempVal;

                            if (higherBound > maxOrbitalDistance) higherBound = maxOrbitalDistance;

                            tempVal = getVariableFromInput("orbital radius", "AU", "" + ourStars[i].getSepModifier() + " AU", tempVal, lowerBound, higherBound);

                            ourStars[i].orbitalRadius = tempVal;

                        } while (ourStars[i].orbitalRadius > maxOrbitalDistance);
                    }

                    modifiers = 0; //reset the thing.
                    //now we generate eccentricities
                    if (ourStars[i].orbitalSep == 1) modifiers = modifiers - 10; //Very Close
                    if (ourStars[i].orbitalSep == 2) modifiers = modifiers - 6; //Close
                    if (ourStars[i].orbitalSep == 3) modifiers = modifiers - 2; //Moderate  

                    roll = ourBag.gurpsRoll(modifiers);
                    if (roll <= 3) ourStars[i].orbitalEccent = 0;
                    if (roll == 4) ourStars[i].orbitalEccent = .1m;
                    if (roll == 5) ourStars[i].orbitalEccent = .2m;
                    if (roll == 6) ourStars[i].orbitalEccent = .3m;
                    if (roll == 7 || roll == 8) ourStars[i].orbitalEccent = .4m;
                    if (roll >= 9 && roll <= 11) ourStars[i].orbitalEccent = .5m;
                    if (roll == 12 || roll == 13) ourStars[i].orbitalEccent = .6m;
                    if (roll == 14 || roll == 15) ourStars[i].orbitalEccent = .7m;
                    if (roll == 16) ourStars[i].orbitalEccent = .8m;
                    if (roll == 17) ourStars[i].orbitalEccent = .9m;
                    if (roll >= 18) ourStars[i].orbitalEccent = .95m;


                }
            }

            //STEP 5 - Start placing orbitals.
            decimal currentOrbital, tmpVal;

            //Step 5a - First: get orbital zone data
            var systemZones = new List<OrbitalZones>();


            bool conGGOK, eccGGOK, epiGGOK; //gas giant checks
            for (int i = 0; i < numStars; i++){
                systemZones.Add(new OrbitalZones(i));
                if (numStars > 1){
                    for (int j = 1; j < numStars; j++){
                        //get forbidden zones
                        if (ourStars[j].parentID == i){
                            //Console.WriteLine("Adding a forbidden zone to {0} as primary", (i + 1));
                            //Console.WriteLine();
                            //Console.WriteLine("ADDING FORBIDDEN ZONE from {0},{1} to star {2}", ourStars[j].getInnerForbiddenZone(),
                                ourStars[j].getOuterForbiddenZone(), (i + 1));
                            systemZones[i].forZones.Add(new OrbitalPair(ourStars[j].getInnerForbiddenZone(),
                                ourStars[j].getOuterForbiddenZone(), true, j, OrbitalPair.IS_FORBIDDEN));
                        }
                        if (ourStars[j].selfID == i){
                            //Console.WriteLine("Adding a forbidden zone to {0} as secondary", (i + 1));
                            //Console.WriteLine();
                           // Console.WriteLine("ADDING FORBIDDEN ZONE from {0},{1} to star {2}", ourStars[j].getInnerForbiddenZone(),
                                ourStars[j].getOuterForbiddenZone(), (i + 1));
                            systemZones[i].forZones.Add(new OrbitalPair(ourStars[j].getInnerForbiddenZone(),
                                ourStars[j].getOuterForbiddenZone(), false, ourStars[j].parentID, OrbitalPair.IS_FORBIDDEN));
                        }
                    }
                }
                systemZones[i].sortForbiddenZones();
                systemZones[i].initalizeCleanZones(ourStars[i].innerRadius(), ourStars[i].outerRadius(),numStars);
                systemZones[i].sortCleanZones();
                systemZones[i].setMaxMin();

                Console.WriteLine("Printing system Zones");
                foreach (OrbitalZones o in systemZones){
                    Console.WriteLine(o);
                }
                Console.WriteLine();
                Console.ReadLine();
                //Step 5B - See if you can roll for each gas giant.   
                

               //set these because we're starting the star gen again.
                conGGOK = false;
                eccGGOK = false;
                epiGGOK = false;

                currentOrbital = ourStars[i].innerRadius();

                Console.WriteLine("Formation zone result: {0}", systemZones[i].noValidFormationZone);
                //now, start generting orbits.
                if (!systemZones[i].noValidFormationZone){

                    Console.WriteLine("There are viable formation zones for star {0}", (i+ 1));
                    // get our formation zone data
                
                    //check the ranges for every gas giant object
                    if (!(systemZones[i].checkRange(ourStars[i].snowLine() * 1m,
                        ourStars[i].snowLine() * 1.5m, numStars) == OrbitalZones.NOGOODORBITS)){
                        //Console.WriteLine("CONVENTIONAL OK");
                        conGGOK = true; //if it's not NOGOODORBITS, it's Ok to generate for this range
                    }

                    if (!(systemZones[i].checkRange(ourStars[i].snowLine() * .125m,
                        ourStars[i].snowLine() * .75m, numStars) == OrbitalZones.NOGOODORBITS)){
                        //Console.WriteLine("ECCENTRIC OK");
                        eccGGOK = true; //OK to generate for this range.
                    }
                   //trigger the epistellar check.
                    if (!(systemZones[i].checkRange(ourStars[i].innerRadius() * .3m,
                        ourStars[i].innerRadius() * 1.8m,numStars, true) == OrbitalZones.NOGOODORBITS)){
                        //Console.WriteLine("EPISTELLAR OK");
                        epiGGOK = true;
                    }
                    //we did this so we don't try to roll something that has no chance of placing valid orbits.
                    roll = ourBag.gurpsRoll(); //let's get the gas giant type.
                    Console.WriteLine("Dice roll is {0}", roll);
                    if ((roll >= 8 && roll <= 11) && (conGGOK)) ourStars[i].gasGiantFlag = 1;
                    if ((roll == 12 || roll == 13) && (eccGGOK)) ourStars[i].gasGiantFlag = 2;
                    if ((roll >= 14) && (epiGGOK)) ourStars[i].gasGiantFlag = 3;
                    Console.WriteLine("Gas giant flag is {0}", ourStars[i].gasGiantFlag);

                    //... we've already set it. (0). Do no overrides.

                    if (ourStars[i].gasGiantFlag == 1){      //generate orbit of a conventional gas giant!
                        do{
                           tmpVal = ourStars[i].snowLine() * (1 + (ourBag.six(2, -2) * .05m));
                        } while (!systemZones[i].checkOrbit(tmpVal));

                        currentOrbital = tmpVal;

                        //and now we place our first orbital. The current planet actually doesn't matter
                        // as we will overwrite it later, once we sort them all. (We simply don't know
                        //  where this will end up.)
                        ourStars[i].addSatelite(
                            new Satelite(i, 0, tmpVal, Satelite.CONTENT_GASGIANT));

                    }

                    if (ourStars[i].gasGiantFlag == 2){ //eccentric gas giant
                         do{
                            tmpVal = ourStars[i].snowLine() * (ourBag.six() * .125m);
                         } while (!systemZones[i].checkOrbit(tmpVal));

                         currentOrbital = tmpVal;
                         ourStars[i].addSatelite(new Satelite(i, 0, tmpVal, Satelite.CONTENT_GASGIANT));
                    }

                    if (ourStars[i].gasGiantFlag == 3){ //generate epistellar gas giant
                         do{
                           tmpVal = ourStars[i].innerRadius() * (ourBag.gurpsRoll() * .1m);
                         } while (!systemZones[i].checkOrbit(tmpVal, true));

                         currentOrbital = tmpVal;
                         ourStars[i].addSatelite(new Satelite(i, 0, tmpVal, Satelite.CONTENT_GASGIANT));
                    }

                    Console.WriteLine("Current Orbital is {0}", currentOrbital);
                    //Step 5C: Place orbits. Left, then right. 
                    //if there is no gas giant

                    if (ourStars[i].gasGiantFlag == 0){
                        bool orbitCheck = false;
                        
                        orbitCheck = systemZones[i].checkOrbit(currentOrbital);

                        if (orbitCheck){
                            Console.WriteLine("Adding orbital (outside loop): {0}", currentOrbital);
                            ourStars[i].addSatelite(new Orbital(i, 0, currentOrbital));
                        }
                    }
                    decimal placeHolder = currentOrbital;
                    
                    do{
                        currentOrbital = systemZones[i].getNextOrbit(currentOrbital, OrbitalZones.DIR_LEFT, ourBag);
                        if (currentOrbital != OrbitalZones.ENDOFORBITAL){
                            Console.WriteLine("Adding orbital: {0}", currentOrbital);
                            ourStars[i].addSatelite(new Orbital(i, 0, currentOrbital));
                        }
                    } while (currentOrbital != OrbitalZones.ENDOFORBITAL);

                    currentOrbital = placeHolder;
                    //now we go right.
                    do{
                        currentOrbital = systemZones[i].getNextOrbit(currentOrbital, OrbitalZones.DIR_RIGHT, ourBag);
                        if (currentOrbital != OrbitalZones.ENDOFORBITAL){
                           // Console.WriteLine("Adding orbital: {0}", currentOrbital);
                            ourStars[i].addSatelite(new Orbital(i, 0, currentOrbital));
                        }
                    } while (currentOrbital != OrbitalZones.ENDOFORBITAL);

                   //orbits filled. Sort them.
                   ourStars[i].printAllOrbitals();
                   ourStars[i].sortOrbitals(); //sort them into order (ascending)
                   if (ourStars[i].determineStatus() > 3) ourStars[i].purgeSwallowedOrbits();
                   ourStars[i].printAllOrbitals();

                   var sysContents = ourStars[i].ourOrbitals; 
                   decimal snowLine = ourStars[i].snowLine(); // get the snow line

                   //Step 5D: now let's start assigning contents. First: Gas giants
                   for (int k = 0; k < sysContents.Count; k++){
                        bool isSatelite = sysContents[k].GetType() == typeof(Satelite);
                        roll = ourBag.gurpsRoll(); //roll the dice!
                        if (!isSatelite){
                           if (ourStars[i].gasGiantFlag == 1){
                                if (roll <= 15 && sysContents[k].orbitalRadius >= snowLine)
                                    sysContents[k] = new Satelite(sysContents[k].parentID, sysContents[k].selfID
                                        , sysContents[k].orbitalRadius, Satelite.CONTENT_GASGIANT);
                           }

                           if (ourStars[i].gasGiantFlag == 2){
                                if (roll <= 8 && sysContents[k].orbitalRadius < snowLine)
                                   sysContents[k] = new Satelite(sysContents[k].parentID, sysContents[k].selfID
                                   , sysContents[i].orbitalRadius, Satelite.CONTENT_GASGIANT);
                                if (roll <= 14 && sysContents[k].orbitalRadius >= snowLine)
                                   sysContents[k] = new Satelite(sysContents[k].parentID, sysContents[k].selfID
                                  , sysContents[k].orbitalRadius, Satelite.CONTENT_GASGIANT);
                           }
                           if (ourStars[i].gasGiantFlag == 3){
                                if (roll <= 6 && sysContents[k].orbitalRadius < snowLine)
                                   sysContents[k] = new Satelite(sysContents[k].parentID, sysContents[k].selfID
                                   , sysContents[i].orbitalRadius, Satelite.CONTENT_GASGIANT);
                                if (roll <= 14 && sysContents[k].orbitalRadius >= snowLine)
                                   sysContents[k] = new Satelite(sysContents[k].parentID, sysContents[k].selfID
                                   , sysContents[k].orbitalRadius, Satelite.CONTENT_GASGIANT);
                                }
                            }
                    }

                    //Step 5E: Fill in the rest of the conents.
                   for (int j = 0; j < sysContents.Count; j++)
                   {
                       //iterate time.
                       bool isSatelite = sysContents[j].GetType() == typeof(Satelite);
                       roll = ourBag.gurpsRoll(); //roll the dice!

                       Console.WriteLine(sysContents[j]);
                       if (sysContents[j] is Satelite)
                       {
                         //  Console.WriteLine("Occupied Orbit at {0} AU", sysContents[j].orbitalRadius);
                         //  Console.ReadLine();
                           Satelite s = (Satelite)sysContents[j];
                           if (s.sateliteType == Satelite.CONTENT_GASGIANT)
                           {
                               if (s.orbitalRadius < ourStars[i].snowLine()) roll = roll + 4;
                               if (j > 0)
                               {
                                   if (sysContents[j - 1].orbitalRadius < ourStars[i].snowLine() &&
                                       s.orbitalRadius >= ourStars[i].snowLine())
                                       roll = roll + 4;
                               }
                               if (roll <= 10) s.sateliteSize = Satelite.SIZE_SMALL;
                               if (roll >= 11 && roll <= 16) s.sateliteSize = Satelite.SIZE_STANDARD;
                               if (roll >= 17) s.sateliteSize = Satelite.SIZE_LARGE;
                           }
                       }

                       if (sysContents[j] is Orbital && !(sysContents[j] is Satelite))
                       {

                         //  Console.WriteLine("Empty Orbit at {0} AU", sysContents[j].orbitalRadius);
                         //  Console.ReadLine();
                         //  Console.WriteLine("Dice roll [PRE-MODS] is {0}", roll);
                        //   Console.WriteLine();
                           //empty orbitals. Let's start setting them.
                           if (systemZones[i].adjForbiddenZone(sysContents[j].orbitalRadius))
                           {
                               roll = roll - 6;
                             //  Console.WriteLine("Next to a forbidden zone");
                           }
                           if (systemZones[i].adjRadius(sysContents[j].orbitalRadius) && (j == 0 || j == (sysContents.Count - 1)))
                           {
                             //  Console.WriteLine("Next to a radius");
                               roll = roll - 3;
                           }

                           if ((j > 0 && sysContents[j - 1] is Satelite) 
                               && (((Satelite)sysContents[j-1]).sateliteType == Satelite.CONTENT_GASGIANT))
                           {
                              // Console.WriteLine("Gas Giant to the left");
                               if (((Satelite)sysContents[j - 1]).sateliteType == Satelite.CONTENT_GASGIANT)
                                   roll = roll - 3;
                           }

                           if (j + 1 < sysContents.Count && sysContents[j + 1] is Satelite)
                           {
                             //  Console.WriteLine("Gas Giant to the right");
                               if (((Satelite)sysContents[j + 1]).sateliteType == Satelite.CONTENT_GASGIANT)
                                   roll = roll - 6;
                           }

                         //  Console.WriteLine("Dice roll [POST-MODS] is {0}", roll);
                          // Console.WriteLine();
                           //we do no change if it's 3 or less (empty)
                           if (roll >= 4 && roll <= 6)
                               sysContents[j] = new AsteroidBelt(sysContents[j].parentID, sysContents[j].selfID,
                                   sysContents[j].orbitalRadius);

                           if (roll == 7 && roll == 8)
                           {
                               sysContents[j] = new Satelite(sysContents[j].parentID, sysContents[j].selfID,
                                   sysContents[j].orbitalRadius, Satelite.CONTENT_TERRESTIAL);
                               ((Satelite)sysContents[j]).sateliteSize = Satelite.SIZE_TINY;
                           }
                           if (roll >= 9 && roll <= 11)
                           {
                               sysContents[j] = new Satelite(sysContents[j].parentID, sysContents[j].selfID,
                                   sysContents[j].orbitalRadius, Satelite.CONTENT_TERRESTIAL);
                               ((Satelite)sysContents[j]).sateliteSize = Satelite.SIZE_SMALL;
                           }
                           if (roll >= 12 && roll <= 15)
                           {
                               sysContents[j] = new Satelite(sysContents[j].parentID, sysContents[j].selfID,
                                   sysContents[j].orbitalRadius, Satelite.CONTENT_TERRESTIAL);
                               ((Satelite)sysContents[j]).sateliteSize = Satelite.SIZE_STANDARD;
                           }
                           if (roll >= 16)
                           {
                               sysContents[j] = new Satelite(sysContents[j].parentID, sysContents[j].selfID,
                                   sysContents[j].orbitalRadius, Satelite.CONTENT_TERRESTIAL);
                               ((Satelite)sysContents[j]).sateliteSize = Satelite.SIZE_LARGE;
                           }
                       }
                   }
                    //Console.ReadLine();
                    ourStars[i].ourOrbitals = sysContents; // reassign this back to the object block
                }    // end many-star fill block.

            }



            //output testing.
            for (int i = 0; i < numStars; i++){
                Console.WriteLine(ourStars[i]);
                Console.WriteLine();
                ourStars[i].printAllOrbitals();
            }

        Console.ReadLine();
 
        }



        // Generates a star. It's used seperatly because this may be called again.
        static Star generateAStar(Star tempStar, Dice ourDice, decimal maxMass, bool forceGarden)
        {
            int NUMPLACESLUM = 5; //This saves me time.
            int roll;
    	    decimal mass = 0.0m, tmpDbl = 0.0m;
            String inputStr;
            bool autoValGen = false; //used if the user wishes to automatically generate values.

   
        	do {
        	    int rollA = ourDice.gurpsRoll();
        	    int rollB = ourDice.gurpsRoll();

                if (forceGarden)
                {
                    rollA = ourDice.six();
                    if (rollA == 1) rollA = 5;
                    if (rollA == 2) rollA = 6;
                    if (rollA == 3 || rollA == 4) rollA = 7;
                    if (rollA == 5 || rollA == 6) rollA = 8;
                }

    		    tempStar.updateMass(stellarMass(rollA, rollB)); //set the mass
                tempStar.setInitMass(mass);
    		    mass = tempStar.mass;
    	    } while (mass >= maxMass);
    	
    	    Console.WriteLine(""); //new line for output sapcing
            Console.WriteLine("We are on star {0}. The generated name is {1}", (tempStar.selfID + 1), (tempStar.name));
    	    Console.Write("Do you wish to enter a new name?: ");
            inputStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputStr)){
                tempStar.name = inputStr;
            }
            Console.WriteLine();
            Console.WriteLine("The new name of the star is {0}", tempStar.name);

           	Console.WriteLine(); //space out for input.

            Console.WriteLine("If you wish no active input (autogenerate all variables excluding mass)");
            Console.Write("Type in your answer here: ");
            
            inputStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputStr)){
                inputStr.ToLower(new CultureInfo("en-US", false));
                if (inputStr == "t" || inputStr == "true" || inputStr == "y" || inputStr == "yes"){
                    autoValGen = true;
                }
            }
            
    	    //allow for user input into mass.
            String allowedVariance = ".1 to " + maxMass;

            tempStar.updateMass(getVariableFromInput("mass", "solar masses", allowedVariance, mass, .1m, maxMass));
            mass = tempStar.mass;
            tempStar.setInitMass(mass);
            maxMass = mass;

    	    //CASE 1: MASS is between .1 and .45 solar masses
            if (mass >= .1m && mass < .45m){
                //see if it's a flare star.
                roll = ourDice.gurpsRoll();
                if (roll >= 12) tempStar.isFlareStar = true;

                tempStar.specType = getStellarTypeFromMass(mass); //get the spectral type
                
                //Get the temperature and query user about changes
                tempStar.setTemperature();
                tmpDbl = tempStar.effTemp;
                if (!autoValGen) 
                     tempStar.effTemp = getVariableFromInput("effective temperature", "K", "100K", tmpDbl, (tmpDbl - 100m), (tmpDbl + 100m));

                //Set luminosity and query user about changes
                tempStar.setLumin();
               // Console.WriteLine("Status is {0} and minLum is {1}", tempStar.determineStatus(), tempStar.getMinLumin());
                tmpDbl = Math.Round(tempStar.currLumin,NUMPLACESLUM);

                if (!autoValGen){
                    Console.WriteLine("Warning: This will also reset the initial luminosity of the star.");
                    tmpDbl = getVariableFromInput("current luminosity", "solar luminosities", "10%", tmpDbl, Math.Round(tmpDbl * .9m, NUMPLACESLUM),
                        Math.Round(tmpDbl * 1.1m, NUMPLACESLUM));
                }
                //in the case of status 0 stars, the current luminosity IS the initial luminosity. (Set from user input)
                // However, the star object handles what needs to be updated.
                tempStar.updateLumin(tmpDbl);
                
                //we have no clue what the actual lifespan is.
                tempStar.mainLimit = 1300.0m; // also used to tell the object this should be status 0.
                tempStar.totalLifeSpanUp(); //update the list
            }
    	
    	    if (mass >= .45m && mass <.95m){
    		    //see if it's a flare star.
    		    if (mass <= .525m){
                    roll = ourDice.gurpsRoll();
                    if (roll >= 12) tempStar.isFlareStar = true;
    		    }
    		    //The luminosity type can be auto determined. No point in doing it here, really.
    		
    		    //now that we've done that, we set the SPECTRAL type, and status. 
    		    tempStar.specType = getStellarTypeFromMass(mass);
    			tempStar.setMainLimit(); //required before we attempt to set luminosity (because this also sets status, now)
    		
    		    //now we set luminosity! :D (Unlike in under .45 masses, inital luminosity is locked.)
    		    tempStar.setLumin();
                //Console.WriteLine("Status is {0} and minLum is {1}", tempStar.determineStatus(), tempStar.getMinLumin());
                tmpDbl = Math.Round(tempStar.currLumin,NUMPLACESLUM);
                if (!autoValGen) 
                    tmpDbl = getVariableFromInput("current luminosity", "solar luminosities", "10%", tmpDbl, Math.Round(tmpDbl * .9m,NUMPLACESLUM),
                    Math.Round(tmpDbl * 1.1m, NUMPLACESLUM));
                tempStar.updateLumin(tmpDbl);
    		
    		    //set temperature.
    		    tempStar.setTemperature();
    		    tmpDbl = tempStar.effTemp;
                if (!autoValGen) 
                     tempStar.effTemp = getVariableFromInput("effective temperature","K","100K",tmpDbl, (tmpDbl-100m),(tmpDbl+100m));
                tempStar.totalLifeSpanUp();
    	    }
    	
    	    if (mass >= .95m && mass <= 2m){
    		    //Now we can generate with all fields
    		
    		    //set limits for all age fields
    		    tempStar.setMainLimit();
    		    tempStar.setSubLimit();
    		    tempStar.setGiantLimit();
    		    tempStar.totalLifeSpanUp(); //when we actually have all three, we can just total them up. Like sane people.
    		    		    
    		    if (tempStar.determineStatus() == 1){
    			    //process as if they're 
        		    tempStar.specType = getStellarTypeFromMass(mass);
        		        		
        		    //now we set luminosity! :D
        		    tempStar.setLumin();
                    //Console.WriteLine("Status is {0} and minLum is {1}", tempStar.determineStatus(), tempStar.getMinLumin());
                    tmpDbl = Math.Round(tempStar.currLumin,NUMPLACESLUM);
                    if (!autoValGen) 
                        tmpDbl = getVariableFromInput("current luminosity", "solar luminosities", "10%", tmpDbl, Math.Round(tmpDbl * .9m, NUMPLACESLUM),
                        Math.Round(tmpDbl * 1.1m, NUMPLACESLUM));
        		    tempStar.updateLumin(tmpDbl);
        		
        		    //set temperature.
        		    tempStar.setTemperature();
        		    tmpDbl = tempStar.effTemp;
                    if (!autoValGen) 
                     tempStar.effTemp = getVariableFromInput("effective temperature","K","100K",tmpDbl, (tmpDbl-100m),(tmpDbl+100m));
        	    }
    		
                //subgiant status
    		    if (tempStar.determineStatus() == 2){
    			    tempStar.setLumin(); //autogenerate luminosity
                    //Console.WriteLine("Status is {0} and minLum is {1}", tempStar.determineStatus(), tempStar.getMinLumin());
                    tmpDbl = Math.Round(tempStar.currLumin,NUMPLACESLUM); //for a subgiant stage, current luminosity is = max luminosity
                    if (!autoValGen) 
                     tmpDbl = getVariableFromInput("current luminosity", "solar luminosities", "10%", tmpDbl, Math.Round(tmpDbl * .9m, NUMPLACESLUM),
                        Math.Round(tmpDbl * 1.1m, NUMPLACESLUM));
        		    tempStar.updateLumin(tmpDbl);
        	
        		    //set temperature and then get the stellar type
        		    tempStar.setTemperature(); //First step, read from table
        		    tmpDbl = (tempStar.effTemp - (tempStar.age - tempStar.mainLimit) * (tempStar.effTemp - 4800));

                    if (!autoValGen) 
                     tempStar.effTemp = getVariableFromInput("effective temperature","K","100K",tmpDbl, (tmpDbl-100m),(tmpDbl+100m));
       		        tempStar.specType = getStellarTypeFromTemp(tmpDbl);
        	    }
    		
                //giant stage
    		    if (tempStar.determineStatus() == 3){
    			    tempStar.setLumin(); //autogenerate luminosity
                   // Console.WriteLine("Status is {0} and minLum is {1}", tempStar.determineStatus(), tempStar.getMinLumin());
                    tmpDbl = Math.Round(tempStar.currLumin,NUMPLACESLUM);
                    if (!autoValGen) 
                        tmpDbl = getVariableFromInput("current luminosity", "solar luminosities", "10%", tmpDbl, Math.Round(tmpDbl * .9m, NUMPLACESLUM),
                        Math.Round(tmpDbl * 1.1m, NUMPLACESLUM));
        		    tempStar.updateLumin(tmpDbl);
        		
        		    //set temperature and get spectral type
        		    tmpDbl = 3000 + (ourDice.six(2,-2)* 200);
        		    tempStar.effTemp = tmpDbl;
        		    tempStar.specType = getStellarTypeFromTemp(tmpDbl);
    		    }   
    		
                //White dwarf stage
    		    if (tempStar.determineStatus() == 4){
                    Console.WriteLine("Star {0} is a White Dwarf. All variables are auto assigned.", (tempStar.selfID + 1));
    			    //white dwarves are a bit of a special case.
    			    tempStar.specType = "DC";
    			
    			    tempStar.setLumin(); //autogenerate luminosity
                   // Console.WriteLine("Status is {0} and minLum is {1}", tempStar.determineStatus(), tempStar.getMinLumin());
    			    tmpDbl = .9m + (ourDice.six(2,-2)*.05m);
    			
    			    //reset to accommodate for the fact it's a dead star now. :/
    			    tempStar.updateMass(tmpDbl);
    			    tempStar.updateLumin(.00003m*ourDice.six());
    			
                    //not that accurate, not that wrong though..
    			    decimal whiteDwarfSpan = tempStar.age  - tempStar.mainLimit;
                    if (whiteDwarfSpan < 1.0m) tempStar.effTemp = 10000m;
        		    if (1.0m <= whiteDwarfSpan && whiteDwarfSpan < 2.5m) tempStar.effTemp = 5000m;
        		    if (whiteDwarfSpan >= 2.5m) tempStar.effTemp = 3796m;
        		
    		}
    		
    	}
    	
    	
    	tempStar.setRadius(); //before we leave, set the radius

    	return tempStar;
        }

        static decimal generateStellarAge(int roll, Dice ourBag)
        {
            //roll is 0-10000.
            if (roll < 46) return 0.0m;      
            if (roll >= 46 && roll < 926)     return ourBag.rollRange(0.1m, 1.9m);
            if (roll >= 926 && roll < 9074)   return ourBag.rollRange(2m, 6m);
            if (roll >= 9074 && roll < 9954)  return ourBag.rollRange(8m, 2.75m);
            if (roll >= 9954) return ourBag.rollRange(10.75m, 2.95m);
            
            return 4.60m;
            
        }

      /*  static String getGenericName(String parentName, int bodyID, int parentID, int bodyType)
        {

            char[] starNames = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
            switch (bodyType)
            {
                case 1: return (parentName + "-" + starNames[bodyID]);
                case 2: return (parentName + toRoman(bodyID));
                case 3: return (parentName + "[" + bodyID + "]");
                default: return "Invalid Entity";
            }
        } */

        //CREDIT: StackOverflow Contributor Mosè Bottacini
        //LINK  : http://stackoverflow.com/questions/7040289/converting-integers-to-roman-numerals 

        static string toRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;            
            if (number >= 1000) return "M" + toRoman(number - 1000);
            if (number >= 900) return "CM" + toRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + toRoman(number - 500);
            if (number >= 400) return "CD" + toRoman(number - 400);
            if (number >= 100) return "C" + toRoman(number - 100);            
            if (number >= 90) return "XC" + toRoman(number - 90);
            if (number >= 50) return "L" + toRoman(number - 50);
            if (number >= 40) return "XL" + toRoman(number - 40);
            if (number >= 10) return "X" + toRoman(number - 10);
            if (number >= 9) return "IX" + toRoman(number - 9);
            if (number >= 5) return "V" + toRoman(number - 5);
            if (number >= 4) return "IV" + toRoman(number - 4);
            if (number >= 1) return "I" + toRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        private static String getStellarTypeFromMass(decimal mass)
        {
            if (mass <= .125m) return "M7";
            if (.125m < mass && mass <= .175m) return "M6";
            if (.175m < mass && mass <= .225m) return "M5";
            if (.225m < mass && mass <= .325m) return "M4";
            if (.325m < mass && mass <= .375m) return "M3";
            if (.375m < mass && mass <= .425m) return "M2";
            if (.425m < mass && mass <= .475m) return "M1";
            if (.475m < mass && mass <= .525m) return "M0";
            if (.525m < mass && mass <= .575m) return "K8";
            if (.575m < mass && mass <= .625m) return "K6";
            if (.625m < mass && mass <= .675m) return "K5";
            if (.675m < mass && mass <= .725m) return "K4";
            if (.725m < mass && mass <= .775m) return "K2";
            if (.775m < mass && mass <= .825m) return "K0";
            if (.825m < mass && mass <= .875m) return "G8";
            if (.875m < mass && mass <= .925m) return "G6";
            if (.925m < mass && mass <= .975m) return "G4";
            if (.975m < mass && mass <= 1.025m) return "G2";
            if (1.025m < mass && mass <= 1.075m) return "G1";
            if (1.075m < mass && mass <= 1.125m) return "G0";
            if (1.175m < mass && mass <= 1.225m) return "F9";
            if (1.175m < mass && mass <= 1.225m) return "F8";
            if (1.225m < mass && mass <= 1.275m) return "F7";
            if (1.275m < mass && mass <= 1.325m) return "F6";
            if (1.325m < mass && mass <= 1.375m) return "F5";
            if (1.375m < mass && mass <= 1.425m) return "F4";
            if (1.425m < mass && mass <= 1.475m) return "F3";
            if (1.475m < mass && mass <= 1.55m) return "F2";
            if (1.55m < mass && mass <= 1.65m) return "F0";
            if (1.65m < mass && mass <= 1.75m) return "A9";
            if (1.75m < mass && mass <= 1.85m) return "A7";
            if (1.85m < mass && mass <= 1.95m) return "A6";
            if (1.95m < mass && mass <= 2.0m) return "A5";

            return "X0";
        }

        private static String getStellarTypeFromTemp(decimal temp)
        {
            if (temp < 3150m) return "M7";
            if (3150m <= temp && temp < 3175m) return "M6";
            if (3175m <= temp && temp < 3250m) return "M5";
            if (3250m <= temp && temp < 3350m) return "M4";
            if (3350m <= temp && temp < 3450m) return "M3";
            if (3450m <= temp && temp < 3550m) return "M2";
            if (3550m <= temp && temp < 3700m) return "M1";
            if (3700m <= temp && temp < 3900m) return "M0";
            if (3900m <= temp && temp < 4100m) return "K8";
            if (4100m <= temp && temp < 4300m) return "K6";
            if (4300m <= temp && temp < 4500m) return "K5";
            if (4500m <= temp && temp < 4750m) return "K4";
            if (4750m <= temp && temp < 5050m) return "K2";
            if (5050m <= temp && temp < 5300m) return "K0";
            if (5300m <= temp && temp < 5450m) return "G8";
            if (5450m <= temp && temp < 5600m) return "G6";
            if (5600m <= temp && temp < 5750m) return "G4";
            if (5750m <= temp && temp < 5850m) return "G2";
            if (5850m <= temp && temp < 5950m) return "G1";
            if (5950m <= temp && temp < 6050m) return "G0";
            if (6050m <= temp && temp < 6150m) return "F9";
            if (6150m <= temp && temp < 6350m) return "F8";
            if (6350m <= temp && temp < 6450m) return "F7";
            if (6450m <= temp && temp < 6550m) return "F6";
            if (6550m <= temp && temp < 6650m) return "F5";
            if (6650m <= temp && temp < 6750m) return "F4";
            if (6750m <= temp && temp < 6950m) return "F3";
            if (6950m <= temp && temp < 7150m) return "F2";
            if (7150m <= temp && temp < 7400m) return "F0";
            if (7400m <= temp && temp < 7650m) return "A9";
            if (7650m <= temp && temp < 7900m) return "A7";
            if (7900m <= temp && temp < 8100m) return "A6";
            if (8100m <= temp && temp < 8300m) return "A5";

            return "X0";
        }

        private static decimal stellarMass(int rollA, int rollB)
        {
            //Console.WriteLine("The stellar mass rolls are " + rollA + " and " + rollB);
            //now we implement the table.

            //if we're forcing a garden world, the first roll is changed here.
            if (rollA == 3)
            {
                if (rollB >= 3 && rollB <= 10) return 2.0m;
                if (rollB >= 11 && rollB <= 18) return 1.9m;
                return 0.0m;
            }

            if (rollA == 4)
            {
                if (rollB >= 3 && rollB <= 8) return 1.8m;
                if (rollB >= 9 && rollB <= 11) return 1.7m;
                if (rollB >= 12 && rollB <= 18) return 1.6m;
                return 0.0m;
            }

            if (rollA == 5)
            {
                if (rollB >= 3 && rollB <= 7) return 1.5m;
                if (rollB >= 8 && rollB <= 10) return 1.45m;
                if (rollB >= 11 && rollB <= 12) return 1.4m;
                if (rollB >= 13 && rollB <= 18) return 1.35m;
                return 0.0m;
            }

            if (rollA == 6)
            {
                if (rollB >= 3 && rollB <= 7) return 1.3m;
                if (rollB >= 8 && rollB <= 9) return 1.25m;
                if (rollB == 10) return 1.2m;
                if (rollB >= 11 && rollB <= 12) return 1.15m;
                if (rollB >= 13 && rollB <= 18) return 1.1m;
                return 0.0m;
            }

            if (rollA == 7)
            {
                if (rollB >= 3 && rollB <= 7) return 1.05m;
                if (rollB >= 8 && rollB <= 9) return 1m;
                if (rollB == 10) return .95m;
                if (rollB >= 11 && rollB <= 12) return .9m;
                if (rollB >= 13 && rollB <= 18) return .85m;
                return 0.0m;
            }

            if (rollA == 8)
            {
                if (rollB >= 3 && rollB <= 7) return .8m;
                if (rollB >= 8 && rollB <= 9) return .75m;
                if (rollB == 10) return .7m;
                if (rollB >= 11 && rollB <= 12) return .65m;
                if (rollB >= 13 && rollB <= 18) return .6m;
                return 0.0m;
            }

            if (rollA == 9)
            {
                if (rollB >= 3 && rollB <= 8) return .55m;
                if (rollB >= 9 && rollB <= 11) return .5m;
                if (rollB >= 12 && rollB <= 18) return .45m;
                return 0.0m;
            }

            if (rollA == 10)
            {
                if (rollB >= 3 && rollB <= 8) return .4m;
                if (rollB >= 9 && rollB <= 11) return .35m;
                if (rollB >= 12 && rollB <= 18) return .3m;
                return 0.0m;

            }


            if (rollA == 11) return 0.25m;
            if (rollA == 12) return 0.20m;
            if (rollA == 13) return 0.15m;
            if (rollA >= 14) return 0.10m;
            return 0.0m;
        }

        public static decimal getVariableFromInput(String varName, String unit, String allowedVariance, decimal baseVal,
            decimal lowerBound, decimal upperBound){
            String inputStr;
            decimal tmpDbl = baseVal;
                     
            Console.WriteLine("The generated {0} for this star is {1} {2}.", varName,tmpDbl,unit);
            Console.WriteLine("The allowable range is [{0} to {1}] {2}.", lowerBound, upperBound, unit);
            Console.WriteLine("Variance is {0}", allowedVariance);

            do  {
                Console.Write("Please enter your new {0}: ", varName);
                inputStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputStr)){
                    if (!(Decimal.TryParse(inputStr, out tmpDbl))){
                        Console.WriteLine("Please enter a number.");
                    }
                }
            } while (!(tmpDbl >= (lowerBound) && tmpDbl <= (upperBound)));
            //clear space, output new value, clear space
            Console.WriteLine();
            Console.WriteLine("The new {0} is {1} {2}.", varName, tmpDbl, unit);
            Console.WriteLine();
            return tmpDbl;
        }

        public static bool returnTrueOrFalse(string test){
            if (!string.IsNullOrEmpty(test)){
                test = test.ToLower(new CultureInfo("en-US", false));
                if (test == "t" || test == "true" || test == "y" || test == "yes"){
                    return true;
                }
            }  
            return false;
        }

    }
}
