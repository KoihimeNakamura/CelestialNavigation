namespace StarSystemGurpsGen
{
    partial class CreateStars
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSystem = new System.Windows.Forms.Panel();
            this.lblAgeYear = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.chkAgeOverride = new System.Windows.Forms.CheckBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.chkOpenCluster = new System.Windows.Forms.CheckBox();
            this.chkForceGarden = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAnyFlareStar = new System.Windows.Forms.CheckBox();
            this.chkMoreFlare = new System.Windows.Forms.CheckBox();
            this.chkFantasyColors = new System.Windows.Forms.CheckBox();
            this.numMaxMass = new System.Windows.Forms.NumericUpDown();
            this.lblMassB = new System.Windows.Forms.Label();
            this.lblMass = new System.Windows.Forms.Label();
            this.numMinMass = new System.Windows.Forms.NumericUpDown();
            this.chkStellarMass = new System.Windows.Forms.CheckBox();
            this.chkExtLowStellar = new System.Windows.Forms.CheckBox();
            this.chkLesserEccentricity = new System.Windows.Forms.CheckBox();
            this.chkStarOverride = new System.Windows.Forms.CheckBox();
            this.numStars = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenStars = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSysName = new System.Windows.Forms.TextBox();
            this.btnRandomName = new System.Windows.Forms.Button();
            this.chkBypassRules = new System.Windows.Forms.CheckBox();
            this.pnlSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStars)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please set options for your star generation phase! (Includes some system settings" +
    ".)";
            // 
            // pnlSystem
            // 
            this.pnlSystem.Controls.Add(this.lblAgeYear);
            this.pnlSystem.Controls.Add(this.numAge);
            this.pnlSystem.Controls.Add(this.chkAgeOverride);
            this.pnlSystem.Controls.Add(this.chkVerbose);
            this.pnlSystem.Controls.Add(this.chkOpenCluster);
            this.pnlSystem.Controls.Add(this.chkForceGarden);
            this.pnlSystem.Controls.Add(this.label2);
            this.pnlSystem.Location = new System.Drawing.Point(12, 40);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Size = new System.Drawing.Size(270, 155);
            this.pnlSystem.TabIndex = 1;
            // 
            // lblAgeYear
            // 
            this.lblAgeYear.AutoSize = true;
            this.lblAgeYear.Location = new System.Drawing.Point(223, 103);
            this.lblAgeYear.Name = "lblAgeYear";
            this.lblAgeYear.Size = new System.Drawing.Size(23, 13);
            this.lblAgeYear.TabIndex = 6;
            this.lblAgeYear.Text = "Gyr";
            // 
            // numAge
            // 
            this.numAge.DecimalPlaces = 2;
            this.numAge.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numAge.Location = new System.Drawing.Point(163, 99);
            this.numAge.Maximum = new decimal(new int[] {
            138,
            0,
            0,
            65536});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(53, 20);
            this.numAge.TabIndex = 5;
            this.numAge.Visible = false;
            // 
            // chkAgeOverride
            // 
            this.chkAgeOverride.AutoSize = true;
            this.chkAgeOverride.Location = new System.Drawing.Point(14, 101);
            this.chkAgeOverride.Name = "chkAgeOverride";
            this.chkAgeOverride.Size = new System.Drawing.Size(143, 17);
            this.chkAgeOverride.TabIndex = 4;
            this.chkAgeOverride.Text = "Override Age Generation";
            this.chkAgeOverride.UseVisualStyleBackColor = true;
            this.chkAgeOverride.CheckedChanged += new System.EventHandler(this.chkAgeOverride_CheckedChanged);
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(14, 76);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(100, 17);
            this.chkVerbose.TabIndex = 3;
            this.chkVerbose.Text = "Verbose Output";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // chkOpenCluster
            // 
            this.chkOpenCluster.AutoSize = true;
            this.chkOpenCluster.Location = new System.Drawing.Point(14, 51);
            this.chkOpenCluster.Name = "chkOpenCluster";
            this.chkOpenCluster.Size = new System.Drawing.Size(216, 17);
            this.chkOpenCluster.TabIndex = 2;
            this.chkOpenCluster.Text = "Is this system in an Open Stellar Cluster?";
            this.chkOpenCluster.UseVisualStyleBackColor = true;
            // 
            // chkForceGarden
            // 
            this.chkForceGarden.AutoSize = true;
            this.chkForceGarden.Location = new System.Drawing.Point(14, 26);
            this.chkForceGarden.Name = "chkForceGarden";
            this.chkForceGarden.Size = new System.Drawing.Size(248, 17);
            this.chkForceGarden.TabIndex = 1;
            this.chkForceGarden.Text = "Force Favorable Conditions for a Garden World";
            this.chkForceGarden.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "System Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkBypassRules);
            this.panel1.Controls.Add(this.chkAnyFlareStar);
            this.panel1.Controls.Add(this.chkMoreFlare);
            this.panel1.Controls.Add(this.chkFantasyColors);
            this.panel1.Controls.Add(this.numMaxMass);
            this.panel1.Controls.Add(this.lblMassB);
            this.panel1.Controls.Add(this.lblMass);
            this.panel1.Controls.Add(this.numMinMass);
            this.panel1.Controls.Add(this.chkStellarMass);
            this.panel1.Controls.Add(this.chkExtLowStellar);
            this.panel1.Controls.Add(this.chkLesserEccentricity);
            this.panel1.Controls.Add(this.chkStarOverride);
            this.panel1.Controls.Add(this.numStars);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(304, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 261);
            this.panel1.TabIndex = 2;
            // 
            // chkAnyFlareStar
            // 
            this.chkAnyFlareStar.AutoSize = true;
            this.chkAnyFlareStar.Location = new System.Drawing.Point(15, 235);
            this.chkAnyFlareStar.Name = "chkAnyFlareStar";
            this.chkAnyFlareStar.Size = new System.Drawing.Size(162, 17);
            this.chkAnyFlareStar.TabIndex = 23;
            this.chkAnyFlareStar.Text = "Any Star Can Be A Flare Star";
            this.chkAnyFlareStar.UseVisualStyleBackColor = true;
            // 
            // chkMoreFlare
            // 
            this.chkMoreFlare.AutoSize = true;
            this.chkMoreFlare.Location = new System.Drawing.Point(15, 210);
            this.chkMoreFlare.Name = "chkMoreFlare";
            this.chkMoreFlare.Size = new System.Drawing.Size(103, 17);
            this.chkMoreFlare.TabIndex = 22;
            this.chkMoreFlare.Text = "More Flare Stars";
            this.chkMoreFlare.UseVisualStyleBackColor = true;
            // 
            // chkFantasyColors
            // 
            this.chkFantasyColors.AutoSize = true;
            this.chkFantasyColors.Location = new System.Drawing.Point(15, 184);
            this.chkFantasyColors.Name = "chkFantasyColors";
            this.chkFantasyColors.Size = new System.Drawing.Size(124, 17);
            this.chkFantasyColors.TabIndex = 21;
            this.chkFantasyColors.Text = "Apply Fantasy Colors";
            this.chkFantasyColors.UseVisualStyleBackColor = true;
            // 
            // numMaxMass
            // 
            this.numMaxMass.DecimalPlaces = 2;
            this.numMaxMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMaxMass.Location = new System.Drawing.Point(137, 152);
            this.numMaxMass.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxMass.Name = "numMaxMass";
            this.numMaxMass.Size = new System.Drawing.Size(54, 20);
            this.numMaxMass.TabIndex = 20;
            this.numMaxMass.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxMass.Visible = false;
            // 
            // lblMassB
            // 
            this.lblMassB.AutoSize = true;
            this.lblMassB.Location = new System.Drawing.Point(115, 154);
            this.lblMassB.Name = "lblMassB";
            this.lblMassB.Size = new System.Drawing.Size(16, 13);
            this.lblMassB.TabIndex = 19;
            this.lblMassB.Text = "to";
            this.lblMassB.Visible = false;
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(15, 153);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(39, 13);
            this.lblMass.TabIndex = 18;
            this.lblMass.Text = "Range";
            this.lblMass.Visible = false;
            // 
            // numMinMass
            // 
            this.numMinMass.DecimalPlaces = 2;
            this.numMinMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMinMass.Location = new System.Drawing.Point(60, 152);
            this.numMinMass.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinMass.Name = "numMinMass";
            this.numMinMass.Size = new System.Drawing.Size(46, 20);
            this.numMinMass.TabIndex = 17;
            this.numMinMass.Visible = false;
            // 
            // chkStellarMass
            // 
            this.chkStellarMass.AutoSize = true;
            this.chkStellarMass.Location = new System.Drawing.Point(15, 126);
            this.chkStellarMass.Name = "chkStellarMass";
            this.chkStellarMass.Size = new System.Drawing.Size(181, 17);
            this.chkStellarMass.TabIndex = 16;
            this.chkStellarMass.Text = "Override Stellar Mass Generation";
            this.chkStellarMass.UseVisualStyleBackColor = true;
            this.chkStellarMass.CheckedChanged += new System.EventHandler(this.chkStellarMass_CheckedChanged);
            // 
            // chkExtLowStellar
            // 
            this.chkExtLowStellar.AutoSize = true;
            this.chkExtLowStellar.Location = new System.Drawing.Point(15, 101);
            this.chkExtLowStellar.Name = "chkExtLowStellar";
            this.chkExtLowStellar.Size = new System.Drawing.Size(182, 17);
            this.chkExtLowStellar.TabIndex = 15;
            this.chkExtLowStellar.Text = "Extremely Low Stellar Eccentricty";
            this.chkExtLowStellar.UseVisualStyleBackColor = true;
            // 
            // chkLesserEccentricity
            // 
            this.chkLesserEccentricity.AutoSize = true;
            this.chkLesserEccentricity.Location = new System.Drawing.Point(15, 76);
            this.chkLesserEccentricity.Name = "chkLesserEccentricity";
            this.chkLesserEccentricity.Size = new System.Drawing.Size(192, 17);
            this.chkLesserEccentricity.TabIndex = 14;
            this.chkLesserEccentricity.Text = "Lower Maximum Stellar Eccentricity";
            this.chkLesserEccentricity.UseVisualStyleBackColor = true;
            // 
            // chkStarOverride
            // 
            this.chkStarOverride.AutoSize = true;
            this.chkStarOverride.Location = new System.Drawing.Point(15, 27);
            this.chkStarOverride.Name = "chkStarOverride";
            this.chkStarOverride.Size = new System.Drawing.Size(110, 17);
            this.chkStarOverride.TabIndex = 13;
            this.chkStarOverride.Text = "Specify # of Stars";
            this.chkStarOverride.UseVisualStyleBackColor = true;
            this.chkStarOverride.CheckedChanged += new System.EventHandler(this.numStarOverride_CheckedChanged);
            // 
            // numStars
            // 
            this.numStars.Location = new System.Drawing.Point(131, 23);
            this.numStars.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numStars.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStars.Name = "numStars";
            this.numStars.Size = new System.Drawing.Size(39, 20);
            this.numStars.TabIndex = 11;
            this.numStars.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStars.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stellar Generation Options";
            // 
            // btnGenStars
            // 
            this.btnGenStars.Location = new System.Drawing.Point(238, 317);
            this.btnGenStars.Name = "btnGenStars";
            this.btnGenStars.Size = new System.Drawing.Size(120, 28);
            this.btnGenStars.TabIndex = 3;
            this.btnGenStars.Text = "Generate Stars";
            this.btnGenStars.UseVisualStyleBackColor = true;
            this.btnGenStars.Click += new System.EventHandler(this.btnGenStars_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "System Name:";
            // 
            // txtSysName
            // 
            this.txtSysName.Location = new System.Drawing.Point(92, 201);
            this.txtSysName.Name = "txtSysName";
            this.txtSysName.Size = new System.Drawing.Size(124, 20);
            this.txtSysName.TabIndex = 5;
            // 
            // btnRandomName
            // 
            this.btnRandomName.Location = new System.Drawing.Point(227, 202);
            this.btnRandomName.Name = "btnRandomName";
            this.btnRandomName.Size = new System.Drawing.Size(57, 23);
            this.btnRandomName.TabIndex = 6;
            this.btnRandomName.Text = "Random";
            this.btnRandomName.UseVisualStyleBackColor = true;
            this.btnRandomName.Click += new System.EventHandler(this.btnRandomName_Click);
            // 
            // chkBypassRules
            // 
            this.chkBypassRules.AutoSize = true;
            this.chkBypassRules.Location = new System.Drawing.Point(15, 50);
            this.chkBypassRules.Name = "chkBypassRules";
            this.chkBypassRules.Size = new System.Drawing.Size(184, 17);
            this.chkBypassRules.TabIndex = 24;
            this.chkBypassRules.Text = "Roll secondary star mass on table";
            this.chkBypassRules.UseVisualStyleBackColor = true;
            // 
            // CreateStars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 357);
            this.Controls.Add(this.btnRandomName);
            this.Controls.Add(this.txtSysName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenStars);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSystem);
            this.Controls.Add(this.label1);
            this.Name = "CreateStars";
            this.Text = "Dialog: Create Stars";
            this.pnlSystem.ResumeLayout(false);
            this.pnlSystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSystem;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.CheckBox chkOpenCluster;
        private System.Windows.Forms.CheckBox chkForceGarden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkStarOverride;
        private System.Windows.Forms.NumericUpDown numStars;
        private System.Windows.Forms.CheckBox chkExtLowStellar;
        private System.Windows.Forms.CheckBox chkLesserEccentricity;
        private System.Windows.Forms.CheckBox chkAgeOverride;
        private System.Windows.Forms.Label lblAgeYear;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.NumericUpDown numMaxMass;
        private System.Windows.Forms.Label lblMassB;
        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.NumericUpDown numMinMass;
        private System.Windows.Forms.CheckBox chkStellarMass;
        private System.Windows.Forms.CheckBox chkFantasyColors;
        private System.Windows.Forms.CheckBox chkMoreFlare;
        private System.Windows.Forms.CheckBox chkAnyFlareStar;
        private System.Windows.Forms.Button btnGenStars;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSysName;
        private System.Windows.Forms.Button btnRandomName;
        private System.Windows.Forms.CheckBox chkBypassRules;
    }
}