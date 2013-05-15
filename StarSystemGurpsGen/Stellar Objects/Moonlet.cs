using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    public class Moonlet : Orbital
    {
        public double planetRadius { get; set; } 
        public string moonName { get; set; }

        public Moonlet(int parent, int self, double planetRadius, string name) : base(parent, self)
        {
            this.planetRadius = planetRadius;
            this.moonName = name;
        }

        //copy constructor
        public Moonlet(Moonlet inBound) : base (inBound.parentID, inBound.selfID)
        {
            this.planetRadius = inBound.planetRadius;
            this.moonName = inBound.moonName;
            this.orbitalRadius = inBound.orbitalRadius;
            this.orbitalPeriod = inBound.orbitalPeriod;
        }

        public override string ToString()
        {
            string ret = "";
            ret = this.moonName + " orbiting at " + Math.Round(this.orbitalRadius, 3) + " Earth diameters and ";
            ret = ret + this.planetRadius + " planetary radii";
            return ret;
        }
    }
}
