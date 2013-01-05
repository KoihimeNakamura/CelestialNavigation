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
    public partial class StarSystemGurpsGen : Form
    {
        Dice velvetBag;
        String sysName;
        List <Star> core;
        BindingList<Satelite> cleanPlanets { get; set; }
        decimal systemAge;
        decimal maxMass = 2.0m;
        
        int subCompanionStar1index;
        int subCompanionStar2index;
        int star2index;

        private void StarSystemGurpsGen_Load(object sender, EventArgs e)
        {
            sysAgeTT.IsBalloon = true;            
        }

        
        public StarSystemGurpsGen()
        {
            InitializeComponent();
            velvetBag = new Dice();
            core = new List<Star>();
            cleanPlanets = new BindingList<Satelite>();
            planetGrid.DataSource = cleanPlanets;
            
        }

        private void genPlanets_Click(object sender, EventArgs e)
        {
            beginStep2.Enabled = false;
            sysAge.ReadOnly = true;
            numStars.ReadOnly = true;
            inpSysName.ReadOnly = true;
            this.sysName = inpSysName.Text;
            int starLimit = Convert.ToInt16(numStars.Text);
            int roll; //used for rolling
            this.systemAge = Convert.ToDecimal(sysAge.Text);

            for (int i = 0; i < starLimit; i++)
            {
                //if it's the primary star, add it now.
                if (i == 0) this.core.Add(new Star(this.systemAge, Star.IS_PRIMARY, i, Star.IS_PRIMARY, sysName));
                else
                {
                    this.core.Add(new Star(this.systemAge, 0, i));
                    if (i == 1) this.core[i].addOrder(Star.IS_SECONDARY);
                    if (i == 2) this.core[i].addOrder(Star.IS_TRINARY);
                    this.core[i].genGenericName(sysName);
                    this.core[i].parentName = this.core[0].name;
                }
                //generate the actual star, and if it's the primary, set the new maximum mass possible
                Program.generateAStar(this.core[i], this.velvetBag, this.maxMass, forceGarden.Checked,forceHighStarMass.Checked);
                if (i == 0) { 
                    this.maxMass = this.core[i].initMass;
                    if (this.maxMass == 0m) throw new Exception("Max mass is being set to 0 solar masses.");
                }
            }

            //generating orbital radius
            if (starLimit > 1)
            {
                decimal minOrbitalDistance = 0.0m;
                decimal maxOrbitalDistance = 600.0m;
                decimal tempVal = 0.0m;
                for (int i = 1; i < starLimit; i++)
                {
                    int modifiers = 0;
                    minOrbitalDistance = this.core[i - 1].orbitalRadius;

                    //set the min and max conditions for the first star here.
                    if (this.core[i].parentID == 0 || this.core[i].parentID == Star.IS_PRIMARY)
                    {
                        //apply modifiers
                        if (this.core[i].selfID == 2) modifiers = modifiers + 6;
                        if (forceGarden.Checked && this.core[i].parentID != 1) modifiers = modifiers + 4;

                        if (minOrbitalDistance == 600.0m)
                        {
                            //in this situation, orbital 3 or so can't be safely placed because the range is 0. 
                            // so we autogenerate it.
                            tempVal = this.velvetBag.rollRange(25, 25);
                            this.core[i].orbitalSep = 5;
                            this.core[i - 1].orbitalRadius = this.core[i - 1].orbitalRadius - tempVal;
                            this.core[i].orbitalRadius = 600m + tempVal;
                            minOrbitalDistance = this.core[i].orbitalRadius;
                        }
                        else
                        {
                            do
                            {
                                decimal lowerBound = 0.0m;
                                decimal higherBound = 0.0m;
                                //roll the dice

                                roll = this.velvetBag.gurpsRoll(modifiers);
                                if (roll <= 6) this.core[i].orbitalSep = 1;
                                if (roll >= 7 && roll <= 9) this.core[i].orbitalSep = 2;
                                if (roll >= 10 && roll <= 11) this.core[i].orbitalSep = 3;
                                if (roll >= 12 && roll <= 14) this.core[i].orbitalSep = 4;
                                if (roll >= 15) this.core[i].orbitalSep = 5;

                                //generate the orbital radius
                                do
                                {
                                    tempVal = this.velvetBag.six(2) * this.core[i].getSepModifier();
                                } while (tempVal <= minOrbitalDistance);

                                //if (this.core[i].selfID == 2) tempVal = this.velvetBag.six(1, 7) * this.core[i].getSepModifier(); 
                                lowerBound = tempVal - .5m * this.core[i].getSepModifier();
                                higherBound = .5m * this.core[i].getSepModifier() + tempVal;


                                //set for constraints
                                if (lowerBound < minOrbitalDistance) lowerBound = minOrbitalDistance;
                                if (higherBound > maxOrbitalDistance) higherBound = maxOrbitalDistance;

                                this.core[i].orbitalRadius = tempVal;
                            } while (this.core[i].orbitalRadius <= minOrbitalDistance || this.core[i].orbitalRadius > maxOrbitalDistance);

                            //let's see if it has a subcompanion
                            if (this.core[i].orbitalSep == 5)
                            {
                                roll = this.velvetBag.gurpsRoll();
                                if (roll >= 11)
                                {
                                    if (this.core[i].orderID == Star.IS_TRINARY)
                                    {
                                        this.subCompanionStar2index = starLimit;
                                    }
                                    //generate the subcompanion
                                    this.core.Add(new Star(this.systemAge, i, starLimit));
                                    this.core[starLimit].genGenericName(sysName);
                                    if (i == 1) this.core[starLimit].addOrder(Star.IS_SECCOMP);
                                    if (i == 2) this.core[starLimit].addOrder(Star.IS_TRICOMP);
                                    //set the name, then generate the star
                                    this.core[starLimit].parentName = this.core[i].name;
                                    Program.generateAStar(this.core[starLimit], this.velvetBag, this.core[i].mass, false, false);
                                    starLimit++; //increment the total number of stars we have generated
                                }

                            }
                        }
                    }
                    else
                    {
                        minOrbitalDistance = 0m;
                        maxOrbitalDistance = this.core[this.core[i].parentID].orbitalRadius;
                        //roll for seperation
                        do
                        {
                            decimal lowerBound = 0.0m;
                            decimal higherBound = 0.0m;
                            //roll the dice

                            roll = this.velvetBag.gurpsRoll(-6);
                            if (roll <= 6) this.core[i].orbitalSep = 1;
                            if (roll >= 7 && roll <= 9) this.core[i].orbitalSep = 2;
                            if (roll >= 10 && roll <= 11) this.core[i].orbitalSep = 3;
                            if (roll >= 12 && roll <= 14) this.core[i].orbitalSep = 4;
                            if (roll >= 15) this.core[i].orbitalSep = 5;

                            //set the subcompanion orbital
                            tempVal = this.velvetBag.six(2) * this.core[i].getSepModifier();
                            lowerBound = tempVal - .5m * this.core[i].getSepModifier();
                            higherBound = .5m * this.core[i].getSepModifier() + tempVal;

                            if (higherBound > maxOrbitalDistance) higherBound = maxOrbitalDistance;

                            this.core[i].orbitalRadius = tempVal;

                        } while (this.core[i].orbitalRadius > maxOrbitalDistance);
                    }

                    modifiers = 0; //reset the thing.
                    //now we generate eccentricities
                    if (this.core[i].orbitalSep == 1) modifiers = modifiers - 10; //Very Close
                    if (this.core[i].orbitalSep == 2) modifiers = modifiers - 6; //Close
                    if (this.core[i].orbitalSep == 3) modifiers = modifiers - 2; //Moderate  

                    roll = this.velvetBag.gurpsRoll(modifiers);
                    if (roll <= 3) this.core[i].orbitalEccent = 0;
                    if (roll == 4) this.core[i].orbitalEccent = .1m;
                    if (roll == 5) this.core[i].orbitalEccent = .2m;
                    if (roll == 6) this.core[i].orbitalEccent = .3m;
                    if (roll == 7 || roll == 8) this.core[i].orbitalEccent = .4m;
                    if (roll >= 9 && roll <= 11) this.core[i].orbitalEccent = .5m;
                    if (roll == 12 || roll == 13) this.core[i].orbitalEccent = .6m;
                    if (roll == 14 || roll == 15) this.core[i].orbitalEccent = .7m;
                    if (roll == 16) this.core[i].orbitalEccent = .8m;
                    if (roll == 17) this.core[i].orbitalEccent = .9m;
                    if (roll >= 18) this.core[i].orbitalEccent = .95m;


                }
            }
            // MessageBox.Show("We have " + starLimit + " stars.");
            //Enable buttons.
            if (starLimit >= 2)
            {
                star1PropLbl.Visible = true;
                if (this.core[1].determineStatus() != 4)  star1Lumin.Visible = true;
                if (this.core[1].determineStatus() != 4)  star1Mass.Visible = true;
                star1Name.Visible = true;
                star1OrbRad.Visible = true;
                if(this.core[1].determineStatus() != 4) star1Temp.Visible = true;
              }

            if (starLimit >= 3 && this.core[2].parentID == 0)
            {
                star2PropLbl.Visible = true;
                if (this.core[2].determineStatus() != 4)  star2Lumin.Visible = true;
                if (this.core[2].determineStatus() != 4)  star2Mass.Visible = true;
                star2Name.Visible = true;
                star2OrbRad.Visible = true;
                if (this.core[2].determineStatus() != 4)  star2Temp.Visible = true;
                this.star2index = 2;
            }

            if (starLimit >= 3 && this.core[2].parentID == 1)
            {
                star1SCPropLbl.Visible = true;
                if (this.core[2].determineStatus() != 4) star1SCLumin.Visible = true;
                if (this.core[2].determineStatus() != 4) star1SCMass.Visible = true;
                star1SCName.Visible = true;
                star1SCOrbRad.Visible = true;
                if (this.core[2].determineStatus() != 4) star1SCTemp.Visible = true;
                this.subCompanionStar1index = 2;
            }

            if (starLimit >= 4 && this.core[3].parentID == 1)
            {
                if (this.core[3].determineStatus() != 4) star1SCLumin.Visible = true;
                if (this.core[3].determineStatus() != 4) star1SCMass.Visible = true;
                star1SCName.Visible = true;
                star1SCOrbRad.Visible = true;
                if (this.core[3].determineStatus() != 4) star1SCTemp.Visible = true;
                this.subCompanionStar1index = 3;
            }

            if (starLimit >= 5 && this.core[4].parentID == 2)
            {
                star2SCPropLbl.Visible = true;
                if (this.core[4].determineStatus() != 4) star2SCLumin.Visible = true;
                if (this.core[4].determineStatus() != 4) star2SCMass.Visible = true;
                star2SCName.Visible = true;
                star2SCOrbRad.Visible = true;
                if (this.core[4].determineStatus() != 4) star2SCTemp.Visible = true;
                this.subCompanionStar1index = 4;
            }

            if (starLimit >= 4 && this.core[3].parentID == 2)
            {
                star2SCPropLbl.Visible = true;
                if (this.core[3].determineStatus() != 4) star2SCLumin.Visible = true;
                if (this.core[3].determineStatus() != 4) star2SCMass.Visible = true;
                star2SCName.Visible = true;
                star2SCOrbRad.Visible = true;
                if (this.core[3].determineStatus() != 4) star2SCTemp.Visible = true;
                this.subCompanionStar1index = 3;
            }
            
            //check for first star!
            if (this.core[0].determineStatus() == 4)
            {
                star0Lumin.Visible = false;
                star0Mass.Visible = false;
                star0Temp.Visible = false;
            }

            //enable output!
            String genStarOutput = ""; // .. wtf.
            for (int i = 0; i < starLimit; i++){
                genStarOutput += this.core[i] + Environment.NewLine;
                //adding an second new line
                genStarOutput += Environment.NewLine;
            }

            starOutput.Text = genStarOutput;
            beginStep3.Enabled = true;
        }


        private void beginGen_Click(object sender, EventArgs e)
        {
            sysAge.ReadOnly = false;
            numStars.ReadOnly = false;
            inpSysName.ReadOnly = false;
            //generate the age
            this.systemAge = Math.Round(Star.generateStellarAge(this.velvetBag),5) ;
            // MessageBox.Show("Generated " + systemAge + ".");
            sysAge.Text = Convert.ToString(this.systemAge);

            //generate number of stars
            int rollStars = this.velvetBag.gurpsRoll() - 1;
            if (openCluster.Checked == true) rollStars = rollStars + 3;
            rollStars = (int)Math.Floor(rollStars / 5m);

            //logic fix
            if (rollStars == 0) rollStars = 1;
            if (rollStars == 4) rollStars = 3;

            numStars.Text = Convert.ToString(rollStars);

            openCluster.Enabled = false;
            forceHighStarMass.Enabled = false;
            forceGarden.Enabled = false;
            beginGen.Enabled = false;
            
        }

        //CREDIT: StackOverflow Contributor Mosè Bottacini
        //LINK  : http://stackoverflow.com/questions/7040289/converting-integers-to-roman-numerals 

        static string toRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + toRoman(number - 1000);
            if (number >= 900) return "CM" + toRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + toRoman(number - 500);
            if (number >= 400) return "CD" + toRoman(number - 400);
            if (number >= 100) return "C" + toRoman(number - 100);
            if (number >= 90) return "XC" + toRoman(number - 90);
            if (number >= 50) return "L" + toRoman(number - 50);
            if (number >= 40) return "XL" + toRoman(number - 40);
            if (number >= 10) return "X" + toRoman(number - 10);
            if (number >= 9) return "IX" + toRoman(number - 9);
            if (number >= 5) return "V" + toRoman(number - 5);
            if (number >= 4) return "IV" + toRoman(number - 4);
            if (number >= 1) return "I" + toRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        private void numStars_TextChanged(object sender, EventArgs e)
        {
            int contents;
            if (Int32.TryParse(numStars.Text, out contents)){
                if (contents < 1 || contents > 3){
                    MessageBox.Show("This only supports up to 3 primary stars.");
                    beginStep2.Enabled = false;
                }
                else beginStep2.Enabled = true;
                
            }
        }

        private void sysAge_TextChanged(object sender, EventArgs e)
        {
            decimal ourAge;
            if (Decimal.TryParse(sysAge.Text,out ourAge)){
                if (ourAge < 0 || ourAge > 13.9m){
                    sysAge.Text = "Invalid";
                    beginStep2.Enabled = false;
             }

                else beginStep2.Enabled = true;
                
            }
        }

        private void sysAge_KeyDown(object sender, KeyEventArgs e)
        {
            decimal ourAge;
            if (decimal.TryParse(sysAge.Text, out ourAge)){
            
                if (ourAge < 0 || ourAge > 13.9m){
                    sysAge.Text = "Invalid";
                    beginStep2.Enabled = false;
                }

                else
                    beginStep2.Enabled = true;
            
            }
        }

        private void star0Mass_Click(object sender, EventArgs e)
        {
            alterMass(0, 2.0m);
        }

        private void star0Lumin_Click(object sender, EventArgs e){
            alterLumin(0); 
        }

        private void generateStellarOutput()
        {
            String genStarOutput = "";
            for (int i = 0; i < this.core.Count; i++)
            {
                genStarOutput += this.core[i] + Environment.NewLine;
                //adding an second new line
                genStarOutput += Environment.NewLine;
            }

            starOutput.Text = genStarOutput;
        }

        private void resetALLTHETHINGS_Click(object sender, EventArgs e)
        {
            //TAB 1 first
            beginGen.Enabled = true;
            sysAge.Enabled = true;

            beginStep2.Enabled = false;
            beginStep3.Enabled = false;
            
            numStars.Text = "";
            sysAge.Text = "";
            forceHighStarMass.Checked = false;
            openCluster.Checked = false;
            forceGarden.Checked = false;

            openCluster.Enabled = true;
            numStars.Enabled = true;
            forceHighStarMass.Enabled = true;
            forceGarden.Enabled = true;
            inpSysName.Enabled = true;

            //TAB 2
            starOutput.Text = "";
            star1Lumin.Visible = false;
            star1Mass.Visible = false;
            star1Name.Visible = false;
            star1OrbRad.Visible = false;

            star2Lumin.Visible = false;
            star2Mass.Visible = false;
            star2Name.Visible = false;
            star2OrbRad.Visible = false;

            star1SCLumin.Visible = false;
            star1SCMass.Visible = false;
            star1SCName.Visible = false;
            star1SCOrbRad.Visible = false;

            star2SCLumin.Visible = false;
            star2SCMass.Visible = false;
            star2SCName.Visible = false;
            star2SCOrbRad.Visible = false;

            beginStep2.Enabled = false;
            beginStep3.Enabled = false;
        }

        private void star0Temp_Click(object sender, EventArgs e)
        {
            alterTemp(0);
        }

        private void alterMass(int index, decimal maxMass)
        {
            String res = "";
            do
            {
                DialogResult dgResult = Program.InputBox("Star" + (index + 1) + " Mass", "This can be between .1 solar masses and " + maxMass + " solar masses.", ref res);
                if (dgResult == DialogResult.OK)
                {
                    decimal temp;
                    if (Decimal.TryParse(res, out temp))
                    {
                        if (temp >= .1m && temp <= 2m)
                        {
                            this.core[index].updateStar(temp, this.velvetBag);
                            generateStellarOutput();
                            return;
                        }
                    }
                    else MessageBox.Show("Please only enter decimals between .1 solar masses and 2 solar masses.");
                }
                if (dgResult == DialogResult.Cancel) return;

            } while (true);
        }

        private void alterLumin(int index)
        {
            String res = "";
            do
            {
                decimal cL = this.core[index].currLumin;
                decimal lowerLimit = (decimal)Math.Round(this.core[index].currLumin * .9m, 5);
                decimal higherLimit = (decimal)Math.Round(this.core[index].currLumin * 1.1m, 5);

                String displayPrompt = "This can be within 10% of the current luminosity." + Environment.NewLine;
                displayPrompt += "Current luminosity is " + Math.Round(cL, 5) + " solar luminosities.";

                DialogResult dgResult = Program.InputBox("Star" + (index + 1) + " Luminosity", displayPrompt, ref res);
                if (dgResult == DialogResult.OK)
                {
                    decimal temp;
                    if (Decimal.TryParse(res, out temp))
                    {
                        if (temp > lowerLimit && temp < higherLimit)
                        {
                            this.core[index].updateLumin(temp);
                            generateStellarOutput();
                            return;

                        }
                    }
                    else MessageBox.Show("Please only enter decimals within 10% of current luminosity.");
                }
                if (dgResult == DialogResult.Cancel) return;

            } while (true);

        }

        private void alterTemp(int index)
        {
            String res = "";
            do
            {
                decimal cL = this.core[index].effTemp;
                decimal lowerLimit = (decimal)Math.Round((this.core[index].effTemp - 100), 5);
                decimal higherLimit = (decimal)Math.Round((this.core[index].effTemp + 100), 5);

                String displayPrompt = "This can be within 100K of the current temperature." + Environment.NewLine;
                displayPrompt += "Current temperature is " + Math.Round(cL, 5) + "K";

                DialogResult dgResult = Program.InputBox("Star" + (index + 1) + " Effective Temperature", displayPrompt, ref res);
                if (dgResult == DialogResult.OK)
                {
                    decimal temp;
                    if (Decimal.TryParse(res, out temp))
                    {
                        if (temp > lowerLimit && temp < higherLimit)
                        {
                            this.core[index].effTemp = temp;
                            generateStellarOutput();
                            return;

                        }
                    }
                    else MessageBox.Show("Please only enter decimals within 100K of current luminosity");
                }
                if (dgResult == DialogResult.Cancel) return;

            } while (true);
        }

        private void beginStep3_Click(object sender, EventArgs e)
        {
            beginStep2.Enabled = false;
            beginStep3.Enabled = false;
            int totalStars = this.core.Count;
            int roll; //roll variable

            //gas giant flags
            bool conGGOK = false;
            bool epiGGOK = false;
            bool eccGGOK = false;

            //start disabling buttons.
            star0Lumin.Visible = false;
            star0Mass.Visible = false;
            star0Name.Visible = false;
            star0Temp.Visible = false;

            star1Lumin.Visible = false;
            star1Mass.Visible = false;
            star1Temp.Visible = false;
            star1Name.Visible = false;
            star1OrbRad.Visible = false;

            star2Lumin.Visible = false;
            star2Mass.Visible = false;
            star2Temp.Visible = false;
            star2Name.Visible = false;
            star2OrbRad.Visible = false;

            star1SCLumin.Visible = false;
            star1SCMass.Visible = false;
            star1SCName.Visible = false;
            star1SCTemp.Visible = false;
            star1OrbRad.Visible = false;

            star2SCLumin.Visible = false;
            star2SCMass.Visible = false;
            star2SCName.Visible = false;
            star2SCTemp.Visible = false;
            star2SCOrbRad.Visible = false;

            int totalOrbCount = 0; //total orbital count
            //first off, master loop. 
            for (int currStar = 0; currStar < totalStars; currStar++){
                Range temp;
                int currOrb = 0; //current orbital
               //draw up forbidden zones.
                if (!this.core[currStar].testInitlizationZones()) this.core[currStar].initalizeZonesOfInterest();
                for (int i = 1; i < totalStars; i++){
                    if (this.core[i].parentID == currStar){
                        temp = new Range(this.core[i].getInnerForbiddenZone(), this.core[i].getOuterForbiddenZone());
                        this.core[currStar].createForbiddenZone(temp, currStar, i);
                    }
                    if (this.core[i].selfID == currStar){
                        temp = new Range(this.core[i].getInnerForbiddenZone(), this.core[i].getOuterForbiddenZone());
                        this.core[currStar].createForbiddenZone(temp, this.core[i].parentID, currStar);
                    }
                }

                this.core[currStar].sortForbidden();
                this.core[currStar].createCleanZones();
                
                //now start checking gas giant checks.
                if (this.core[currStar].checkEpiRange() > 0) epiGGOK = true;
                if (this.core[currStar].checkEccRange() > 0) eccGGOK = true;
                if (this.core[currStar].checkConRange() > 0) conGGOK = true;

                //pick the gas giant flag.
                
                bool escapeVar = false;
                do{
                    roll = this.velvetBag.gurpsRoll();
                    if (roll < 8) escapeVar = true; //0 is default set.

                    if ((roll >= 8) && (roll <= 12) && (conGGOK)){
                        this.core[currStar].gasGiantFlag = Star.GASGIANT_CONVENTIONAL;
                        escapeVar = true;
                    }

                    if ((roll == 13) && (roll == 14) && (eccGGOK)){
                        this.core[currStar].gasGiantFlag = Star.GASGIANT_ECCENTRIC;
                        escapeVar = true;
                    }

                    if ((roll >= 15) && (roll <= 18) && (epiGGOK)){
                        this.core[currStar].gasGiantFlag = Star.GASGIANT_EPISTELLAR;
                        escapeVar = true;
                    }

                } while (!escapeVar);


                //we have our gas giant flag. Now, let's start the fun bits!
                Satelite placeHolder;
                decimal currentOrbital = 0m;

                if (this.core[currStar].gasGiantFlag == Star.GASGIANT_CONVENTIONAL){
                    if (this.core[currStar].checkConRange() < .15m){
                        //force assign one.
                        currentOrbital = this.core[currStar].pickInRange(this.core[currStar].getConventionalRange());
                    }
                    else{
                        //roll for it!
                        do{
                            roll = this.velvetBag.six(2,-2);
                            currentOrbital = ((roll * .05m) + 1 ) * this.core[currStar].snowLine();
                        } while (this.core[currStar].verifyCleanOrbit(currentOrbital));
                    }

                    //we have our orbital. Now let's assign it to placeholder.
                    placeHolder = new Satelite(this.core[currStar].orderID, 0, currentOrbital, 0, Satelite.CONTENT_GASGIANT);
                }

                if (this.core[currStar].gasGiantFlag == Star.GASGIANT_ECCENTRIC){
                    if (this.core[currStar].checkEccRange() < .15m){
                        //force assign one.
                        currentOrbital = this.core[currStar].pickInRange(this.core[currStar].getEccentricRange());
                    }
                    else{
                        //roll for it!
                        do
                        {
                            roll = this.velvetBag.six();
                            currentOrbital = (roll * .125m) * this.core[currStar].snowLine();
                        } while (this.core[currStar].verifyCleanOrbit(currentOrbital));
                    }

                    //we have our orbital. Now let's assign it to placeholder.
                    placeHolder = new Satelite(this.core[currStar].orderID, 0, currentOrbital, 0, Satelite.CONTENT_GASGIANT);
                }

                if (this.core[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                {
                    if (this.core[currStar].checkEccRange() < .15m){
                        //force assign one.
                        currentOrbital = this.core[currStar].pickInRange(this.core[currStar].getEpistellarRange());
                    }
                    else{
                        //roll for it!
                        do{
                            roll = this.velvetBag.gurpsRoll();
                            currentOrbital = (roll * .1m) * this.core[currStar].innerRadius();
                        } while (!(this.core[currStar].verifyForbiddenOrbit(currentOrbital)));
                    }

                    //we have our orbital. Now let's assign it to placeholder.
                    placeHolder = new Satelite(this.core[currStar].orderID, 0, currentOrbital, 0, Satelite.CONTENT_GASGIANT);
                }

                //now we can start generating orbitals.
              /*  do{


                } while (); */
                


            }

            //allow finalized output now.
            genOutput.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void populateSortedOrbits(BindingList<Satelite> destArray, List<Satelite> srcArray)
        {
            foreach (Satelite o in srcArray){
                destArray.Add(o);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|.txt";
            saveFileDialog1.Title = "Save to a text file";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                //fs.Write(this.printOutput());
                fs.Close();
            }
        }

        private void star0Name_Click(object sender, EventArgs e)
        {
            String res = "";
            if (Program.InputBox("Primary Star Name", "Please enter the star name", ref res) == DialogResult.OK)
            {
                this.core[0].name = res;
            }
        }

        private void star1Mass_Click(object sender, EventArgs e)
        {
            alterMass(1,this.maxMass);
        }

        private void star2Mass_Click(object sender, EventArgs e)
        {
            alterMass(this.star2index, maxMass);
        }

        private void star1SCMass_Click(object sender, EventArgs e)
        {
            alterMass(this.subCompanionStar1index, this.core[1].mass);
        }

        private void star2SCMass_Click(object sender, EventArgs e)
        {
            alterMass(this.subCompanionStar2index, this.core[this.star2index].mass);
        }

        private void star1Lumin_Click(object sender, EventArgs e)
        {
            alterLumin(1);
        }

        private void star2Lumin_Click(object sender, EventArgs e)
        {
            alterLumin(this.star2index);
        }

        private void star1SCLumin_Click(object sender, EventArgs e)
        {
            alterLumin(this.subCompanionStar1index);
        }

        private void star2SCLumin_Click(object sender, EventArgs e)
        {
            alterLumin(this.subCompanionStar2index);
        }

        private void star1Temp_Click(object sender, EventArgs e)
        {
            alterTemp(1);
        }

        private void star2Temp_Click(object sender, EventArgs e)
        {
            alterTemp(this.star2index);
        }

        private void star1SCTemp_Click(object sender, EventArgs e)
        {
            alterTemp(this.subCompanionStar1index);
        }

        private void star2SCTemp_Click(object sender, EventArgs e)
        {
            alterTemp(this.subCompanionStar2index);
        }

        private void star1Name_Click(object sender, EventArgs e)
        {
            String res = "";
            if (Program.InputBox("Secondary Star Name", "Please enter the star name", ref res) == DialogResult.OK)
            {
                this.core[1].name = res;
            }
        }

        private void star2Name_Click(object sender, EventArgs e)
        {
            String res = "";
            if (Program.InputBox("Trinary Star Name", "Please enter the star name", ref res) == DialogResult.OK)
            {
                this.core[this.star2index].name = res;
            }
        }

        private void star1SCName_Click(object sender, EventArgs e)
        {
            String res = "";
            if (Program.InputBox("Subcompanion Star of Star 2 Name", "Please enter the star name", ref res) == DialogResult.OK)
            {
                this.core[this.subCompanionStar1index].name = res;
            }
        }

        private void star2SCName_Click(object sender, EventArgs e)
        {
            String res = "";
            if (Program.InputBox("Subcompanion Star of Star 3 Name", "Please enter the star name", ref res) == DialogResult.OK)
            {
                this.core[this.subCompanionStar2index].name = res;
            }
        }

        private void star1OrbRad_Click(object sender, EventArgs e)
        {
            alterOrbRad(1);
        }

        private void alterOrbRad(int index)
        {
            String res = "";
            //get orbital radius
            decimal ourSep = this.core[index].getSepModifier();
            decimal lowerLimit = this.core[index].orbitalRadius - (.5m * ourSep);
            decimal upperLimit = this.core[index].orbitalRadius + (.5m * ourSep);
            
            do {
            String displayPrompt = "This can be within 50% of the current seperation." + Environment.NewLine;
            displayPrompt += "Current seperation is " + ourSep + " AU. The radius is " + this.core[index].orbitalRadius + " AU";

                DialogResult dgResult = Program.InputBox("Star" + (index + 1) + " Effective Temperature", displayPrompt, ref res);
                if (dgResult == DialogResult.OK)
                {
                    decimal temp;
                    if (Decimal.TryParse(res, out temp))
                    {
                        if (temp > lowerLimit && temp < upperLimit)
                        {
                            this.core[index].orbitalRadius = temp;
                            generateStellarOutput();
                            return;

                        }
                    }
                    else MessageBox.Show("Please only enter decimals within 100K of current luminosity");
                }
                if (dgResult == DialogResult.Cancel) return;

            } while (true);
            

        }

        private void star2OrbRad_Click(object sender, EventArgs e)
        {
            alterOrbRad(this.star2index);
        }

        private void star1SCOrbRad_Click(object sender, EventArgs e)
        {
            alterOrbRad(this.subCompanionStar1index);
        }

        private void star2SCOrbRad_Click(object sender, EventArgs e)
        {
            alterOrbRad(this.subCompanionStar2index);
        }

       
      

   }
}
