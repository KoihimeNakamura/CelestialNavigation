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
            if (mySystem == null)
                mySystem = new StarSystem();

            if (sysName.Text == "")
                sysName.Text = libStarGen.genRandomSysName(velvetBag);

            mySystem.resetSystem();

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
                    lblStar1.Text = s.printSummaryLine("Star 1:");
                }

                if (s.selfID == Star.IS_SECONDARY)
                {
                    lblStar2.Visible = true;
                    lblStar2.Text = s.printSummaryLine("Star 2:");
                }

                if (s.selfID == Star.IS_TRINARY)
                {
                    lblStar3.Visible = true;
                    lblStar3.Text = s.printSummaryLine("Star 3:");
                }

                if (s.selfID == Star.IS_SECCOMP)
                {
                    lblSubStar2.Visible = true;
                    lblSubStar2.Text = s.printSummaryLine("Star 2 Companion:");
                }

                if (s.selfID == Star.IS_TRICOMP)
                {
                    lblSubStar3.Visible = true;
                    lblSubStar3.Text = s.printSummaryLine("Star 3 Companion:");
                }
            }
        }

        private void lblStar3_Click(object sender, EventArgs e)
        {

        }

   }
}
