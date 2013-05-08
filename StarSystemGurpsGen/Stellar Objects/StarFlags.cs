using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public partial class Star : Orbital
    {
        //flags        
        //description types
        readonly public static int IS_PRIMARY = 9000; //flag for orbitals
        readonly public static int IS_SECONDARY = 9001;
        readonly public static int IS_TRINARY = 9002;
        readonly public static int IS_SECCOMP = 9005;
        readonly public static int IS_TRICOMP = 9006;

        //gas giant flags.
        readonly public static int GASGIANT_NONE = 700;
        readonly public static int GASGIANT_CONVENTIONAL = 701;
        readonly public static int GASGIANT_ECCENTRIC = 702;
        readonly public static int GASGIANT_EPISTELLAR = 703;

        //orbital seperation flags
        readonly public static int ORBSEP_NONE = 501;
        readonly public static int ORBSEP_VERYCLOSE = 502;
        readonly public static int ORBSEP_CLOSE = 503;
        readonly public static int ORBSEP_MODERATE = 504;
        readonly public static int ORBSEP_WIDE = 505;
        readonly public static int ORBSEP_DISTANT = 506;
        readonly public static int ORBSEP_CONTACT = 507;
    }
}
