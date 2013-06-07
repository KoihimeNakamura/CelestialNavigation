using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSystemGurpsGen
{
    /// <summary>
    /// This form is used to create the planets.
    /// </summary>
    public partial class CreatePlanets : Form
    {

        /// <summary>
        /// A passed StarSystem object (the one currently being used)
        /// </summary>
        public StarSystem ourSystem { get; set; }

        /// <summary>
        /// A passed Dice object
        /// </summary>
        public Dice velvetBag { get; set; }

        /// <summary>
        /// Parent object, used to pass to the main thing when we're done successfully.
        /// </summary>
        private CelestialNavigation parent { get; set; }


        /// <summary>
        /// The constructor object for this form
        /// </summary>
        public CreatePlanets(StarSystem o, Dice d, CelestialNavigation p)
        {
            this.parent = p;
            this.velvetBag = d;
            this.ourSystem = o; 

            InitializeComponent();

            //creates a tool tip for the form.
            ToolTip starToolTip = new ToolTip();
            starToolTip.AutomaticDelay = 5000;
            starToolTip.InitialDelay = 1000;
            starToolTip.ReshowDelay = 500;
            starToolTip.ShowAlways = true; //always show it.

            starToolTip.SetToolTip(this.chkConGasGiant,"Increases the chances of a conventional gas giant arrangement.");
            starToolTip.SetToolTip(this.onlyGarden, "Only generate Garden worlds, never Ocean worlds.");
            starToolTip.SetToolTip(this.chkMoreAccurateO2Catastrophe, "The Oxygen Catastrophe is now roughly at 3 billion years. (divide by .3 instead of .5)");
            starToolTip.SetToolTip(this.frcStableActivity, "Force tectonic and volcanic activity to be stable.");
            starToolTip.SetToolTip(this.highRVM, "Rather than roll 1-16, it rolls 10-16 on the RVM table.");
            starToolTip.SetToolTip(this.ignoreTides, "Ignore Lunar Tides on Garden Worlds.");
            starToolTip.SetToolTip(this.overridePressure, "This overrides the generated pressure on garden worlds.");
            starToolTip.SetToolTip(this.overrideMoons, "Force generates a certain number of moons on the garden worlds.");
            starToolTip.SetToolTip(this.chkOverrideTilt, "This overrides the axial tilt generation on ALL worlds.");
            starToolTip.SetToolTip(this.chkKeepAxialTiltUnder45, "This rerolls all axial tilts over 45 degrees until it's under.");
            starToolTip.SetToolTip(this.chkDisplayTidalData, "Always display tidal data.");
            starToolTip.SetToolTip(this.chkExpandAsteroidBelt, "Expanded Asteroid Belt sizes/options.");
            
            //tool tips for the moon options
            starToolTip.SetToolTip(this.bookMoon, "Generates purely by the book. (2d6+mods)");
            starToolTip.SetToolTip(this.bookHigh, "Generates by the book but limits to the higher half. (1d6+6+mods)");
            starToolTip.SetToolTip(this.extendNorm, "Generates an orbit range (2d10+mods)");
            starToolTip.SetToolTip(this.extendHigh, "Generated an high orbit range (1d10+10+mods)");
        }

        private void overridePressure_CheckedChanged(object sender, EventArgs e)
        {
            if (overridePressure.Checked)
            {
                lblAtm.Visible = true;
                numAtmPressure.Visible = true;
            }

            if (!overridePressure.Checked)
            {
                lblAtm.Visible = false;
                numAtmPressure.Visible = false;
            }
        }

        /// <summary>
        /// This hides or unhides the moon selector based on the check of it's check mark.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgs object</param>
        private void overrideMoons_CheckedChanged(object sender, EventArgs e)
        {
            if (overrideMoons.Checked)
            {
                lblMoons.Visible = true;
                numMoons.Visible = true;
            }

            if (!overrideMoons.Checked)
            {
                lblMoons.Visible = false;
                numMoons.Visible = false;
            }
        }

        /// <summary>
        /// Sends the completed status and begins generating the planets
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgs object</param>
        private void btnGenPlanets_Click(object sender, EventArgs e)
        {
            //save options
            OptionCont.moreConGasGiantChances = chkConGasGiant.Checked;
            OptionCont.noOceanOnlyGarden = onlyGarden.Checked;
            OptionCont.moreAccurateO2Catastrophe = chkMoreAccurateO2Catastrophe.Checked;
            OptionCont.stableActivity = frcStableActivity.Checked;
            OptionCont.noMarginalAtm = noMarginAtm.Checked;
            OptionCont.highRVMVal = highRVM.Checked;
            OptionCont.overrideHabitability = chkHigherHabitability.Checked;
            OptionCont.ignoreLunarTidesOnGardenWorlds = ignoreTides.Checked;
            OptionCont.rerollAxialTiltOver45 = chkKeepAxialTiltUnder45.Checked;
            OptionCont.alwaysDisplayTidalData = chkDisplayTidalData.Checked;
            OptionCont.expandAsteroidBelt = chkExpandAsteroidBelt.Checked;

            if (overrideMoons.Checked) OptionCont.setNumberOfMoonsOverGarden((int)numMoons.Value);
            if (overridePressure.Checked) OptionCont.setAtmPressure = (double)numAtmPressure.Value;
            if (chkOverrideTilt.Checked) OptionCont.setAxialTilt((int)numTilt.Value);

            //set the moon option.
            if (bookHigh.Checked) OptionCont.moonOrbitFlag = OptionCont.MOON_BOOKHIGH;
            if (bookMoon.Checked) OptionCont.moonOrbitFlag = OptionCont.MOON_BOOK;
            if (extendHigh.Checked) OptionCont.moonOrbitFlag = OptionCont.MOON_EXPANDHIGH;
            if (extendNorm.Checked) OptionCont.moonOrbitFlag = OptionCont.MOON_EXPAND;

            //generate the planets!
            int totalOrbCount = 0; //total orbital count

            //first off, master loop. 
            for (int currStar = 0; currStar < this.ourSystem.sysStars.Count; currStar++)
            {
                Range temp;
                //draw up forbidden zones.
                if (!this.ourSystem.sysStars[currStar].testInitlizationZones()) this.ourSystem.sysStars[currStar].initalizeZonesOfInterest();
                for (int i = 1; i < this.ourSystem.sysStars.Count; i++)
                {
                    if (this.ourSystem.sysStars[i].parentID == this.ourSystem.sysStars[currStar].selfID)
                    {
                        temp = new Range(this.ourSystem.sysStars[i].getInnerForbiddenZone(), this.ourSystem.sysStars[i].getOuterForbiddenZone());
                        this.ourSystem.sysStars[currStar].createForbiddenZone(temp, this.ourSystem.sysStars[currStar].selfID, this.ourSystem.sysStars[i].selfID);
                    }
                    if (this.ourSystem.sysStars[i].selfID == this.ourSystem.sysStars[currStar].selfID)
                    {
                        temp = new Range(this.ourSystem.sysStars[i].getInnerForbiddenZone(), this.ourSystem.sysStars[i].getOuterForbiddenZone());
                        this.ourSystem.sysStars[currStar].createForbiddenZone(temp, this.ourSystem.sysStars[currStar].parentID, this.ourSystem.sysStars[currStar].selfID);
                    }
                }

                this.ourSystem.sysStars[currStar].sortForbidden();
                this.ourSystem.sysStars[currStar].createCleanZones();
                //gas giant flag
                libStarGen.gasGiantFlag(this.ourSystem.sysStars[currStar], velvetBag.gurpsRoll());

                Satellite placeHolder = new Satellite(0, 0, 0, 0);
                int ownership, roll;
                double orbit = 0;
                if (this.ourSystem.sysStars[currStar].gasGiantFlag != Star.GASGIANT_NONE)
                {
                    double rangeAvail = 0, lowerBound = 0, diffRange = 0;
                    Range spawnRange = new Range(0, 1);

                    //get range availability and spawn range

                    //CONVENTIONAL
                    if (this.ourSystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_CONVENTIONAL)
                    {
                        rangeAvail = this.ourSystem.sysStars[currStar].checkConRange();
                        lowerBound = Star.snowLine(this.ourSystem.sysStars[currStar].initLumin) * 1;
                        diffRange = (Star.snowLine(this.ourSystem.sysStars[currStar].initLumin) * 1.5) - lowerBound;
                        spawnRange = this.ourSystem.sysStars[currStar].getConventionalRange();
                    }

                    //ECCENTRIC
                    if (this.ourSystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_ECCENTRIC)
                    {
                        rangeAvail = this.ourSystem.sysStars[currStar].checkEccRange();
                        lowerBound = Star.snowLine(this.ourSystem.sysStars[currStar].initLumin) * .125;
                        diffRange = (Star.snowLine(this.ourSystem.sysStars[currStar].initLumin) * .75) - lowerBound;
                        spawnRange = this.ourSystem.sysStars[currStar].getEccentricRange();
                    }

                    //EPISTELLAR 
                    if (this.ourSystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                    {
                        rangeAvail = this.ourSystem.sysStars[currStar].checkEpiRange();
                        lowerBound = Star.innerRadius(this.ourSystem.sysStars[currStar].initLumin, this.ourSystem.sysStars[currStar].initMass) * .1;
                        diffRange = (Star.innerRadius(this.ourSystem.sysStars[currStar].initLumin, this.ourSystem.sysStars[currStar].initMass) * 1.8) - lowerBound;
                        spawnRange = this.ourSystem.sysStars[currStar].getEpistellarRange();
                    }

                    if (rangeAvail >= .25)
                    {
                        do
                        {
                            orbit = velvetBag.rollRange(lowerBound, diffRange);
                        } while (!this.ourSystem.sysStars[currStar].verifyCleanOrbit(orbit));

                        ownership = this.ourSystem.sysStars[currStar].getOwnership(orbit);

                        if (this.ourSystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                            ownership = this.ourSystem.sysStars[currStar].selfID;

                        placeHolder = new Satellite(ownership, 0, orbit, 0, Satellite.BASETYPE_GASGIANT);

                        roll = velvetBag.gurpsRoll() + 4;
                        libStarGen.updateGasGiantSize(placeHolder, roll);
                    }

                    if (rangeAvail >= .005 && rangeAvail < .25)
                    {
                        orbit = this.ourSystem.sysStars[currStar].pickInRange(spawnRange);
                        ownership = this.ourSystem.sysStars[currStar].getOwnership(orbit);
                        if (this.ourSystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                            ownership = this.ourSystem.sysStars[currStar].selfID;

                        placeHolder = new Satellite(ownership, 0, orbit, 0, Satellite.BASETYPE_GASGIANT);

                        roll = velvetBag.gurpsRoll() + 4;
                        libStarGen.updateGasGiantSize(placeHolder, roll);
                    }
                }

                //now we've determined our placeholdr, let's start working on our orbitals.

                double currOrbit = Star.innerRadius(this.ourSystem.sysStars[currStar].initLumin, this.ourSystem.sysStars[currStar].initMass), nextOrbit = 0;
                double distance = .15;

                //now we have our placeholder.
                if (placeHolder.orbitalRadius != 0)
                {
                    this.ourSystem.sysStars[currStar].addSatellite(placeHolder);
                    currOrbit = placeHolder.orbitalRadius;
                }

                if (this.ourSystem.sysStars[currStar].gasGiantFlag != Star.GASGIANT_EPISTELLAR && placeHolder.orbitalRadius != 0)
                {
                    //we're moving left.
                    //LEFT RIGHT LEFT
                    //.. sorry about that
                    double innerRadius = Star.innerRadius(this.ourSystem.sysStars[currStar].initLumin, this.ourSystem.sysStars[currStar].initMass);
                    do
                    {
                        //as we're moving left, divide.
                        nextOrbit = currOrbit / libStarGen.getOrbitalRatio(velvetBag);

                        if (nextOrbit > currOrbit - distance)
                            nextOrbit = currOrbit - distance;

                        if (this.ourSystem.sysStars[currStar].verifyCleanOrbit(nextOrbit) && this.ourSystem.sysStars[currStar].withinCreationRange(nextOrbit))
                        {
                            ownership = this.ourSystem.sysStars[currStar].getOwnership(nextOrbit);
                            this.ourSystem.sysStars[currStar].addSatellite(new Satellite(ownership, 0, nextOrbit, 0));
                        }

                        currOrbit = nextOrbit;

                        //now let's check on 
                    } while (currOrbit > innerRadius);

                }

                //MOVE RIGHT!
                //now we have our placeholder.
                if (this.ourSystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR || placeHolder.orbitalRadius == 0)
                {
                    double outerRadius = Star.outerRadius(this.ourSystem.sysStars[currStar].initMass);
                    do
                    {
                        //as we're moving right, multiply.
                        nextOrbit = currOrbit * libStarGen.getOrbitalRatio(velvetBag);

                        if (nextOrbit < currOrbit + distance)
                            nextOrbit = currOrbit + distance;

                        if (this.ourSystem.sysStars[currStar].verifyCleanOrbit(nextOrbit) && this.ourSystem.sysStars[currStar].withinCreationRange(nextOrbit))
                        {
                            ownership = this.ourSystem.sysStars[currStar].getOwnership(nextOrbit);
                            this.ourSystem.sysStars[currStar].addSatellite(new Satellite(ownership, 0, nextOrbit, 0));
                        }

                        currOrbit = nextOrbit;

                        if (currOrbit < 0)
                            currOrbit = outerRadius + 10;
                        //now let's check on 
                    } while (currOrbit < outerRadius);
                }

                //if a clean zone has 0 planets, add one.
                foreach (cleanZone c in this.ourSystem.sysStars[currStar].zonesOfInterest.formationZones)
                {
                    if (!this.ourSystem.sysStars[currStar].cleanZoneHasOrbits(c))
                    {
                        nextOrbit = this.ourSystem.sysStars[currStar].pickInRange(c.getRange());
                        ownership = this.ourSystem.sysStars[currStar].getOwnership(nextOrbit);
                        this.ourSystem.sysStars[currStar].addSatellite(new Satellite(ownership, 0, nextOrbit, 0));
                    }
                }

                //sort orbitals
                this.ourSystem.sysStars[currStar].sortOrbitals();
                this.ourSystem.sysStars[currStar].giveOrbitalsOrder(ref totalOrbCount);

                //now we get orbital contents, then fill in details
                libStarGen.populateOrbits(this.ourSystem.sysStars[currStar], velvetBag);

                //set any star with all empty orbits to have one planet
                if (this.ourSystem.sysStars[currStar].isAllEmptyOrbits() && OptionCont.ensureOneOrbit)
                {
                    int newPlanet = velvetBag.rng(1, this.ourSystem.sysStars[currStar].sysPlanets.Count, -1);
                    this.ourSystem.sysStars[currStar].sysPlanets[newPlanet].updateTypeSize(Satellite.BASETYPE_TERRESTIAL, Satellite.SIZE_MEDIUM);
                }
            }

            for (int currStar = 0; currStar < this.ourSystem.sysStars.Count; currStar++)
            {
                double[,] distChart = libStarGen.genDistChart(this.ourSystem.sysStars);
                for (int i = 0; i < this.ourSystem.sysStars[currStar].sysPlanets.Count; i++)
                {
                    this.ourSystem.sysStars[currStar].sysPlanets[i].updateBlackBodyTemp(distChart, this.ourSystem.sysStars);
                }
                libStarGen.createPlanets(this.ourSystem, this.ourSystem.sysStars[currStar].sysPlanets, velvetBag);
            }
        }

        /// <summary>
        /// Display or hide the override tilt based on if this is checked.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgs object</param>
        private void chkOverrideTilt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverrideTilt.Checked)
            {
                lblDegrees.Visible = true;
                numTilt.Visible = true;
            }

            if (!chkOverrideTilt.Checked)
            {
                lblDegrees.Visible = false;
                numTilt.Visible = false;
            }
        }

    }
}
