using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    class Satelite : Orbital
    {
        //flags!
        readonly public static int ORBIT_PRISEC = 9002; //primary and secondary
        readonly public static int ORBIT_PRISECTRI = 9003; //all three
        readonly public static int ORBIT_PRITRI = 9006; //shouldn't happen but we'll have it here for coding elemetns
        readonly public static int ORBIT_SECCOM = 9004; //secondary and companion
        readonly public static int ORBIT_TRICOM = 9005; //trinary and companion

        readonly public static int CONTENT_MOON = 210;
        readonly public static int CONTENT_GASGIANT = 211;
        readonly public static int CONTENT_TERRESTIAL = 212;

        readonly public static int SIZE_SMALL = 12;
        readonly public static int SIZE_TINY = 13;
        readonly public static int SIZE_STANDARD = 14;
        readonly public static int SIZE_LARGE = 15;

        //fields
        public int sateliteType { get; protected set; }
        public int sateliteSize { get; set; }

        public Satelite (int parent, int self, decimal radius, int satType = 0) : base(parent, self){
            //Sat Type optional default is 0 (unassigned)
            this.sateliteType = satType;
            this.orbitalRadius = radius;
        }


        public override string ToString()
        {
            String ret;
            ret = "This is a ";

            if (this.sateliteType == Satelite.CONTENT_GASGIANT) ret = ret + "Gas Giant";
            if (this.sateliteType == Satelite.CONTENT_MOON) ret = ret + " Moon";
            if (this.sateliteType == Satelite.CONTENT_TERRESTIAL) ret = ret + " Terrestial Planet";
            if (this.sateliteType == 0) ret = ret + " UNASSIGNED";

            ret = ret + " orbiting at " + Math.Round(this.orbitalRadius,3) + " AU out, orbiting parent " + this.parentID +" .";

            return ret;
        }
    }
}
