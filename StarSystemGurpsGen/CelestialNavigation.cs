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
            starTable.Columns.Add("Spectral Type", typeof(string));
            starTable.Columns.Add("Current Luminosity (sol lumin)", typeof(double));
            starTable.Columns.Add("Effective Temperature(K)", typeof(double));
            starTable.Columns.Add("Orbital Radius (AU)", typeof(double));
            starTable.Columns.Add("Gas Giant", typeof(string));
            starTable.Columns.Add("Color", typeof(string));
            starTable.Columns.Add("Stellar Evolution Stage", typeof(string));

            //assign the source. We do it this way to allow for refreshing things.
            starSource = new BindingSource();
            starSource.DataSource = this.starTable;
            createStarsFinished = false;

            dgvStars.DataSource = starSource;
        
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
                    starTable.Rows.Add(s.currMass, s.name, s.specType, Math.Round(s.currLumin,4), s.effTemp, s.orbitalRadius, Star.descGasGiantFlag(s.gasGiantFlag), s.starColor, s.returnCurrentBranchDesc());
                }

                lblSysAge.Text = this.ourSystem.sysAge + " GYr";
                lblSysName.Text = this.ourSystem.sysName;
            }
        }

        private void btnGenPlanets_Click(object sender, EventArgs e)
        {

        }

    }
}
