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
        //data element

        public StarSystem mySystem;
        public Dice velvetBag = new Dice();

        private void StarSystemGurpsGen_Load(object sender, EventArgs e)
        {
            
        }

        
        public StarSystemGurpsGen()
        {
            InitializeComponent();
            var mySystem = new StarSystem();
        }


        /* private void populateSortedOrbits(BindingList<Satelite> destArray, List<Satelite> srcArray)
        {
            foreach (Satelite o in srcArray){
                destArray.Add(o);
            }
        } */



        /* private void setGasGiantSize(Satelite s, int roll)
        {
            if (roll <= 10) s.updateSize(Satelite.SIZE_SMALL);
            if (roll >= 11 && roll <= 16) s.updateSize(Satelite.SIZE_MEDIUM);
            if (roll >= 17) s.updateSize(Satelite.SIZE_LARGE);

        } */

        /* private void setTypeFromOrbital(Satelite s, int roll)
        {
            s.DEBUG_MOD = roll;
            if (roll <= 3)
                s.updateType(Satelite.CONTENT_EMPTY);
            if (roll >= 4 && roll <= 6)
                s.updateType(Satelite.CONTENT_ASTEROIDBELT);
            if (roll >= 7 && roll <= 8)
                s.updateTypeSize(Satelite.CONTENT_TERRESTIAL, Satelite.SIZE_TINY);
            if (roll >= 9 && roll <= 11)
                s.updateTypeSize(Satelite.CONTENT_TERRESTIAL, Satelite.SIZE_SMALL);
            if (roll >= 12 && roll <= 15)
                s.updateTypeSize(Satelite.CONTENT_TERRESTIAL, Satelite.SIZE_STANDARD);
            if (roll >= 16)
                s.updateTypeSize(Satelite.CONTENT_TERRESTIAL, Satelite.SIZE_LARGE);

        } */

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarOptions optForm = new StarOptions(this);
            optForm.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnGenRandom_Click(object sender, EventArgs e)
        {
            //sysName.Text = Program.genRandomName();
            sysName.Text = libStarGen.genRandomSysName(velvetBag);
        }

        private void step1CoreSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lblHeight = 67;
            int lblLength = 401;
            int btnLeft = 488;
            int currHeight = 128;
            int spacing = 10;
            int setLeft = 68;
            int btnHeight = 25;

            if (mySystem == null)
                mySystem = new StarSystem();

            if (sysName.Text == "")
                sysName.Text = libStarGen.genRandomSysName(velvetBag);

            mySystem.resetSystem();
            clearDisplay();

            mySystem.genStellarAge(velvetBag);
            lblSysAge.Text = "System Age: " + mySystem.sysAge + " GYr";
            libStarGen.createStars(velvetBag, mySystem);

            mySystem.sysStars[0].updateMass(Star.rollMass(velvetBag));
            mySystem.maxMass = mySystem.sysStars[0].currMass;

            foreach (Star s in mySystem.sysStars)
            {
                libStarGen.generateAStar(s, velvetBag, mySystem.maxMass);
                if (s.selfID != Star.IS_PRIMARY)
                    s.parentName = mySystem.sysStars[0].name;
            }

            if (mySystem.countStars() > 1)
            {
                libStarGen.genStellarOrbitals(mySystem, velvetBag);
            }

            label1.Visible = true;
            //output stars
            foreach (Star s in mySystem.sysStars)
            {
                if (s.selfID == Star.IS_PRIMARY)
                {
                    lblStar1.Visible = true;
                    btnAlterStar.Visible = true;
                    lblStar1.Text = s.printSummaryLine("Star 1:");
                }

                if (s.selfID == Star.IS_SECONDARY)
                {
                    Label lblStar2 = new System.Windows.Forms.Label();
                    lblStar2.Location = new System.Drawing.Point(setLeft, currHeight);
                    lblStar2.Name = "lblStar2";
                    lblStar2.Size = new System.Drawing.Size(lblLength, lblHeight);
                    lblStar2.Visible = true;
                    lblStar2.Text = s.printSummaryLine("Star 2:");
                    this.Controls.Add(lblStar2);
                    
                    //add button!
                    Button star2alter = new System.Windows.Forms.Button();
                    star2alter.Location = new System.Drawing.Point(btnLeft, currHeight);
                    star2alter.Name = "star2alter";
                    star2alter.Size = new System.Drawing.Size(93, btnHeight);
                    star2alter.Visible = true;
                    star2alter.Text = "Alter Star 2";
                    star2alter.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(star2alter);

                    currHeight += lblHeight + spacing;
                }

                if (s.selfID == Star.IS_SECCOMP)
                {
                    Label lblStar2Sub = new System.Windows.Forms.Label();
                    lblStar2Sub.Location = new System.Drawing.Point(setLeft, currHeight);
                    lblStar2Sub.Name = "lblStar2Sub";
                    lblStar2Sub.Size = new System.Drawing.Size(lblLength, lblHeight);
                    lblStar2Sub.Visible = true;
                    lblStar2Sub.Text = s.printSummaryLine("Star 2 SubCompanion:");
                    this.Controls.Add(lblStar2Sub);

                    Button star2subAlter = new System.Windows.Forms.Button();
                    star2subAlter.Location = new System.Drawing.Point(btnLeft, currHeight);
                    star2subAlter.Name = "star2subAlter";
                    star2subAlter.Size = new System.Drawing.Size(93, btnHeight);
                    star2subAlter.Visible = true;
                    star2subAlter.Text = "Alter Star 2 Sub";
                    star2subAlter.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(star2subAlter);
                    currHeight += lblHeight + spacing;
                }

                if (s.selfID == Star.IS_TRINARY)
                {
                    Label lblStar3 = new System.Windows.Forms.Label();
                    lblStar3.Location = new System.Drawing.Point(setLeft, currHeight);
                    lblStar3.Name = "lblStar3";
                    lblStar3.Size = new System.Drawing.Size(lblLength, lblHeight);
                    lblStar3.Visible = true;
                    lblStar3.Text = s.printSummaryLine("Star 3:");
                    this.Controls.Add(lblStar3);

                    Button star3alter = new System.Windows.Forms.Button();
                    star3alter.Location = new System.Drawing.Point(btnLeft, currHeight);
                    star3alter.Name = "star3alter";
                    star3alter.Size = new System.Drawing.Size(93, btnHeight);
                    star3alter.Visible = true;
                    star3alter.Text = "Alter Star 3";
                    star3alter.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(star3alter);
                    currHeight += lblHeight + spacing;

                }                

                if (s.selfID == Star.IS_TRICOMP)
                {
                    Label lblStar3Sub = new System.Windows.Forms.Label();
                    lblStar3Sub.Location = new System.Drawing.Point(setLeft, currHeight);
                    lblStar3Sub.Name = "lblStar3Sub";
                    lblStar3Sub.Size = new System.Drawing.Size(lblLength, lblHeight);
                    lblStar3Sub.Visible = true;
                    lblStar3Sub.Text = s.printSummaryLine("Star 3 SubCompanion:");
                    this.Controls.Add(lblStar3Sub);

                    Button star3subAlter = new System.Windows.Forms.Button();
                    star3subAlter.Location = new System.Drawing.Point(btnLeft, currHeight);
                    star3subAlter.Name = "star3subAlter";
                    star3subAlter.Size = new System.Drawing.Size(93, btnHeight);
                    star3subAlter.Visible = true;
                    star3subAlter.Text = "Star 3 Sub";
                    star3subAlter.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(star3subAlter);
                    currHeight += lblHeight + spacing;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
            MessageBox.Show(sender.ToString());
        }

        private void clearDisplay()
        {
            lblStar1.Text = "";

            if (this.Controls.ContainsKey("lblStar2"))
            {
                this.Controls.RemoveByKey("lblStar2");
                this.Controls.RemoveByKey("star2alter");
            }

            if (this.Controls.ContainsKey("lblStar2Sub"))
            {
                this.Controls.RemoveByKey("lblStar2Sub");
                this.Controls.RemoveByKey("star2subAlter");
            }

            if (this.Controls.ContainsKey("lblStar3"))
            {
                this.Controls.RemoveByKey("lblStar3");
                this.Controls.RemoveByKey("star3alter");
            }
            
            if (this.Controls.ContainsKey("lblStar3Sub")){
                this.Controls.RemoveByKey("lblStar3Sub");
                this.Controls.RemoveByKey("star3subAlter");
            }
        }
   }
}
