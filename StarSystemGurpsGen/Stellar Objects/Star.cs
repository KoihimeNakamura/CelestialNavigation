using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    /* StarFlags.cs contains all the flags for the Star object
     * StarSatellite.cs contains all of the satellite options
     * 
     * 
     * 
     */
      
    /// <summary>
    ///  Star contains the flags and objects for.. a star. Also for it's subject planets, and formation and forbidden zones.
    ///  Is a child of <see cref="Orbital"/>
    /// </summary>
    public partial class Star : Orbital
    {

        //member arrays of the object

        /// <summary>
        ///   This member contains the table we roll on for stellar mass.
        /// </summary>
        public static double[][] starMassTable = new double[][]{
                 new double[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //Index 0
                 new double[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //Roll 1
                 new double[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, //Roll 2
                 new double[] {0,0,0,2,2,2,2,2,2,2,2,1.9,1.9,1.9,1.9,1.9,1.9,1.9,1.9}, //Roll: 3
                 new double[] {0,0,0,1.8,1.8,1.8,1.8,1.8,1.8,1.7,1.7,1.7,1.6,1.6,1.6,1.6,1.6,1.6,1.6}, //Roll: 4
                 new double[] {0,0,0,1.5,1.5,1.5,1.5,1.5,1.45,1.45,1.45,1.4,1.4,1.35,1.35,1.35,1.35,1.35,1.35,1.35}, //Roll:5
                 new double[] {0,0,0,1.3,1.3,1.3,1.3,1.3,1.25,1.25,1.2,1.15,1.15,1.1,1.1,1.1,1.1,1.1,1.1}, //Roll: 6
                 new double[] {0,0,0,1.05,1.05,1.05,1.05,1.05,1,1,.95,.9,.9,.85,.85,.85,.85,.85,.85}, //Roll: 7
                 new double[] {0,0,0,.8,.8,.8,.8,.8,.8,.75,.75,.7,.65,.65,.6,.6,.6,.6,.6,.6}, //Roll: 8
                 new double[] {0,0,0,.55,.55,.55,.55,.55,.55,.5,.5,.5,.45,.45,.45,.45,.45,.45,.45}, //Roll: 9
                 new double[] {0,0,0,.4,.4,.4,.4,.4,.4,.35,.35,.35,.3,.3,.3,.3,.3,.3,.3}, //Roll: 10
                 new double[] {0,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25,0.25}, //Roll 11
                 new double[] {0,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2,0.2}, //Roll 12
                 new double[] {0,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15,0.15}, //Roll 13
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 14
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 15
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 16
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 17
                 new double[] {0,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1,0.1}, //Roll 18
             };

        /// <summary>
        ///  The minimum luminosity of the star, given its' mass
        /// </summary>
        public static double[][] minLuminTable = new double[34][]{
            new double[2]{.1, .0012},
            new double[2]{.15, .0036},
            new double[2] {.2, .0079 },
            new double[2] {.25, .015 },
            new double[2] {.3, .024 },
            new double[2] {.35, .037 },
            new double[2] {.4, .054 },
            new double[2] {.45, .07 },
            new double[2] {.5, .09 },
            new double[2] {.55, .11 },
            new double[2] {.6, .13 },
            new double[2] {.65, .15 },
            new double[2] {.7, .12 },
            new double[2] {.75, .23 },
            new double[2] {.8, .28 },
            new double[2] {.85, .36 },
            new double[2] {.9, .45 },
            new double[2] {.95, .56 },
            new double[2] {1, .68 },
            new double[2] {1.05, .87 },
            new double[2] {1.1, 1.1 },
            new double[2] {1.15, 1.4 },
            new double[2] {1.2, 1.7 },
            new double[2] {1.25, 2.1 },
            new double[2] {1.3, 2.5 },
            new double[2] {1.35, 3.1 },
            new double[2] {1.4, 3.7 },
            new double[2] {1.45, 4.3 },
            new double[2] {1.5, 5.1 },
            new double[2] {1.6, 6.7 },
            new double[2] {1.7, 8.6 },
            new double[2] {1.8, 11 },
            new double[2] {1.9, 13 },
            new double[2] {2, 16 },
        };
     
        //properties of the star

        /// <summary>
        ///   currMass is the current Mass of the star
        /// </summary>
        public double currMass { get; protected set; }

        /// <summary>
        ///  initMass is the initial mass of the star
        ///  <remarks>This is one of the things placed here for white dwarves, 
        ///  since they have an arbitrary changed mass.</remarks>
        /// </summary>
        public double initMass { get; protected set; }

        /// <summary>
        /// The radius of the star, stored in __AU__. 
        /// </summary>
        public double radius { get; set; }

        /// <summary>
        /// The current luminosity. Stored in __solar luminosities__
        /// </summary>
        public double currLumin { get; set; }

        /// <summary>
        /// The initial luminosity. Needed to determine various elements of formation.
        /// </summary>
        public double initLumin { get; protected set; }

        /// <summary>
        ///  The maximum luminsoity. It's used for internal factors, but generally only relevant for giant and white dwarf phase
        /// </summary>
        protected double maxLumin { get; set; }

        /// <summary>
        ///  The effective temperature of the surface of the star. 
        /// </summary>
        public double effTemp { get; set; }

        /// <summary>
        ///  The spectral type of the star.
        /// </summary>
        public string specType { get; set; }

        /// <summary>
        /// This determiners if it's a flare star 
        /// </summary>
        public bool isFlareStar { get; set; }

        /// <summary>
        ///  The age of the star. I don't LIKE storing it here, but the star needs to know it's own age in order to know where it is.
        /// </summary>
        public double starAge { get; set; } 

        //labeling and order properties
        /// <summary>
        ///  Order ID: this stores a number from (0,9) which is used to determine the name. 
        /// </summary>
        public int orderID { get; set; }

        /// <summary>
        ///  Orbital Serpation Flag (Very Close, etc.)
        /// </summary>
        public int orbitalSep { get; set; }

        //flags for planetary creation
        /// <summary>
        ///  In GURPS, whether or not you have any gas giants, and where they are, is dependent on this flag
        /// </summary>
        public int gasGiantFlag { get; set; }

        /// <summary>
        /// This contains every orbital that planets can form in the star.
        /// </summary>
        public List<Satellite> sysPlanets { get; set; }

        /// <summary>
        /// Soon to be removed.
        /// </summary>
        public formationHelper zonesOfInterest { get; set; }

        /// <summary>
        ///  Contains the segments that make up the lifespan of the star.
        /// </summary>
        public StarAgeLine evoLine { get; set; }
        
        /// <summary>
        ///  This stores the distance of each star from the primary. It's needed for blackbody calculations.
        /// </summary>
        public double distFromPrimary { get; set; }

        /// <summary>
        ///  This is the stellar color. Not always used.
        /// </summary>
        public string starColor { get; set; }

        public Star(int parent, int self) : base(parent, self)
        {
            this.orbitalRadius = 0.0;
            this.gasGiantFlag = Star.GASGIANT_NONE; //set to none automatically. We will set it correctly later.
            this.evoLine = new StarAgeLine();
            this.sysPlanets = new List<Satellite>();
        }

        public Star(double age, int parent, int self, int order, string baseName)
            : base(parent, self)
        {
            this.starAge = age;
            this.orbitalRadius = 0.0;
            this.gasGiantFlag = Star.GASGIANT_NONE; //set to none automatically. We will set it correctly later.
            this.orderID = order;
            this.name = Star.genGenericName(baseName, order);
            this.evoLine = new StarAgeLine();
            this.sysPlanets = new List<Satellite>();
        }

        public Star(double age, int parent, int self, int order) : base(parent,self)
        {
            this.starAge = age;
            this.orbitalRadius = 0.0;
            this.gasGiantFlag = Star.GASGIANT_NONE;
            this.evoLine = new StarAgeLine();
            this.orderID = order;
            this.sysPlanets = new List<Satellite>();
        }

        //this function names the star (generically)
        public static string genGenericName(String sysName, int id)
        {
            char[] starNames = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
            return (sysName + "-" + starNames[id]);
        }

        //zones of interest functions - both to see if it's initated and to create it.

        //init formulas
        //passthrough functions
        public void createForbiddenZone(Range incoming, int primary, int secondary)
        {
            this.zonesOfInterest.createForbiddenZone(incoming, primary, secondary);
        }

        public void createCleanZones()
        {
            this.zonesOfInterest.createCleanZones(Star.innerRadius(this.initLumin,this.initMass), Star.outerRadius(this.initMass));
        }

        public void sortForbidden()
        {
            this.zonesOfInterest.sortForbiddenZones();
        }

        public void sortClean()
        {
            this.zonesOfInterest.sortCleanZones();
        }

        public double verifyRange(Range incoming)
        {
            return this.zonesOfInterest.verifyRange(incoming);
        }

        public double pickInRange(Range incoming)
        {
            return this.zonesOfInterest.pickInRange(incoming);
        }

        public bool verifyCleanOrbit(double incoming)
        {
            return this.zonesOfInterest.isWithinCleanZone(incoming);
        }

        public bool withinCreationRange(double incoming)
        {
            if (incoming >= Star.innerRadius(this.initLumin, this.initMass) && incoming <= Star.outerRadius(this.initMass))
            {
                return true;
            }

            return false;
        }

        public List<cleanZone> getCleanZones()
        {
            return this.zonesOfInterest.formationZones;
        }

        public bool cleanZoneHasOrbits(cleanZone clear)
        {
            foreach (Satellite s in this.sysPlanets)
            {
                if (clear.withinRange(s.orbitalRadius)) return true;
            }

            return false;
        }

        public bool verifyForbiddenOrbit(double incoming)
        {
            return this.zonesOfInterest.isWithinForbiddenZone(incoming);
        }

        public double getNextCleanOrbit(double orbit, int flag)
        {
            return this.zonesOfInterest.getNextCleanOrbit(orbit, flag);
        }

        public double getMinCleanOrbit()
        {
            return this.zonesOfInterest.getMinimalCleanZone();
        }

        public double getMaxCleanOrbit()
        {
            return this.zonesOfInterest.getMaximalCleanZone();
        }

        public double getRangeWidth(double orbit)
        {
            return this.zonesOfInterest.getRangeWidth(orbit);
        }

        public int getOwnership(double orbital)
        {
            return this.zonesOfInterest.getOwnership(orbital);
        }

        public int getAdjacencyMod(double orbital)
        {
            return this.zonesOfInterest.getAdjacencyMod(orbital);
        }

        public double pickInCurrentRange(double orbit, double minLimit)
        {
            double retValue;

            if (this.zonesOfInterest.getRangeWidth(orbit) < minLimit)
            {
                do
                {
                    retValue = this.zonesOfInterest.pickInRange(this.zonesOfInterest.getRange(orbit));
                } while (retValue == orbit);
            }
            else
            {
                do
                {
                    retValue = this.zonesOfInterest.pickInRange(this.zonesOfInterest.getRange(orbit));
                } while (retValue < orbit + minLimit);
            }


            return retValue;
            //return this.zonesOfInterest.pickInRange(this.zonesOfInterest.getRange(orbit));
        }

        public virtual bool isAllEmptyOrbits()
        {
            foreach (Satellite s in this.sysPlanets)
            {
                if (s.baseType != Satellite.BASETYPE_EMPTY) return false;
            }

            return true;
        }

        //mass functionality
        public virtual void updateMass(double mass, bool isWhiteDwarf = false)
        {
            if (mass == 0)
                throw new Exception("Mass is 0 solar masses.");
            
            this.currMass = mass;

            this.evoLine.addMainLimit(Star.findMainLimit(this.currMass));
            this.evoLine.addSubLimit(Star.findSubLimit(this.currMass));
            this.evoLine.addGiantLimit(Star.findGiantLimit(this.currMass));
            

            if (!isWhiteDwarf) this.initMass = mass;
        }

        //add the order ID.
        public virtual void addOrder(int orderID)
        {
            this.orderID = orderID;
        }

        //generic update lumin (auto determine it in case we don't need to)
        public static double getCurrLumin(StarAgeLine ageL, double age, double mass){
            int ageGroup = ageL.findCurrentAgeGroup(age);
    
            if (ageGroup == StarAgeLine.RET_MAINBRANCH && mass < .45)
                return Star.getMinLumin(mass);
            if (ageGroup == StarAgeLine.RET_MAINBRANCH && mass >= .45)  
                    return (Star.getMinLumin(mass) + ((age / ageL.getMainLimit()) * (Star.getMaxLumin(mass) - Star.getMinLumin(mass))));
            if (ageGroup == StarAgeLine.RET_SUBBRANCH)
                    return Star.getMaxLumin(mass);
            if (ageGroup == StarAgeLine.RET_GIANTBRANCH)
                return Star.getMaxLumin(mass) * 10000; //IMPLEMENTED HOUSE RULE.
            if (ageGroup == StarAgeLine.RET_DWARFBRANCH)
                return .0043;

            return 0;
        }

        public static double getCurrentTemp(StarAgeLine ageL, double age, double mass, Dice ourDice)
        {
            if (ageL.findCurrentAgeGroup(age) == StarAgeLine.RET_MAINBRANCH) 
                return Star.getInitTemp(mass);
            if (ageL.findCurrentAgeGroup(age) == StarAgeLine.RET_SUBBRANCH)
                return (Star.getInitTemp(mass) - ageL.calcWithInSubLimit(age) * (Star.getInitTemp(mass) - 4800));
            if (ageL.findCurrentAgeGroup(age) == StarAgeLine.RET_GIANTBRANCH)
                return (3000 + ourDice.rng(2, 6, -2) * 200);
            if (ageL.findCurrentAgeGroup(age) == StarAgeLine.RET_DWARFBRANCH)
                return Star.WhiteDwarfTemp(mass, (age - ageL.getGiantLimit()));

            return 0;
        }

        public virtual void setLumin(){
            int currAgeGroup = this.evoLine.findCurrentAgeGroup(this.starAge);
            this.initLumin = getMinLumin(); //this applies for most stars.
  
            this.currLumin = Star.getCurrLumin(this.evoLine, this.starAge, this.currMass);
  
            if (currAgeGroup == StarAgeLine.RET_GIANTBRANCH)
                this.maxLumin = this.currLumin;
            
            if (currAgeGroup == StarAgeLine.RET_DWARFBRANCH)
                this.maxLumin = Star.getMinLumin(this.currMass) * 10000;
        }

        public virtual void updateLumin(double lumin)
        {
            int currStatus = this.evoLine.findCurrentAgeGroup(this.starAge);
            
            if (currStatus == StarAgeLine.RET_MAINBRANCH && this.currMass < .45){
                this.currLumin = lumin;
                this.initLumin = lumin;
            }

            if ((currStatus == StarAgeLine.RET_MAINBRANCH && this.currMass >= .45) || currStatus == StarAgeLine.RET_SUBBRANCH || currStatus == StarAgeLine.RET_GIANTBRANCH || currStatus == StarAgeLine.RET_GIANTBRANCH)
                this.currLumin = lumin;
        }

        //returns the radius in terms of either KM or AU.
        public virtual double getRadiusAU() { return this.radius; }
        public virtual double getRadiusKM() { return this.radius * Orbital.AUtoKM; }

        //update temp.
        public virtual void updateTemp(double effTemp)
        {
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_SUBBRANCH || this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_GIANTBRANCH)
            {
                this.effTemp = effTemp;
                this.specType = Star.getStellarTypeFromTemp(this.effTemp);
            }
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_MAINBRANCH) this.effTemp = effTemp;
        }

        //describes the age status.
        public virtual String getStatusDesc()
        {
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_MAINBRANCH) return "Main Sequence";
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_SUBBRANCH) return "Subgiant Branch";
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_GIANTBRANCH) return "Asymptotic Giant Branch";
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_DWARFBRANCH) return "White Dwarf";

            return "INVALID STATUS";
        }


        public virtual void setSpectralType(Dice ourDice)
        {
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_MAINBRANCH)
                this.specType = Star.getStellarTypeFromMass(this.currMass) + " V";

            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_SUBBRANCH)
                this.specType = Star.getStellarTypeFromTemp(this.currMass) + " IV";

            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_GIANTBRANCH)
                this.specType = Star.getStellarTypeFromTemp(this.currMass) + " II";

            //the fun one - white dwarf
            if (this.evoLine.findCurrentAgeGroup(this.starAge) == StarAgeLine.RET_DWARFBRANCH)
            {
                double surfTemp = 50400.0 / this.effTemp;
                surfTemp = Math.Round(surfTemp, 1);
                if (this.effTemp < 10) surfTemp = 10; //fixes a DBZ_INFINTY bug.

                string[] types = {"DA","DAB","DAO","DAZ","DB","DBZ","DC","DQ","DZ","DO","DX"};

                this.specType = types[ourDice.rng(1, 11, -1)] + surfTemp;
            }

        }

        public virtual bool testInitlizationZones()
        {
            if (this.zonesOfInterest == null) return false;
            return true;
        }

        public virtual void initalizeZonesOfInterest()
        {
            zonesOfInterest = new formationHelper(this.selfID);
        }

        public void sortForbiddenZones()
        {
            this.zonesOfInterest.sortForbiddenZones();
        }

        public void sortCleanZones()
        {
            this.zonesOfInterest.sortCleanZones();
        }

        public double getClosestDistToForbiddenZone(double orbit)
        {
            return this.zonesOfInterest.getClosestDistFromForbiddenZone(orbit);
        }

        public double getClosestForbiddenZoneRatio(double orbit)
        {
            return this.zonesOfInterest.getClosestForbiddenZoneRatio(orbit);
        }

        public bool containsGasGiants(bool pastSnowLine = true)
        {
            foreach (Satellite s in this.sysPlanets)
            {
                if (!pastSnowLine) 
                    if (s.SatelliteType == Satellite.BASETYPE_GASGIANT) return true;
                else 
                    if (s.SatelliteType == Satellite.BASETYPE_GASGIANT && s.orbitalRadius > Star.snowLine(this.initLumin) ) return true;
            }

            return false;
        }

        //checks the previous satellite to see if it's a gas giant
        public bool isPrevSatelliteGasGiant(double orbitalRadius)
        {
            for (int i = 0; i < this.sysPlanets.Count; i++)
            {
                if (this.sysPlanets[i].orbitalRadius == orbitalRadius)
                {
                    if (i == 0)
                        return false;
                    else
                        if (this.sysPlanets[i - 1].baseType == Satellite.BASETYPE_GASGIANT)
                            return true;
                }

            }

            return false;
        }


        //checks the next satellite to see if it's a gas giant
        public bool isNextSatelliteGasGiant(double orbitalRadius)
        {
            for (int i = 0; i < this.sysPlanets.Count; i++)
            {
                if (this.sysPlanets[i].orbitalRadius == orbitalRadius)
                {
                    if (i == (this.sysPlanets.Count - 1))
                        return false;
                    else
                        if (this.sysPlanets[i + 1].baseType == Satellite.BASETYPE_GASGIANT)
                            return true;
                }

            }

            return false;
        }

        public string printSummaryLine(string intro = "")
        {
            string desc = "";

            if (this.selfID != IS_PRIMARY)
            {
                desc = intro + " " + this.currMass + " solar masses, " + Math.Round(this.currLumin, OptionCont.numberOfDecimal) + " solar luminosities. Eff Temp: " + this.effTemp + "K, apparent color ";
                desc += Star.getColor(this.effTemp) + ". This star orbits " + Star.getDescOrderFlag(this.parentID) + " at " + this.orbitalRadius + "AU out with an eccentricity of " + this.orbitalEccent;
            }
            else
            {
                desc = intro + " " + this.currMass + " solar masses, " + Math.Round(this.currLumin, OptionCont.numberOfDecimal) + " solar luminosities. Eff Temp: " + this.effTemp + "K, apparent color ";
                desc += Star.getColor(this.effTemp);
            }

            return desc;
        }
        public override string ToString()
        {
            String ret;
            String nL = Environment.NewLine + "    ";

            ret = this.name + " is a " + this.getStatusDesc() + " star with spectral type " + this.specType;
            ret = ret + nL + "This star has " + this.currMass + " solar masses, and a current luminosity of " + Math.Round(this.currLumin,OptionCont.numberOfDecimal);
            ret = ret + nL + "solar luminosities. It has a surface temperature of " + Math.Round(this.effTemp,OptionCont.numberOfDecimal) + "K.";
            ret = ret + nL + "This star's radius is " + Math.Round(this.getRadiusAU(),OptionCont.numberOfDecimal) + " AU.";
            ret = ret + nL + "Apparent Color : " + Star.getColor(this.effTemp);

            if (OptionCont.getVerboseOutput())
            {
                ret = ret + Environment.NewLine;
                ret = ret + nL + "Initial Luminosity: " + this.initLumin + " solar luminosities.";
                ret = ret + nL + "Initial Mass: " + this.initMass + " solar masses";
                ret = ret + nL + "Formation Zones: " + Star.innerRadius(this.initLumin, this.initMass) + " AU to " + Math.Round(Star.outerRadius(this.initMass), OptionCont.numberOfDecimal) + " AU";
                ret = ret + nL + "Snow Line: " + Math.Round(Star.snowLine(this.initLumin),OptionCont.numberOfDecimal) + " AU.";
            }

            ret = ret + Environment.NewLine;
            if (this.isFlareStar)
            {
                ret = ret + nL + "This star is a flare star.";
            }

            ret = ret + Environment.NewLine;

            if (OptionCont.getVerboseOutput())
            {
                ret = ret + nL + "Self ID: " + Star.getDescOrderFlag(this.selfID) + " and Parent ID: " + Star.getDescOrderFlag(this.parentID);
                ret = ret + nL;
            }

            //printing out age details
            ret = ret + nL + "Evolution Data";
            ret = ret + Environment.NewLine;

            if (this.evoLine.getGiantLimit() < 1000)
            {
                ret = ret + nL + "Main Sequence Ends: " + this.evoLine.getMainLimit() + " Gyr,";
                ret = ret + " Subgiant Ends: " + this.evoLine.getSubLimit() + " Gyr";
                ret = ret + nL + "Giant Stage Ends: " + this.evoLine.getGiantLimit() + " Gyr";

                if (this.starAge < this.evoLine.getMainLimit())
                    ret = ret + nL + "This star will exit the main sequence phase in: " + (this.evoLine.getMainLimit() - this.starAge) + " Gyr";
                if (this.starAge >= this.evoLine.getMainLimit() && this.starAge < this.evoLine.getSubLimit())
                    ret = ret + nL + "This star will exit the subgiant phase in: " + (this.evoLine.getSubLimit() - this.starAge) + " Gyr";
                if (this.starAge >= this.evoLine.getSubLimit() && this.starAge < this.evoLine.getGiantLimit())
                    ret = ret + nL + "This star will exit the giant phase in: " + (this.evoLine.getGiantLimit() - this.starAge) + " Gyr";
                if (this.starAge >= this.evoLine.getGiantLimit())
                    ret = ret + nL + "This star has been a white dwarf for: " + (this.starAge - this.evoLine.getGiantLimit()) + " Gyr";
            }

            else
            {
                ret = ret + nL + "This star will burn out sometime well after the galaxy disappears.";
            }

            if (this.selfID != Star.IS_PRIMARY)
            {
                ret = ret + Environment.NewLine;
                ret = ret + nL + "Orbital Details";
                ret = ret + nL + "This orbits " + this.parentName + " at " + this.orbitalRadius + " AU.";

                if (this.orbitalEccent > 0)
                {
                    ret = ret + nL + "Eccentricity: " + this.orbitalEccent + ".";
                    ret = ret + nL + "Periapsis: " + Orbital.getPeriapsis(this.orbitalEccent, this.orbitalRadius) + " AU and Apapasis: " + Orbital.getApapsis(this.orbitalEccent, this.orbitalRadius) + " AU.";
                }

                ret = ret + nL + "Orbital period is " + Math.Round(this.orbitalPeriod,2) + " years (" + Math.Round(this.orbitalPeriod * 365.25,2);
                ret = ret + " days)";
                ret = ret + nL + "This has a seperation of " + libStarGen.getSeperationStr(this.orbitalSep);

            }

            ret = ret + nL;
            ret = ret + nL + "Orbital Details";
            foreach (Satellite s in this.sysPlanets)
            {
                ret = ret + nL + s;
                ret = ret + nL;
            }
            ret = ret + nL;

            if (OptionCont.getVerboseOutput())
            {
                ret = ret + nL;
                ret = ret + nL + "Formation Zone Details";
                ret = ret + nL;
                foreach (forbiddenZone r in this.zonesOfInterest.forbiddenZones)
                {
                    ret = ret + nL + r;
                }
                ret = ret + nL;
                foreach (cleanZone r in this.zonesOfInterest.formationZones)
                {
                    ret = ret + nL + r;
                }
                ret = ret + nL;
                ret = ret + nL + "Gas Giant Flag: " + Star.descGasGiantFlag(this.gasGiantFlag);
                ret = ret + nL;
            }

            return ret;
        }

        public static void generateEccentricity(int roll, Star s)
        {
            //set the eccentricity
            if (roll <= 3) s.orbitalEccent = 0;
            if (roll == 4) s.orbitalEccent = .1;
            if (roll == 5) s.orbitalEccent = .2;
            if (roll == 6) s.orbitalEccent = .3;
            if (roll == 7 || roll == 8) s.orbitalEccent = .4;
            if (roll >= 9 && roll <= 11) s.orbitalEccent = .5;
            if (roll == 12 || roll == 13) s.orbitalEccent = .6;
            if (roll == 14 || roll == 15) s.orbitalEccent = .7;
            if (roll == 16) s.orbitalEccent = .8;
            if (roll == 17) s.orbitalEccent = .9;
            if (roll >= 18) s.orbitalEccent = .95;
        }

        public static string getDescFromFlag(int flag)
        {
            if (flag == Star.IS_PRIMARY) return "Primary Star";
            if (flag == Star.IS_SECONDARY) return "Secondary Star";
            if (flag == Star.IS_SECCOMP) return "Secondary Companion";
            if (flag == Star.IS_TRINARY) return "Trinary Star";
            if (flag == Star.IS_TRICOMP) return "Trinary Companion";

            return "[ERROR]";
        }

        public void giveOrbitalsOrder(ref int totalOrbitals)
        {
            int currOrb = 0;
            foreach (Satellite s in this.sysPlanets)
            {
                s.selfID = currOrb;
                s.masterOrderID = totalOrbitals;
              
                totalOrbitals++;
                currOrb++;
            }
        }

    }
}