using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    static class OptionCont
    {
        //flags
        readonly public static int MOON_BOOK = 0;
        readonly public static int MOON_BOOKHIGH = 1;
        readonly public static int MOON_EXPAND = 2;
        readonly public static int MOON_EXPANDHIGH = 3;

        public static bool forceGardenFavorable = false; //OPTION FORM OK, Star NOT OK
        public static bool inOpenCluster = false; //OPTION FORM OK, Star NOT OK
        public static bool expandAsteroidBelt = false; //Satellite OK, OPTION FORM OK, Orbital Code NOT OK
        private static bool verboseOutput = false; //Satellite OK, OPTION FORM OK, Star NOT OK, Formation NOT OK
        public static bool alwaysDisplayTidalData = false; //Satellite OK, OPTION FORM OK - COMPLETE

        public static bool stellarMassRangeSet = false; //OPTION FORM OK
        public static double minStellarMass = .1; //OPTION FORM OK
        public static double maxStellarMass = 2; //OPTION FORM OK

        public static int moonOrbitFlag = OptionCont.MOON_BOOK; //OPTION FORM OK, Satellite OK - COMPLETE
        public static bool replaceLowRedWithBrown = false; //OPTION FORM OK, WITHHELD - SEE CHANGELOG
        public static bool altMassRollMethod = false; //SEE CHANGELOG.
        public static bool noOceanOnlyGarden = false; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool numStarOverride = false; //OPTION FORM OK, StarSystem OK - COMPLETE
        public static int numStars = -1; //OPTION FORM OK, StarSystem OK - COMPLETE

        public static bool presetOverride = false; //OPTION FORM OK
        public static double presetAge = -1.0; //OPTION FORM OK

        public static int numberOfDecimal = 4; //OPTION FORM OK, Satellite OK, Star NOT OK

        public static bool highRVMVal = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static bool noMarginalAtm = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static bool stableActivity = false; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool atmPresOverride = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static double setAtmPres = -1; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool moonOverride = false; //OPTION FORM OK, Satellite OK - COMPLETE
        public static int maxMoonsOverGarden = -1; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool ignoreLunarTides = false; //OPTION FORM OK, Satellite OK - COMPLETE

        public static bool lessStellarEccent = false; //OPTION FORM OK, Star OK - COMPLETE
        public static bool forceVeryLowStellarEccent = false; //Star OK 

        public static bool ensureOneOrbit = false; //Satelite OK

        //accessors
        public static bool getVerboseOutput()
        {
            return OptionCont.verboseOutput;
        }

        public static void setVerboseOutput(bool setting)
        {
            OptionCont.verboseOutput = setting;
            if (setting == true)
                OptionCont.alwaysDisplayTidalData = true;
        }
    }
}
