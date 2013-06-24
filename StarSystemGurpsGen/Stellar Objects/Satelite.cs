using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    /// <summary>
    /// The object for satelites and moons in this object
    /// </summary>
    public class Satellite : Orbital
    {
        //flags!

        // generic error flags
        // mainly used to release error conditions from functions

        /// <summary>
        /// FLAG: The orbit has an error (or could not be correctly added)
        /// </summary>
        readonly public static int ERROR_ORBIT = -1;

        /// <summary>
        /// FLAG: The basetype has an error (or could not be correctly set)
        /// </summary>
        readonly public static int ERROR_BASETYPE = -2;

        /// <summary>
        /// FLAG: The subtype has an error (or could not be correctly set)
        /// </summary>
        readonly public static int ERROR_SUBTYPE = -3;

        /// <summary>
        /// FLAG: The size has an error (or could not be correctly set)
        /// </summary>
        readonly public static int ERROR_SIZE = -4;

        /// <summary>
        /// FLAG: The atmosphere size has an error (or could not be correctly set)
        /// </summary>
        readonly public static int ERROR_ATM = -5;

        /// <summary>
        /// FLAG: The atmosphere condition has an error (or could not be correctly set)
        /// </summary>
        readonly public static int ERROR_ATMCOND = -6;

        /// <summary>
        /// FLAG: Unknown error!
        /// </summary>
        readonly public static int ERROR_GENERIC = -7;

        /// <summary>
        /// The amount of gravity on Earth.
        /// </summary>
        readonly public static double GFORCE = 9.80665;

        // owner flags.
        // we use the star ids when it's just one star, though.
        readonly public static int ORBIT_PRISEC = 9102; //primary and secondary
        readonly public static int ORBIT_PRISECTRI = 9103; //all three
        readonly public static int ORBIT_PRITRI = 9106; //shouldn't happen .(Primary and Trinary)
        readonly public static int ORBIT_SECCOM = 9104; //secondary and companion
        readonly public static int ORBIT_TRICOM = 9105; //trinary and companion
        readonly public static int ORBIT_SECTRI = 9107; //this so shouldn't happen. Secondary and Trinary.
        readonly public static int ORBIT_PLANET = 9108; //for moons

        // base type flags
        // these are used because certain things need to check what the base type is.
        readonly public static int BASETYPE_MOON = 210;
        readonly public static int BASETYPE_ASTEROIDBELT = 211;
        readonly public static int BASETYPE_EMPTY = 212; 
        readonly public static int BASETYPE_GASGIANT = 220;
        readonly public static int BASETYPE_TERRESTIAL = 230;
        
        readonly public static int BASETYPE_UNSET = 999;

        //sub type flags: i.e a Terrestial(Ice) Small, for example.
        readonly public static int SUBTYPE_ICE = 231;
        readonly public static int SUBTYPE_ROCK = 232;
        readonly public static int SUBTYPE_SULFUR = 233;
        readonly public static int SUBTYPE_HADEAN = 234;
        readonly public static int SUBTYPE_AMMONIA = 235;
        readonly public static int SUBTYPE_GARDEN = 236;
        readonly public static int SUBTYPE_OCEAN = 237;
        readonly public static int SUBTYPE_GREENHOUSE = 238;
        readonly public static int SUBTYPE_CHTHONIAN = 239;

        // size flags
        // grouped into related sizes for different base types.
        readonly public static int SIZE_UNSET = BASETYPE_UNSET;
        readonly public static int SIZE_TINY = 11;
        readonly public static int SIZE_SMALL = 12;
        readonly public static int SIZE_MEDIUM = 13;
        readonly public static int SIZE_LARGE = 14;

       /* CHART FOR SIZES:
        * TINY : Asteroid Belt (Sparse), Terrestial (Tiny)
        * SMALL: Asteroid Belt (Light), Terrestial (Small), Gas Giant (Small)
        * MEDIUM: Asteroid Belt (Moderate), Terrestial (Standard), Gas Giant (Medium)
        * LARGE: Asteroid Belt (Dense), Terrestial (Large), Gas Giant (Large) */

       
        // atm flags
        // flags for type. Used to make sure we keep all refrences consistant
        readonly public static int ATM_BASE_PRES = 300;
        readonly public static int ATM_PRES_NONE = ATM_BASE_PRES + 0;
        readonly public static int ATM_PRES_TRACE = ATM_BASE_PRES + 1;
        readonly public static int ATM_PRES_VERYTHIN = ATM_BASE_PRES + 2;
        readonly public static int ATM_PRES_THIN = ATM_BASE_PRES + 3;
        readonly public static int ATM_PRES_STANDARD = ATM_BASE_PRES + 4;
        readonly public static int ATM_PRES_DENSE = ATM_BASE_PRES + 5;
        readonly public static int ATM_PRES_VERYDENSE = ATM_BASE_PRES + 6;
        readonly public static int ATM_PRES_SUPERDENSE = ATM_BASE_PRES + 7;
       
        // flags for badstuff
        readonly public static int ATM_BASE_COND = 330;
        readonly public static int ATM_COND_CORROSIVE = ATM_BASE_COND + 0;
        readonly public static int ATM_COND_SUFFOCATING = ATM_BASE_COND + 1;
        readonly public static int ATM_COND_FLAMP1 = ATM_BASE_COND + 2;

        //the following are [Toxic]
        readonly public static int ATM_BASE_TOXIC = 340;
        readonly public static int ATM_TOXIC_MILDLY = ATM_BASE_TOXIC + 0;
        readonly public static int ATM_TOXIC_HIGHLY = ATM_BASE_TOXIC + 1;
        readonly public static int ATM_TOXIC_LETHALLY = ATM_BASE_TOXIC + 2;

        // the following are [Marginal].
        readonly public static int ATM_BASE_MARGINAL = 350;
        readonly public static int ATM_MARG_INERT = ATM_BASE_MARGINAL + 0;
        readonly public static int ATM_MARG_CHLORINE = ATM_BASE_MARGINAL + 1;
        readonly public static int ATM_MARG_FLOURINE = ATM_BASE_MARGINAL + 2;
        readonly public static int ATM_MARG_SULFUR = ATM_BASE_MARGINAL + 3;
        readonly public static int ATM_MARG_NITROGEN = ATM_BASE_MARGINAL + 4;
        readonly public static int ATM_MARG_ORGANIC = ATM_BASE_MARGINAL + 5;
        readonly public static int ATM_MARG_LOWOXY = ATM_BASE_MARGINAL + 6;
        readonly public static int ATM_MARG_HIGHOXY = ATM_BASE_MARGINAL + 7;
        readonly public static int ATM_MARG_POLLUTANTS = ATM_BASE_MARGINAL + 8;
        readonly public static int ATM_MARG_HIGHCO2 = ATM_BASE_MARGINAL + 9;

        /// <summary>
        /// This flag stores the count of marginal flags. If you add one, please increment this.
        /// </summary>
        readonly protected static int MARGINAL_INCREMENT = 10;

        /// <summary>
        /// This flag stors the count of conditional flags. If you add one, please increment this
        /// </summary>
        readonly protected static int COND_INCREMENT = 3;

        /// <summary>
        /// This flag stores the count of toxicity flags.
        /// </summary>
        readonly protected static int TOXIC_INCREMENT = 3;

        // range flags
        // used to calc further down (can be altered at will)
        readonly public static int RNG_ATMTOXIC = 3;

        // geologic flags
        // used for both tectonic and heavy actvitiy.
        readonly public static int GEOLOGIC_NONE = 30;
        readonly public static int GEOLOGIC_LIGHT = 31;
        readonly public static int GEOLOGIC_MODERATE = 32;
        readonly public static int GEOLOGIC_HEAVY = 33;
        readonly public static int GEOLOGIC_EXTREME = 34;

        // climate flags
        // climates are decided via temperatures. We store them here
        // These are their stories *CLANG CLANG*
        readonly public static int CLIMATE_FROZEN = 40;
        readonly public static int CLIMATE_VERYCOLD = 41;
        readonly public static int CLIMATE_COLD = 42;
        readonly public static int CLIMATE_CHILLY = 43;
        readonly public static int CLIMATE_COOL = 44;
        readonly public static int CLIMATE_NORMAL = 45;
        readonly public static int CLIMATE_WARM = 46;
        readonly public static int CLIMATE_TROPICAL = 47;
        readonly public static int CLIMATE_HOT = 48;
        readonly public static int CLIMATE_VERYHOT = 49;
        readonly public static int CLIMATE_INFERNAL = 50;
        readonly public static int CLIMATE_NONE = 51;

        //description flags
        readonly public static int DESC_SUBSURFOCEAN = 61;
        readonly public static int DESC_RAD_HIGHBACK = 62;
        readonly public static int DESC_RAD_LETHALBACK = 63;
        readonly public static int DESC_SPECRINGSYS = 64;
        readonly public static int DESC_FAINTRINGSYS = 65;

        //converstion factors
        readonly public static double CONVFAC_DENSITY = 5.52;
        readonly public static double CONVFAC_DIAMETER = 12756.2;
        readonly public static double CONVFAC_GRAVITY = 9.81;


        //tide flags
        readonly public static int TIDE_PRIMARYSTAR = 101;
        readonly public static int TIDE_SECONDARYSTAR = 102;
        readonly public static int TIDE_TRINARYSTAR = 103;
        readonly public static int TIDE_SECCOMPSTAR = 104;
        readonly public static int TIDE_TRICOMPSTAR = 105;
        readonly public static int TIDE_PARPLANET = 107;

        readonly public static int TIDE_MOON_BASE = 110;
        readonly public static int TIDE_MOON1 = 111;
        readonly public static int TIDE_MOON2 = 112;
        readonly public static int TIDE_MOON3 = 113;
        readonly public static int TIDE_MOON4 = 114;
        readonly public static int TIDE_MOON5 = 115;
        readonly public static int TIDE_MOON6 = 116;
        readonly public static int TIDE_MOON7 = 117;
        readonly public static int TIDE_MOON8 = 118;
        readonly public static int TIDE_MOON9 = 119;
        readonly public static int TIDE_MOON10 = 120;
        

        //general properties - Satellite size and type: these fields deteremine the base type.
        public int baseType { get; protected set; } 
        public int SatelliteType { get; protected set; }
        public int SatelliteSize { get; protected set; }
        
        //planet properties - moon properties
        public List<Moonlet> innerMoonlets { get; set; } 
        public List<Satellite> majorMoons { get; set; }
        public List<Moonlet> outerMoonlets { get; set; } //For Gas Giants: Used for outermost family.

        //moon properties
        public double orbitalCycle { get; set; } //apparent motion of this Satellite around it's primary. Only used if it's a moon.
        public double parentDiam { get; set; }
        public double moonRadius { get; set; }

        //general properties - self properties
        public double diameter { get; set; }
        public double mass { get; set; }
        public double density { get; set; }
        public double gravity { get; set; } //I'd like to say this should be derived. Sigh.
        public double axialTilt { get; set; }

        //general properties - orbital properties
        public double siderealPeriod { get; set; } //base sidereal day
        public double rotationalPeriod { get; set; } //solar day
        public bool retrogradeMotion { get; set; } //does this orbit in retrograde?      

        //general properties - climate and atmosphere properties
        public double hydCoverage { get; set; }
        public double surfaceTemp { get; set; }
        public double dayFaceMod { get; set; }
        public double nightFaceMod { get; set; }
 
        public double atmMass { get; set; }
        public double atmPres { get; protected set; }
        public List<int> atmCate { get; set; }
        protected List<int> descListing { get; set; }

       //general properties - resources and geologic properties
        public int RVM { get; set; }
        public int volActivity { get; set; }
        public int tecActivity { get; set; }

        //general properties - tide data
        public Dictionary<int,double> tideForce { get; set; }
        public bool isResonant { get; set; }
        public bool isTideLocked { get; set; }
        public double tideTotal { get; set; }

        //order properties
        public int masterOrderID { get; set; } //used to track what planet this is in a multi-star system.

        //gas giant properties: lookup table for gas giants.
        public double[][] gasGiantTable = new double[][]{
                 new double[] {0}, //Index 0
                 new double[] {0}, //Roll 1
                 new double[] {0}, //Roll 2
                 new double[] {10,.42,100,.18,600,.31}, //Roll 3
                 new double[] {10,.42,100,.18,600,.31}, //Roll 4
                 new double[] {10,.42,100,.18,600,.31}, //Roll 5
                 new double[] {10,.42,100,.18,600,.31}, //Roll 6
                 new double[] {10,.42,100,.18,600,.31}, //Roll 7
                 new double[] {10,.42,100,.18,600,.31}, //Roll 8
                 new double[] {15,.26,150,.19,800,.35}, //Roll 9
                 new double[] {15,.26,150,.19,800,.35}, //Roll 10
                 new double[] {20,.22,200,.20,1000,.4}, //Roll 11
                 new double[] {30,.19,250,.22,1500,.6}, //Roll 12
                 new double[] {40,.17,300,.24,2000,.8}, //Roll 13
                 new double[] {50,.17,350,.25,2500,1.0}, //Roll 14
                 new double[] {60,.17,400,.26,3000,1.2}, //Roll 15
                 new double[] {70,.17,450,.27,3500,1.4}, //Roll 16
                 new double[] {80,.17,500,.29,4000,1.6}, //Roll 17
                 new double[] {80,.17,500,.29,4000,1.6}, //Roll 18
        };

        public double[][] terrDenTable = new double[][]{
            new double[] {0}, //Index 0
            new double[] {0}, //Roll 1
            new double[] {0}, //Roll 2
            new double[] {.3,.6,.8}, //Roll 3
            new double[] {.3,.6,.8}, //Roll 4
            new double[] {.3,.6,.8}, //Roll 5 
            new double[] {.3,.6,.8}, //Roll 6
            new double[] {.4,.7,.9}, //Roll 7
            new double[] {.4,.7,.9}, //Roll 8
            new double[] {.4,.7,.9}, //Roll 9
            new double[] {.4,.7,.9}, //Roll 10
            new double[] {.5,.8,1.0}, //Roll 11
            new double[] {.5,.8,1.0}, //Roll 12
            new double[] {.5,.8,1.0}, //Roll 13
            new double[] {.5,.8,1.0}, //Roll 14
            new double[] {.6,.9,1.1}, //Roll 15
            new double[] {.6,.9,1.1}, //Roll 16
            new double[] {.6,.9,1.1}, //Roll 17
            new double[] {.7,1.0,1.2}, //Roll 18
        };

        protected void initiateLists()
        {
            this.majorMoons = new List<Satellite>();
            this.atmCate = new List<int>();
            this.innerMoonlets = new List<Moonlet>();
            this.outerMoonlets = new List<Moonlet>();
            this.descListing = new List<int>();
            this.tideForce = new Dictionary<int,double>();
        }

        public void updateAtmPres(double atmPres)
        {
            this.atmPres = atmPres;
            if (this.atmPres == 0)
            {
                //reset mass to 0
                this.atmMass = 0.0;

                //nuke it.
                if (this.atmCate.Count > 0)
                    this.atmCate.RemoveRange(0, this.atmCate.Count);
            }
        }

        /// <summary>
        /// Constructor object
        /// </summary>
        /// <param name="parent">The parent ID (inherited from Orbital)</param>
        /// <param name="self">Self ID (inherited from Orbital)</param>
        /// <param name="radius">Orbital Radius of the satelite</param>
        /// <param name="masterCount">In a system, the ordinal of the planet from the sun</param>
        /// <param name="satType">The Satelite Type. Default is BASETYPE_UNSET</param>
        public Satellite(int parent, int self, double radius, int masterCount, int satType = 999)
            : base(parent, self)
        {
            initiateLists();
            updateType(satType); //call updateType.

            this.orbitalRadius = radius;
            this.masterOrderID = masterCount;
            this.SatelliteSize = Satellite.SIZE_UNSET;
            this.isResonant = false;
        }

        /// <summary>
        /// The copy constructor
        /// </summary>
        /// <param name="s">The satelite object we are copying</param>
        public Satellite(Satellite s) : base(s.parentID, s.selfID){

           // .. it's a copy constructor.
            initiateLists();
            updateType(s.SatelliteType);
            updateSize(s.SatelliteSize);

            foreach (Moonlet m in s.innerMoonlets)
                this.innerMoonlets.Add(new Moonlet(m));

            foreach (Moonlet m in s.outerMoonlets)
                this.outerMoonlets.Add(new Moonlet(m));

            foreach (Satellite m in s.majorMoons)
                this.majorMoons.Add(new Satellite(m));

            this.orbitalCycle = s.orbitalCycle;
            this.diameter = s.diameter;
            this.mass = s.mass;
            this.density = s.density;
            this.axialTilt = s.axialTilt;
            this.siderealPeriod = s.siderealPeriod;
            this.rotationalPeriod = s.rotationalPeriod;
            this.retrogradeMotion = s.retrogradeMotion;

            foreach (int atmType in s.atmCate)
                this.atmCate.Add(atmType);

            foreach (KeyValuePair<int, double> kvp in s.tideForce)
            {
                this.tideForce.Add(kvp.Key, kvp.Value);
            }
            
            this.volActivity = s.volActivity;
            this.tecActivity = s.tecActivity;
            this.masterOrderID = s.masterOrderID;

            this.surfaceTemp = s.surfaceTemp;
            this.dayFaceMod = s.dayFaceMod;
            this.nightFaceMod = s.nightFaceMod;

            this.hydCoverage = s.hydCoverage;
            this.atmMass = s.atmMass;
            this.atmPres = s.atmPres;
            this.RVM = s.RVM;
            this.isResonant = s.isResonant;

        }

        /// <summary>
        /// This determines the habitability score of a satelite
        /// </summary>
        /// <returns>The habitability score of a satelite</returns>
        public virtual int getHabitability()
        {
            int mod = 0;

            //Geologic modifiers
            if (this.volActivity == GEOLOGIC_HEAVY) 
                mod = mod - 1;
            if (this.volActivity == GEOLOGIC_EXTREME) 
                mod = mod - 2;
            if (this.tecActivity == GEOLOGIC_EXTREME) 
                mod = mod - 2;

            bool isMarginal = false;
            if (this.atmCate.Count > 0)
            {
                foreach (int currAtmNote in this.atmCate)
                {
                    if (currAtmNote >= ATM_BASE_TOXIC && currAtmNote < (ATM_BASE_TOXIC + RNG_ATMTOXIC))
                        mod = mod - 1;
                    if (currAtmNote == ATM_COND_CORROSIVE) 
                        mod = mod - 1;

                    if (currAtmNote >= ATM_BASE_MARGINAL && currAtmNote < (ATM_BASE_MARGINAL + MARGINAL_INCREMENT))
                        isMarginal = true;
                }
            }

            if (this.getAtmCategory() == ATM_PRES_VERYTHIN) 
                mod = mod + 1;
            if (this.getAtmCategory() == ATM_PRES_THIN) 
                mod = mod + 2;
            if (this.getAtmCategory() == ATM_PRES_STANDARD) 
                mod = mod + 3;
            if (this.getAtmCategory() == ATM_PRES_DENSE) 
                mod = mod + 3;
            if (this.getAtmCategory() == ATM_PRES_VERYDENSE) 
                mod = mod + 1;
            if (this.getAtmCategory() == ATM_PRES_SUPERDENSE) 
                mod = mod + 1;

            if (isMarginal) 
                mod = mod + 1;
            if (this.hydCoverage > .0 && this.hydCoverage <= .59) 
                mod = mod + 1;
            if (this.hydCoverage > .59 && this.hydCoverage <= .90) 
                mod = mod + 2;
            if (this.hydCoverage > .90 && this.hydCoverage <= .99) 
                mod = mod + 1;

            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_COLD) mod = mod + 1;
            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_CHILLY) mod = mod + 2;
            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_COOL) mod = mod + 2;
            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_NORMAL) mod = mod + 2;
            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_WARM) mod = mod + 2;
            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_TROPICAL) mod = mod + 2;
            if (this.atmPres > 0.01 && this.getClimate(this.surfaceTemp) == Satellite.CLIMATE_HOT) mod = mod + 1;

            if (mod >= 8 && !OptionCont.overrideHabitability) return 8;
            else return mod;
        }

        /// <summary>
        /// This returns the description of the RVM score according to the GURPS ruleset
        /// </summary>
        /// <returns>A string describing the RVM score</returns>
        public virtual string getRVMDesc()
        {
            if (this.RVM == -5) return "Worthless";
            if (this.RVM == -4) return "Very Scant";
            if (this.RVM == -3) return "Scant";
            if (this.RVM == -2) return "Very Poor";
            if (this.RVM == -1) return "Poor";
            if (this.RVM == 0) return "Average";
            if (this.RVM == 1) return "Abundant";
            if (this.RVM == 2) return "Very Abundant";
            if (this.RVM == 3) return "Rich";
            if (this.RVM == 4) return "Very Rich";
            if (this.RVM == 5) return "Motherlode";

            return "Error";
        }

        //sets the total planet # in a multi star, as well as the current one around it's parent.
        // in the case of a one-star system you shouldn't assign them different numbers. 
        public virtual void updateOrbitalData(int masterOrbPos, int localOrbPos)
        {
            this.masterOrderID = masterOrbPos;
            this.selfID = localOrbPos;
        }

        /// <summary>
        /// Adds an ATM Category Flag
        /// </summary>
        /// <param name="s">The flag to be added</param>
        public virtual void addAtmCategory(int s)
        {
            this.atmCate.Add(s);
        }

        /// <summary>
        /// This generates the world type, given our age, blackbody temperature and mass.
        /// </summary>
        /// <param name="maxMass">The mass of the star (used for Ammonia worlds)</param>
        /// <param name="sysAge">Age of the planet</param>
        /// <param name="ourBag">Dice object used for rolls</param>
        /// <remarks>This is placed here so that somoene with the Satellite class can create one almost without additional logic coding.</remarks>
        public virtual void genWorldType(double maxMass, double sysAge, Dice ourBag)
        {
            if ((this.baseType == Satellite.BASETYPE_TERRESTIAL) || (this.baseType == Satellite.BASETYPE_MOON))
            {
                if (this.SatelliteSize == Satellite.SIZE_TINY)
                {
                    if (this.blackbodyTemp <= 140.50) this.updateType(Satellite.SUBTYPE_ICE);
                    if (this.blackbodyTemp > 140.50) this.updateType(Satellite.SUBTYPE_ROCK);
                }

                if (this.SatelliteSize == Satellite.SIZE_SMALL)
                {
                    if (this.blackbodyTemp <= 80.50) this.updateType(Satellite.SUBTYPE_HADEAN);
                    if ((80.50 < this.blackbodyTemp) && (this.blackbodyTemp <= 140.50)) this.updateType(Satellite.SUBTYPE_ICE);
                    if (this.blackbodyTemp > 140.50) this.updateType(Satellite.SUBTYPE_ROCK);

                }

                if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                {
                    if (this.blackbodyTemp <= 80.50) this.updateType(Satellite.SUBTYPE_HADEAN);
                    if ((this.blackbodyTemp > 80.50) && (this.blackbodyTemp <= 150.50)) this.updateType(Satellite.SUBTYPE_ICE);

                    if ((this.blackbodyTemp > 150.50) && (this.blackbodyTemp <= 230.50))
                    {
                        if (maxMass <= .65) this.updateType(Satellite.SUBTYPE_AMMONIA);
                        else this.updateType(Satellite.SUBTYPE_ICE);
                    }

                    if ((this.blackbodyTemp > 230.50) && (this.blackbodyTemp <= 240.50)) this.updateType(Satellite.SUBTYPE_ICE);
                    if ((this.blackbodyTemp > 240.50) && (this.blackbodyTemp <= 320.50))
                    {
                        int roll = ourBag.rng(3, 6, 0), mod = 0;

                        mod = (int)Math.Floor(sysAge / .5);
                        if (mod > 10) mod = 10;

                        roll = roll + mod;

                        if (!OptionCont.noOceanOnlyGarden)
                        {
                            if (roll >= 18) this.updateType(Satellite.SUBTYPE_GARDEN);
                            else this.updateType(Satellite.SUBTYPE_OCEAN);
                        }
                        else 
                        this.updateType(Satellite.SUBTYPE_GARDEN);

                    }

                    if ((this.blackbodyTemp > 321.50) && (this.blackbodyTemp <= 500.50)) this.updateType(Satellite.SUBTYPE_GREENHOUSE);
                    if (this.blackbodyTemp > 500.50) this.updateType(Satellite.SUBTYPE_CHTHONIAN);

                }

                if (this.SatelliteSize == Satellite.SIZE_LARGE)
                {                   
                    if (this.blackbodyTemp <= 150.50) this.updateType(Satellite.SUBTYPE_HADEAN);
                    if ((this.blackbodyTemp > 150.50) && (this.blackbodyTemp <= 230.50))
                    {
                        if (maxMass <= .65) this.updateType(Satellite.SUBTYPE_AMMONIA);
                        else this.updateType(Satellite.SUBTYPE_ICE);
                    }

                    if ((this.blackbodyTemp > 230.50) && (this.blackbodyTemp <= 240.50)) this.updateType(Satellite.SUBTYPE_ICE);
                    if ((this.blackbodyTemp > 240.50) && (this.blackbodyTemp <= 320.50))
                    {
                        int roll = ourBag.rng(3, 6, 0), mod = 0;

                        if (OptionCont.moreAccurateO2Catastrophe) mod = (int)Math.Floor(sysAge / .3);
                        else mod = (int)Math.Floor(sysAge / .5); 

                        if (!OptionCont.moreLargeGarden) if (mod > 5) mod = 5;
                        if (OptionCont.moreLargeGarden) if (mod > 10) mod = 10;

                        roll = roll + mod;

                        this.updateType(Satellite.SUBTYPE_GARDEN);

                    }

                    if ((this.blackbodyTemp > 321.50) && (this.blackbodyTemp <= 500.50)) this.updateType(Satellite.SUBTYPE_GREENHOUSE);
                    if (this.blackbodyTemp > 500.50) this.updateType(Satellite.SUBTYPE_CHTHONIAN);
                }
            }

        } 

        
        /// <summary>
        /// Blackbody wrapper if you're invoking for the same satelite you want the temp for. Invokes the other function
        /// </summary>
        /// <param name="distChart">The distance chart of each star to each other</param>
        /// <param name="ourStars">List of our stars</param>
        public virtual void updateBlackBodyTemp(double[,] distChart,List<Star> ourStars)
        {
            this.blackbodyTemp = calcBlackbodyTemp(distChart, ourStars, this.orbitalRadius, this.parentID);
        }

        //There might be a better way to calc this than I did.
        /// <summary>
        /// Blackbody function that calcluates our temperatuer
        /// </summary>
        /// <param name="distChart">The distance chart of each star to each other</param>
        /// <param name="stars">List of our stars</param>
        /// <param name="planetRadius">Radius of this satellite</param>
        /// <param name="planetOwnership">The parent ID (what star does this satellite orbit)</param>
        /// <returns></returns>
        public virtual double calcBlackbodyTemp(double[,] distChart,List<Star> stars, double planetRadius, int planetOwnership)
        {
            double currTemp = 0.0;
            double blackMulti = 278.0;
            double currDistance = 0.0;
            //first get distances of each star to the primary.
            var distTable = new Dictionary<int, Dictionary<int, double>>();
            int[] satIDFlags = new int[5] { Star.IS_PRIMARY, Star.IS_SECONDARY, Star.IS_TRINARY, Star.IS_SECCOMP, Star.IS_TRICOMP };
           
            for (int i = 0; i < stars.Count; i++)
            {


                int currStar = 0, planetOwner = 0;

                //first, determine the lookup for the planet ownership
                if ((planetOwnership == Satellite.ORBIT_PRISEC) || (planetOwnership == Satellite.ORBIT_PRISECTRI) ||
                    (planetOwnership == Satellite.ORBIT_PRITRI) || (planetOwnership == Star.IS_PRIMARY))
                    planetOwner = 0;
                if ((planetOwnership == Satellite.ORBIT_SECCOM) || (planetOwnership == Satellite.ORBIT_SECTRI) ||
                    (planetOwnership == Star.IS_SECONDARY))
                    planetOwner = 1;
                if ((planetOwnership == Satellite.ORBIT_TRICOM) || (planetOwnership == Star.IS_TRINARY))
                    planetOwner = 2;
                if (planetOwnership == Star.IS_SECCOMP) planetOwner = 3;
                if (planetOwnership == Star.IS_TRICOMP) planetOwner = 4;


                //second, lookup for the star we're in.
                if (stars[i].orderID == Star.IS_PRIMARY) currStar = 0;
                if (stars[i].orderID == Star.IS_SECONDARY) currStar = 1;
                if (stars[i].orderID == Star.IS_TRINARY) currStar = 2;
                if (stars[i].orderID == Star.IS_SECCOMP) currStar = 3;
                if (stars[i].orderID == Star.IS_TRICOMP) currStar = 4;

                currDistance = Math.Abs(distChart[planetOwner, currStar] + planetRadius);

                //add the blackbody for this star
                currTemp = currTemp + Math.Pow((blackMulti * Math.Pow(stars[i].currLumin, .25)) / Math.Sqrt(currDistance), 4);
            }

            currTemp = Math.Pow(currTemp, .25);
            return currTemp;

        } 



        /// <summary>
        /// This determines what types can be added. It performs some sanity checking to make sure that invalid combinations are not allowed.
        /// </summary>
        /// <param name="flag">The flag we are updating for</param>
        /// <exception cref="Exception">Throws an exception if you attempt to set an invalid combo.</exception>
        public virtual void updateType(int flag)
        {
            if (flag == Satellite.BASETYPE_ASTEROIDBELT)
                this.baseType = flag;
            if (flag == Satellite.BASETYPE_EMPTY)
                this.baseType = flag;
            if (flag == Satellite.BASETYPE_GASGIANT)
                this.baseType = flag;
            if (flag == Satellite.BASETYPE_MOON)
                this.baseType = flag;
            if (flag == Satellite.BASETYPE_TERRESTIAL)
                this.baseType = flag;

            if (flag == Satellite.BASETYPE_UNSET){
                this.baseType = flag;
                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_AMMONIA)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");
                
                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.
                
                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_CHTHONIAN)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");
                
                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.

                this.SatelliteType = flag;
            }
            
            if (flag == Satellite.SUBTYPE_GARDEN)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");

                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.

                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_GREENHOUSE)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");

                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.
               
                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_HADEAN)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");

                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.

                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_ICE)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");

                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.

                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_ROCK)
            {
                if (!(this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON
                    || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");

                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_TERRESTIAL; //moons MUST set this or you'll kinda regret it.

                this.SatelliteType = flag;
            }

            if (flag == Satellite.SUBTYPE_SULFUR)
            {
                if (!(this.baseType == Satellite.BASETYPE_MOON || this.baseType == Satellite.BASETYPE_UNSET))
                    throw new Exception("Cannot set this as a type for this base type.");

                if (this.baseType == Satellite.BASETYPE_UNSET)
                    this.baseType = Satellite.BASETYPE_MOON; //Can only be a moon.

                this.SatelliteType = flag;
            }

        }
      
        /* the following functions will create the physical properties of terrestial and gas planets. 
         * Asteroid Belts don't really have much, and empty orbitals are empty. */

        // FEW NOTES HERE: If you want to set the density of a gas giant, you'll auto set the mass. This is because the mass to generate the diameter. And for ease of use I'm 
        // letting it stand now.

        /// <summary>
        /// This function generates the density of a sateltie. You MUST have set a basetype first.
        /// </summary>
        /// <param name="ourBag">Our dice object</param>
        /// <exception cref="Exception">Throws an exception if you attempt to invoke this on an satellite with any of: UNSET, EMPTY OR ASTEROID basetypes.</exception>
        /// <remarks>For a satellite with a basetype of GASGIANT, it will auto set the mass. </remarks>
        public virtual void genDensity(Dice ourBag)
        {
            if (this.baseType == Satellite.BASETYPE_EMPTY || this.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                throw new Exception("You cannot give these types of orbits a density.");
            if (this.baseType == Satellite.BASETYPE_UNSET || this.SatelliteSize == Satellite.SIZE_UNSET)
                throw new Exception("Please give this orbit a size or basetype first.");

            int roll = ourBag.rng(3, 6, 0);
            if (this.baseType == Satellite.BASETYPE_GASGIANT)
            {
                double varMass = ourBag.rng(1, 50, 0) * .01;
                if (roll != 18)
                {
                    int massEntry = 0, densityEntry = 1;
                    if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                    {
                        massEntry = 2;
                        densityEntry = 3;
                    }

                    if (this.SatelliteSize == Satellite.SIZE_LARGE)
                    {
                        massEntry = 4;
                        densityEntry = 5;
                    }

                    //now we interporlate
                    this.mass = ((this.gasGiantTable[roll + 1][massEntry] - this.gasGiantTable[roll][massEntry] * varMass) + this.gasGiantTable[roll][massEntry]);
                    this.density = ((this.gasGiantTable[roll + 1][densityEntry] - this.gasGiantTable[roll][densityEntry] * varMass) + this.gasGiantTable[roll][densityEntry]);
                }
                else if (roll == 18)
                {
                    int massEntry = 0, densityEntry = 1;
                    if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                    {
                        massEntry = 2;
                        densityEntry = 3;
                    }

                    if (this.SatelliteSize == Satellite.SIZE_LARGE)
                    {
                        massEntry = 4;
                        densityEntry = 5;
                    }

                    this.mass = this.gasGiantTable[roll][massEntry];
                    this.density = this.gasGiantTable[roll][densityEntry];
                }
            }

            if (this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON)
            {

                int densityEntry = 0; //means we don't need to bother specifying for icy core!
                if (this.SatelliteType == Satellite.SUBTYPE_ROCK) densityEntry = 1;
                
                if (this.SatelliteType == Satellite.SUBTYPE_OCEAN) densityEntry = 2;
                if (this.SatelliteType == Satellite.SUBTYPE_GARDEN) densityEntry = 2;
                if (this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE) densityEntry = 2;
                if (this.SatelliteType == Satellite.SUBTYPE_CHTHONIAN) densityEntry = 2;
                if (this.SatelliteType == Satellite.SUBTYPE_ICE && this.SatelliteSize == Satellite.SIZE_LARGE)
                    densityEntry = 2;

                this.density = this.terrDenTable[roll][densityEntry];
            }
        }

        /// <summary>
        /// This function will set the diameter, mass and gravity, given the density.
        /// </summary>
        /// <param name="ourBag">Our dice object</param>
        /// <exception cref="Exception">Throws an exception if it's called on anything but a moon and gas giant</exception>
        /// <exception cref="Exception">Throws an exception if the density is unset.</exception>
        public virtual void genPhysicalParameters(Dice ourBag)
        {
            if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT || this.baseType == Satellite.BASETYPE_EMPTY || this.baseType == Satellite.BASETYPE_UNSET)
                throw new Exception("Please only call this on a moon, terrestial planet or gas giant.");
            if (this.density == 0)
                throw new Exception("Density unset.");

            if (this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_MOON)
            {
                double baseVal = Math.Sqrt(this.blackbodyTemp/this.density);

                //range for small is .004 to .024
                if (this.SatelliteSize == Satellite.SIZE_TINY) 
                    this.diameter = ourBag.rollRange(.004,.020) * baseVal;

                //range for small is .024 to .030
                if (this.SatelliteSize == Satellite.SIZE_SMALL)
                    this.diameter = ourBag.rollRange(.024,.006) * baseVal;
                
                //range for medium is .030 to .065
                if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                    this.diameter = ourBag.rollRange(.030,.035) * baseVal;

                //range for large is .065 to .091
                if (this.SatelliteSize == Satellite.SIZE_LARGE)
                    this.diameter = ourBag.rollRange(.065, .026) * baseVal;

                this.mass = this.density * Math.Pow(this.diameter, 3);
                this.gravity = this.density * this.diameter;
            }

            if (this.baseType == Satellite.BASETYPE_GASGIANT)
            {
               this.diameter = Math.Pow((this.mass / this.density), .33);
               this.gravity = this.density * this.diameter;
            }
        }

        /// <summary>
        /// This sets the atmospheric pressure given the table and various properties of the atmosphere.
        /// </summary>
        public virtual void calcAtmPres()
        {
            if (!(this.baseType == Satellite.BASETYPE_MOON || this.baseType == Satellite.BASETYPE_TERRESTIAL))
                throw new Exception("You can only invoke this on a terrestial planet or terrestial moon.");
            
            if (this.gravity == 0)
                throw new Exception("You cannot calculate Atmospheric pressure until you have gravity defined.");

            double presFact = 0.0;

            //pull the fact from the table. Well, from this..
            if (this.SatelliteSize == Satellite.SIZE_SMALL && this.SatelliteType == Satellite.SUBTYPE_ICE)
                presFact = 10.0;

            if (this.SatelliteSize == Satellite.SIZE_MEDIUM && this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
                    presFact = 100.0;

            if (this.SatelliteSize == Satellite.SIZE_LARGE && this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
                    presFact = 500.0;

            if (this.SatelliteSize == Satellite.SIZE_MEDIUM){
                if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA) presFact = 1.0;
                if (this.SatelliteType == Satellite.SUBTYPE_ICE) presFact = 1.0;
                if (this.SatelliteType == Satellite.SUBTYPE_OCEAN) presFact = 1.0;
                if (this.SatelliteType == Satellite.SUBTYPE_GARDEN) presFact = 1.0;
            }

            if (this.SatelliteSize == Satellite.SIZE_LARGE)
            {
                if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA) presFact = 5.0;
                if (this.SatelliteType == Satellite.SUBTYPE_ICE) presFact = 5.0;
                if (this.SatelliteType == Satellite.SUBTYPE_OCEAN) presFact = 5.0;
                 if (this.SatelliteType == Satellite.SUBTYPE_GARDEN) presFact = 5.0;
            }

            this.atmPres = this.atmMass * this.gravity * presFact;

            if ((this.SatelliteSize == Satellite.SIZE_TINY) || (this.SatelliteType == Satellite.SUBTYPE_HADEAN))
            {
                this.atmPres = 0;
                this.atmMass = 0;
            }

            if ((this.SatelliteType == Satellite.SUBTYPE_CHTHONIAN) ||
                (this.SatelliteType == Satellite.SUBTYPE_ROCK && this.SatelliteSize == Satellite.SIZE_SMALL))
            {
                this.atmPres = .01;
                this.atmMass = .01;
            }

            if (OptionCont.setAtmPressure != -1 && this.SatelliteType == Satellite.SUBTYPE_GARDEN)
                this.atmPres = OptionCont.setAtmPressure;

        }
        
        /// <summary>
        /// Calculates an axial tilt of a satellite given the ruleset
        /// </summary>
        /// <param name="ourBag"></param>
        public virtual void createAxialTilt(Dice ourBag)
        {
            do
            {
                switch (ourBag.gurpsRoll())
                {
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        this.axialTilt = ourBag.rng(2, 6, -2);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        this.axialTilt = 10 + ourBag.rng(2, 6, -2);
                        break;
                    case 10:
                    case 11:
                    case 12:
                        this.axialTilt = 20 + ourBag.rng(2, 6, -2);
                        break;
                    case 13:
                    case 14:
                        this.axialTilt = 30 + ourBag.rng(2, 6, -2);
                        break;
                    case 15:
                    case 16:
                        this.axialTilt = 30 + ourBag.rng(2, 6, -2);
                        break;
                    case 17:
                    case 18:
                        switch (ourBag.rng(1, 6, 0))
                        {
                            case 1:
                            case 2:
                                this.axialTilt = 50 + ourBag.rng(2, 6, -2);
                                break;
                            case 3:
                            case 4:
                                this.axialTilt = 60 + ourBag.rng(2, 6, -2);
                                break;
                            case 5:
                                this.axialTilt = 70 + ourBag.rng(2, 6, -2);
                                break;
                            case 6:
                                this.axialTilt = 80 + ourBag.rng(2, 6, -2);
                                break;
                        }
                        break;
                }
            } while (OptionCont.rerollAxialTiltOver45 && this.axialTilt > 45);


           if (OptionCont.getAxialTilt() != -1)
                this.axialTilt = OptionCont.getAxialTilt();
        }    

        /// <summary>
        /// Sets the Resource Value Modifier for this satelite
        /// </summary>
        /// <param name="roll">The dice roll</param>
        public virtual void populateRVM(int roll)
        {
            if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT)
            {
                if (roll == 3) this.RVM = -5;
                if (roll == 4) this.RVM = -4;
                if (roll == 5) this.RVM = -3;
                if (roll == 6 || roll == 7) this.RVM = -2;
                if (roll == 8 || roll == 9) this.RVM = -1;
                if (roll == 10 || roll == 11) this.RVM = 0;
                if (roll == 12 || roll == 13) this.RVM = 1;
                if (roll == 14 || roll == 15) this.RVM = 2;
                if (roll == 16) this.RVM = 3;
                if (roll == 17) this.RVM = 4;
                if (roll == 18) this.RVM = 5;
            }

            else
            {
                if (roll <= 2) this.RVM = -3;
                if (roll == 3 || roll == 4) this.RVM = -2;
                if (roll >= 5 && roll <= 7) this.RVM = -1;
                if (roll >= 8 && roll <= 13) this.RVM = 0;
                if (roll >= 14 && roll <= 16) this.RVM = 1;
                if (roll >= 17 && roll <= 18) this.RVM = 2;
                if (roll >= 19) this.RVM = 3;
            }
        }

       /// <summary>
       /// Sets climate and atmospheric data for this satelite. 
       /// </summary>
       /// <param name="maxMass">The maximum mass of the star</param>
       /// <param name="ourBag">The Dice object</param>
       public void setClimateData(double maxMass, Dice ourBag)
        {
            int roll;
            //atm mass first.
            this.atmMass = 0.01; //default case
            
            //ice case
            if ((this.SatelliteType == Satellite.SUBTYPE_ICE))
            {
                this.atmMass = (ourBag.rng(3, 6, 0) / 10.0) + (ourBag.rng(1, 6, -1) / 100.0);
                this.atmCate.Add(ATM_COND_SUFFOCATING);
   
                if (this.SatelliteSize == Satellite.SIZE_SMALL)
                {
                    roll = ourBag.rng(3, 6, 0);
                    if (roll >= 15) this.atmCate.Add(ATM_TOXIC_HIGHLY);
                    else this.atmCate.Add(ATM_TOXIC_MILDLY);
                }

                else if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                {
                    roll = ourBag.rng(3, 6, 0);
                    if (roll >= 13) this.atmCate.Add(ATM_TOXIC_MILDLY);
                }

                else if (this.SatelliteSize == Satellite.SIZE_LARGE) this.atmCate.Add(ATM_TOXIC_HIGHLY);
            }

            //Either ammonia or greenhouse
            if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA || this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
            {
                this.atmMass = (ourBag.rng(3, 6, 0) / 10.0) + (ourBag.rng(1, 6, -1) / 100.0);
                this.atmCate.Add(ATM_COND_SUFFOCATING);
                this.atmCate.Add(ATM_TOXIC_LETHALLY);
                this.atmCate.Add(ATM_COND_CORROSIVE);
            }

            //ocean case
            if (this.SatelliteType == Satellite.SUBTYPE_OCEAN)
            {
                this.atmMass = (ourBag.rng(3, 6, 0) / 10.0) + (ourBag.rng(1, 6, -1) / 100.0);
                this.atmCate.Add(ATM_COND_SUFFOCATING);

                if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                {
                    roll = ourBag.rng(3, 6, 0);
                    if (roll >= 13) this.atmCate.Add(ATM_TOXIC_MILDLY);
                }

                else if (this.SatelliteSize == Satellite.SIZE_LARGE)
                {
                    this.atmCate.Add(ATM_COND_SUFFOCATING);
                    this.atmCate.Add(ATM_TOXIC_HIGHLY);
                }
            }

            //either garden
            if (this.SatelliteType == Satellite.SUBTYPE_GARDEN)
            {
                this.atmMass = (ourBag.rng(3, 6, 0) / 10.0) + (ourBag.rng(1, 6, -1) / 100.0);
                roll = ourBag.rng(3, 6, 0);
                if (roll >= 12 && !OptionCont.noMarginalAtm)
                {
                    //add marginal code here
                    foreach (int i in genMarginal(ourBag))
                        this.atmCate.Add(i);
                    
                }
            }


            //NOW, for hydrographic coverage
            this.hydCoverage = 0.0; //default.
            if (this.SatelliteType == Satellite.SUBTYPE_ICE)
            {
                if (this.SatelliteSize == Satellite.SIZE_SMALL)
                {
                    roll = ourBag.rng(1, 6, 2);
                    this.hydCoverage = roll * .1;
                }

                if (this.SatelliteSize == Satellite.SIZE_MEDIUM || this.SatelliteSize == Satellite.SIZE_LARGE)
                {
                    roll = ourBag.rng(2, 6, -2);
                    if (roll < 0) roll = 0;
                    this.hydCoverage = roll * .1;
                }
            }

            if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA)
            {
                roll = ourBag.rng(2, 6, 0);
                if (roll > 10) roll = 10;
                this.hydCoverage = roll * .1;
            }

            if (this.SatelliteType == Satellite.SUBTYPE_OCEAN || this.SatelliteType == Satellite.SUBTYPE_GARDEN)
            {
                if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                {
                    roll = ourBag.rng(1, 6, 4);
                    this.hydCoverage = roll * .1;
                }

                if (this.SatelliteSize == Satellite.SIZE_LARGE)
                {
                    roll = ourBag.rng(1, 6, 6);
                    if (roll > 10) roll = 10;
                    this.hydCoverage = roll * .1;
                }
            }

            if (this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
            {
                roll = ourBag.rng(2, 6, -7);
                if (roll < 0) roll = 0;
                this.hydCoverage = roll * .1;
            }

            //randomize coverage!
            if (this.hydCoverage >= .1)
            {
                roll = ourBag.rng(1, 10, -5);
                this.hydCoverage = this.hydCoverage + (roll * .01);
            }

        }

       public virtual void detSurfaceTemp(double modifiers)
       {
           double absorptionFactor = 0.0, greenHouseFactor = 0.0;

           if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT) absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_ICE && this.SatelliteSize == Satellite.SIZE_TINY)
               absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_ROCK && this.SatelliteSize == Satellite.SIZE_TINY)
               absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_SULFUR && this.SatelliteSize == Satellite.SIZE_TINY)
               absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_HADEAN && this.SatelliteSize == Satellite.SIZE_SMALL)
               absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_ICE && this.SatelliteSize == Satellite.SIZE_SMALL)
           {
               absorptionFactor = getAbsorptionFactor(modifiers);
               greenHouseFactor = .10;
           }
           if (this.SatelliteType == Satellite.SUBTYPE_ROCK && this.SatelliteSize == Satellite.SIZE_SMALL)
               absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_HADEAN && this.SatelliteSize == Satellite.SIZE_MEDIUM)
               absorptionFactor = getAbsorptionFactor(modifiers);
           if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA)
           {
               absorptionFactor = getAbsorptionFactor(modifiers);
               greenHouseFactor = .20;
           }
           if (this.SatelliteType == Satellite.SUBTYPE_ICE &&
               (this.SatelliteSize == Satellite.SIZE_MEDIUM || this.SatelliteSize == Satellite.SIZE_LARGE))
           {
               absorptionFactor = getAbsorptionFactor(modifiers);
               greenHouseFactor = .20;
           }

           if (this.SatelliteType == Satellite.SUBTYPE_OCEAN || this.SatelliteType == Satellite.SUBTYPE_GARDEN)
           {
               if (this.hydCoverage <= .20)
               {
                   absorptionFactor = getAbsorptionFactor(modifiers);
                   greenHouseFactor = .16;
               }

               if (this.hydCoverage > .20 && this.hydCoverage <= .50)
               {
                   absorptionFactor = getAbsorptionFactor(modifiers);
                   greenHouseFactor = .16;
               }

               if (this.hydCoverage > .50 && this.hydCoverage <= .90)
               {
                   absorptionFactor = getAbsorptionFactor(modifiers);
                   greenHouseFactor = .16;
               }

               if (this.hydCoverage > .90)
               {
                   absorptionFactor = getAbsorptionFactor(modifiers);
                   greenHouseFactor = .16;
               }
           }

           if (this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
           {
               absorptionFactor = getAbsorptionFactor(modifiers);
               greenHouseFactor = 2.0;
           }

           if (this.SatelliteType == Satellite.SUBTYPE_CHTHONIAN)
           {
               absorptionFactor = getAbsorptionFactor(modifiers);
           }

           //get the surface temp.
           this.surfaceTemp = this.blackbodyTemp * (absorptionFactor * (1 + (this.atmMass * greenHouseFactor))); 
       }

       public virtual double getAbsorptionFactor(double modifiers)
       {
           double absorptionFactor = 0;

           if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT) absorptionFactor = .97;
           if (this.SatelliteType == Satellite.SUBTYPE_ICE && this.SatelliteSize == Satellite.SIZE_TINY)
               absorptionFactor = .86;
           if (this.SatelliteType == Satellite.SUBTYPE_ROCK && this.SatelliteSize == Satellite.SIZE_TINY)
               absorptionFactor = .97;
           if (this.SatelliteType == Satellite.SUBTYPE_SULFUR && this.SatelliteSize == Satellite.SIZE_TINY)
               absorptionFactor = .77;
           if (this.SatelliteType == Satellite.SUBTYPE_HADEAN && this.SatelliteSize == Satellite.SIZE_SMALL)
               absorptionFactor = .67;
           if (this.SatelliteType == Satellite.SUBTYPE_ICE && this.SatelliteSize == Satellite.SIZE_SMALL)
               absorptionFactor = .93;
           if (this.SatelliteType == Satellite.SUBTYPE_ROCK && this.SatelliteSize == Satellite.SIZE_SMALL)
               absorptionFactor = .96;
           if (this.SatelliteType == Satellite.SUBTYPE_HADEAN && this.SatelliteSize == Satellite.SIZE_MEDIUM)
               absorptionFactor = .67;
           if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA)
               absorptionFactor = .84;
           if (this.SatelliteType == Satellite.SUBTYPE_ICE &&
               (this.SatelliteSize == Satellite.SIZE_MEDIUM || this.SatelliteSize == Satellite.SIZE_LARGE))
               absorptionFactor = .86;
           
           if (this.SatelliteType == Satellite.SUBTYPE_OCEAN || this.SatelliteType == Satellite.SUBTYPE_GARDEN)
           {
               if (this.hydCoverage <= .20)
                 absorptionFactor = .95;
               if (this.hydCoverage > .20 && this.hydCoverage <= .50)
                 absorptionFactor = .92;
                
               if (this.hydCoverage > .50 && this.hydCoverage <= .90)
                 absorptionFactor = .88;
               
               if (this.hydCoverage > .90)
                  absorptionFactor = .84;
            }

           if (this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
              absorptionFactor = .77;

           if (this.SatelliteType == Satellite.SUBTYPE_CHTHONIAN)
               absorptionFactor = .97;

           return absorptionFactor + modifiers;
       }

       public virtual List<int> genMarginal(Dice ourBag)
        {
            var ret = new List<int>();
            int roll = ourBag.rng(3, 6, 0);
            if (roll == 3 || roll == 4)
            {
                roll = ourBag.rng(3, 6, 0);
                //for the difference
                if (roll >= 16) ret.Add(ATM_MARG_FLOURINE);
                else ret.Add(ATM_MARG_CHLORINE);

                //always true
                ret.Add(ATM_TOXIC_HIGHLY);
            }


            if (roll == 5 || roll == 6)
            {
                ret.Add(ATM_MARG_SULFUR);
                ret.Add(ATM_TOXIC_MILDLY);
            }

            if (roll == 7)
            {
                ret.Add(ATM_MARG_NITROGEN);
                ret.Add(ATM_TOXIC_MILDLY);
            }

            if (roll == 8 || roll == 9)
            {
                ret.Add(ATM_MARG_ORGANIC);
                roll = ourBag.rng(3, 6, 0);
                if (roll >= 17) ret.Add(ATM_TOXIC_HIGHLY); 
                else if (roll >= 12 && roll <= 16) ret.Add(ATM_TOXIC_MILDLY);
            }

            if (roll == 10 || roll == 11)
            {
                ret.Add(ATM_MARG_LOWOXY);
            }

            if (roll == 12 || roll == 13)
            {
                ret.Add(ATM_MARG_POLLUTANTS);
                roll = ourBag.rng(3, 6, 0);
                if (roll >= 9 && roll <= 11) ret.Add(ATM_TOXIC_MILDLY);
                else if (roll >= 17) ret.Add(ATM_TOXIC_HIGHLY);
            }

            if (roll == 14)
            {
                ret.Add(ATM_MARG_HIGHCO2);
                roll = ourBag.rng(3, 6, 0);
                if (roll >= 15) ret.Add(ATM_TOXIC_MILDLY);
            }

            if (roll == 15 || roll == 16)
            {
                ret.Add(ATM_MARG_HIGHOXY);
                roll = ourBag.rng(3, 6, 0);
                if (roll >= 15)
                {
                    ret.Add(ATM_TOXIC_MILDLY);
                    ret.Add(ATM_COND_FLAMP1);
                }
            }
            if (roll == 17 || roll == 18)
            {
                ret.Add(ATM_MARG_INERT);
            }


            return ret;

        }

        public virtual void generateOrbitalPeriod(double parentMass)
        {
            if (this.baseType == Satellite.BASETYPE_TERRESTIAL || this.baseType == Satellite.BASETYPE_GASGIANT)
            {
                this.orbitalPeriod = (Math.Sqrt(Math.Pow(this.orbitalRadius, 3) / ((this.mass * .0000030024584) + parentMass)) * 365.25);
            }
            if (this.baseType == Satellite.BASETYPE_MOON)
            {
                this.orbitalPeriod = .166 * Math.Sqrt(Math.Pow(this.orbitalRadius, 3) / (this.mass + parentMass));
            }
        }
        
       /// <summary>
       /// This function sets the size of a satelite.
       /// </summary>
       /// <param name="flag">The size to set to</param>
       /// <exception cref="Exception">It will throw an exception if you attempt to set Tiny on a Gas Giant</exception>
        public virtual void updateSize(int flag)
        {
            if (this.baseType == Satellite.BASETYPE_GASGIANT && flag == Satellite.SIZE_TINY)
                throw new Exception("You cannot have Tiny Gas Giants");

            this.SatelliteSize = flag;
            this.SatelliteSize = this.SatelliteSize;
        }
        
        /// <summary>
        /// A shortcut function to update both the type and size of a satellite
        /// </summary>
        /// <param name="typeFlag">The type of a satellite</param>
        /// <param name="sizeFlag">The size of a satellite</param>
        public virtual void updateTypeSize(int typeFlag, int sizeFlag)
        {
            this.updateType(typeFlag);
            this.updateSize(sizeFlag);
        }

        /// <summary>
        /// Returns the affinity of the planet
        /// </summary>
        /// <returns>The affinity (RVM + Habitability)</returns>
        public virtual int getAffinity()
        {
            return getHabitability() + RVM;
        }

        /// <summary>
        /// This factor calculates the differentation on a moon. Should only be invoked on a gas giant moon
        /// </summary>
        /// <param name="parentMass">The parent mass of the moon</param>
        /// <param name="ourBag">Dice object used for rolls</param>
        /// <returns>The differentation factor</returns>
        /// <exception cref="Exception">Will throw an exception if you invoke this on a satellite that isn't a moon</exception>
        public double getDifferentationFactor(double parentMass, Dice ourBag)
        {
            if (!(this.baseType == Satellite.BASETYPE_MOON))
                throw new Exception("Cannot call this except on a moon.");

            double value = 0;
            double factor = 0;

            if (parentMass > 3900) factor = .7; 

            if (parentMass > 2500 && parentMass < 3900) factor = .6;
            if (parentMass > 1000 && parentMass < 2500) factor = .5;
            if (parentMass > 300 && parentMass < 1000) factor = .4;
            if (parentMass < 300) factor = .3;


            value = (1 / Math.Sqrt(this.moonRadius * factor) * 100);
                        
            return value;
        }

        /// <summary>
        /// This function calculates the category given the atmospheric pressure
        /// </summary>
        /// <returns>The flag describing the pressure category</returns>
        public virtual int getAtmCategory()
        {
            if (this.atmPres < 0.01) return ATM_PRES_NONE;
            if (this.atmPres == 0.01) return ATM_PRES_TRACE;
            if (0.01 < this.atmPres && this.atmPres <= 0.5) return ATM_PRES_VERYTHIN;
            if (0.5 < this.atmPres && this.atmPres <= 0.8) return ATM_PRES_THIN;
            if (0.8 < this.atmPres && this.atmPres <= 1.2) return ATM_PRES_STANDARD;
            if (1.2 < this.atmPres && this.atmPres <= 1.5) return ATM_PRES_DENSE;
            if (1.5 < this.atmPres && this.atmPres <= 10) return ATM_PRES_VERYDENSE;
            if (this.atmPres > 10) return ATM_PRES_SUPERDENSE;

            return ERROR_ATM;
        }

        /// <summary>
        /// Describes the volcanic activity of this satelite
        /// </summary>
        /// <returns>The description (a string)</returns>
        public virtual string getVolDesc()
        {
            if (this.volActivity == Satellite.GEOLOGIC_NONE) return "None";
            if (this.volActivity == Satellite.GEOLOGIC_LIGHT) return "Light";
            if (this.volActivity == Satellite.GEOLOGIC_MODERATE) return "Moderate";
            if (this.volActivity == Satellite.GEOLOGIC_HEAVY) return "Heavy";
            if (this.volActivity == Satellite.GEOLOGIC_EXTREME) return "Extreme";

            return "Error";
        }

        /// <summary>
        /// Describes the tectonic activity of this satelite
        /// </summary>
        /// <returns>The description (a string)</returns>
        public virtual string getTecDesc()
        {
            if (this.tecActivity == Satellite.GEOLOGIC_NONE) return "None";
            if (this.tecActivity == Satellite.GEOLOGIC_LIGHT) return "Light";
            if (this.tecActivity == Satellite.GEOLOGIC_MODERATE) return "Moderate";
            if (this.tecActivity == Satellite.GEOLOGIC_HEAVY) return "Heavy";
            if (this.tecActivity == Satellite.GEOLOGIC_EXTREME) return "Extreme";

            return "Error";
        }
        
       /// <summary>
       /// Used to describe the satellite type within the object
       /// </summary>
       /// <returns>The description</returns>
        protected virtual string convSatelliteTypeToString()
        {
            if (this.SatelliteType == Satellite.SUBTYPE_AMMONIA)
                return "Ammonia";
            if (this.SatelliteType == Satellite.SUBTYPE_CHTHONIAN)
                return "Chthonian";
            if (this.SatelliteType == Satellite.SUBTYPE_GARDEN)
            {
                if (this.hydCoverage < 1)
                    return "Garden";
                else
                    return "Oceanic Garden";
            }
            if (this.SatelliteType == Satellite.SUBTYPE_GREENHOUSE)
            {
                if (this.hydCoverage > 0)
                    return "Wet Greenhouse";
                else
                    return "Dry Greenhouse";
            }
            if (this.SatelliteType == Satellite.SUBTYPE_HADEAN)
                return "Hadean";
            if (this.SatelliteType == Satellite.SUBTYPE_ICE)
                return "Ice";
            if (this.SatelliteType == Satellite.SUBTYPE_OCEAN)
                return "Ocean";
            if (this.SatelliteType == Satellite.SUBTYPE_ROCK)
                return "Rock";
            if (this.SatelliteType == Satellite.SUBTYPE_SULFUR)
                return "Sulfur";

            //base types
            if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                return "Asteroid Belt";
            if (this.baseType == Satellite.BASETYPE_EMPTY)
                return "Empty";
            if (this.baseType == Satellite.BASETYPE_TERRESTIAL)
                return "Terrestial";
            if (this.baseType == Satellite.BASETYPE_MOON)
                return "Moon";
            if (this.baseType == Satellite.BASETYPE_UNSET)
                return "Unset";
            if (this.baseType == Satellite.BASETYPE_GASGIANT)
                return "Gas Giant";

            return "???";

        }

        /// <summary>
        /// Describes the satelite type, given the subtype.
        /// </summary>
        /// <param name="flag">Subtype flag</param>
        /// <param name="hydCoverage">The hydrographic coverage of the planet</param>
        /// <returns>description of the satellite</returns>
        public virtual string convSatelliteTypeToString(double hydCoverage, int flag)
        {
            if (flag == Satellite.SUBTYPE_AMMONIA)
                return "Ammonia";
            if (flag == Satellite.SUBTYPE_CHTHONIAN)
                return "Chthonian";
            if (flag == Satellite.SUBTYPE_GARDEN)
            {
                if (hydCoverage < 1)
                    return "Garden";
                else
                    return "Oceanic Garden";
            }
            if (flag == Satellite.SUBTYPE_GREENHOUSE)
            {
                if (hydCoverage > 0)
                    return "Wet Greenhouse";
                else
                    return "Dry Greenhouse";
            }
            if (flag == Satellite.SUBTYPE_HADEAN)
                return "Hadean";
            if (flag == Satellite.SUBTYPE_ICE)
                return "Ice";
            if (flag == Satellite.SUBTYPE_OCEAN)
                return "Ocean";
            if (flag == Satellite.SUBTYPE_ROCK)
                return "Rock";
            if (flag == Satellite.SUBTYPE_SULFUR)
                return "Sulfur";

            //base types
            if (flag == Satellite.BASETYPE_ASTEROIDBELT)
                return "Asteroid Belt";
            if (flag == Satellite.BASETYPE_EMPTY)
                return "Empty";
            if (flag == Satellite.BASETYPE_TERRESTIAL)
                return "Terrestial";
            if (flag == Satellite.BASETYPE_MOON)
                return "Moon";
            if (flag == Satellite.BASETYPE_UNSET)
                return "Unset";
            return "???";

        }

        /// <summary>
        ///  Describe the size of the satelite of the self object
        /// </summary>
        /// <returns>Return the description (string)</returns>
        protected virtual string describeSatelliteSize()
        {
            if (this.baseType == Satellite.BASETYPE_MOON || this.baseType == Satellite.BASETYPE_TERRESTIAL)
            {
                if (this.SatelliteSize == Satellite.SIZE_TINY) return "Tiny";
                if (this.SatelliteSize == Satellite.SIZE_SMALL) return "Small";
                if (this.SatelliteSize == Satellite.SIZE_MEDIUM) return "Standard";
                if (this.SatelliteSize == Satellite.SIZE_LARGE) return "Large";
                return "???";
            }

            if (this.baseType == Satellite.BASETYPE_GASGIANT)
            {
                if (this.SatelliteSize == Satellite.SIZE_SMALL) return "Small";
                if (this.SatelliteSize == Satellite.SIZE_MEDIUM) return "Medium";
                if (this.SatelliteSize == Satellite.SIZE_LARGE) return "Large";
                return "???";
            }

            if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT)
            {
                if (this.SatelliteSize == Satellite.SIZE_TINY) return "Sparse";
                if (this.SatelliteSize == Satellite.SIZE_SMALL) return "Light";
                if (this.SatelliteSize == Satellite.SIZE_MEDIUM) return "Moderate";
                if (this.SatelliteSize == Satellite.SIZE_LARGE) return "Dense";
                return "???";
            }

            if (this.baseType == Satellite.BASETYPE_EMPTY)
            {
                return "";
            }

            return "???";
        }

        /// <summary>
        /// Describe the satellite size given a flag (used for access outside the object)
        /// </summary>
        /// <param name="flag">The flag describing the size of the satellite</param>
        /// <param name="baseType">The flag describing the base type of the satellite</param>
        /// <returns>The description</returns>
        public static string describeSatelliteSize(int baseType, int flag)
        {
            if (baseType == Satellite.BASETYPE_MOON || baseType == Satellite.BASETYPE_TERRESTIAL)
            {
                if (flag == Satellite.SIZE_TINY) return "Tiny";
                if (flag == Satellite.SIZE_SMALL) return "Small";
                if (flag == Satellite.SIZE_MEDIUM) return "Standard";
                if (flag == Satellite.SIZE_LARGE) return "Large";
                return "???";
            }

            if (baseType == Satellite.BASETYPE_GASGIANT)
            {
                if (flag == Satellite.SIZE_SMALL) return "Small";
                if (flag == Satellite.SIZE_MEDIUM) return "Medium";
                if (flag == Satellite.SIZE_LARGE) return "Large";
                return "???";
            }

            if (baseType == Satellite.BASETYPE_ASTEROIDBELT)
            {
                if (flag == Satellite.SIZE_TINY) return "Sparse";
                if (flag == Satellite.SIZE_SMALL) return "Light";
                if (flag == Satellite.SIZE_MEDIUM) return "Moderate";
                if (flag == Satellite.SIZE_LARGE) return "Dense";
                return "???";
            }

            return "???";
        }

        /// <summary>
        /// Returns the planetary diameter in KM, rather than Earth diameters
        /// </summary>
        /// <returns>double diameter in KM</returns>
        public virtual double diameterInKM()
        {
            return this.diameter * 12756;
        }

        public virtual string descCurrentClimate()
        {
            return this.getClimateDesc(this.getClimate(this.surfaceTemp));
        }

        /// <summary>
        /// This describes the climate given a flag.
        /// </summary>
        /// <param name="climate">The climate flag</param>
        /// <returns>The description (a string) of this climate</returns>
        public virtual string getClimateDesc(int climate)
        {
            
            if (climate == CLIMATE_NONE) 
                return "Climate: No atmosphere";
            
            if (climate == CLIMATE_FROZEN) 
                return "Climate: Frozen (Below -20° F)";
            if (climate == CLIMATE_VERYCOLD) 
                return "Climate: Very Cold (Between -20°F and 0°F)";

            if (climate == CLIMATE_COLD) 
                return "Climate: Cold (Between 0°F and 20°F)";

            if (climate == CLIMATE_CHILLY)
                return "Climate: Chilly (Between 20°F and 40°F)";

            if (climate == CLIMATE_COOL) 
                return "Climate: Cool (Between 40°F and 60°F)";

            if (climate == CLIMATE_NORMAL) 
                return "Climate: Normal (Between 60°F and 80°F)";

            if (climate == CLIMATE_WARM) 
                return "Climate: Warm (Between 80°F and 100°F)";

            if (climate == CLIMATE_TROPICAL) 
                return "Climate: Tropical (Between 100°F and 120°F)";
            
            if (climate == CLIMATE_HOT) 
                return "Climate: Hot (Between 120°F and 140°F)";
            
            if (climate == CLIMATE_VERYHOT)
                return "Climate: Very Hot (Between 140°F and 160°F)";

            if (climate == CLIMATE_INFERNAL)
                return "Climate: Infernal (Above 160°F)";

            else
                return "Climate: ????";
        }

        //calculates the climate given a temperature.
        // like the others, this is overrridable, if you wish to use a different table than the GURPS 4e one. 
        public virtual int getClimate(double temp)
        {
            if (this.atmMass <= 0.01) return CLIMATE_NONE;
            else
            {

                if (temp <= 244.50) return CLIMATE_FROZEN;
                if (temp > 244.50 && temp <= 255.50) return CLIMATE_VERYCOLD;
                if (temp > 255.50 && temp <= 266.50) return CLIMATE_COLD;
                if (temp > 266.50 && temp <= 278.50) return CLIMATE_CHILLY;
                if (temp > 278.50 && temp <= 289.50) return CLIMATE_COOL;
                if (temp > 289.50 && temp <= 300.50) return CLIMATE_NORMAL;
                if (temp > 300.50 && temp <= 311.50) return CLIMATE_WARM;
                if (temp > 311.50 && temp <= 322.50) return CLIMATE_TROPICAL;
                if (temp > 322.50 && temp <= 333.50) return CLIMATE_HOT;
                if (temp > 333.50 && temp <= 344.50) return CLIMATE_VERYHOT;
                if (temp > 344.50) return CLIMATE_INFERNAL;
            }


            return ERROR_GENERIC;
        }

        /// <summary>
        /// This describes the current atmospheric category
        /// </summary>
        /// <returns>A string description of the category</returns>
        public virtual string getDescAtmCategory()
        {

            if (this.getAtmCategory() == ATM_PRES_NONE)
                return "None";
            if (this.getAtmCategory() == ATM_PRES_TRACE)
                return "Trace";
            if (this.getAtmCategory() == ATM_PRES_VERYTHIN)
                return "Very Thin";
            if (this.getAtmCategory() == ATM_PRES_THIN)
                return "Thin";
            if (this.getAtmCategory() == ATM_PRES_STANDARD)
                return "Standard";
            if (this.getAtmCategory() == ATM_PRES_DENSE)
                return "Dense";
            if (this.getAtmCategory() == ATM_PRES_VERYDENSE)
                return "Very Dense";
            if (this.getAtmCategory() == ATM_PRES_SUPERDENSE)
                return "Superdense";

            return "???";
        }

        /// <summary>
        /// Converting the flags describing various atmospheric conditions
        /// </summary>
        /// <param name="code">The code to be described</param>
        /// <returns>A description of the code</returns>
        public virtual string convAtmCodeToString(int code)
        {
            String ret = "";
            
            //condtionals
            if (code == ATM_COND_CORROSIVE) return "Corrosive";
            if (code == ATM_COND_FLAMP1) return "Flammability Class +1";
            if (code == ATM_COND_SUFFOCATING) return "Suffocating";

            //marginal
            if (code == ATM_MARG_CHLORINE) return "Marginal: Chlorine";
            if (code == ATM_MARG_FLOURINE) return "Marginal: Flourine";
            if (code == ATM_MARG_HIGHCO2) return "Marginal: High Carbon Dioxide";
            if (code == ATM_MARG_HIGHOXY) return "Marginal: High Oxygen";
            if (code == ATM_MARG_INERT) return "Marginal: Inert Gases";
            if (code == ATM_MARG_LOWOXY) return "Marginal: Low Oxygen";
            if (code == ATM_MARG_NITROGEN) return "Marginal: Nitrogen";
            if (code == ATM_MARG_ORGANIC) return "Marginal: Organic Toxins";
            if (code == ATM_MARG_POLLUTANTS) return "Marginal: Pollutants";
            if (code == ATM_MARG_SULFUR) return "Marginal: Sulfur";

            //toxic
            if (code == ATM_TOXIC_HIGHLY) return "Highly Toxic";
            if (code == ATM_TOXIC_LETHALLY) return "Lethally Toxic";
            if (code == ATM_TOXIC_MILDLY) return "Mildly Toxic";

            return ret;

        }

        /// <summary>
        /// Convert the description flag to a string for description
        /// </summary>
        /// <param name="i">The flag</param>
        /// <returns>The string describing the flag</returns>
        public virtual string convDescCodeToString(int i)
        {
            if (i == Satellite.DESC_FAINTRINGSYS) return "Faint Ring System";
            if (i == Satellite.DESC_RAD_HIGHBACK) return "High Background Radiation";
            if (i == Satellite.DESC_RAD_LETHALBACK) return "Lethal Background Radiation";
            if (i == Satellite.DESC_SPECRINGSYS) return "Spectular Ring System";
            if (i == Satellite.DESC_SUBSURFOCEAN) return "Subsurface Ocean";

            return "???";
        }

        /// <summary>
        /// Generates the eccentricity of the planet's orbit around it's primary.
        /// </summary>
        /// <param name="flag">The gas giant flag</param>
        /// <param name="snowLine">Location of the snow line</param>
        /// <param name="ourDice">Our dice object</param>
        public virtual void getPlanetEccentricity(int flag, double snowLine, Dice ourDice)
        {

            int roll = ourDice.gurpsRoll();
            double mod = 0;

            if (this.selfID == 0 && this.baseType == Satellite.BASETYPE_GASGIANT && flag == Star.GASGIANT_EPISTELLAR)
                roll = roll - 6;
            if (this.baseType == Satellite.BASETYPE_GASGIANT && flag == Star.GASGIANT_ECCENTRIC && this.orbitalRadius < snowLine)
                roll = roll + 4;
            if (flag == Star.GASGIANT_CONVENTIONAL)
                roll = roll - 6;
            if (roll <= 3) this.orbitalEccent = .0;
            else if (roll >= 4 && roll <= 6) this.orbitalEccent = .05;
            else if (roll >= 7 && roll <= 9) this.orbitalEccent = .1;
            else if (roll >= 10 && roll <= 11) this.orbitalEccent = .15;
            else if (roll == 12) this.orbitalEccent = .2;
            else if (roll == 13) this.orbitalEccent = .3;
            else if (roll == 14) this.orbitalEccent = .4;
            else if (roll == 15) this.orbitalEccent = .5;
            else if (roll == 16) this.orbitalEccent = .6;
            else if (roll == 17) this.orbitalEccent = .7;
            else if (roll >= 18) this.orbitalEccent = .8;

            if (roll <= 11 && roll != 3)
            {
                mod = ourDice.rng(1, 5, -2) * .01;
            }
            else if (roll >= 12)
            {
                mod = ourDice.rng(1, 10, -5) * .01;
            }

            this.orbitalEccent = this.orbitalEccent + mod;
        }

        /// <summary>
        /// Generate (and store) the orbital velocity for an object (sidereal period)
        /// </summary>
        /// <param name="ourBag">Dice object</param>
        public void generateOrbitalVelocity(Dice ourBag)
        {
            if (this.tideTotal < 50)
            {
                int roll = ourBag.gurpsRoll();
                int temp = (int)Math.Floor(roll + this.tideTotal);

                if (this.SatelliteSize == Satellite.SIZE_TINY) temp = temp + 18;
                if (this.SatelliteSize == Satellite.SIZE_SMALL) temp = temp + 14;
                if (this.SatelliteSize == Satellite.SIZE_MEDIUM) temp = temp + 10;
                if (this.SatelliteSize == Satellite.SIZE_LARGE) temp = temp + 6;

                if ((roll >= 16) || (temp >= 36))
                {

                    switch (ourBag.rng(2, 6, 0))
                    {
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            this.siderealPeriod = (temp / 24.0);
                            break;
                        case 7:
                            this.siderealPeriod = (ourBag.rng(1, 6) * 2);
                            break;
                        case 8:
                            this.siderealPeriod = (ourBag.rng(1, 6) * 5);
                            break;
                        case 9:
                            this.siderealPeriod = (ourBag.rng(1, 6) * 10);
                            break;
                        case 10:
                            this.siderealPeriod = (ourBag.rng(1, 6) * 20);
                            break;
                        case 11:
                            this.siderealPeriod = (ourBag.rng(1, 6) * 50);
                            break;
                        case 12:
                            this.siderealPeriod = (ourBag.rng(1, 6) * 100);
                            break;
                    }



                }
                else if (!this.isTideLocked) this.siderealPeriod = (double) (temp / 24.0);

                if (this.isTideLocked) this.siderealPeriod = this.orbitalPeriod;
            }
            if (this.siderealPeriod >= this.orbitalPeriod)
            {
                this.isTideLocked = true;
            }
        }

        /// <summary>
        /// This function creates a generic name for satellites and moons
        /// </summary>
        /// <param name="parentName">The star's name</param>
        /// <param name="systemName">The system's name</param>
        public virtual void genGenericName(String parentName, String systemName)
        {
            base.genGenericName();
            if (this.baseType == Satellite.BASETYPE_TERRESTIAL || 
                this.baseType == Satellite.BASETYPE_GASGIANT)
            {
                if (this.parentID >= 9000 && this.parentID <= 9050)
                    this.name = parentName + (this.selfID + 1);
                else
                {
                    if (this.parentID == Satellite.ORBIT_PRISEC)
                        this.name = systemName + "-AB" + (this.selfID + 1);
                    if (this.parentID == Satellite.ORBIT_PRISECTRI)
                        this.name = systemName + "-ABC" + (this.selfID + 1);
                    if (this.parentID == Satellite.ORBIT_PRITRI)
                        this.name = systemName + "-AC" + (this.selfID + 1);
                    if (this.parentID == Satellite.ORBIT_SECCOM)
                        this.name = systemName + "-BD" + (this.selfID + 1);
                    if (this.parentID == Satellite.ORBIT_SECTRI)
                        this.name = systemName + "-BC" + (this.selfID + 1);
                    if (this.parentID == Satellite.ORBIT_TRICOM)
                        this.name = systemName + "-CE" + (this.selfID + 1);
                }


            }
            if (this.baseType == Satellite.BASETYPE_MOON)
            {
                string[] moonStr = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV" };
                this.name = parentName + moonStr[this.selfID];
            }
        }

        /// <summary>
        /// Creaates moons around sateliets according to GURPS 4e rules.
        /// </summary>
        /// <param name="sysName">The system name</param>
        /// <param name="ourBag">Dice object used in rolling</param>
        /// <param name="flag">The OptionCont flag describing where we put moon orbits</param>
        public void createMoons(string sysName, Dice ourBag, int flag = 0)
        {
            String[] moonletNames = { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu",
                                      "Nu", "Ksi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega" };


            //initiate objects
            int currMoonlet = 0;
            var occupiedOrbits = new List<double>();
            double currOrbit;

            int mods, numRoll, roll; //roll variables
            
            //terrestial
            if (this.baseType == BASETYPE_TERRESTIAL)
            {
                //moonlets
                numRoll = ourBag.rng(1, 6, -2);
               
                //modifiers for moonlets
                if (this.SatelliteSize == Satellite.SIZE_TINY)
                    numRoll = numRoll - 2;
                if (this.SatelliteSize == Satellite.SIZE_SMALL)
                    numRoll = numRoll - 1;
                if (this.SatelliteSize == Satellite.SIZE_LARGE)
                    numRoll = numRoll + 1;
                if (this.orbitalRadius <= 1.5 && .75 < this.orbitalRadius)
                    numRoll = numRoll - 1;
                if (this.orbitalRadius <= .75 && .5 < this.orbitalRadius)
                    numRoll = numRoll - 3;

                if (this.orbitalRadius <= .5) numRoll = 0; //set to 0, since we cannot have any in this range

                if (numRoll > 0){
                    for (int i = 0; i < numRoll; i++)
                    {
                        do
                        {
                            roll = ourBag.rng(1, 6, 4);
                            currOrbit = (roll / 4.0);
                        } while ((scanOccupiedOrbits(occupiedOrbits, currOrbit)));

                        occupiedOrbits.Add(currOrbit);
                        this.innerMoonlets.Add(new Moonlet(this.selfID, i, currOrbit, moonletNames[currMoonlet]));
                        this.innerMoonlets[i].orbitalRadius = this.innerMoonlets[i].planetRadius * this.diameter;
                        currMoonlet++;
                    }
                }

                //major moons
                numRoll = ourBag.rng(1, 6, -4);

                if (this.SatelliteSize == Satellite.SIZE_TINY)
                    numRoll = numRoll - 2;
                if (this.SatelliteSize == Satellite.SIZE_SMALL)
                    numRoll = numRoll + 1;
                if (this.SatelliteSize == Satellite.SIZE_LARGE)
                    numRoll = numRoll - 1;
                if (this.orbitalRadius <= 1.5 && .75 < this.orbitalRadius)
                    numRoll = numRoll - 1;
                
                if (this.orbitalRadius <= .75) numRoll = 0;

                if (OptionCont.getNumberOfMoonsOverGarden() != -1 && this.SatelliteType == SUBTYPE_GARDEN)
                    numRoll = OptionCont.getNumberOfMoonsOverGarden();

                if (numRoll > 0){
                    for (int i = 0; i < numRoll; i++)
                    {
                        int size = Satellite.SIZE_MEDIUM;

                        roll = ourBag.rng(3, 6, 0);
                        if (this.SatelliteSize == Satellite.SIZE_TINY) size = Satellite.SIZE_TINY;

                        if (this.SatelliteSize == Satellite.SIZE_SMALL) size = Satellite.SIZE_TINY;

                        if (this.SatelliteSize == Satellite.SIZE_MEDIUM)
                        {
                            if (roll >= 10) size = Satellite.SIZE_SMALL;
                            else size = Satellite.SIZE_TINY;
                        }

                        if (this.SatelliteSize == Satellite.SIZE_LARGE)
                        {
                            if (roll >= 15) size = Satellite.SIZE_MEDIUM;
                            if (roll >= 12 && roll <= 14) size = Satellite.SIZE_SMALL;
                            size = Satellite.SIZE_TINY;
                        }

                        do
                        {
                            mods = 0;
                            if (this.SatelliteType - size == 2) mods = 2;
                            if (this.SatelliteType - size == 1) mods = 4;

                            if (flag == OptionCont.MOON_BOOK) roll = ourBag.rng(2, 6, mods);
                            if (flag == OptionCont.MOON_BOOKHIGH) roll = ourBag.rng(1, 6, mods + 6);
                            if (flag == OptionCont.MOON_EXPAND) roll = ourBag.rng(2, 10, mods);
                            if (flag == OptionCont.MOON_EXPANDHIGH) roll = ourBag.rng(2, 6, mods + 12);

                            currOrbit = roll * 2.5;

                        } while ((scanOccupiedOrbits(occupiedOrbits, currOrbit)) && !(withinOtherOrbits(occupiedOrbits, currOrbit, 5.0)));

                        occupiedOrbits.Add(currOrbit);
                        this.majorMoons.Add(new Satellite(Satellite.ORBIT_PLANET, i, (currOrbit * this.diameter), i, Satellite.BASETYPE_MOON));
                        this.majorMoons[i].updateSize(size);
                        this.majorMoons[i].moonRadius = currOrbit;
                        this.majorMoons[i].blackbodyTemp = this.blackbodyTemp;
                        this.majorMoons[i].parentDiam = this.diameter * 12756.2;
                    }
                }
            }

            //gas giant
            if (this.baseType == Satellite.BASETYPE_GASGIANT)
            {
                //moonlets (inner)
                numRoll = ourBag.rng(2, 6, 0);
                if (this.orbitalRadius <= .1)
                    numRoll = numRoll - 10;
                else if (this.orbitalRadius > .1 && .5 >= this.orbitalRadius)
                    numRoll = numRoll - 8;
                else if (this.orbitalRadius > .5 && .75 >= this.orbitalRadius)
                    numRoll = numRoll - 6;
                else if (this.orbitalRadius > .75 && 1.5 >= this.orbitalRadius)
                    numRoll = numRoll - 3;

                if (numRoll > 0)
                {
                    for (int i = 0; i < numRoll; i++)
                    {
                        currOrbit = ourBag.rng(1, 6, 4) * .25;
                        this.innerMoonlets.Add(new Moonlet(this.selfID, currMoonlet, currOrbit, moonletNames[currMoonlet]));
                        this.innerMoonlets[i].orbitalRadius = currOrbit * this.diameter;
                        currMoonlet++;
                    }
                }

                //major moons
                numRoll = ourBag.rng(1, 6, 0);
                if (this.orbitalRadius <= .1)
                    numRoll = numRoll - 6;
                else if (this.orbitalRadius > .1 && .5 >= this.orbitalRadius)
                    numRoll = numRoll - 5;
                else if (this.orbitalRadius > .5 && .75 >= this.orbitalRadius)
                    numRoll = numRoll - 4;
                else if (this.orbitalRadius > .75 && 1.5 >= this.orbitalRadius)
                    numRoll = numRoll - 1;

                if (numRoll > 0)
                {
                    for (int i = 0; i < numRoll; i++)
                    {
                        int size = Satellite.SIZE_MEDIUM;

                        roll = ourBag.gurpsRoll();
                        if (roll >= 15) size = Satellite.SIZE_MEDIUM;
                        if (roll >= 12 && roll <= 14) size = Satellite.SIZE_SMALL;
                        if (roll < 12) size = Satellite.SIZE_TINY;


                        do
                        {
                            roll = ourBag.rng(3, 6, 3);
                            if (roll >= 15) roll = roll + ourBag.rng(2, 6, 0);
                            currOrbit = roll / 2.0;

                        } while ((scanOccupiedOrbits(occupiedOrbits, currOrbit)) && !(withinOtherOrbits(occupiedOrbits, currOrbit, 1.0)));

                        occupiedOrbits.Add(currOrbit);
                        this.majorMoons.Add(new Satellite(Satellite.ORBIT_PLANET, i, (currOrbit * this.diameter), i, Satellite.BASETYPE_MOON));
                        this.majorMoons[i].updateSize(size);
                        this.majorMoons[i].moonRadius = currOrbit;
                        this.majorMoons[i].blackbodyTemp = this.blackbodyTemp;
                        this.majorMoons[i].parentDiam = this.diameter * 12756.2;
                    }
                }

                //Captured Moons
                numRoll = ourBag.rng(1, 6, 0);
                if (this.orbitalRadius <= .5)
                    numRoll = numRoll - 6;
                else if (this.orbitalRadius > .5 && .75 >= this.orbitalRadius)
                    numRoll = numRoll - 5;
                else if (this.orbitalRadius > .75 && 1.5 >= this.orbitalRadius)
                    numRoll = numRoll - 4;
                else if (this.orbitalRadius > 1.5 && 3 >= this.orbitalRadius)
                    numRoll = numRoll - 1;

                if (numRoll > 0)
                {
                    for (int i = 0; i < numRoll; i++)
                    {
                        do
                        {
                            roll = ourBag.rng(1, 280, 20);
                            currOrbit = roll;
                        } while ((scanOccupiedOrbits(occupiedOrbits, currOrbit)));
                        occupiedOrbits.Add(currOrbit);

                        this.outerMoonlets.Add(new Moonlet(this.selfID, currMoonlet, currOrbit, moonletNames[currMoonlet]));
                        this.outerMoonlets[i].orbitalRadius = currMoonlet * this.diameter;
                        currMoonlet++;
                    }
                }

            }
            


            if (this.baseType == Satellite.BASETYPE_GASGIANT)
            {
                if (this.innerMoonlets.Count >= 10)
                {
                    this.updateDescListing(Satellite.DESC_SPECRINGSYS);
                }
                if (this.innerMoonlets.Count >= 6 && this.innerMoonlets.Count < 9)
                {
                    this.updateDescListing(Satellite.DESC_FAINTRINGSYS);
                }
            }
        }

        /// <summary>
        ///  This function describes the atm in a string.
        /// </summary>
        /// <returns></returns>
        public string descAtm()
        {
            List<string> dA = new List<string>();

            //find conditions
            foreach (int i in this.atmCate)
            {
                if (i > ATM_BASE_COND && i < (COND_INCREMENT + ATM_BASE_COND)) dA.Add("Special Condition");
                if (i > ATM_BASE_MARGINAL && i < (MARGINAL_INCREMENT + ATM_BASE_MARGINAL)) dA.Add("Marginal");
                if (i > ATM_BASE_TOXIC && i < (TOXIC_INCREMENT + ATM_BASE_TOXIC)) dA.Add("Toxic");
            }

            string desc = "";
            for (int i = 0; i < dA.Count; i++)
            {
                desc += dA[i];
                if ((i + 1) < dA.Count) desc += " & ";
            }

            return desc;
        }

        /// <summary>
        /// Updates the description of the atmosphere
        /// </summary>
        /// <param name="flag">The flag we're adding to the atmosphere</param>
        public void updateDescListing(int flag)
        {
            this.descListing.Add(flag);
        }

        /// <summary>
        /// Describes a planet in the format of Large(Rock) for example
        /// </summary>
        /// <returns>string describing size(type)</returns>
        public string descSizeType()
        {
            return (this.describeSatelliteSize() + "(" + this.convSatelliteTypeToString() + ")");
        }

        /// <summary>
        /// A helper function to scan for occupied orbits (during moon generation)
        /// </summary>
        /// <param name="occuOrbits">The list of occupied orbits</param>
        /// <param name="current">The orbit to add</param>
        /// <returns>True if there is an orbit conflict, false otherwise</returns>
        protected static bool scanOccupiedOrbits(List<double> occuOrbits, double current){
            foreach (double orbit in occuOrbits){
                if (orbit == current) return true;
            }

            return false;
        } 

         /// <summary>
         /// Another helper function: makes sure that the orbit is not within the safety margin
         /// </summary>
         /// <param name="occuOrbits">The list of current objects</param>
         /// <param name="current">the orbit to be added</param>
         /// <param name="margin">The margin of safety</param>
         /// <returns></returns>
         protected static bool withinOtherOrbits(List<double> occuOrbits, double current, double margin)
         {
            foreach (double orbit in occuOrbits)
            {
                if (orbit + margin <= current) return true;
            }

            return false;
        }

         /// <summary>
         /// The ToString Object for our planet or moon
         /// </summary>
         /// <returns>A description of the object</returns>
         public override string ToString()
         {
             String ret ="";
             String nL = Environment.NewLine;
             String spacing = "    ";
             int numOfDigits = OptionCont.numberOfDecimal;
             int numOfSmallDigits = 2;

             if (this.rotationalPeriod < 0)
             {
                 this.rotationalPeriod = this.rotationalPeriod * -1;
                 this.retrogradeMotion = true;
             }
             
             //short cut.
             if (this.baseType == Satellite.BASETYPE_UNSET)
             {
                 ret = "[ORBIT " + (this.selfID + 1) + "] Unset Orbital at " + Math.Round(this.orbitalRadius,numOfDigits)  + " AU.";
                 return ret;
             }

             if (this.baseType == Satellite.BASETYPE_EMPTY)
             {
                 ret = "[ORBIT " + (this.selfID + 1) + "] Empty Orbital at " + Math.Round(this.orbitalRadius, numOfDigits) + " AU.";
                 return ret;
             }
             
             if (this.baseType == Satellite.BASETYPE_ASTEROIDBELT)
             {
                ret = "[ORBIT " + (this.selfID + 1) + "]";

                if (OptionCont.expandAsteroidBelt)
                    ret = ret + nL + spacing + "Asteroid Belt (" + this.describeSatelliteSize() + ")";
                else
                    ret = ret + nL + spacing + "Asteroid Belt";

                ret = ret + " and orbits at " + Math.Round(this.orbitalRadius, numOfDigits) + " AU.";
                ret = ret + nL + spacing + "Blackbody Temperature is " + Math.Round(this.blackbodyTemp, numOfSmallDigits) + "K";
                ret = ret + nL + spacing + "RVM: " + this.RVM + " (" + this.getRVMDesc() + ")";
                return ret;
             }

             //main block
             if (this.baseType == Satellite.BASETYPE_MOON)
             {
                 ret = "[MOON " + (this.selfID + 1) + "]";
                 ret = ret + nL + spacing + this.name + " is a ";
             }
             else
             {
                 ret = "[ORBIT " + (this.selfID + 1) + "]";
                 ret = ret + nL + spacing + this.name + " is a ";
             }

             if (!(this.baseType == Satellite.BASETYPE_GASGIANT))
                 ret = ret + this.describeSatelliteSize() + " (" + this.convSatelliteTypeToString() + ")";
             else 
                 ret = ret + "Gas Giant (" + this.describeSatelliteSize() + ")";

             if (!(this.baseType == Satellite.BASETYPE_MOON))
             {
                 ret = ret + " and orbits at " + Math.Round(this.orbitalRadius, numOfDigits) + " AU";
                 if (this.retrogradeMotion) ret = ret + " in a retrograde manner.";
                 else ret = ret + ".";
             }
             else
             {
                 ret = ret + " and orbits at " + Math.Round(this.orbitalRadius, numOfDigits) + " earth diameters.";
                 ret = ret + nL + spacing + "Planetary Diameters: " + this.moonRadius;
                 if (this.retrogradeMotion) ret = ret + nL + spacing + "Orbits in a retrograde manner.";
             }
             
             ret = ret + nL + spacing + "Blackbody Temperature is " + Math.Round(this.blackbodyTemp, numOfSmallDigits) + "K";

             ret = ret + nL + spacing + "Orbital Parent: " + Star.getDescSelfFlag(this.parentID) + ".";

             ret = ret + nL;

             //atmospheric data
             if (this.baseType == Satellite.BASETYPE_MOON || this.baseType == Satellite.BASETYPE_TERRESTIAL)
             {
                 ret = ret + nL + spacing + "Atmospheric Data:";
                 ret = ret + nL + spacing + "Pressure: " + this.getDescAtmCategory() + " (" + Math.Round(this.atmPres, (numOfSmallDigits + 1)) + " atm).";
                 ret = ret + nL + spacing + "Atmospheric Mass: " + this.atmMass + " standard atmospheric mass";
                 
                 if (this.atmCate.Count > 0){
                     ret = ret + nL + spacing + "Atm Notes: ";
                    for(int i = 0; i < this.atmCate.Count; i++)
                    {
                        if (i != this.atmCate.Count - 1)
                         ret = ret + this.convAtmCodeToString(this.atmCate[i]) + ", ";
                        else
                         ret = ret + this.convAtmCodeToString(this.atmCate[i]);
                    }
                }

                 ret = ret + nL;

                 //climate data.
                 ret = ret + nL + spacing + "Climate Data:";

                 if (this.isTideLocked)
                 {
                     double temp = this.surfaceTemp * this.dayFaceMod;
                     ret = ret + nL + spacing + "Day Side Surface Temperature: " + this.tempInKelFarCel(temp);
                     if (this.atmPres > 0)
                        ret = ret + nL + spacing + "Day Side Climate: " + this.getClimateDesc(this.getClimate(temp));

                     temp = this.surfaceTemp * this.nightFaceMod;
                     ret = ret + nL + spacing + "Night Side Surface Temperature: " + this.tempInKelFarCel(temp);
                     if (this.atmPres > 0)
                        ret = ret + nL + spacing + "Night Side Climate: " + this.getClimateDesc(this.getClimate(temp));
                     
                 }
                 else
                 {
                     ret = ret + nL + spacing + "Surface Temperature: " + this.tempInKelFarCel(this.surfaceTemp);
                     if (this.atmPres > 0)
                         ret = ret + nL + spacing + this.getClimateDesc(this.getClimate(this.surfaceTemp));
                 }
                 ret = ret + nL;
             }

             //physical properties
             ret = ret + nL + spacing + "Physical Properties:";
             ret = ret + nL + spacing + "Density: " + this.density + " Earth densities (" + (this.density * CONVFAC_DENSITY) + " g/cc)";
             ret = ret + nL + spacing + "Diameter: " + Math.Round(this.diameter, 3) + " Earth diameters (" + (Math.Round(this.diameter * CONVFAC_DIAMETER,3)) + " km)";
             ret = ret + nL + spacing + "Mass: " + Math.Round(this.mass, 3) + " Earth masses";
             ret = ret + nL + spacing + "Axial Tilt: " + this.axialTilt + "°";
             ret = ret + nL + spacing + "Gravity: " + Math.Round(this.gravity, 3) + " Earth gravities (" + Math.Round(this.gravity * CONVFAC_GRAVITY, 3) + " m/s²)";
             ret = ret + nL + spacing + "RVM: " + this.RVM + " (" + this.getRVMDesc() + "), Tectonic: " + this.getTecDesc() + ", Volcanic: " + this.getVolDesc();
             ret = ret + nL + spacing + "Hydrographic Coverage: " + String.Format("{0:P}", this.hydCoverage);

             //orbital properties
             ret = ret + nL;
             ret = ret + nL + spacing + "Orbital Properties:";
             ret = ret + nL + spacing + "Orbital Period: " + Math.Round(this.orbitalPeriod, 3) + "d (" + Math.Round(this.orbitalPeriod/365.25,3) + "y).";
             
             if (!this.isTideLocked){
                 ret = ret + nL + spacing + "Sidereal Period: " + Math.Round(this.siderealPeriod, 3) + "d.";
                 ret = ret + " Solar Day: " + Math.Round(this.rotationalPeriod,3) + "d.";
             }

             //tide locked.
             if (this.isTideLocked && !this.isResonant)
                 ret = ret + nL + spacing + "This satellite is tide locked.";
             else if (this.isResonant)
                 ret = ret + nL + spacing + "This satellite is locked in a resonant pattern.";

             //tide data
             if (this.hydCoverage > 0 || OptionCont.alwaysDisplayTidalData)
             {
                 ret = ret + nL;
                 ret = ret + nL + spacing + "Tidal Data:";
                 if (OptionCont.getVerboseOutput() || OptionCont.alwaysDisplayTidalData) ret = ret + nL + spacing + "Total tidal force: " + Math.Round(this.tideTotal, 3) + " units";
                 if (OptionCont.getVerboseOutput() || OptionCont.alwaysDisplayTidalData) ret = ret + nL;

                 ret = ret + this.displayTidalData() + nL;
             }

             //description block

             if (this.descListing.Count > 0)
             {
                 ret = ret + nL;
                 ret = ret + nL + spacing + "Special Description Notes: ";
                 ret = ret + " ";
                 for (int i = 0; i < this.descListing.Count; i++)
                 {
                     if (i == (this.descListing.Count - 1))
                        ret = ret + convDescCodeToString(this.descListing[i]) + " ";
                     else
                         ret = ret + convDescCodeToString(this.descListing[i]) + ", ";
                 }
             }

             //moon block
             if (this.baseType == Satellite.BASETYPE_GASGIANT)
             {
                 ret = ret + nL;
                 if (this.innerMoonlets.Count > 0)
                 {
                     ret = ret + nL + spacing + "Inner Moonlets:";
                     ret = ret + nL + spacing;
                     foreach (Moonlet m in this.innerMoonlets)
                     {
                         ret = ret + m + nL + spacing;
                     }
                 }
                  else{
                     ret = ret + nL + spacing + "Inner Moonlets: 0";
                     ret = ret + nL;
                  }

                 if (this.outerMoonlets.Count > 0)
                 {
                     ret = ret + nL + spacing + "Outer Moonlets:";
                     ret = ret + nL + spacing;
                     foreach (Moonlet m in this.outerMoonlets)
                     {
                         ret = ret + m + " " + nL + spacing;
                     }
                 }
                 else{
                    ret = ret + nL + spacing + "Outer Moonlets: 0";
                    ret = ret + nL;
                 }

                 //major moons
                 if (this.majorMoons.Count > 0)
                 {
                     ret = ret + nL + spacing + "Major Moons" + nL;
                     foreach (Satellite s in this.majorMoons)
                         ret = ret + spacing + s + nL;
                 }
                 else
                 {
                     ret = ret + nL + spacing + "Major Moons: 0";
                     ret = ret + nL;
                 }
             }

             if (this.baseType == Satellite.BASETYPE_TERRESTIAL)
             {
                 if (this.innerMoonlets.Count > 0)
                 {
                     ret = ret + nL + spacing + "Inner Moonlets:";
                     ret = ret + nL + spacing;
                     foreach (Moonlet m in this.innerMoonlets)
                     {
                         ret = ret + m + " " + nL + spacing;
                     }
                 }
                 else
                 {
                     ret = ret + nL + spacing + "Inner Moonlets: 0";
                     ret = ret + nL;
                 }

                 //major moons
                 if (this.majorMoons.Count > 0)
                 {
                     ret = ret + nL + spacing + "Major Moons" + nL;
                     foreach (Satellite s in this.majorMoons)
                         ret = ret + nL + s + nL;
                 }
                 else
                 {
                     ret = ret + nL + spacing + "Major Moons: 0";
                     ret = ret + nL;
                 }
             }

             return ret;
         }

         /// <summary>
         /// This lists Kelvin, Farenheit and Celsius temperatures. 
         /// </summary>
         /// <param name="temp">The temperature in Kelvin</param>
         /// <returns>A string describing all three</returns>
         protected string tempInKelFarCel(double temp)
         {
             String ret = "";
             ret = ret + Math.Round(temp, 3) + "K, ";
             ret = ret + Math.Round(((temp - 273.15) * 1.8 ) + 32,3) + "°F, ";
             ret = ret + Math.Round(temp - 273.15, 3) + "°C";
             return ret;

         }

         /// <summary>
         /// Calculates the total tidal force acting on an object
         /// </summary>
         /// <param name="sysAge">The age of the system</param>
         /// <returns>The Tidal Force</returns>
         public double totalTidalForce(double sysAge)
         {
             double val = 0.0;
             foreach (KeyValuePair<int, double> tideData in this.tideForce)
             {
                 if (!((tideData.Key >= TIDE_MOON1 && tideData.Key <= TIDE_MOON10) && OptionCont.ignoreLunarTidesOnGardenWorlds))
                     val = val + tideData.Value;
             }

             val = (val * sysAge) / this.mass;
             return val;
         }

         /// <summary>
         /// Output formatted tidal data 
         /// </summary>
         /// <returns>Formatted Tidal Data</returns>
         public string displayTidalData()
         {
             string ret = "";
             string nL = Environment.NewLine;
             string spacing = "    ";
             string ourFlag = " ";
             string toBeAdded = "";
             bool addStr;
             double tideVal;

             foreach (KeyValuePair<int, double> tideData in this.tideForce)
             {
                 addStr = true;
                 if (tideData.Key == Satellite.TIDE_MOON1) ourFlag = "moon one";
                 if (tideData.Key == Satellite.TIDE_MOON2) ourFlag = "moon two";
                 if (tideData.Key == Satellite.TIDE_MOON3) ourFlag = "moon three";
                 if (tideData.Key == Satellite.TIDE_MOON4) ourFlag = "moon four";
                 if (tideData.Key == Satellite.TIDE_MOON5) ourFlag = "moon five";
                 if (tideData.Key == Satellite.TIDE_MOON6) ourFlag = "moon six";
                 if (tideData.Key == Satellite.TIDE_MOON7) ourFlag = "moon seven";
                 if (tideData.Key == Satellite.TIDE_MOON8) ourFlag = "moon eight";
                 if (tideData.Key == Satellite.TIDE_MOON9) ourFlag = "moon nine";
                 if (tideData.Key == Satellite.TIDE_MOON10) ourFlag = "moon ten";

                 if (tideData.Key == Satellite.TIDE_PRIMARYSTAR) ourFlag = "the primary star";
                 if (tideData.Key == Satellite.TIDE_SECONDARYSTAR) ourFlag  = "the secondary star";
                 if (tideData.Key == Satellite.TIDE_TRINARYSTAR) ourFlag = "the trinary star";
                 if (tideData.Key == Satellite.TIDE_SECCOMPSTAR) ourFlag = "the secondary companion star";
                 if (tideData.Key == Satellite.TIDE_TRICOMPSTAR) ourFlag = "the trinary companion star";
                 if (tideData.Key == Satellite.TIDE_PARPLANET) ourFlag = "parent planet";

                 tideVal = tideData.Value;
                 toBeAdded = nL + spacing + "Tidal Force generated by " + ourFlag + " is " + String.Format("{0:N2}",tideVal) + "ft amplitude";

                 if (tideData.Key >= Satellite.TIDE_MOON_BASE && tideData.Key <= (Satellite.TIDE_MOON_BASE +10))
                 {
                     if (OptionCont.ignoreLunarTidesOnGardenWorlds && this.SatelliteType == SUBTYPE_GARDEN)
                         addStr = false;
                 } 

                 if (addStr) ret = ret + toBeAdded;
             }

             return ret;

         }
    }
}