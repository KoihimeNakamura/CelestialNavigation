using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    /// <summary>
    /// This class is an container for the generator status. Accessed by both thing setting it (Front-end) and the generator using them.
    /// </summary>
    static class OptionCont
    {
        /// <summary>
        /// Exposed so that people may set it later via an option menu. Controls displayed figures in various outputs
        /// </summary>
        public static int numberOfDecimal = 4;  
        
        //flags for settings.

        /// <summary>
        /// This flag sets the moon orbit status to : By The Book. (see the setting for details.)
        /// </summary>
        readonly public static int MOON_BOOK = 0;
        
        /// <summary>
        /// This flag sets the moon orbit status to : By the Book, High Only. (see the setting for details.)
        /// </summary>
        readonly public static int MOON_BOOKHIGH = 1;

        /// <summary>
        /// This flag sets the moon orbit status to: Extended. (see the setting for details.)
        /// </summary>
        readonly public static int MOON_EXPAND = 2;

        /// <summary>
        /// This flag sets the moon orbit status to: Extended, High Only. (see the setting for details)
        /// </summary>
        readonly public static int MOON_EXPANDHIGH = 3;

        /// <summary>
        /// This setting is intended to make a garden world during generation much more likely. (affecting star size and stellar spacing)
        /// </summary>
        /// <remarks>
        /// This setting is per GURPS Space (4e) pg 101. Also, pg 105.
        /// </remarks>
        public static bool forceGardenFavorable = false;
        // TODO: Check Implementations

        /// <summary>
        /// This setting sets the system in an open cluster or not. In an open cluster, stars are more common (The roll modifier is +3)
        /// </summary>
        /// <remarks>
        /// This setting is per GURPS Space (4e) pg 70, 100. 
        /// </remarks>
        public static bool inOpenCluster = false; 
        // TODO: Check Implementations

        /// <summary>
        /// This setting enables much more verbose output (exposes details normaly used during system generation.) 
        /// Has it's own accessors.
        /// </summary>
        private static bool verboseOutput = false; //Satellite OK, OPTION FORM OK, Star NOT OK, Formation NOT OK
        

        //WARNING: THIS BREAKS COMPATIABLITY WITH STARSYSTEM. 
        //FIX THIS. 

        /// <summary>
        /// The manually set number of stars. If this is -1, then this was not manually set. 
        /// </summary>
        private static int numStars = -1;
        // TODO: Seriously, check Implementations.

        //WARNING: THIS BREAKS COMPATIABLITY WITH STARSYSTEM. 
        //FIX THIS. 

        /// <summary>
        /// This setting enables a preset age. Used because the stage a star is in depends on the age of a system. (Also, some plans for later.)
        /// </summary>
        private static double presetAge = -1.0;
        // TODO: Seriously, check Implementations.


        /// <summary>
        /// Override detector for the stellar mass range indicator.
        /// </summary>
        public static bool stellarMassRangeSet = false; 

        /// <summary>
        /// The minimum stellar mass for the generator
        /// </summary>
        public static double minStellarMass = .1; 

        /// <summary>
        /// The maximum stellar mass for the generator. 
        /// </summary>
        public static double maxStellarMass = 2; 
        
        /// <summary>
        /// Caps Stellar Eccentricity at .5
        /// </summary>
        public static bool lessStellarEccent = false; 

        /// <summary>
        /// Caps Stellar Eccentricity at .1
        /// </summary>
        public static bool forceVeryLowStellarEccent = false; 
        //TODO: Check Implementation
        
        /// <summary>
        /// Overrides the current method of determining color (based on effective surface temperature) for a random color.
        /// </summary>
        public static bool fantasyColors = false;
        //TODO: Implement

        /// <summary>
        /// Flare star variability (base is 12+) is lengthened to 9+
        /// </summary>
        public static bool moreFlareStarChance = false;
        //TODO: Implement

        /// <summary>
        /// By GURPS Space (p128) only M-class stars (under .45 solar masses) can be flare stars. This setting makes ANY star be a flare star
        /// </summary>
        /// <remarks>
        /// It is not recommended you enable this and the other flare star option.
        /// </remarks>
        public static bool anyStarFlareStar = false;
        //TODO: Implement
        
        /// <summary>
        /// The prefix used by the basic random name generator.
        /// </summary>
        public static string sysNamePrefix = "XSC";


        /// <summary>
        /// This tells it to roll rather than use the index array for secondary star mass
        /// </summary>
        public static bool useStraightRoll = false;
        //TODO: Implement

        public static bool expandAsteroidBelt = false; //Satellite OK, OPTION FORM OK, Orbital Code NOT OK
        
        public static bool alwaysDisplayTidalData = false; //Satellite OK, OPTION FORM OK - COMPLETE



        public static int moonOrbitFlag = OptionCont.MOON_BOOK; //OPTION FORM OK, Satellite OK - COMPLETE
        public static bool replaceLowRedWithBrown = false; //OPTION FORM OK, WITHHELD - SEE CHANGELOG
        public static bool altMassRollMethod = false; //SEE CHANGELOG.
        public static bool noOceanOnlyGarden = false; //OPTION FORM OK, Satellite OK - COMPLETE

        

        public static bool highRVMVal = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static bool noMarginalAtm = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static bool stableActivity = false; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool atmPresOverride = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static double setAtmPres = -1; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool moonOverride = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static int maxMoonsOverGarden = -1; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool ignoreLunarTides = false; //OPTION FORM OK, Satellite OK - COMPLETE



        public static bool ensureOneOrbit = false; //Satelite OK

        //accessors

        /// <summary>
        /// This function is an accessor for the property <see cref="OptionCont.verboseOutput"/>
        /// </summary>
        /// <returns>The property</returns>
        public static bool getVerboseOutput()
        {
            return OptionCont.verboseOutput;
        }

        /// <summary>
        ///  This function is an accessor for the property <see cref="OptionCont.verboseOutput"/>.
        ///  Used to ensure that if you're enabling verbose output you display tidal data as well.
        /// </summary>
        /// <param name="setting">The value you are setting verbose output to</param>
        public static void setVerboseOutput(bool setting)
        {
            OptionCont.verboseOutput = setting;
            if (setting == true)
                OptionCont.alwaysDisplayTidalData = true;
        }


        /// <summary>
        /// This function is an accessor for the property <see cref="OptionCont.numStars"/>
        /// Used to do error checking (i.e no setting for 4 or more stars.
        /// </summary>
        /// <param name="num">This is an integer representing the number of stars</param>
        /// <returns>If the property was succesfully set</returns>
        public static bool setNumberOfStars(int num)
        {
            if ((num == -1) || (num >= 1 && num <= 3))
            {
                OptionCont.numStars = num;
                return true;
            }

            else return false;
        }

        /// <summary>
        /// This returns the property <see cref="OptionCont.numStars"/>
        /// </summary>
        /// <returns>The property</returns>
        public static int getNumberOfStars()
        {
            return OptionCont.numStars;
        }


        /// <summary>
        /// This function is an accessor for the property <see cref="OptionCont.presetAge"/>
        /// There may be bound checking later.
        /// </summary>
        /// <param name="age">A double representing the age to be set</param>
        public static void setSystemAge(double age)
        {
            OptionCont.presetAge = age;
        }

        /// <summary>
        /// This returns the property <see cref="OptionCont.presetAge"/>
        /// </summary>
        /// <returns>The property</returns>
        public static double getSystemAge()
        {
            return OptionCont.presetAge;
        }
    }
}
