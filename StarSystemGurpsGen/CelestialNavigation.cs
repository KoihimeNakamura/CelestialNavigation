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

        public CelestialNavigation()
        {
            ourSystem = new StarSystem();
            velvetBag = new Dice();
            InitializeComponent();

            //assign the source. We do it this way to allow for refreshing things.
            starSource = new BindingSource();
            starSource.DataSource = this.ourSystem.sysStars;

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
    }
}
