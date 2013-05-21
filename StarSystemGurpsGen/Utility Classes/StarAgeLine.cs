using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    /// <summary>
    /// This class is used to track the current position of the star in it's growth sequence, as well as provide tracking for dates.
    /// </summary>
    public class StarAgeLine : TimeLine
    {
        //flags

        /// <summary>
        /// This flag is used to set or get the sequence for Main Sequence
        /// </summary>
        readonly protected static int AG_MAINLIMIT = 0;

        /// <summary>
        ///  This flag is used to set or get the sequence for Sub Giant branch
        /// </summary>
        readonly protected static int AG_SUBLIMIT = 1;

        /// <summary>
        /// This flag is used to set or get the sequence for the Asymptomic Giant Branch
        /// </summary>
        readonly protected static int AG_GIANTLIMIT = 2;
        
        /// <summary>
        /// Flag to signify it's the mainbranch
        /// </summary>
        readonly public static int RET_MAINBRANCH = 20;

        /// <summary>
        /// Flag to signify it's in the sub giant branch
        /// </summary>
        readonly public static int RET_SUBBRANCH = 21;

        /// <summary>
        /// Flag to signify it's in the Asymptomic Giant Branch
        /// </summary>
        readonly public static int RET_GIANTBRANCH = 22;

        /// <summary>
        /// Flag to signify it's in the White Dwarf Stage
        /// </summary>
        readonly public static int RET_DWARFBRANCH = 23;

        /// <summary>
        /// Error flag.
        /// </summary>
        readonly public static int RET_ERROR = -1;

        /// <summary>
        /// Base Constructor
        /// </summary>
        public StarAgeLine()
        {
            base.initList();
        }

        /// <summary>
        /// Constructor assuming 
        /// </summary>
        /// <param name="inLen"></param>
        public StarAgeLine(double[] inLen)
            : base(inLen)
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">The StarAgeLine object being copied</param>
        public StarAgeLine(StarAgeLine s)
        {
            initList();
            foreach (double d in s.points)
            {
                this.points.Add(d);
            }
        }

        /// <summary>
        /// Gets the position within the Sub Giant Branch
        /// </summary>
        /// <param name="age">The age of the star</param>
        /// <returns>The position (0 - 1) within the branch. </returns>
        /// <exception cref="Exception">If the age is beyond the Sub Giant Branch, this function throws an exception</exception>
        public double calcWithInSubLimit(double age)
        {
            if (age >= this.points[AG_SUBLIMIT]) //basic error checking.
                throw new Exception("This star is beyond the Sub Giant Branch");

            double pos;
            pos = (age - this.points[AG_MAINLIMIT]) / (this.points[AG_SUBLIMIT] - this.points[AG_MAINLIMIT]);

            return pos;
        }

        /// <summary>
        /// Gets the position within the Asympotic Giant Branch
        /// </summary>
        /// <param name="age">The age of the Star</param>
        /// <returns>The position (0 - 1) within the branch.</returns>
        /// <exception cref="Exception">If the age is beyond the Asymptotic Giant Branch, this function throws an exception</exception>
        public double calcWithInGiantLimit(double age)
        {
            if (age >= this.points[AG_GIANTLIMIT]) //basic error checking.
                throw new Exception("This star is beyond the Asymptotic Giant Branch");

            double pos;
            pos = (age - this.points[AG_SUBLIMIT]) / (this.points[AG_GIANTLIMIT] - this.points[AG_SUBLIMIT]);

            return pos;
        }

        /// <summary>
        /// Returns the main sequence limit
        /// </summary>
        /// <returns>The main sequence limit</returns>
        public double getMainLimit()
        {
            return this.points[AG_MAINLIMIT];
        }

        /// <summary>
        /// Returns the sub giant branch limit
        /// </summary>
        /// <returns>The sub giant branch limit</returns>
        public double getSubLimit()
        {
            return this.points[AG_SUBLIMIT];
        }

        /// <summary>
        /// Returns the Asymptotic Giant Branch Limit
        /// </summary>
        /// <returns>The Asymptotic Giant Branch Limit</returns>
        public double getGiantLimit()
        {
            return this.points[AG_GIANTLIMIT];
        }

        /// <summary>
        /// A function to determine where you are in the age progression of a star
        /// </summary>
        /// <param name="currAge">The current age</param>
        /// <returns>Returns the flag for where you are</returns>
        public int findCurrentAgeGroup(double currAge)
        {
            if (currAge < this.points[AG_MAINLIMIT])
                return RET_MAINBRANCH;
            if (currAge < this.points[AG_SUBLIMIT])
                return RET_SUBBRANCH;
            if (currAge < this.points[AG_GIANTLIMIT])
                return RET_GIANTBRANCH;
            if (currAge > this.points[AG_GIANTLIMIT])
                return RET_DWARFBRANCH;

            return RET_ERROR;
        }

        /// <summary>
        /// This function adds the main sequence limit
        /// </summary>
        /// <param name="d">The limit of the main sequence</param>
        public void addMainLimit(double d)
        {
            // if it's not added, add it.
            if (this.points.Count > 1)
                this.points[AG_MAINLIMIT] = d;
            else
                this.points.Add(d);
        }

        /// <summary>
        /// This function adds the Sub Giant Sequence Limit
        /// </summary>
        /// <param name="d">The limit of the Sub Giant Sequence</param>
        /// <exception cref="Exception">Throws an exception if the main sequence limit has not been set</exception>
        public void addSubLimit(double d)
        {
            // if it's not added, add it. Throw an error if no one has set the main limit.
            if (this.points.Count > 2)
                this.points[AG_SUBLIMIT] = d + this.points[AG_MAINLIMIT]; //add the main limit to this.
            else if (this.points.Count < 1)
                throw new Exception("Main sequence limit has not been set.");
            else
                this.points.Add(d + this.points[AG_MAINLIMIT]);
        }

        /// <summary>
        /// This function adds the Asymptotic Giant Branch limit
        /// </summary>
        /// <param name="d">The limit of the Asymptotic Giant Branch</param>
        /// <exception cref="Exception">Throws an exception if the sublimit has not been set.</exception>
        public void addGiantLimit(double d)
        {
            // if it's not added, add it. Throw an error if no one has set the sub limit.
            if (this.points.Count > 3)
                this.points[AG_GIANTLIMIT] = d + this.points[AG_SUBLIMIT]; //add the sub limit to this.
            else if (this.points.Count < 2)
                throw new Exception("Sublimit has not been set.");
            else
                this.points.Add(d + this.points[AG_SUBLIMIT]);
        }

        /// <summary>
        /// This function returns the description of the flags.
        /// </summary>
        /// <param name="branch">The flag branch</param>
        /// <returns>The description</returns>
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
