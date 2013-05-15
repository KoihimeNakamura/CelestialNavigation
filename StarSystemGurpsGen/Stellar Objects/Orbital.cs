using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemGurpsGen
{
    /// <summary>
    ///  This is the base class to everything that occupies a potential Orbital. Stars, Satellites, Moonlets.
    /// </summary>
   public class Orbital
    {
        /// <summary>
        ///  This contains the number of kilometers in an AU (distance of Earth to the Sun), or
        ///  149,597,871 km = 1 AU
        /// </summary>
        public static long AUtoKM = 149597871;

        //orbital details
        /// <summary>
        /// ID of the body anything in this orbital orbits (may be Star or Satellite)
        /// </summary>
        public int parentID { get; set; }
 
        /// <summary>
        ///  Used to track where this is. 
        ///  <remarks> In a Star, this will be [Primary, Secondary, etc.]; in a Satelite, it'll just be an integer
        ///  </remarks>
        /// </summary>
        public int selfID { get; set; } 

        /// <summary>
        /// the radius of the orbit around the parent body
        /// </summary>
        public double orbitalRadius { get; set; } 

        /// <summary>
        /// the eccentricity of the orbit (i.e difference from a perfect circle.)
        /// </summary>
        public double orbitalEccent { get; set; } 
        
        /// <summary>
        /// Blackbody temperature of this object, although in Star this is left unset.
        /// </summary>
        public double blackbodyTemp { get; set; } 

        /// <summary>
        /// time it takes to revolve around a parent object
        /// </summary>
        public double orbitalPeriod { get; set; } 

        /// <summary>
        ///  The object's name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The parent of this object's name. Used in display mostly.
        /// </summary>
        public string parentName { get; set; }

        /// <summary>
        ///  Constructor for an Orbital. Assumes both elements are 0, and is used so it can be initalized by itself, 
        ///  although that will probably never happen now.
        /// </summary>
        public Orbital(){
            this.parentID = 0;
            this.selfID = 0;
        }

        /// <summary>
        ///   Constructor, given a parent ID and self ID
        /// </summary>
        /// <param name="parent">ID of the parent object</param>
        /// <param name="self">ID of the object</param>
        public Orbital(int parent, int self)  {
            this.parentID = parent;
            this.selfID = self;
        }
       
        /// <summary>
        ///  Constructor, given a parent ID, self ID and radius of the object
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="self"></param>
        /// <param name="radius">Orbital Radius of the object.</param>
        public Orbital(int parent, int self, double radius){
            this.orbitalRadius = radius;
            this.selfID = self;
            this.parentID = parent;

        }
     
        /// <summary>
        ///  Gets the periapsis, now a static function because I need to access it outside of it's object. 
        ///  The periapsis is the CLOSEST approach to a star
        /// </summary>
        /// <param name="eccent">(double) The eccentricity of an orbit</param>
        /// <param name="radius">(double) The radius of an object</param>
        /// <returns>Returns the closest approach (is a double)</returns>
        public static double getPeriapsis(double eccent, double radius)
        {
            return ((1 - eccent) * radius);
        }

        /// <summary>
        /// Calculates the apapasis (furthest approach) of an object around it's parent. 
        /// </summary>
        /// <param name="eccent">(double) The eccentricity of an orbit</param>
        /// <param name="radius">(double) The radius of an object</param>
        /// <returns></returns>
        public static double getApapsis(double eccent, double radius){
            return ((1 + eccent) * radius);
        }

        /// <summary>
        /// Returns a summarization of what it is.
        /// </summary>
        /// <returns>a string describing the object.</returns>
        public override string ToString()
        {
            String myStr = this.name  + " : Orbital at " + orbitalRadius.ToString() + "AU ";
            return myStr;
        }
        /// <summary>
        ///  Creates a generic name, although this is mainly here so people will override it. 
        ///  But something will always generate a name.
        /// </summary>
        public virtual void genGenericName(){
            this.name = "Orbital " + this.selfID;
        }
    }
}
