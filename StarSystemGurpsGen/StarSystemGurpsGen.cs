using System;
using System.IO;
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
            mySystem.sysName = sysName.Text;
            mySystem.genStellarAge(velvetBag);
            lblSysAge.Text = "System Age: " + mySystem.sysAge + " GYr";
            libStarGen.createStars(velvetBag, mySystem);

            mySystem.sysStars[0].updateMass(Star.rollMass(velvetBag));
            mySystem.maxMass = mySystem.sysStars[0].currMass;

            foreach (Star s in mySystem.sysStars)
            {
                libStarGen.generateAStar(s, velvetBag, mySystem.maxMass, mySystem.sysName);
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
                    star3subAlter.Text = "Alter Star 3 Sub";
                    star3subAlter.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(star3subAlter);
                    currHeight += lblHeight + spacing;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
           // MessageBox.Show(sender.ToString());
            Button ourButton = (System.Windows.Forms.Button) sender;
            if (ourButton.Text == "Alter Star 1")
            {
                StarAlter updateStar = new StarAlter(0, this.mySystem);
                updateStar.ShowDialog();
            }

            if (ourButton.Text == "Alter Star 2")
            {
                StarAlter updateStar = new StarAlter(this.mySystem.star2index, this.mySystem);
                updateStar.ShowDialog();
            }

            if (ourButton.Text == "Alter Star 3")
            {
                StarAlter updateStar = new StarAlter(this.mySystem.star3index, this.mySystem);
                updateStar.ShowDialog();
            }

            if (ourButton.Text == "Alter Star 2 Sub")
            {
                StarAlter updateStar = new StarAlter(this.mySystem.subCompanionStar2index, this.mySystem);
                updateStar.ShowDialog();
            }

            if (ourButton.Text == "Alter Star 3 Sub")
            {
                StarAlter updateStar = new StarAlter(this.mySystem.subCompanionStar3index, this.mySystem);
                updateStar.ShowDialog();
            }
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

            if (this.Controls.ContainsKey("btnOrbits2"))
                this.Controls.RemoveByKey("btnOrbits2");

            if (this.Controls.ContainsKey("btnOrbits3"))
                this.Controls.RemoveByKey("btnOrbits3");

            if (this.Controls.ContainsKey("btnOrbits2Sub"))
                this.Controls.RemoveByKey("btnOrbits2Sub");

            if (this.Controls.ContainsKey("btnOrbits3Sub"))
                this.Controls.RemoveByKey("btnOrbits3Sub");
        }

        private void step2DetermineSafeOrbitalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
             int totalOrbCount = 0; //total orbital count

             //first off, master loop. 
             for (int currStar = 0; currStar < this.mySystem.sysStars.Count; currStar++)
             {
                 Range temp;
                 //draw up forbidden zones.
                 if (!this.mySystem.sysStars[currStar].testInitlizationZones()) this.mySystem.sysStars[currStar].initalizeZonesOfInterest();
                 for (int i = 1; i < this.mySystem.sysStars.Count; i++)
                 {
                     if (this.mySystem.sysStars[i].parentID == this.mySystem.sysStars[currStar].selfID)
                     {
                         temp = new Range(this.mySystem.sysStars[i].getInnerForbiddenZone(), this.mySystem.sysStars[i].getOuterForbiddenZone());
                         this.mySystem.sysStars[currStar].createForbiddenZone(temp, this.mySystem.sysStars[currStar].selfID, this.mySystem.sysStars[i].selfID);
                     }
                     if (this.mySystem.sysStars[i].selfID == this.mySystem.sysStars[currStar].selfID)
                     {
                         temp = new Range(this.mySystem.sysStars[i].getInnerForbiddenZone(), this.mySystem.sysStars[i].getOuterForbiddenZone());
                         this.mySystem.sysStars[currStar].createForbiddenZone(temp, this.mySystem.sysStars[currStar].parentID, this.mySystem.sysStars[currStar].selfID);
                     }
                 }

                 this.mySystem.sysStars[currStar].sortForbidden();
                 this.mySystem.sysStars[currStar].createCleanZones(); 

                 //gas giant flag
                 libStarGen.gasGiantFlag(this.mySystem.sysStars[currStar], velvetBag.gurpsRoll());

                 Satellite placeHolder = new Satellite(0, 0, 0, 0);
                 int ownership, roll;
                 double orbit = 0;
                 if (this.mySystem.sysStars[currStar].gasGiantFlag != Star.GASGIANT_NONE)
                 {
                     double rangeAvail = 0, lowerBound = 0, diffRange = 0;
                     Range spawnRange = new Range(0, 1);

                     //get range availability and spawn range

                     //CONVENTIONAL
                     if (this.mySystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_CONVENTIONAL)
                     {
                         rangeAvail = this.mySystem.sysStars[currStar].checkConRange();
                         lowerBound = Star.snowLine(this.mySystem.sysStars[currStar].initLumin) * 1;
                         diffRange = (Star.snowLine(this.mySystem.sysStars[currStar].initLumin) * 1.5) - lowerBound;
                         spawnRange = this.mySystem.sysStars[currStar].getConventionalRange();
                     }

                     //ECCENTRIC
                     if (this.mySystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_ECCENTRIC)
                     {
                         rangeAvail = this.mySystem.sysStars[currStar].checkEccRange();
                         lowerBound = Star.snowLine(this.mySystem.sysStars[currStar].initLumin) * .125;
                         diffRange = (Star.snowLine(this.mySystem.sysStars[currStar].initLumin) * .75) - lowerBound;
                         spawnRange = this.mySystem.sysStars[currStar].getEccentricRange();
                     }

                     //EPISTELLAR 
                     if (this.mySystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                     {
                         rangeAvail = this.mySystem.sysStars[currStar].checkEpiRange();
                         lowerBound = Star.innerRadius(this.mySystem.sysStars[currStar].initLumin, this.mySystem.sysStars[currStar].initMass) * .1;
                         diffRange = (Star.innerRadius(this.mySystem.sysStars[currStar].initLumin, this.mySystem.sysStars[currStar].initMass) * 1.8) - lowerBound;
                         spawnRange = this.mySystem.sysStars[currStar].getEpistellarRange();
                     }

                     if (rangeAvail >= .25)
                     {
                         do
                         {
                             orbit = velvetBag.rollRange(lowerBound, diffRange);
                         } while (!this.mySystem.sysStars[currStar].verifyCleanOrbit(orbit));

                         ownership = this.mySystem.sysStars[currStar].getOwnership(orbit);

                         if (this.mySystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                             ownership = this.mySystem.sysStars[currStar].selfID;

                         placeHolder = new Satellite(ownership, 0, orbit, 0, Satellite.BASETYPE_GASGIANT);

                         roll = velvetBag.gurpsRoll() + 4;
                         libStarGen.updateGasGiantSize(placeHolder, roll);
                     }

                     if (rangeAvail >= .005 && rangeAvail < .25)
                     {
                         orbit = this.mySystem.sysStars[currStar].pickInRange(spawnRange);
                         ownership = this.mySystem.sysStars[currStar].getOwnership(orbit);
                         if (this.mySystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR)
                             ownership = this.mySystem.sysStars[currStar].selfID;

                         placeHolder = new Satellite(ownership, 0, orbit, 0, Satellite.BASETYPE_GASGIANT);

                         roll = velvetBag.gurpsRoll() + 4;
                         libStarGen.updateGasGiantSize(placeHolder, roll);
                     }
                 }

                 //now we've determined our placeholdr, let's start working on our orbitals.

                  double currOrbit = Star.innerRadius(this.mySystem.sysStars[currStar].initLumin, this.mySystem.sysStars[currStar].initMass), nextOrbit = 0;
                  double distance = .15;
                 
                  //now we have our placeholder.
                  if (placeHolder.orbitalRadius != 0)
                  {
                      this.mySystem.sysStars[currStar].addSatellite(placeHolder);
                      currOrbit = placeHolder.orbitalRadius;
                  }

                  if (this.mySystem.sysStars[currStar].gasGiantFlag != Star.GASGIANT_EPISTELLAR && placeHolder.orbitalRadius != 0)
                  {
                      //we're moving left.
                      //LEFT RIGHT LEFT
                      //.. sorry about that
                      double innerRadius = Star.innerRadius(this.mySystem.sysStars[currStar].initLumin, this.mySystem.sysStars[currStar].initMass);
                      do{
                          //as we're moving left, divide.
                          nextOrbit =  currOrbit / libStarGen.getOrbitalRatio(velvetBag);

                          if (nextOrbit > currOrbit - distance)
                              nextOrbit = currOrbit - distance;

                          if (this.mySystem.sysStars[currStar].verifyCleanOrbit(nextOrbit) && this.mySystem.sysStars[currStar].withinCreationRange(nextOrbit))
                          {
                              ownership = this.mySystem.sysStars[currStar].getOwnership(nextOrbit);
                              this.mySystem.sysStars[currStar].addSatellite(new Satellite(ownership, 0, nextOrbit, 0));
                          }

                          currOrbit = nextOrbit;
                          
                          //now let's check on 
                      } while (currOrbit > innerRadius);
                         
                  }

                 //MOVE RIGHT!
                 //now we have our placeholder.
                 if (this.mySystem.sysStars[currStar].gasGiantFlag == Star.GASGIANT_EPISTELLAR || placeHolder.orbitalRadius == 0){
                     double outerRadius = Star.outerRadius(this.mySystem.sysStars[currStar].initMass);
                      do
                      {
                          //as we're moving right, multiply.
                          nextOrbit = currOrbit * libStarGen.getOrbitalRatio(velvetBag);

                          if (nextOrbit < currOrbit + distance)
                              nextOrbit = currOrbit + distance;

                          if (this.mySystem.sysStars[currStar].verifyCleanOrbit(nextOrbit) && this.mySystem.sysStars[currStar].withinCreationRange(nextOrbit))
                          {
                              ownership = this.mySystem.sysStars[currStar].getOwnership(nextOrbit);
                              this.mySystem.sysStars[currStar].addSatellite(new Satellite(ownership, 0, nextOrbit, 0));
                          }

                          currOrbit = nextOrbit;

                          if (currOrbit < 0)
                              currOrbit = outerRadius + 10;
                          //now let's check on 
                      } while (currOrbit < outerRadius);
                  }

                 //if a clean zone has 0 planets, add one.
                 foreach (cleanZone c in this.mySystem.sysStars[currStar].zonesOfInterest.formationZones)
                 {
                     if (!this.mySystem.sysStars[currStar].cleanZoneHasOrbits(c))
                     {
                         nextOrbit =  this.mySystem.sysStars[currStar].pickInRange(c.getRange());
                         ownership = this.mySystem.sysStars[currStar].getOwnership(nextOrbit);
                         this.mySystem.sysStars[currStar].addSatellite(new Satellite(ownership, 0,nextOrbit, 0));
                     }
                 }

                 //sort orbitals
                 this.mySystem.sysStars[currStar].sortOrbitals();
                 this.mySystem.sysStars[currStar].giveOrbitalsOrder(ref totalOrbCount);

                 //now we get orbital contents, then fill in details
                 libStarGen.populateOrbits(this.mySystem.sysStars[currStar], velvetBag);

                 //set any star with all empty orbits to have one planet
                 if (this.mySystem.sysStars[currStar].isAllEmptyOrbits() && OptionCont.ensureOneOrbit)
                 {
                     int newPlanet = velvetBag.rng(1, this.mySystem.sysStars[currStar].sysPlanets.Count, -1);
                     this.mySystem.sysStars[currStar].sysPlanets[newPlanet].updateTypeSize(Satellite.BASETYPE_TERRESTIAL, Satellite.SIZE_MEDIUM);
                 }
             }

             /* 
             int lblHeight = 67;
             int btnLeft = 596;
             int currHeight = 128;
             int spacing = 10;
             int btnHeight = 25;

             foreach (Star s in mySystem.sysStars)
             {
                 if (s.selfID == Star.IS_SECONDARY)
                 {
                     Button btnOrbits2 = new System.Windows.Forms.Button();
                     btnOrbits2.Location = new System.Drawing.Point(btnLeft, currHeight);
                     btnOrbits2.Name = "btnOrbits2";
                     btnOrbits2.Size = new System.Drawing.Size(93, btnHeight);
                     btnOrbits2.Visible = true;
                     btnOrbits2.Text = "Display Orbits 2";
                     btnOrbits2.Click += new System.EventHandler(this.btnOrbits_Click);
                     this.Controls.Add(btnOrbits2);
                     currHeight += lblHeight + spacing;
                 }

                 if (s.selfID == Star.IS_SECCOMP)
                 {
                     Button btnOrbits2Sub = new System.Windows.Forms.Button();
                     btnOrbits2Sub.Location = new System.Drawing.Point(btnLeft, currHeight);
                     btnOrbits2Sub.Name = "btnOrbits2sub";
                     btnOrbits2Sub.Size = new System.Drawing.Size(93, btnHeight);
                     btnOrbits2Sub.Visible = true;
                     btnOrbits2Sub.Text = "Display Orbits 2 Sub";
                     btnOrbits2Sub.Click += new System.EventHandler(this.btnOrbits_Click);
                     this.Controls.Add(btnOrbits2Sub);
                     currHeight += lblHeight + spacing;
                 }

                 if (s.selfID == Star.IS_TRINARY)
                 {
                     Button btnOrbits3 = new System.Windows.Forms.Button();
                     btnOrbits3.Location = new System.Drawing.Point(btnLeft, currHeight);
                     btnOrbits3.Name = "btnOrbits3";
                     btnOrbits3.Size = new System.Drawing.Size(93, btnHeight);
                     btnOrbits3.Visible = true;
                     btnOrbits3.Text = "Display Orbits 3";
                     btnOrbits3.Click += new System.EventHandler(this.btnOrbits_Click);
                     this.Controls.Add(btnOrbits3);
                     currHeight += lblHeight + spacing;
                 }

                 if (s.selfID == Star.IS_TRICOMP)
                 {
                     Button btnOrbits3Sub = new System.Windows.Forms.Button();
                     btnOrbits3Sub.Location = new System.Drawing.Point(btnLeft, currHeight);
                     btnOrbits3Sub.Name = "btnOrbits3Sub";
                     btnOrbits3Sub.Size = new System.Drawing.Size(93, btnHeight);
                     btnOrbits3Sub.Visible = true;
                     btnOrbits3Sub.Text = "Display Orbits 3 Sub";
                     btnOrbits3Sub.Click += new System.EventHandler(this.btnOrbits_Click);
                     this.Controls.Add(btnOrbits3Sub);
                     currHeight += lblHeight + spacing;
                 }
             } */

             for (int currStar = 0; currStar < this.mySystem.sysStars.Count; currStar++)
             {
                 double[,] distChart = libStarGen.genDistChart(this.mySystem.sysStars);
                 for (int i = 0; i < this.mySystem.sysStars[currStar].sysPlanets.Count; i++)
                 {
                     this.mySystem.sysStars[currStar].sysPlanets[i].updateBlackBodyTemp(distChart, this.mySystem.sysStars);
                 }
                 libStarGen.createPlanets(this.mySystem, this.mySystem.sysStars[currStar].sysPlanets, velvetBag);
             }
        }

        private void btnOrbits_Click(object sender, EventArgs e)
        {
            Button ourButton = (System.Windows.Forms.Button)sender;

        }

        private void step3OutputToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ourSystem = "";
            
                ourSystem += "System Name: " + this.mySystem.sysName + Environment.NewLine;
                ourSystem += "System Age: " + this.mySystem.sysAge + Environment.NewLine;
                ourSystem += Environment.NewLine;
                foreach (Star s in this.mySystem.sysStars)
                {
                    ourSystem += s + Environment.NewLine;
                    ourSystem += Environment.NewLine;
                }

                OutputWindow printSystem = new OutputWindow(ourSystem, this.mySystem.sysName);
                printSystem.ShowDialog();
            
        }

        private void outputToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save System Details";
            //saveFileDialog1.InitialDirectory = sOutputFolder;
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = this.mySystem.sysName + ".txt";

            //use a if here to see if the user actually click save button.
            //if DialogResult.OK means the user actually click save button.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //do something here using the filename
                string filename = saveFileDialog1.FileName;

                //now we open it!
                TextWriter fileOutput = new StreamWriter(filename);

                fileOutput.WriteLine("System Name: " + this.mySystem.sysName);
                fileOutput.WriteLine("System Age: " + this.mySystem.sysAge);
                fileOutput.WriteLine();
                foreach (Star s in this.mySystem.sysStars)
                {
                    fileOutput.WriteLine(s);
                    fileOutput.WriteLine();
                }

                fileOutput.Close();

            }
        }
   }
}
