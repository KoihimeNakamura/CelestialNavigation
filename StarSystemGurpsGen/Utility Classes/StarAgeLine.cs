using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class StarAgeLine : TimeLine
    {
        //flags
        readonly public static int AG_MAINLIMIT = 0;
        readonly public static int AG_SUBLIMIT = 1;
        readonly public static int AG_GIANTLIMIT = 2;

        readonly public static int RET_MAINBRANCH = 20;
        readonly public static int RET_SUBBRANCH = 21;
        readonly public static int RET_GIANTBRANCH = 22;
        readonly public static int RET_DWARFBRANCH = 23;
        readonly public static int RET_ERROR = -1;

        public StarAgeLine()
        {
            base.initList();
        }

        public StarAgeLine(double[] inLen)
            : base(inLen)
        {
        }

        //copy constructor
        public StarAgeLine(StarAgeLine s)
        {
            initList();
            foreach (double d in s.lengths)
            {
                this.lengths.Add(d);
            }
        }

        public double calcWithInSubLimit(double age)
        {
            double pos;
            pos = (age - this.lengths[AG_MAINLIMIT]) / (this.lengths[AG_SUBLIMIT] - this.lengths[AG_MAINLIMIT]);

            return pos;
        }

        public double calcWithInGiantLimit(double age)
        {
            double pos;
            pos = (age - this.lengths[AG_SUBLIMIT]) / (this.lengths[AG_GIANTLIMIT] - this.lengths[AG_SUBLIMIT]);

            return pos;
        }

        public double getMainLimit()
        {
            return this.lengths[AG_MAINLIMIT];
        }

        public double getSubLimit()
        {
            return this.lengths[AG_SUBLIMIT];
        }

        public double getGiantLimit()
        {
            return this.lengths[AG_GIANTLIMIT];
        }

        public int findCurrentAgeGroup(double currAge)
        {
            if (currAge < this.lengths[AG_MAINLIMIT])
                return RET_MAINBRANCH;
            if (currAge < this.lengths[AG_SUBLIMIT])
                return RET_SUBBRANCH;
            if (currAge < this.lengths[AG_GIANTLIMIT])
                return RET_GIANTBRANCH;
            if (currAge > this.lengths[AG_GIANTLIMIT])
                return RET_DWARFBRANCH;

            return RET_ERROR;
        }

        public void addMainLimit(double d)
        {
            if (this.lengths.Count > 1)
                this.lengths[AG_MAINLIMIT] = d;
            else
                this.lengths.Add(d);
        }

        public void addSubLimit(double d)
        {
            if (this.lengths.Count > 2)
                this.lengths[AG_SUBLIMIT] = d + this.lengths[AG_MAINLIMIT];
            else if (this.lengths.Count < 1)
                throw new Exception("Mainlimit has not been set.");
            else
                this.lengths.Add(d + this.lengths[AG_MAINLIMIT]);
        }

        public void addGiantLimit(double d)
        {
            if (this.lengths.Count > 3)
                this.lengths[AG_GIANTLIMIT] = d + this.lengths[AG_SUBLIMIT];
            else if (this.lengths.Count < 2)
                throw new Exception("Sublimit has not been set.");
            else
                this.lengths.Add(d + this.lengths[AG_SUBLIMIT]);
        }

        public static string descBranch(int branch)
        {
            if (branch == RET_MAINBRANCH) return "Main Sequence";
            if (branch == RET_SUBBRANCH) return "Sub Giant Star";
            if (branch == RET_GIANTBRANCH) return "Asymptoic Giant Branch";
            if (branch == RET_DWARFBRANCH) return "White Dwarf Branch";

            return "ERROR";
        }
    }
}
