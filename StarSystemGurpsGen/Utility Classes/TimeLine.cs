using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
   /// <summary>
   /// A base class for something with multiple segments (i.e a timeline)
   /// </summary>
    public class TimeLine
    {
        /// <summary>
        /// Internal array to track points.
        /// </summary>
        protected List<double> points;


        /// <summary>
        /// A function used to initiate the <see cref="TimeLine.points"/> object
        /// </summary>
        public void initList()
        {
            this.points = new List<double>();
        }

        /// <summary>
        /// A constructor assuming a list of existing points.
        /// </summary>
        /// <param name="inLen">The list of existing points</param>
        public TimeLine(double[] inLen)
        {
            initList();
            for (int i = 0; i < inLen.Length; i++)
                this.points.Add(inLen[i]);
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        public TimeLine()
        {
            initList();
        }

        /// <summary>
        /// Used to get a count of the number of points
        /// </summary>
        /// <returns>The number of points in the internal array</returns>
        public int Count()
        {
            return this.points.Count;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="t">The object to be copied</param>
        public TimeLine(TimeLine t)
        {
            initList();
            foreach (double d in t.points)
            {
                this.points.Add(d);
            }
        }

        /// <summary>
        /// Gets the distance from the first point and the last point
        /// </summary>
        /// <returns>The distance</returns>
        public double getMaxLength()
        {
            double total = 0;
            double max = this.points[this.points.Count - 1];
            double min = this.points[0];

            total = Math.Abs(Math.Abs(max) - Math.Abs(min));

            return total;
        }

        /// <summary>
        /// Adds a point to the line
        /// </summary>
        /// <param name="d">The point to be added to the line</param>
        /// <remarks>This automatically sorts it, so that the list will always have points correctly placed</remarks>
        public void addToLine(double d)
        {
            this.points.Add(d);
            this.points.Sort();
        }

       

    }
}
