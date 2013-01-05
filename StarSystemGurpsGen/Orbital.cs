using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    class Orbital
    {

        public static long AUtoKM = 149597871;

        //orbital details
        public int parentID { get; set; } // ID of the body anything in this orbital orbits.
        public int selfID { get; set; } //used to track what THIS is. (also, the orbit order)
        public decimal orbitalRadius { get; set; } //the radius of the orbit around the parent body
        public decimal orbitalEccent { get; set; } //the eccentricity of the orbit
        public decimal blackbodyTemp { get; set; } // the blackbody temp of this orbit
        public decimal orbitalPeriod { get; set; } // time it takes to revolve around a parent object
        public String name { get; set; }

        public Orbital(){
            this.parentID = 0;
            this.selfID = 0;
        }

        public Orbital(int parent, int self)  {
            this.parentID = parent;
            this.selfID = self;
        }

        public Orbital(int parent, int self, decimal radius){
            this.orbitalRadius = radius;
            this.selfID = self;
            this.parentID = parent;

        }

        public decimal getPeriapsis(){
            return ((1 - this.orbitalEccent) * this.orbitalRadius);
        }

        public decimal getApapsis(){
            return ((1 + this.orbitalEccent) * this.orbitalRadius);
        }

        public override string ToString()
        {
            String myStr = this.name  + " : Empty Orbit at " + orbitalRadius.ToString() + "AU ";
            return myStr;
        }

        public decimal xToYPower(decimal x, decimal y)
        {
            double tmp;
            tmp = Math.Pow((double)x, (double)y);
            return (decimal)tmp;
        }

        public virtual void genGenericName(){
            this.name = "Orbital " + this.selfID;
        }
    }
}
