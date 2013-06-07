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
        private static bool verboseOutput = false; 
        
        /// <summary>
        /// The manually set number of stars. 
        /// </summary>
        /// <remarks>The value of -1 means unset. Please keep this in mind when accessing this option</remarks>
        private static int numStars = -1;
        
        /// <summary>
        /// This setting enables a preset age. Used because the stage a star is in depends on the age of a system. (Also, some plans for later.)
        /// </summary>
        /// <remarks>The value of -1 means unset. Please keep this in mind when accessing this option</remarks>
        private static double presetAge = -1.0;

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
        
        /// <summary>
        /// Overrides the current method of determining color (based on effective surface temperature) for a random color.
        /// </summary>
        public static bool fantasyColors = false;

        /// <summary>
        /// Flare star variability (base is 12+) is lengthened to 9+
        /// </summary>
        public static bool moreFlareStarChance = false;

        /// <summary>
        /// By GURPS Space (p128) only M-class stars (under .45 solar masses) can be flare stars. This setting makes ANY star be a flare star
        /// </summary>
        /// <remarks>
        /// It is not recommended you enable this and the other flare star option.
        /// </remarks>
        public static bool anyStarFlareStar = false;
        
        /// <summary>
        /// The prefix used by the basic random name generator.
        /// </summary>
        public static string sysNamePrefix = "XSC";

        /// <summary>
        /// This tells it to roll rather than use the index array for secondary star mass
        /// </summary>
        public static bool useStraightRoll = false;
        
        /// <summary>
        /// This gives more conventional gas giant chances
        /// </summary>
        public static bool moreConGasGiantChances = false;
      
        /// <summary>
        /// This option forces only garden no ocean worlds.
        /// </summary>
        public static bool noOceanOnlyGarden = false;

        /// <summary>
        /// More chances of a large garden world.
        /// </summary>
        public static bool moreLargeGarden = false;

        /// <summary>
        /// More accurate timing of an oxygen catastrophe 
        /// </summary>
        public static bool moreAccurateO2Catastrophe = false;

        /// <summary>
        /// Prefer High RVM values
        /// </summary>
        public static bool highRVMVal = false; 

        /// <summary>
        /// No Marginal Atmosphere conditions
        /// </summary>
        public static bool noMarginalAtm = false; 

        /// <summary>
        /// Forces stable activity (volcanic, activity) to Moderate.
        /// </summary>
        public static bool stableActivity = false; 

        /// <summary>
        /// This sets the atmospheric pressure via override (For Garden Worlds only)
        /// </summary>
        /// <remarks>The value of -1 means unset. Please keep this in mind when accessing this option</remarks>
        public static double setAtmPressure = -1.0; 

        /// <summary>
        /// This sets the number of moons via override. (For Garden Worlds only)
        /// </summary>
        /// <remarks>The value of -1 means unset. Please keep this in mind when accessing this option</remarks>
        private static int numMoonsOverGarden = -1;

        /// <summary>
        /// This overrides GURPS's default limit of +8 Habitablility
        /// </summary>
        public static bool overrideHabitability = false;

        /// <summary>
        /// This overrides generated axial tilt.
        /// </summary>
        /// <remarks>The value of -1 means unset. Please keep this in mind when accessing this option</remarks>
        private static int forceAxialTilt = -1;

        /// <summary>
        /// Reroll the axial tilt over 45 degrees.
        /// </summary>
        public static bool rerollAxialTiltOver45 = false;

        /// <summary>
        /// This option ignores lunar tides on garden worlds for purposes of determining tidal force.
        /// </summary>
        public static bool ignoreLunarTidesOnGardenWorlds = false; 

        /// <summary>
        /// This option forces to display all tidal data no matter what on the output.
        /// </summary>
        public static bool alwaysDisplayTidalData = false;

        /// <summary>
        /// This option expands the asteroid belt size/RVM. 
        /// </summary>
        public static bool expandAsteroidBelt = false;

        /// <summary>
        /// This option sets the moon orbit flag during generation
        /// </summary>
        public static int moonOrbitFlag = OptionCont.MOON_BOOK;

        /// <summary>
        /// This option forces at least one terrestial planet to be created during orbital generation. 
        /// (Will only be invoked if none are generated)
        /// </summary>
        public static bool ensureOneOrbit = false; 

        //unverified options.
        public static bool replaceLowRedWithBrown = false; //OPTION FORM OK, WITHHELD - SEE CHANGELOG
        public static bool altMassRollMethod = false; //SEE CHANGELOG.
        

        //accessors

        /// <summary>
        /// This fucntion is an accessor for the property <see cref="OptionCont.forceAxialTilt"/>
        /// </summary>
        /// <param name="tilt">The tilt to be set</param>
        /// <returns>True if valid, false if invalid</returns>
        public static bool setAxialTilt(int tilt)
        {
            if (tilt >= 1 && tilt <= 90)
            {
                OptionCont.forceAxialTilt = tilt;
                return true;
            }

            return false;
        }

        /// <summary>
        /// This function is an accessor for the property <see cref="OptionCont.forceAxialTilt"/>
        /// </summary>
        /// <returns>The current tilt</returns>
        public static int getAxialTilt()
        {
            return OptionCont.forceAxialTilt;
        }

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
        /// <returns>If the property was succesfully set (will return false if it's over 3 or under 1)</returns>
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
        /// This sets the property <see cref="OptionCont.numMoonsOverGarden"/>
        /// </summary>
        /// <param name="num">This is an double representing the number of moons</param>
        /// <returns>If the property was succesfully set (will return false if it's over 3 or under 1)</returns>
        public static bool setNumberOfMoonsOverGarden(int num)
        {
            if ((num == -1) || (num >= 1 && num <= 3))
            {
                OptionCont.numMoonsOverGarden = num;
                return true;
            }

            else return false;
        }

        /// <summary>
        /// Returns the number of moons.
        /// </summary>
        /// <returns>The number of moons</returns>
        public static int getNumberOfMoonsOverGarden()
        {
            return OptionCont.numMoonsOverGarden;
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
