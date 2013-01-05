using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StarSystemGurpsGen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StarSystemGurpsGen());
        }

        public static void generateAStar(Star tempStar, Dice ourDice, decimal maxMass, bool forceGarden, bool forceHighMass)
        {

            decimal mass = 0.0m;

            if (maxMass != 0.1m)
            {
                do
                {
                    int rollA = ourDice.gurpsRoll();
                    int rollB = ourDice.gurpsRoll();

                    if (forceGarden)
                    {
                        rollA = ourDice.six();
                        if (rollA == 1) rollA = 5;
                        if (rollA == 2) rollA = 6;
                        if (rollA == 3 || rollA == 4) rollA = 7;
                        if (rollA == 5 || rollA == 6) rollA = 8;
                    }

                    if (forceHighMass){
                        rollA = ourDice.anySize(5) + 2;
                    }

                    tempStar.updateMass(Star.stellarMass(rollA, rollB)); //set the mass
                    mass = tempStar.mass;
                    tempStar.setInitMass(mass);
                    mass = tempStar.mass;
                } while (mass > maxMass);
            }
            if (maxMass == 0.1m){
                tempStar.updateMass(.1m);
                mass = .1m;
            }

            tempStar.updateStar(mass, ourDice);

        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 54, 372, 20);
            buttonOk.SetBounds(228, 90, 75, 23);
            buttonCancel.SetBounds(309, 90, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 125);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
