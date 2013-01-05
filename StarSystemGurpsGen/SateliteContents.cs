using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSystemGurpsGen
{
    class SateliteContents 
    {
        public List<Satelite> members { get; set; }

        public SateliteContents(){
            members = new List<Satelite>();
        }

        public void Add(Satelite s)
        {
            members.Add(s);
        }

        public void purgeSwallowedOrbits(decimal radius){
            members.RemoveAll(orbital => orbital.orbitalRadius <= radius);
            //listRemoveCLR.FastRemoveAll(members, orbital => orbital.orbitalRadius <= radius);
        }


        public void sortByRadius(){
            Satelite curItem;
            int itemHole;

            for (int i = 1; i < this.members.Count - 1; i++){
                curItem = this.members[i];
                itemHole = i;
                while (itemHole > 0 && this.members[itemHole - 1].orbitalRadius > curItem.orbitalRadius){
                    members[itemHole] = members[itemHole - 1];
                    itemHole = itemHole - 1;
                }

                members[itemHole] = curItem;
            }
            //this.ourPlanets.Sort((x, y) => x.orbitalRadius.CompareTo(y.orbitalRadius));

        }
    }
}
