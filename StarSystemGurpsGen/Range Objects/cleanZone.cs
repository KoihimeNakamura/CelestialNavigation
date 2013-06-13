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
        public int orbitDesc { get; set; }

        public cleanZone(double lower, double upper, int ownership, int orbitDesc)
            : base(lower, upper)
        {
            this.ownershipFlag = ownership;
            this.orbitDesc = orbitDesc;
        }

        public cleanZone(Range incoming, int ownership, int orbitDesc)
            : base(incoming)
        {
            this.ownershipFlag = ownership;
            this.orbitDesc = orbitDesc;
        }

        //copy constructor
        public cleanZone(cleanZone c)
            : base(c.lowerBound, c.upperBound)
        {
            this.ownershipFlag = c.ownershipFlag;
            this.orbitDesc = c.orbitDesc;
        }

        public Range getRange()
        {
            return new Range(this.lowerBound, this.upperBound);
        }

        public override String ToString()
        {
            String ret = "This clean zone is from " + this.lowerBound + " to " + this.upperBound + " AU";
            ret = ret + Environment.NewLine + "    " + " with ownership " + Star.getDescSelfFlag(this.ownershipFlag) + " and ";
            ret = ret + "orbit desc of " + Star.getDescSelfFlag(this.orbitDesc);

            return ret;
        }
    } 
}
