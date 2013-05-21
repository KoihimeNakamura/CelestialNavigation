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

        public CelestialNavigation()
        {
            ourSystem = new StarSystem();
            velvetBag = new Dice();
            InitializeComponent();

            starTable = new DataTable("starTable");
            starTable.Columns.Add("currMass", typeof(double));
            starTable.Columns.Add("name", typeof(string));
            starTable.Columns.Add("currLumin", typeof(double));
            starTable.Columns.Add("effTemp", typeof(double));
            starTable.Columns.Add("orbitalRadius", typeof(double));
            starTable.Columns.Add("gasGiantFlag", typeof(string));
            starTable.Columns.Add("starColor", typeof(string));
            starTable.Columns.Add("currentStage", typeof(string));

            //assign the source. We do it this way to allow for refreshing things.
            starSource = new BindingSource();
            starSource.DataSource = this.starTable;

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
        /// Begin Step 1 - generating the base system and stars.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnGenStars_Click(object sender, EventArgs e)
        {
            CreateStars nCS = new CreateStars(this.ourSystem, this.velvetBag);
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
        }
    }
}
