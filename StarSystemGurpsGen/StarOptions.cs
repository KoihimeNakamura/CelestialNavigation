using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace StarSystemGurpsGen
{
    public partial class StarOptions : Form
    {
        protected StarSystemGurpsGen parent;

        public StarOptions(StarSystemGurpsGen s)
        {
            InitializeComponent();
            parent = s;
        }

        private void appChanges_Click(object sender, EventArgs e)
        {
            applyChanges();
        }

        private void applyChanges()
        {
            //set the moon flags.
            if (bookMoon.Checked == true) OptionCont.moonOrbitFlag = OptionCont.MOON_BOOK;
            if (bookHigh.Checked == true) OptionCont.moonOrbitFlag = OptionCont.MOON_BOOKHIGH;
            if (extendNorm.Checked == true) OptionCont.moonOrbitFlag = OptionCont.MOON_EXPAND;
            if (extendHigh.Checked == true) OptionCont.moonOrbitFlag = OptionCont.MOON_EXPANDHIGH;

            //garden options
            if (forceGarden.Checked == true) OptionCont.forceGardenFavorable = true;
            if (forceGarden.Checked == false) OptionCont.forceGardenFavorable = false;

            //open cluster
            if (openCluster.Checked == true) OptionCont.inOpenCluster = true;
            if (openCluster.Checked == false) OptionCont.inOpenCluster = false;

            //tidal data
            if (alwaysTidalData.Checked == true) OptionCont.alwaysDisplayTidalData = true;
            if (alwaysTidalData.Checked == false) OptionCont.alwaysDisplayTidalData = false;

            //verbose output
            if (verboseOutput.Checked == true) OptionCont.setVerboseOutput(true);
            if (verboseOutput.Checked == false) OptionCont.setVerboseOutput(false);

            //expand asteroid belt
            if (expandAsBelt.Checked == true) OptionCont.expandAsteroidBelt = true;
            if (expandAsBelt.Checked == false) OptionCont.expandAsteroidBelt = false;

            //stellar mass range
            if (stelMasSet.Checked)
            {
                OptionCont.stellarMassRangeSet = true;
                OptionCont.minStellarMass = (double) stelMinMass.Value;
                OptionCont.maxStellarMass = (double) stelMaxMass.Value;

                if (OptionCont.minStellarMass > OptionCont.maxStellarMass)
                {
                    double temp = OptionCont.maxStellarMass;
                    OptionCont.maxStellarMass = OptionCont.minStellarMass;
                    OptionCont.minStellarMass = temp;

                    stelMinMass.Value = (decimal) OptionCont.minStellarMass;
                    stelMaxMass.Value = (decimal) OptionCont.maxStellarMass;
                }
            }

            if (stelMasSet.Checked == false) OptionCont.stellarMassRangeSet = false;

            //numstars
            OptionCont.numStars = (int)this.numStars.Value;
            OptionCont.numStarOverride = numStarOverride.Checked;

            //set atm pressure
            if (overridePressure.Checked && validateATMPressure())
            {
                OptionCont.atmPresOverride = true;
                OptionCont.setAtmPres = Convert.ToInt16(atmPresFld.Text);
            }

            if (overridePressure.Checked == false) OptionCont.atmPresOverride = false;

            //set moon override
            if (overrideMoons.Checked == true)
            {
                OptionCont.moonOverride = true;
                OptionCont.maxMoonsOverGarden = (int)this.numMoons.Value;
            }

            if (overrideMoons.Checked == false) OptionCont.moonOverride = false;

            //lunar tides
            OptionCont.ignoreLunarTides = this.ignoreTides.Checked;

            //high RVM
            OptionCont.highRVMVal = this.highRVM.Checked;

            //marginal atmosphere
            OptionCont.noMarginalAtm = this.noMarginAtm.Checked;

            //stable activity
            OptionCont.stableActivity = this.frcStableActivity.Checked;

            //number of digits
            OptionCont.numberOfDecimal = (int)this.numDigits.Value;

            //stellar eccentricity
            OptionCont.lessStellarEccent = this.lessStellarEcc.Checked;

            //ageset
            if (overrideAge.Checked == true)
            {
                OptionCont.presetOverride = true;
                OptionCont.presetAge = this.ageBar.Value / 100.0;
            }

            if (overrideAge.Checked == false) OptionCont.presetOverride = false;

            //brown dwarf
            OptionCont.replaceLowRedWithBrown = this.repLowRedWithBrown.Checked;

            //no ocean only garden
            OptionCont.noOceanOnlyGarden = this.onlyGarden.Checked;

            //force very low stellar Eccentricity
            OptionCont.forceVeryLowStellarEccent = this.chkForceLowStellarEccent.Checked;

            //ensure one orbit
            OptionCont.ensureOneOrbit = this.chkOneOrbit.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            applyChanges();
            this.Visible = false;
            //parent.ShowDialog();
        }

        private void stelMasSet_CheckedChanged(object sender, EventArgs e)
        {
            if (stelMasSet.Checked == true)
            {
                stelMinMass.Enabled = true;
                stelMaxMass.Enabled = true;
            }

            if (stelMasSet.Checked == false)
            {
                stelMinMass.Enabled = false;
                stelMaxMass.Enabled = false;
            }
        }

        private void numStarOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (numStarOverride.Checked == true)
            {
                numStars.Enabled = true;
            }

            if (numStarOverride.Checked == false)
            {
                numStars.Enabled = false;
            }
        }

        private void atmPresFld_TextChanged(object sender, EventArgs e)
        {
            double testVal;
            if (!Double.TryParse(atmPresFld.Text, out testVal))
            {
                MessageBox.Show("This is not a valid decimal.");
                atmPresFld.Text = "2";
            }

            if (testVal < 0 && testVal > 500)
            {
                atmPresFld.Text = "2";
                MessageBox.Show("Out of range.");
            }
        }

        private void moonOverGarden_TextChanged(object sender, EventArgs e)
        {
            double testVal;
            if (!Double.TryParse(numMoons.Text, out testVal))
            {
                
                numMoons.BackColor = Color.Red;
            }

            if (testVal > 0 && testVal < 500)
            {
                numMoons.Text = "2";
                MessageBox.Show("Out of range.");
            }
        }

        private void overridePressure_CheckedChanged(object sender, EventArgs e)
        {
            if (overridePressure.Checked == true)
                atmPresFld.Enabled = true;

            if (overridePressure.Checked == false)
                atmPresFld.Enabled = false;
        }

        private void overrideMoons_CheckedChanged(object sender, EventArgs e)
        {
            if (overrideMoons.Checked == true)
                this.numMoons.Enabled = true;

            if (overrideMoons.Checked == false)
               
                this.numMoons.Enabled = false;
        }

        private void ageBar_Scroll(object sender, EventArgs e)
        {
            lblAgeVal.Text = Convert.ToString((double) ageBar.Value / 100.0) + " GYr";
        }

        private void overrideAge_CheckedChanged(object sender, EventArgs e)
        {
            if (overrideAge.Checked == true)
            {
                ageBar.Enabled = true;
            }

            if (overrideAge.Checked == false)
            {
                ageBar.Enabled = false;
            }

        }

        private void StarOptions_Load(object sender, EventArgs e)
        {
            numDigits.Value = 4;
        }

        private void canChanges_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void atmPresFld_Validating(object sender, CancelEventArgs e)
        {
            validateATMPressure();
        }

        private bool validateATMPressure()
        {
            bool status = true;
            double testVal;

            if (Double.TryParse(atmPresFld.Text, out testVal)){
                if (testVal < 0 || testVal > 500){
                    status = false;
                    atmPresFld.BackColor = Color.Red;
                    errorProvider1.SetError(atmPresFld, "Value is not within 0 to 500.");
                }

                if (testVal >= 0 && testVal < 500)
                {
                    status = true;
                    atmPresFld.BackColor = Color.Empty;
                    errorProvider1.SetError(atmPresFld, "");
                }

            }


            return status;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

 
        

    }
}
