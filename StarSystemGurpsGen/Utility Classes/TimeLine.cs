using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
   
    public class TimeLine
    {
        protected List<double> lengths;

        public void initList()
        {
            lengths = new List<double>();
        }

        public TimeLine(double[] inLen)
        {
            initList();
            for (int i = 0; i < inLen.Length; i++)
                this.lengths.Add(inLen[i]);
        }

        public TimeLine()
        {
            initList();
        }

        public int Count()
        {
            return this.lengths.Count;
        }

        //copy constructor
        public TimeLine(TimeLine t)
        {
            initList();
            foreach (double d in t.lengths)
            {
                this.lengths.Add(d);
            }
        }

        public double getMaxLength()
        {
            double total = 0;
            double max = this.lengths[this.lengths.Count - 1];
            double min = this.lengths[0];

            total = Math.Abs(Math.Abs(max) - Math.Abs(min));

            return total;
        }

        public void addToLine(double d)
        {
            this.lengths.Add(d);
            this.lengths.Sort();
        }

       

    }
}
