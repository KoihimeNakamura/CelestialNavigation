using System;
using System.IO;
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
    public partial class OutputWindow : Form
    {
        private string sysName { get; set; }
        public OutputWindow(string ourSystem, string sysName)
        {
            InitializeComponent();
            txtOutput.Text = ourSystem;
            this.sysName = sysName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save System Details";
            //saveFileDialog1.InitialDirectory = sOutputFolder;
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = this.sysName + ".txt";

            //use a if here to see if the user actually click save button.
            //if DialogResult.OK means the user actually click save button.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //do something here using the filename
                string filename = saveFileDialog1.FileName;

                //now we open it!
                TextWriter fileOutput = new StreamWriter(filename);

                fileOutput.WriteLine(txtOutput.Text);

                fileOutput.Close();

            }
        }
    }
}
