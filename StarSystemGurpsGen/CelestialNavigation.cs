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
    public partial class CelestialNavigation : Form
    {
        /// <summary>
        ///   This is our star system. There are many like it, but this is ours. 
        ///   Used to keep all of our details
        /// </summary>
        public StarSystem ourSystem { get; set; }

        /// <summary>
        ///  The dice this program uses. Our PRNG.
        /// </summary>
        public Dice velvetBag { get; set; }

        /// <summary>
        ///  The binding source for the star display DGV.
        /// </summary>
        private BindingSource starSource { get; set; }

        /// <summary>
        ///  The star display table. Used to abstract things.
        /// </summary>
        private DataTable starTable { get; set; }

        /// <summary>
        /// The binding soruce for the planet display DGV
        /// </summary>
        private BindingSource planetSource { get; set; }

        /// <summary>
        /// The plaent display table. Used to abstract things.
        /// </summary>
        private DataTable planetTable { get; set; }

        /// <summary>
        /// This is used to tell the parent form (this form) we're done with star generation
        /// </summary>
        public bool createStarsFinished { get; set; }

        /// <summary>
        /// This is used to tell the parent form (this form) we're done with planet generation.
        /// </summary>
        public bool createPlanetsFinished { get; set; }

        /// <summary>
        /// Constructor for the form object.
        /// </summary>
        public CelestialNavigation()
        {
            ourSystem = new StarSystem();
            velvetBag = new Dice();
            InitializeComponent();

            starTable = new DataTable("starTable");
            starTable.Columns.Add("Current Mass (sol mass)", typeof(double));
            starTable.Columns.Add("Name", typeof(string));
            starTable.Columns.Add("Order", typeof(string));
            starTable.Columns.Add("Spectral Type", typeof(string));
            starTable.Columns.Add("Current Luminosity (sol lumin)", typeof(double));
            starTable.Columns.Add("Effective Temperature(K)", typeof(double));
            starTable.Columns.Add("Orbital Radius (AU)", typeof(double));
            starTable.Columns.Add("Gas Giant", typeof(string));
            starTable.Columns.Add("Color", typeof(string));
            starTable.Columns.Add("Stellar Evolution Stage", typeof(string));
            starTable.Columns.Add("Flare Star", typeof(string));

            planetTable = new DataTable("planetTable");
            planetTable.Columns.Add("Name", typeof(string));
            planetTable.Columns.Add("Size (Type)", typeof(string));
            planetTable.Columns.Add("Diameter (KM)", typeof(double));
            planetTable.Columns.Add("Orbital Radius (AU)", typeof(double));
            planetTable.Columns.Add("Gravity (m/s)", typeof(double));
            planetTable.Columns.Add("Atmosphere Pressure (atm)", typeof(string));
            planetTable.Columns.Add("Atmosphere Notes", typeof(string));
            planetTable.Columns.Add("Hydrographic Coverage", typeof(string));
            planetTable.Columns.Add("Climate Data", typeof(string));
            planetTable.Columns.Add("Resource Indicator", typeof(string));


            //assign the source. We do it this way to allow for refreshing things.
            starSource = new BindingSource();
            starSource.DataSource = this.starTable;
            createStarsFinished = false;

            planetSource = new BindingSource();
            planetSource.DataSource = this.planetTable;
            createPlanetsFinished = false;

            dgvStars.DataSource = starSource;
            dgvPlanets.DataSource = planetSource;

            dgvPlanets.Columns[2].Width = 130;
            dgvPlanets.Columns[3].Width = 100;
            dgvPlanets.Columns[5].Width = 160;
            dgvPlanets.Columns[6].Width = 150;
            dgvPlanets.Columns[7].Width = 100;
            dgvPlanets.Columns[8].Width = 195;
        
        }

        /// <summary>
        ///  This refreshes the DataGridView for displaying stars
        /// </summary>
        private void refreshStarDGV()
        {
            // dgvLegacyAM.DataSource = null;
            // dgvLegacyAM.DataSource = ourAm;
            starSource.ResetBindings(false);
        }

        /// <summary>
        /// This refreshes the PlanetGridView for displaying planets
        /// </summary>
        private void refreshPlanetDGV()
        {
            planetSource.ResetBindings(false);
        }

        /// <summary>
        /// Begin Step 1 - generating the base system and stars, then displays them
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnGenStars_Click(object sender, EventArgs e)
        {
            this.createStarsFinished = false;

            //clear the tables.
            if (this.ourSystem.countStars() > 0)
            {
                this.ourSystem.sysStars.Clear();
                this.starTable.Clear();
                refreshStarDGV();
            }

            CreateStars nCS = new CreateStars(this.ourSystem, this.velvetBag, this);

            //register a closed event here.
            nCS.FormClosed += new System.Windows.Forms.FormClosedEventHandler(createStars_Closed);
            nCS.ShowDialog();
        }

        /// <summary>
        /// Resets the system.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ourSystem.resetSystem();
            lblSysAge.Text = "";
            lblSysName.Text = "";

            this.ourSystem.sysStars.Clear();
            this.starTable.Clear();
            refreshStarDGV();

            lblNumberPlanets.Text = "";
            this.planetTable.Clear();
            refreshPlanetDGV();
        }

        /// <summary>
        /// The object called when the create stars form is closed. Checks to see if we should update the listing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void createStars_Closed(object sender, EventArgs e)
        {
            if (this.createStarsFinished)
            {
                foreach (Star s in this.ourSystem.sysStars)
                {
                    object[] rowVal = new object[11];
                    rowVal[0] = s.currMass;
                    rowVal[1] = s.name;
                    rowVal[2] = Star.getDescFromFlag(s.selfID);
                    rowVal[3] = s.specType;
                    rowVal[4] = Math.Round(s.currLumin, 4);
                    rowVal[5] = s.effTemp;
                    rowVal[6] = s.orbitalRadius;
                    rowVal[7] = Star.descGasGiantFlag(s.gasGiantFlag);
                    rowVal[8] = s.starColor;
                    rowVal[9] = s.returnCurrentBranchDesc();
                    rowVal[10] = s.isFlareStar;

                    starTable.Rows.Add(rowVal);
                }

                lblSysAge.Text = this.ourSystem.sysAge + " GYr";
                lblSysName.Text = this.ourSystem.sysName;
            }
        }

        /// <summary>
        /// The object called when the create planets form is closed. Checks to see if we should update the listing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void createPlanets_Closed(object sender, EventArgs e)
        {
            if (this.createPlanetsFinished)
            {
                lblNumberPlanets.Text = this.ourSystem.countPlanets().ToString();
                foreach (Star s in this.ourSystem.sysStars)
                {
                    foreach (Satellite pl in s.sysPlanets)
                    {
                        if (pl.baseType != Satellite.BASETYPE_EMPTY)
                        {
                            object[] ourValues = new object[10];
                            ourValues[0] = pl.name;
                            
                            if (pl.baseType != Satellite.BASETYPE_ASTEROIDBELT || OptionCont.expandAsteroidBelt)
                            {
                                ourValues[1] = pl.descSizeType();
                            }
                            if (pl.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                            {
                                ourValues[1] = "Asteroid Belt";
                            }

                            ourValues[2] = Math.Round(pl.diameterInKM(), 2);
                            ourValues[3] = Math.Round(pl.orbitalRadius, 2);
                            ourValues[4] = Math.Round(pl.gravity * Satellite.GFORCE, 2);
                            
                            if (pl.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                                ourValues[5] = "None.";

                            if (pl.baseType == Satellite.BASETYPE_GASGIANT)
                                ourValues[5] = "Superdense Atmosphere.";

                            if (pl.baseType == Satellite.BASETYPE_MOON || pl.baseType == Satellite.BASETYPE_TERRESTIAL)
                                ourValues[5] = pl.getDescAtmCategory() + "(" + Math.Round(pl.atmPres,2) + ")";
                            

                            ourValues[6] = pl.descAtm();
                            ourValues[7] = (pl.hydCoverage * 100) + "%";

                            if (pl.baseType == Satellite.BASETYPE_MOON || pl.baseType == Satellite.BASETYPE_TERRESTIAL)
                                ourValues[8] = pl.getClimateDesc(pl.getClimate(pl.surfaceTemp)) + "( " + Math.Round(pl.surfaceTemp, 2) + "K/ " + Math.Round(libStarGen.convertTemp("kelvin", "celsius", pl.surfaceTemp), 2) + "C)";
                            else
                                ourValues[8] = "Blackbody Temperature: " + Math.Round(pl.blackbodyTemp,2) + "K";

                            ourValues[9] = pl.getRVMDesc();

                            planetTable.Rows.Add(ourValues);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the planetary generator
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnGenPlanets_Click(object sender, EventArgs e)
        {
            this.createPlanetsFinished = false;

            //clear the tables.
            if (this.ourSystem.countPlanets() > 0)
            {
                this.ourSystem.clearPlanets();
                this.planetTable.Clear();
                refreshPlanetDGV();
            }

            CreatePlanets pCS = new CreatePlanets(this.ourSystem, this.velvetBag, this);

            //register a closed event here.
            pCS.FormClosed += new System.Windows.Forms.FormClosedEventHandler(createPlanets_Closed);
            pCS.ShowDialog();
        }

        private void chkEmptyDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmptyDisplay.Checked)
            {
                if (this.createPlanetsFinished)
                {
                    lblNumberPlanets.Text = this.ourSystem.countPlanets().ToString();
                    this.planetTable.Clear();
                    refreshPlanetDGV();
                    foreach (Star s in this.ourSystem.sysStars)
                    {
                        foreach (Satellite pl in s.sysPlanets)
                        {
                            object[] ourValues = new object[10];
                            ourValues[0] = pl.name;

                            if (pl.baseType != Satellite.BASETYPE_ASTEROIDBELT || OptionCont.expandAsteroidBelt)
                            {
                                ourValues[1] = pl.descSizeType();
                            }
                            if (pl.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                            {
                                ourValues[1] = "Asteroid Belt";
                            }

                            if (pl.baseType == Satellite.BASETYPE_EMPTY)
                                ourValues[1] = "Empty";

                            ourValues[2] = Math.Round(pl.diameterInKM(), 2);
                            ourValues[3] = Math.Round(pl.orbitalRadius, 2);
                            ourValues[4] = Math.Round(pl.gravity * Satellite.GFORCE, 2);

                            if (pl.baseType == Satellite.BASETYPE_ASTEROIDBELT || pl.baseType == Satellite.BASETYPE_EMPTY)
                                ourValues[5] = "None.";

                            if (pl.baseType == Satellite.BASETYPE_GASGIANT)
                                ourValues[5] = "Superdense Atmosphere.";

                            if (pl.baseType == Satellite.BASETYPE_MOON || pl.baseType == Satellite.BASETYPE_TERRESTIAL)
                                ourValues[5] = pl.getDescAtmCategory() + "(" + Math.Round(pl.atmPres, 2) + ")";


                            ourValues[6] = pl.descAtm();
                            ourValues[7] = (pl.hydCoverage * 100) + "%";

                            if (pl.baseType == Satellite.BASETYPE_MOON || pl.baseType == Satellite.BASETYPE_TERRESTIAL)
                                ourValues[8] = pl.getClimateDesc(pl.getClimate(pl.surfaceTemp)) + "( " + Math.Round(pl.surfaceTemp, 2) + "K/ " + Math.Round(libStarGen.convertTemp("kelvin", "celsius", pl.surfaceTemp), 2) + "C)";
                            else
                                ourValues[8] = "Blackbody Temperature: " + Math.Round(pl.blackbodyTemp, 2) + "K";

                            ourValues[9] = pl.getRVMDesc();

                            planetTable.Rows.Add(ourValues);
                        }
                    }
                }
            }

            if (!chkEmptyDisplay.Checked)
            {
                if (this.createPlanetsFinished)
                {
                    lblNumberPlanets.Text = this.ourSystem.countPlanets().ToString();
                    this.planetTable.Clear();
                    refreshPlanetDGV();
                    foreach (Star s in this.ourSystem.sysStars)
                    {
                        foreach (Satellite pl in s.sysPlanets)
                        {
                            if (pl.baseType != Satellite.BASETYPE_EMPTY)
                            {
                                object[] ourValues = new object[10];
                                ourValues[0] = pl.name;

                                if (pl.baseType != Satellite.BASETYPE_ASTEROIDBELT || OptionCont.expandAsteroidBelt)
                                {
                                    ourValues[1] = pl.descSizeType();
                                }
                                if (pl.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                                {
                                    ourValues[1] = "Asteroid Belt";
                                }

                                ourValues[2] = Math.Round(pl.diameterInKM(), 2);
                                ourValues[3] = Math.Round(pl.orbitalRadius, 2);
                                ourValues[4] = Math.Round(pl.gravity * Satellite.GFORCE, 2);

                                if (pl.baseType == Satellite.BASETYPE_ASTEROIDBELT)
                                    ourValues[5] = "None.";

                                if (pl.baseType == Satellite.BASETYPE_GASGIANT)
                                    ourValues[5] = "Superdense Atmosphere.";

                                if (pl.baseType == Satellite.BASETYPE_MOON || pl.baseType == Satellite.BASETYPE_TERRESTIAL)
                                    ourValues[5] = pl.getDescAtmCategory() + "(" + Math.Round(pl.atmPres, 2) + ")";


                                ourValues[6] = pl.descAtm();
                                ourValues[7] = (pl.hydCoverage * 100) + "%";

                                if (pl.baseType == Satellite.BASETYPE_MOON || pl.baseType == Satellite.BASETYPE_TERRESTIAL)
                                    ourValues[8] = pl.getClimateDesc(pl.getClimate(pl.surfaceTemp)) + "( " + Math.Round(pl.surfaceTemp, 2) + "K/ " + Math.Round(libStarGen.convertTemp("kelvin", "celsius", pl.surfaceTemp), 2) + "C)";
                                else
                                    ourValues[8] = "Blackbody Temperature: " + Math.Round(pl.blackbodyTemp, 2) + "K";

                                ourValues[9] = pl.getRVMDesc();

                                planetTable.Rows.Add(ourValues);
                            }
                        }
                    }
                }
            }
        }

    }
}
