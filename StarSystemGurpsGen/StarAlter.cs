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
    public partial class StarAlter : Form
    {
        public StarSystem ourSystem { get; set; }
        public int starID { get; set; }

        public StarAlter(int id, StarSystem o)
        {
            InitializeComponent();
            this.starID = id;
            ourSystem = o;
        }

        private void StarAlter_Load(object sender, EventArgs e)
        {

        }
    }
}
