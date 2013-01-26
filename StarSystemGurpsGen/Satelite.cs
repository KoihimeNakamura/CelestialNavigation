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
        readonly public static int CONTENT_UNSET = -1;

        readonly public static int CONTENT_ICE = 214;
        readonly public static int CONTENT_ROCK = 215;
        readonly public static int CONTENT_SULFUR = 216;
        readonly public static int CONTENT_HADEAN = 217;
        readonly public static int CONTENT_AMMONIA = 218;
        readonly public static int CONTENT_GARDEN = 219;
        readonly public static int CONTENT_OCEAN = 220;
        readonly public static int CONTENT_GREENHOUSE = 221;
        readonly public static int CONTENT_CHTHONIAN = 222;

        readonly public static int SIZE_UNSET = CONTENT_UNSET;
        readonly public static int SIZE_SMALL = 12;
        readonly public static int SIZE_TINY = 13;
        readonly public static int SIZE_STANDARD = 14;
        readonly public static int SIZE_LARGE = 15;
        readonly public static int SIZE_MEDIUM = 16;

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
        public double diameter { get; set; }
        public double mass { get; set; }
        public double density { get; set; }
        public double gravity { get; set; }

        //terrestial qualities
        public double hydCoverage { get; set; }
        public double atmMass { get; set; }
        public double atmPres { get; set; }
        public int RVM { get; set; }

        public int DEBUG_MOD { get; set; }

        //order properties
        public int masterOrderID { get; set; }

        public Satelite(int parent, int self, double radius, int masterCount,  int satType = 0)
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
            this.DEBUG_MOD = 90;
        }

        public Satelite(int parent, int self, double radius, String parentDesc, int masterCount, int satType = 0)
            : base(parent, self)
        {
            //Sat Type optional default is 0 (unassigned)
            this.updateType(satType);

            this.orbitalRadius = radius;
            this.masterOrderID = masterCount;
            this.sateliteSize = Satelite.SIZE_UNSET;

            this.parentDesc = parentDesc;
            this.DEBUG_MOD = 90;
        }

        //copy constructor
        public Satelite(Satelite s) : base(s.parentID, s.selfID){
            this.updateType(s.sateliteType);
            this.orbitalRadius = s.orbitalRadius;
            this.masterOrderID = s.masterOrderID;
            this.parentDesc = s.parentDesc;

            this.isMoon = s.isMoon;
            this.updateType(s.sateliteType);
            this.updateSize(s.sateliteSize);
            this.diameter = s.diameter;
            this.mass = s.mass;
            this.density = s.density;
            this.gravity = s.gravity;
            this.hydCoverage = s.hydCoverage;
            this.atmMass = s.atmMass;
            this.atmPres = s.atmPres;
            this.RVM = s.RVM;
            this.DEBUG_MOD = s.DEBUG_MOD;

        }

        public int getHabitability()
        {
            return 0;
        }

        public void updateOrbitalData(int masterOrbPos, int localOrbPos)
        {
            this.masterOrderID = masterOrbPos;
            this.selfID = localOrbPos;
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
            if (this.sateliteSize == Satelite.SIZE_MEDIUM) this.descSatSize = "Medium";
            if (this.sateliteSize == Satelite.SIZE_LARGE) this.descSatSize = "Large";
        }

        public void updateTypeSize(int typeFlag, int sizeFlag)
        {
            this.updateType(typeFlag);
            this.updateSize(sizeFlag);
        }

        public int getAffinity()
        {
            return getHabitability() + RVM;
        }

        public string getAtmCategory()
        {
            if (this.atmPres <= 0.01) return "Trace";
            if (0.01 < this.atmPres && this.atmPres <= 0.5) return "Very Thin";
            if (0.5 < this.atmPres && this.atmPres <= 0.8) return "Thin";
            if (0.8 < this.atmPres && this.atmPres <= 1.2) return "Standard";
            if (1.2 < this.atmPres && this.atmPres <= 1.5) return "Dense";
            if (1.5 < this.atmPres && this.atmPres <= 10) return "Very Dense";
            if (this.atmPres > 10) return "Superdense";

            return "Error";
        }


        public override string ToString()
        {
            String ret;
            ret = "This is a " + this.descSatSize + " (" + this.descSatType + ")";

            ret = ret + " orbiting at " + Math.Round(this.orbitalRadius,3) + " AU out, orbiting parent " + this.parentID +" .";

            return ret;
        }

    }
}
