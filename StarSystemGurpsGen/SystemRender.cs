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
    public partial class SystemRender : Form
    {
        /// <summary>
        /// This is the system we will be rendering.
        /// </summary>
        protected StarSystem targetScan;

        /// <summary>
        /// The canvas we draw on
        /// </summary>
        protected Graphics ourCanvas;

        public SystemRender(StarSystem s)
        {
            this.targetScan = s;
            InitializeComponent();

        }

        private void SystemRender_Paint(object sender, PaintEventArgs e)
        {

          //create our objects.
          ourCanvas = this.CreateGraphics();
          SolidBrush solidColorBrush = new SolidBrush( Color.White );
          Pen myPen = new Pen( solidColorBrush );
          
          Point center = new Point((int)Math.Floor((double)this.Size.Width/2), (int)Math.Floor((double)this.Size.Height/2));


        }

    }
}
