using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class cleanZone : Range
    {
        public int ownershipFlag { get; set; }

        public cleanZone(double lower, double upper, int ownership)
            : base(lower, upper)
        {
            this.ownershipFlag = ownership;
        }

        public cleanZone(Range incoming, int ownership)
            : base(incoming)
        {
            this.ownershipFlag = ownership;
        }

        //copy constructor
        public cleanZone(cleanZone c)
            : base(c.lowerBound, c.upperBound)
        {
            this.ownershipFlag = c.ownershipFlag;
        }

        public override String ToString()
        {
            return ("This clean zone is from " + this.lowerBound + " to " + this.upperBound + " AU");
        }
    }
}
