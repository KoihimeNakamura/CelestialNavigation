using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen 
{
    class FormationZone
    {
        //flags
        public static int FZ_VALIDORBIT = 610;
        public static int FZ_TOOCLOSE = 611;
        public static int FZ_FORBIDDEN = 612;
        public static int FZ_OUTBOUNDS = 613;
        public static int FZ_BADPARENT = 9999;


        //constants
        public static double minDistance = .15;
        public static double minOrbitalRatio = 1.4;
        public static double maxOrbitalRatio = 2.1;

        public List<FormationSegment> segments { get; set; }
        public int parentID { get; set; }
        public List<double> ourOrbits { get; set; }

        public FormationZone(double lower, double upper, int parentID)
        {
            this.segments = new List<FormationSegment>();
            this.segments.Add(new FormationSegment(parentID, lower, upper));
            this.parentID = parentID;
            this.ourOrbits = new List<double>();
        }

        public FormationZone(Range incoming, int parentID)
        {
            this.segments = new List<FormationSegment>();
            this.segments.Add(new FormationSegment(parentID, incoming));
            this.parentID = parentID;
            this.ourOrbits = new List<double>();
        }


        public int checkOrbit(double orbit)
        {
            foreach (FormationSegment l in segments)
            {
                if (l.withinRange(orbit))
                {
                    if (l.parentID == FormationZone.FZ_BADPARENT) return FZ_FORBIDDEN;
                    foreach (double d in ourOrbits)
                    {
                        if (d - .15 < orbit && orbit > d + .15)
                            return FZ_TOOCLOSE;
                        if (d / 1.4 < orbit && orbit > d * 1.4)
                            return FZ_TOOCLOSE;
                    }

                    return FZ_VALIDORBIT;
                }
            }

            return FZ_OUTBOUNDS;
        }

        public double nextCleanOrbit(double orbit)
        {
            bool nextSegment = false;
            foreach (FormationSegment l in segments)
            {
                if (l.withinRange(orbit)){
                    nextSegment = true;
                }

                if (nextSegment)
                {
                    //skip if it's a bad parent.
                    //else return the start of this segment.
                    if (l.parentID == FZ_BADPARENT)
                    {
                        nextSegment = true;
                    }
                    else
                    {
                        return l.lowerBound;
                    }
                }
            }

            return FZ_OUTBOUNDS;
        }
    }
}
