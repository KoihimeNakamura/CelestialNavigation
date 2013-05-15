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
    public partial class StarAlter : Form
    {      
        public StarSystem ourSystem { get; set; }
        public int starID { get; set; }
        protected StarAgeLine currAgeChart { get; set; }
        public int currAgeStatus { get; set; }
        public Dice myDice { get; set; }
        public double origRadius { get; set; }

        public double minGoodLumin { get; set; }
        public double maxGoodLumin { get; set; }
        public double minGoodTemp { get; set; }
        public double maxGoodTemp { get; set; }

        public StarAlter(int id, StarSystem o)
        {
            InitializeComponent();
            this.starID = id;
            this.myDice = new Dice();
            ourSystem = o;
            displayFromStar();
            this.currAgeChart = new StarAgeLine();

            //hide orbital options for ID 0.
            if (id == 0)
            {
               pnlOrbital.Visible = false;
            }

        }

        private void StarAlter_Load(object sender, EventArgs e)
        {

        }

        private void displayFromStar()
        {
            txtName.Text = this.ourSystem.sysStars[this.starID].name;
            numInitMass.Value = (decimal)this.ourSystem.sysStars[this.starID].initMass;
            numCurrMass.Value = (decimal)this.ourSystem.sysStars[this.starID].currMass;

            txtInitLumin.Text = this.ourSystem.sysStars[this.starID].initLumin.ToString();
            txtCurrLumin.Text = this.ourSystem.sysStars[this.starID].currLumin.ToString();
            txtEffTemp.Text = this.ourSystem.sysStars[this.starID].effTemp.ToString();
            
            createAcceptRanges(this.ourSystem.sysStars[this.starID].currLumin, this.ourSystem.sysStars[this.starID].effTemp);

            numAge.Value = (decimal)this.ourSystem.sysStars[this.starID].starAge;
            if ((double)numCurrMass.Value > .525)
                chkFlareStar.Enabled = false;

            if (this.ourSystem.sysStars[this.starID].isFlareStar)
                chkFlareStar.Checked = true;

            txtOrbitalParent.Text = this.ourSystem.sysStars[this.starID].parentName;
            txtRadius.Text = this.ourSystem.sysStars[this.starID].orbitalRadius.ToString();
            numEccent.Value = (decimal)this.ourSystem.sysStars[this.starID].orbitalEccent;

            lblStellarColor.Text = "Stellar Color: " + Star.getColor(this.ourSystem.sysStars[this.starID].effTemp);

            this.currAgeStatus = this.ourSystem.sysStars[this.starID].evoLine.findCurrentAgeGroup((double)numAge.Value);
            lblCurrentStage.Text = "Current Status: " + StarAgeLine.descBranch(this.currAgeStatus);

            //MessageBox.Show(Star.getRadius(this.ourSystem.sysStars[this.starID].currMass, this.ourSystem.sysStars[this.starID].effTemp, this.ourSystem.sysStars[this.starID].currLumin, this.currAgeStatus).ToString());
            lblStellarRadius.Text = "Star Radius: " + this.ourSystem.sysStars[this.starID].radius + " AU";
            lblInnerFormation.Text = "Inner Radius of Formation Zone: " + Star.innerRadius(this.ourSystem.sysStars[this.starID].initLumin, this.ourSystem.sysStars[this.starID].initMass) + " AU";
            lblOuterFormation.Text = "Outer Radius of Formation Zone: " + Star.outerRadius(this.ourSystem.sysStars[this.starID].initMass) + " AU";
            lblSnowLine.Text = "Snow Line: " + Star.snowLine(this.ourSystem.sysStars[this.starID].initLumin) + " AU";

            lblPeriapsis.Text = "Periapsis: " + Star.getPeriapsis((double)numEccent.Value, Convert.ToDouble(txtRadius.Text)) + " AU";
            lblApapsis.Text = "Apapsis: " + Star.getApapsis((double)numEccent.Value, Convert.ToDouble(txtRadius.Text)) + " AU";

            lblEndMain.Text = "End of Main Sequence: " + this.ourSystem.sysStars[this.starID].evoLine.getMainLimit() + " GYr";
            lblEndSubGiant.Text = "End of the Sub Giant Sequence: " + this.ourSystem.sysStars[this.starID].evoLine.getSubLimit() + " GYr";
            lblEndGiantPhase.Text = "End of the Giant Phase: " + this.ourSystem.sysStars[this.starID].evoLine.getGiantLimit() + " GYr";

            this.currAgeStatus = this.ourSystem.sysStars[this.starID].evoLine.findCurrentAgeGroup((double)numAge.Value);
            lblCurrentStage.Text = "Current Status: " + StarAgeLine.descBranch(this.currAgeStatus);
        }

        private void numCurrMass_Leave(object sender, EventArgs e)
        {
            //first, initial luminosity
            txtInitLumin.Text = Star.getMinLumin((double)numCurrMass.Value).ToString();

            //now we need to get an updated timeline
            this.currAgeChart.addMainLimit(Star.findMainLimit((double)numCurrMass.Value));
            this.currAgeChart.addSubLimit(Star.findSubLimit((double)numCurrMass.Value));
            this.currAgeChart.addGiantLimit(Star.findGiantLimit((double)numCurrMass.Value));

            //now we need to get what stage we are and push the details to the field.
            lblEndMain.Text = "End of Main Sequence: " + this.currAgeChart.getMainLimit() + " GYr";
            lblEndSubGiant.Text = "End of the Sub Giant Sequence: " + this.currAgeChart.getSubLimit() + " GYr";
            lblEndGiantPhase.Text = "End of the Giant Phase: " + this.currAgeChart.getGiantLimit() + " GYr";

            this.currAgeStatus = this.currAgeChart.findCurrentAgeGroup((double)numAge.Value);
            lblCurrentStage.Text = "Current Status: " + StarAgeLine.descBranch(this.currAgeStatus);

            //now we can get the current luminosity, figure out what the intial mass is.
            //and fill in the effective temperature if it's no longer in range.

            numInitMass.Value = numCurrMass.Value;
            txtCurrLumin.Text = Math.Round(Star.getCurrLumin(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value),3).ToString();

            double temp;
            temp = Star.getCurrentTemp(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value, this.myDice);
            txtEffTemp.Text = Convert.ToString(temp);

            //set good ranges
            createAcceptRanges(Star.getCurrLumin(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value), temp);

            //display information for users benefits (formation zones, colors)
            lblStellarColor.Text = "Stellar Color: " + Star.getColor(temp);
            lblStellarRadius.Text = "Stellar Radius: " + Star.getRadius((double)numCurrMass.Value, temp, Star.getCurrLumin(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value),
                  this.currAgeChart.findCurrentAgeGroup((double)numAge.Value)) + " AU";

            lblInnerFormation.Text = "Inner Formation Range: " + Star.innerRadius(Convert.ToDouble(txtInitLumin.Text), (double)numInitMass.Value) + " AU";
            lblOuterFormation.Text = "Outer Formation Range: " + Star.outerRadius((double)numInitMass.Value) + " AU";
            lblSnowLine.Text = "Snow Line: " + Star.snowLine(Convert.ToDouble(txtInitLumin.Text)) + " AU";

            if ((double)numCurrMass.Value > .525)
            {
                chkFlareStar.Checked = false;
                chkFlareStar.Enabled = false;
            }
        }

        private void numAge_Leave(object sender, EventArgs e)
        {

            this.currAgeStatus = this.currAgeChart.findCurrentAgeGroup((double)numAge.Value);
            lblCurrentStage.Text = "Current Status: " + StarAgeLine.descBranch(this.currAgeStatus);

            txtCurrLumin.Text = Math.Round(Star.getCurrLumin(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value), 3).ToString();

            double temp;
            temp = Star.getCurrentTemp(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value, this.myDice);
            txtEffTemp.Text = Convert.ToString(temp);

            createAcceptRanges(Star.getCurrLumin(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value), temp);

            lblStellarColor.Text = "Stellar Color: " + Star.getColor(temp);
            lblStellarRadius.Text = Star.getRadius((double)numCurrMass.Value, temp, Star.getCurrLumin(this.currAgeChart, (double)numAge.Value, (double)numCurrMass.Value),
                  this.currAgeChart.findCurrentAgeGroup((double)numAge.Value)) + " AU";

        }


        private void createAcceptRanges(double lumin, double temp)
        {
            //set good ranges
            this.minGoodLumin = Math.Round(lumin* .9, 3);
            this.maxGoodLumin = Math.Round(lumin * 1.1, 3);

            this.minGoodTemp = temp - 100;
            this.maxGoodTemp = temp + 100;

            //display for user the ranges
            lblCurrLumGR.Text = "Acceptable Range is " + this.minGoodLumin + " to " + this.maxGoodLumin + " solar luminosities";
            lblEffTempGR.Text = "Acceptable Range is " + this.minGoodTemp + " to " + this.maxGoodTemp + " K";
        }

        private void txtCurrLumin_Validating(object sender, CancelEventArgs e)
        {
            double testLumin;
            if (Double.TryParse(txtCurrLumin.Text, out testLumin)){
                if (!(testLumin >= this.minGoodLumin && testLumin <= this.maxGoodLumin)){
                    MessageBox.Show("This has been set outside the range of valid solar luminosities");
                    txtCurrLumin.Text = this.minGoodLumin.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
                txtCurrLumin.Text = this.minGoodLumin.ToString();
            }
        }

        private void txtEffTemp_Validating(object sender, CancelEventArgs e)
        {
            double testTemp;
            if (Double.TryParse(txtEffTemp.Text, out testTemp))
            {
                if (!(testTemp >= this.minGoodTemp && testTemp <= this.maxGoodTemp))
                {
                    MessageBox.Show("This has been set outside the range of valid temperatures");
                    txtEffTemp.Text = this.minGoodTemp.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
                txtEffTemp.Text = this.minGoodTemp.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }


        private void numEccent_Leave(object sender, EventArgs e)
        {
            //txtRadius.Text)
            lblPeriapsis.Text = "Periapsis: " + Orbital.getPeriapsis((double)numEccent.Value, Convert.ToDouble(txtRadius.Text)) + " AU";
            lblApapsis.Text = "Apapsis: " + Orbital.getApapsis((double)numEccent.Value, Convert.ToDouble(txtRadius.Text)) + " AU";
        }

        private void txtRadius_Validating(object sender, CancelEventArgs e)
        {
            double testRadius;
            if (Double.TryParse(txtRadius.Text, out testRadius))
            {
                if (!(testRadius >= 0 && testRadius <= 1000))
                {
                    MessageBox.Show("This has been set outside the range of valid orbital radius");
                    txtRadius.Text = this.origRadius.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
                txtRadius.Text = this.origRadius.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
