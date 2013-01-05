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
        readonly public static int ORBIT_PRITRI = 9006; //shouldn't happen .(Primary and Trinary)
        readonly public static int ORBIT_SECCOM = 9004; //secondary and companion
        readonly public static int ORBIT_TRICOM = 9005; //trinary and companion
        readonly public static int ORBIT_SECTRI = 9006; //this so shouldn't happen. Secondary and Trinary.
        readonly public static int BADPARENT = -9001;

        readonly public static int CONTENT_MOON = 210;
        readonly public static int CONTENT_GASGIANT = 211;
        readonly public static int CONTENT_TERRESTIAL = 212;
        readonly public static int CONTENT_ASTEROIDBELT = 213;
        readonly public static int CONTENT_EMPTY = 999;

        readonly public static int CONTENT_ICE = 214;
        readonly public static int CONTENT_ROCK = 215;
        readonly public static int CONTENT_SULFUR = 216;
        readonly public static int CONTENT_HADEAN = 217;
        readonly public static int CONTENT_AMMONIA = 218;
        readonly public static int CONTENT_GARDEN = 219;
        readonly public static int CONTENT_OCEAN = 220;
        readonly public static int CONTENT_GREENHOUSE = 221;
        readonly public static int CONTENT_CHTHONIAN = 222;

        readonly public static int SIZE_SMALL = 12;
        readonly public static int SIZE_TINY = 13;
        readonly public static int SIZE_STANDARD = 14;
        readonly public static int SIZE_LARGE = 15;

        //fields
        public bool isMoon { get; set; }
        public int sateliteType { get; protected set; }
        public int sateliteSize { get; protected set; }

        public String descSatType { get; set; }
        public String descSatSize { get; set; }
        public String parentDesc { get; set; }

        //moon fields
        public int innerMoonlets { get; set; }
        public int majorMoons { get; set; }
        public int outerMoonlets { get; set; }

        //general properties
        public decimal diameter { get; set; }
        public decimal mass { get; set; }
        public decimal density { get; set; }
        public decimal gravity { get; set; }

        //terrestial qualities
        public decimal hydCoverage { get; set; }
        public decimal atmMass { get; set; }
        public decimal atmPres { get; set; }
        public int RVM { get; set; }
        public int masterOrderID { get; set; }

        public Satelite(int parent, int self, decimal radius, int masterCount,  int satType = 0)
            : base(parent, self)
        {
            //Sat Type optional default is 0 (unassigned)
            this.sateliteType = satType;
            
            if (this.sateliteType == Satelite.CONTENT_ASTEROIDBELT)
                this.descSatType = "Asteroid Belt";

            if (this.sateliteType == Satelite.CONTENT_GASGIANT)
                this.descSatType = "Gas Giant";

            if (this.sateliteType == Satelite.CONTENT_TERRESTIAL)
                this.descSatType = "Terrestial";

            if (this.sateliteType == Satelite.CONTENT_MOON)
                this.descSatType = "Terrestial Moon";

            if (this.sateliteType == Satelite.CONTENT_EMPTY)
                this.descSatType = "Empty Orbital";

            this.masterOrderID = masterCount;
            this.orbitalRadius = radius;
        }

        public Satelite(int parent, int self, decimal radius, String parentDesc, int masterCount, int satType = 0)
            : base(parent, self)
        {
            //Sat Type optional default is 0 (unassigned)
            this.sateliteType = satType;

            if (this.sateliteType == Satelite.CONTENT_ASTEROIDBELT)
                this.descSatType = "Asteroid Belt";

            if (this.sateliteType == Satelite.CONTENT_GASGIANT)
                this.descSatType = "Gas Giant";

            if (this.sateliteType == Satelite.CONTENT_TERRESTIAL)
                this.descSatType = "Terrestial";

            if (this.sateliteType == Satelite.CONTENT_MOON)
                this.descSatType = "Terrestial Moon";

            if (this.sateliteType == Satelite.CONTENT_EMPTY)
                this.descSatType = "Empty Orbital";

            this.orbitalRadius = radius;
            this.masterOrderID = masterCount;

            this.parentDesc = parentDesc;
        }

        public int getHabitability()
        {
            return 0;
        }

        public void updateType(int flag)
        {
            this.sateliteType = flag;

            //update the description
            if (this.sateliteType == Satelite.CONTENT_ASTEROIDBELT) this.descSatType = "Asteroid Belt";
            if (this.sateliteType == Satelite.CONTENT_GASGIANT) this.descSatType = "Gas Giant";
            if (this.sateliteType == Satelite.CONTENT_TERRESTIAL) this.descSatType = "Terrestial";
            if (this.sateliteType == Satelite.CONTENT_MOON) this.descSatType = "Terrestial Moon";
            if (this.sateliteType == Satelite.CONTENT_AMMONIA) this.descSatType = "Ammonia";
            if (this.sateliteType == Satelite.CONTENT_CHTHONIAN) this.descSatType = "Chthonian";
            if (this.sateliteType == Satelite.CONTENT_GARDEN) this.descSatType = "Garden";
            if (this.sateliteType == Satelite.CONTENT_GREENHOUSE) this.descSatType = "Greenhouse";
            if (this.sateliteType == Satelite.CONTENT_HADEAN) this.descSatType = "Hadean";
            if (this.sateliteType == Satelite.CONTENT_ICE) this.descSatType = "Ice";
            if (this.sateliteType == Satelite.CONTENT_OCEAN) this.descSatType = "Ocean";
            if (this.sateliteType == Satelite.CONTENT_ROCK) this.descSatType = "Rock";
            if (this.sateliteType == Satelite.CONTENT_SULFUR) this.descSatType = "Sulfur";

        }

        public void updateSize(int flag)
        {
            this.sateliteSize = flag;
            if (this.sateliteSize == Satelite.SIZE_TINY) this.descSatSize = "Tiny";
            if (this.sateliteSize == Satelite.SIZE_SMALL) this.descSatSize = "Small";
            if (this.sateliteSize == Satelite.SIZE_STANDARD) this.descSatSize = "Standard";
            if (this.sateliteSize == Satelite.SIZE_LARGE) this.descSatSize = "Large";
        }

        public int getAffinity()
        {
            return getHabitability() + RVM;
        }

        public string getAtmCategory()
        {
            if (this.atmPres <= 0.01m) return "Trace";
            if (0.01m < this.atmPres && this.atmPres <= 0.5m) return "Very Thin";
            if (0.5m < this.atmPres && this.atmPres <= 0.8m) return "Thin";
            if (0.8m < this.atmPres && this.atmPres <= 1.2m) return "Standard";
            if (1.2m < this.atmPres && this.atmPres <= 1.5m) return "Dense";
            if (1.5m < this.atmPres && this.atmPres <= 10m) return "Very Dense";
            if (this.atmPres > 10m) return "Superdense";

            return "Error";
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
