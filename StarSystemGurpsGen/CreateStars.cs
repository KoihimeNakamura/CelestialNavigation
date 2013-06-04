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
    /// This object basically runs stellar generation for the program
    /// </summary>
    public partial class CreateStars : Form
    {
        /// <summary>
        /// A passed StarSystem object (the one currently being used)
        /// </summary>
        public StarSystem ourSystem { get; set; }

        /// <summary>
        /// A passed Dice object
        /// </summary>
        public Dice velvetBag { get; set; }

        private CelestialNavigation parent { get; set; }

        /// <summary>
        /// Constructor object for the Create Stars 
        /// </summary>
        /// <param name="s">Our StarSystem</param>
        /// <param name="d">The dice we use</param>
        public CreateStars(StarSystem s, Dice d, CelestialNavigation p)
        {
            velvetBag = d;
            ourSystem = s;
            InitializeComponent();
            parent = p;

            //creates a tool tip for the form.
            ToolTip starToolTip = new ToolTip();
            starToolTip.AutomaticDelay = 5000;
            starToolTip.InitialDelay = 1000;
            starToolTip.ReshowDelay = 500;
            starToolTip.ShowAlways = true; //always show it.

            //adds the tool tips
            starToolTip.SetToolTip(this.chkForceGarden, "Affects star size and spacing (larger size, more spaced stars");
            starToolTip.SetToolTip(this.chkVerbose, "Enables more in depth output in the file.");
            starToolTip.SetToolTip(this.chkOpenCluster, "Places the star in an open cluster. Adds a +3 modifier to the star number roll.");
            starToolTip.SetToolTip(this.chkStarOverride, "Number of Stars. Rather than rolling, this force sets it to the indicated value [1-3].");
            starToolTip.SetToolTip(this.chkAgeOverride, "The Age of the System. It's normally determined by rolling.");
            starToolTip.SetToolTip(this.chkLesserEccentricity, "Caps stellar eccentricity at .5 instead of .99.");
            starToolTip.SetToolTip(this.chkExtLowStellar, "Caps stellar eccentricity at .1 instead of .99");
            starToolTip.SetToolTip(this.chkStellarMass, "Overrides the star mass generator used in GURPS with one that rolls in the set range.");
            starToolTip.SetToolTip(this.chkFantasyColors, "Replaces the color determined by surface temperature with a randomly generated one during star generation.");
            starToolTip.SetToolTip(this.chkBypassRules, "Instead of using the rules (count entries down), this rolls the secondary star mass until it's under the max mass.");

        }

        /// <summary>
        /// This function hides or shows the number of stars you wish to create. See <see cref="OptionCont.numStars"/> for more details.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void numStarOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStarOverride.Checked)
                numStars.Visible = true;

            if (!chkStarOverride.Checked)
                numStars.Visible = false;

        }

        /// <summary>
        /// This function hides or shows the age of the system choice control. See <see cref="OptionCont.agePreset"/> for more details.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void chkAgeOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgeOverride.Checked)
            {
                numAge.Visible = true;
                lblAgeYear.Visible = true;
            }

            if (!chkAgeOverride.Checked)
            {
                numAge.Visible = false;
                lblAgeYear.Visible = false;
            }
        }

        /// <summary>
        /// This function hides or shows the stellar mass choice control. See <see cref="OptionCont.stellarMassRangeSet"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void chkStellarMass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStellarMass.Checked)
            {
                lblMass.Visible = true;
                lblMassB.Visible = true;
                numMinMass.Visible = true;
                numMaxMass.Visible = true;
            }

            if (!chkStellarMass.Checked)
            {
                lblMass.Visible = false;
                lblMassB.Visible = false;
                numMinMass.Visible = false;
                numMaxMass.Visible = false;
            }

        }
        /// <summary>
        /// Saves set options to the Option Container and generates the stars. Then updates the datatable, and returns back to the
        /// main window. 
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnGenStars_Click(object sender, EventArgs e)
        {
            //save to OptionCont
            OptionCont.forceGardenFavorable = chkForceGarden.Checked;
            OptionCont.inOpenCluster = chkOpenCluster.Checked;
            OptionCont.setVerboseOutput(chkVerbose.Checked);

            //set age, or clear age. 
            if (chkAgeOverride.Checked)
               OptionCont.setSystemAge((double)numAge.Value);

            if (!chkAgeOverride.Checked)
                OptionCont.setSystemAge(-1.0);

            //set stars, or clear stars
            if (chkStarOverride.Checked)
                OptionCont.setNumberOfStars((int)numStars.Value);
            if (!chkStarOverride.Checked)
                OptionCont.setNumberOfStars(-1);

            OptionCont.lessStellarEccent = chkLesserEccentricity.Checked;
            OptionCont.forceVeryLowStellarEccent = chkExtLowStellar.Checked;

            //set stellar mass options
            OptionCont.stellarMassRangeSet = chkStellarMass.Checked;
            OptionCont.minStellarMass = (double)numMinMass.Value;
            OptionCont.maxStellarMass = (double)numMaxMass.Value;

            OptionCont.fantasyColors = chkFantasyColors.Checked;
            OptionCont.moreFlareStarChance = chkMoreFlare.Checked;
            OptionCont.anyStarFlareStar = chkAnyFlareStar.Checked;

            //now we start setting system parameters.
            if (txtSysName.Text == "")
                this.ourSystem.sysName = libStarGen.genRandomSysName(OptionCont.sysNamePrefix, velvetBag);
            else
                this.ourSystem.sysName = txtSysName.Text;

            this.ourSystem.sysAge = libStarGen.genSystemAge(velvetBag);

            //start creating and making stars.
            libStarGen.createStars(velvetBag, ourSystem);
            parent.createStarsFinished = true;
            this.Close(); //close the form
            
        }

        /// <summary>
        /// Generates a random name.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void btnRandomName_Click(object sender, EventArgs e)
        {
            txtSysName.Text = libStarGen.genRandomSysName(OptionCont.sysNamePrefix, velvetBag);
        }

    }
}
