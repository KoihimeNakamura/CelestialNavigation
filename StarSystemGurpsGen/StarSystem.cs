using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class StarSystem
    {
        //fields
        public string sysName { get; set; }
        public double sysAge { get; set; }
        public List<Star> sysStars { get; set; }
        public List<Range> habitableZones { get; set; }
        //derived field
        public double maxMass { get; set; }

        //outer system details
        public int numDwarfPlanets { get; set; }
        public double helioPause { get; set; }

        public int subCompanionStar2index { get; set; }
        public int subCompanionStar3index { get; set; }
        public int star2index { get; set; }
        public int star3index { get; set; }

        public void initateLists()
        {
            sysStars = new List<Star>();
            habitableZones = new List<Range>();
        }

        public StarSystem()
        {
            initateLists();
        }


        public void resetSystem()
        {
            this.sysAge = 0.0;
            this.maxMass = 0.0;
            this.numDwarfPlanets = 0;
            this.helioPause = 0.0;
            this.subCompanionStar2index = 0;
            this.subCompanionStar3index = 0;
            this.star2index = 0;
            this.star3index = 0;
            this.sysStars.Clear();
            this.habitableZones.Clear();
        }

        public void addStar(Star newStar){
            this.sysStars.Add(newStar);
        }

        public void addStar(int selfID, int parent, int order)
        {
            if (this.sysAge == 0)
                throw new Exception("This star system needs an age.");

            //Set flags here.
            int curPos = this.sysStars.Count;
            
            if (selfID == Star.IS_SECONDARY)
                this.star2index = curPos;

            if (selfID == Star.IS_SECCOMP)
                this.subCompanionStar2index = curPos;

            if (selfID == Star.IS_TRINARY)
                this.star3index = curPos;

            if (selfID == Star.IS_TRICOMP)
                this.subCompanionStar3index = curPos;

            //add it now

            this.sysStars.Add(new Star(this.sysAge, parent, selfID, order, this.sysName));
        }


        public int getPositionByID(int selfID)
        {
            for (int i = 0; i < this.sysStars.Count; i++)
            {
                if (sysStars[i].selfID == selfID) return i;
            }

            return 0;
        }



        public int getValidParent(int parentFlag)
        {
            int planetOwner = 0;

            if ((parentFlag == Satellite.ORBIT_PRISEC) || (parentFlag == Satellite.ORBIT_PRISECTRI) ||
                (parentFlag == Satellite.ORBIT_PRITRI) || (parentFlag == Star.IS_PRIMARY))
                planetOwner = 0;
            if ((parentFlag == Satellite.ORBIT_SECCOM) || (parentFlag == Satellite.ORBIT_SECTRI) ||
                (parentFlag == Star.IS_SECONDARY))
                planetOwner = this.star2index;
            if ((parentFlag == Satellite.ORBIT_TRICOM) || (parentFlag == Star.IS_TRINARY))
                planetOwner = this.star3index;
            if (parentFlag == Star.IS_SECCOMP) planetOwner = this.subCompanionStar2index;
            if (parentFlag == Star.IS_TRICOMP) planetOwner = this.subCompanionStar3index;

            return planetOwner;
        }

        public int getStellarParentID(int ID)
        {
            if (ID == Star.IS_PRIMARY) return 0;
            if (ID == Star.IS_SECONDARY) return this.star2index;
            if (ID == Star.IS_TRINARY) return this.star3index;
            if (ID == Star.IS_SECCOMP) return this.subCompanionStar2index;
            if (ID == Star.IS_TRICOMP) return this.subCompanionStar3index;

            return 0;
        }

        public static int genNumOfStars(Dice ourDice)
        {
            int roll = 0;

            //if there's an override in, autoreturn it.
            if (OptionCont.numStarOverride) return OptionCont.numStars;

            roll = ourDice.gurpsRoll();

            if (OptionCont.inOpenCluster) roll = roll + 3;

            roll = (int)Math.Floor((roll - 1) / 5.0);

            //logic bugs.
            if (roll < 1) roll = 1;
            if (roll > 3) roll = 3;

            return roll;
        }

        public void genStellarAge(Dice ourDice)
        {
            
            //get first roll
            int roll;
            roll = ourDice.gurpsRoll();

            if (roll == 3)
                this.sysAge = 0.01;
            if (roll >= 4 && roll <= 6)
                this.sysAge = .1 + (ourDice.rng(1, 6, -1) * .3) + (ourDice.rng(1, 6, -1) * .05);
            if (roll >= 7 && roll <= 10)
                this.sysAge = 2 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1);
            if (roll >= 11 && roll <= 14)
                this.sysAge = 5.6 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1);
            if (roll >= 15 && roll <= 17)
                this.sysAge = 8 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1);
            if (roll == 18)
                this.sysAge = 10 + (ourDice.rng(1, 6, -1) * .6) + (ourDice.rng(1, 6, -1) * .1);

            if (OptionCont.presetOverride)
                this.sysAge = OptionCont.presetAge;
            

        }

        public static String getPopulationFromAge(double age)
        {
            if (age >= .01 && age < .1) return "Extreme Population I";
            if (age >= .1 && age < 2) return "Young Population I";
            if (age >= 2 && age < 5.6) return "Intermediate Population I";
            if (age >= 5.6 && age < 8.2) return "Old Population I";
            if (age >= 8.2 && age < 10.4) return "Intermediate Population II";
            if (age >= 10.4) return "Extreme Population II";

            return "???";
        }

        public int countStars()
        {
            return this.sysStars.Count;
        }
    }
}
