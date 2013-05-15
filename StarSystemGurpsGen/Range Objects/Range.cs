using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class Range
    {
        public double lowerBound { get; protected set; }
        public double upperBound { get; protected set; }
        public double length { get; protected set; }

        public Range(double low, double high)
        {
            /* if (high < low)
                throw new Exception("Invalid argument: higher bound is lower than the lower bound");
            if (high == low)
                throw new Exception("Invalid argument: Both range endpoints are the same number"); */

            this.lowerBound = low;
            this.upperBound = high;
            this.length = this.upperBound - this.lowerBound;
        }

        public void setUpperBound(double bound){
            this.upperBound = bound;
            this.length = this.upperBound - this.lowerBound;
        }

        public void setLowerBound(double bound)
        {
            this.lowerBound = bound;
            this.length = this.upperBound - this.lowerBound;
        }

        //copy constructor
        public Range(Range incoming)
        {
            /* if (incoming.upperBound < this.lowerBound)
                throw new Exception("Invalid argument: higher bound is lower than the lower bound");
            if (this.upperBound == this.lowerBound) 
                throw new Exception("Invalid argument: Both range endpoints are the same number"); */

            this.lowerBound = incoming.lowerBound;
            this.upperBound = incoming.upperBound;
            this.length = incoming.length;
        }

        public virtual bool withinRange(double number)
        {
            if (lowerBound <= number && number <= upperBound)
            {
                return true;
            }

            return false;
        }

        public virtual double posWithinRange(double number)
        {
            if (this.withinRange(number))
            {
                return ((number - lowerBound) / this.length);
            }

            return 0.0;
        }


        public override String ToString()
        {
            return ("This range is from " + this.lowerBound + " to " + this.upperBound);
        }


    }
}
