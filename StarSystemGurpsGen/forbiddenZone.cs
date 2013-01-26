using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class forbiddenZone : Range
    {
        public int primaryStar { get; set; }
        public int secondaryStar { get; set; }

        public forbiddenZone(double lower, double upper, int primary, int secondary)
            : base(lower, upper)
        {
            this.primaryStar = primary;
            this.secondaryStar = secondary;
        }

        public forbiddenZone(Range incoming, int primary, int secondary)
            : base(incoming)
        {
            this.primaryStar = primary;
            this.secondaryStar = secondary;
        }

        //copy constructor
        public forbiddenZone(forbiddenZone r)
            : base(r.lowerBound, r.upperBound)
        {
            this.primaryStar = r.primaryStar;
            this.secondaryStar = r.secondaryStar;
        }

        public override bool withinRange(double number)
        {
            if (lowerBound < number && number < upperBound)
            {
                return true;
            }

            return false;
        }

        public override String ToString()
        {
            return ("This forbidden zone is from " + this.lowerBound + " to " + this.upperBound + " AU");
        }
    }
}
