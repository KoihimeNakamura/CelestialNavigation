namespace StarSystemGurpsGen
{
    partial class StarSystemGurpsGen
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sysDetails = new System.Windows.Forms.TabPage();
            this.genOutput = new System.Windows.Forms.Button();
            this.resetALLTHETHINGS = new System.Windows.Forms.Button();
            this.forceHighStarMass = new System.Windows.Forms.CheckBox();
            this.forceGarden = new System.Windows.Forms.CheckBox();
            this.openCluster = new System.Windows.Forms.CheckBox();
            this.sysAge = new System.Windows.Forms.TextBox();
            this.beginStep3 = new System.Windows.Forms.Button();
            this.optLabel = new System.Windows.Forms.Label();
            this.numStars = new System.Windows.Forms.TextBox();
            this.numStarLbl = new System.Windows.Forms.Label();
            this.inpSysName = new System.Windows.Forms.TextBox();
            this.sysNameLbl = new System.Windows.Forms.Label();
            this.gigayear = new System.Windows.Forms.Label();
            this.sysAgeLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.beginStep2 = new System.Windows.Forms.Button();
            this.beginGen = new System.Windows.Forms.Button();
            this.welcome = new System.Windows.Forms.Label();
            this.stars = new System.Windows.Forms.TabPage();
            this.star2SCOrbRad = new System.Windows.Forms.Button();
            this.star1SCOrbRad = new System.Windows.Forms.Button();
            this.star2OrbRad = new System.Windows.Forms.Button();
            this.star1OrbRad = new System.Windows.Forms.Button();
            this.star2SCName = new System.Windows.Forms.Button();
            this.star1SCName = new System.Windows.Forms.Button();
            this.star2Name = new System.Windows.Forms.Button();
            this.star1Name = new System.Windows.Forms.Button();
            this.star0Name = new System.Windows.Forms.Button();
            this.star2SCTemp = new System.Windows.Forms.Button();
            this.star2SCLumin = new System.Windows.Forms.Button();
            this.star2SCMass = new System.Windows.Forms.Button();
            this.star2SCPropLbl = new System.Windows.Forms.Label();
            this.star1SCTemp = new System.Windows.Forms.Button();
            this.star1SCLumin = new System.Windows.Forms.Button();
            this.star1SCMass = new System.Windows.Forms.Button();
            this.star1SCPropLbl = new System.Windows.Forms.Label();
            this.star2Temp = new System.Windows.Forms.Button();
            this.star2Lumin = new System.Windows.Forms.Button();
            this.star2Mass = new System.Windows.Forms.Button();
            this.star2PropLbl = new System.Windows.Forms.Label();
            this.star1Temp = new System.Windows.Forms.Button();
            this.star1Lumin = new System.Windows.Forms.Button();
            this.star1Mass = new System.Windows.Forms.Button();
            this.star1PropLbl = new System.Windows.Forms.Label();
            this.star0Temp = new System.Windows.Forms.Button();
            this.star0Lumin = new System.Windows.Forms.Button();
            this.star0Mass = new System.Windows.Forms.Button();
            this.star0PropLbl = new System.Windows.Forms.Label();
            this.starOutput = new System.Windows.Forms.TextBox();
            this.Planets = new System.Windows.Forms.TabPage();
            this.output = new System.Windows.Forms.TabPage();
            this.saveBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.preOutputLbl = new System.Windows.Forms.Label();
            this.chgNotes = new System.Windows.Forms.TabPage();
            this.sysAgeTT = new System.Windows.Forms.ToolTip(this.components);
            this.planetGrid = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.sysDetails.SuspendLayout();
            this.stars.SuspendLayout();
            this.Planets.SuspendLayout();
            this.output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planetGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sysDetails);
            this.tabControl1.Controls.Add(this.stars);
            this.tabControl1.Controls.Add(this.Planets);
            this.tabControl1.Controls.Add(this.output);
            this.tabControl1.Controls.Add(this.chgNotes);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 549);
            this.tabControl1.TabIndex = 0;
            // 
            // sysDetails
            // 
            this.sysDetails.Controls.Add(this.genOutput);
            this.sysDetails.Controls.Add(this.resetALLTHETHINGS);
            this.sysDetails.Controls.Add(this.forceHighStarMass);
            this.sysDetails.Controls.Add(this.forceGarden);
            this.sysDetails.Controls.Add(this.openCluster);
            this.sysDetails.Controls.Add(this.sysAge);
            this.sysDetails.Controls.Add(this.beginStep3);
            this.sysDetails.Controls.Add(this.optLabel);
            this.sysDetails.Controls.Add(this.numStars);
            this.sysDetails.Controls.Add(this.numStarLbl);
            this.sysDetails.Controls.Add(this.inpSysName);
            this.sysDetails.Controls.Add(this.sysNameLbl);
            this.sysDetails.Controls.Add(this.gigayear);
            this.sysDetails.Controls.Add(this.sysAgeLabel);
            this.sysDetails.Controls.Add(this.noteLabel);
            this.sysDetails.Controls.Add(this.beginStep2);
            this.sysDetails.Controls.Add(this.beginGen);
            this.sysDetails.Controls.Add(this.welcome);
            this.sysDetails.Location = new System.Drawing.Point(4, 22);
            this.sysDetails.Name = "sysDetails";
            this.sysDetails.Size = new System.Drawing.Size(849, 523);
            this.sysDetails.TabIndex = 4;
            this.sysDetails.Text = "System Details";
            this.sysDetails.UseVisualStyleBackColor = true;
            // 
            // genOutput
            // 
            this.genOutput.Location = new System.Drawing.Point(673, 164);
            this.genOutput.Name = "genOutput";
            this.genOutput.Size = new System.Drawing.Size(163, 38);
            this.genOutput.TabIndex = 22;
            this.genOutput.Text = "Step 4 - Output";
            this.genOutput.UseVisualStyleBackColor = true;
            this.genOutput.Visible = false;
            // 
            // resetALLTHETHINGS
            // 
            this.resetALLTHETHINGS.Location = new System.Drawing.Point(675, 208);
            this.resetALLTHETHINGS.Name = "resetALLTHETHINGS";
            this.resetALLTHETHINGS.Size = new System.Drawing.Size(164, 33);
            this.resetALLTHETHINGS.TabIndex = 21;
            this.resetALLTHETHINGS.Text = "Reset For Fresh Gen";
            this.resetALLTHETHINGS.UseVisualStyleBackColor = true;
            this.resetALLTHETHINGS.Click += new System.EventHandler(this.resetALLTHETHINGS_Click);
            // 
            // forceHighStarMass
            // 
            this.forceHighStarMass.AutoSize = true;
            this.forceHighStarMass.Location = new System.Drawing.Point(31, 336);
            this.forceHighStarMass.Name = "forceHighStarMass";
            this.forceHighStarMass.Size = new System.Drawing.Size(523, 17);
            this.forceHighStarMass.TabIndex = 20;
            this.forceHighStarMass.Text = "[STEP 1,2] Force star masses of at least .85 solar masses? (WARNING: This applies" +
    " for the first two stars)";
            this.forceHighStarMass.UseVisualStyleBackColor = true;
            // 
            // forceGarden
            // 
            this.forceGarden.AutoSize = true;
            this.forceGarden.Location = new System.Drawing.Point(31, 313);
            this.forceGarden.Name = "forceGarden";
            this.forceGarden.Size = new System.Drawing.Size(294, 17);
            this.forceGarden.TabIndex = 18;
            this.forceGarden.Text = "[STEP 2,3] Force optimal conditions for a Garden World?";
            this.forceGarden.UseVisualStyleBackColor = true;
            // 
            // openCluster
            // 
            this.openCluster.AutoSize = true;
            this.openCluster.Location = new System.Drawing.Point(31, 292);
            this.openCluster.Name = "openCluster";
            this.openCluster.Size = new System.Drawing.Size(262, 17);
            this.openCluster.TabIndex = 17;
            this.openCluster.Text = "[STEP1] Is this system located in an open cluster?";
            this.openCluster.UseVisualStyleBackColor = true;
            // 
            // sysAge
            // 
            this.sysAge.Location = new System.Drawing.Point(113, 149);
            this.sysAge.Name = "sysAge";
            this.sysAge.Size = new System.Drawing.Size(60, 20);
            this.sysAge.TabIndex = 16;
            this.sysAge.TextChanged += new System.EventHandler(this.sysAge_TextChanged);
            this.sysAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sysAge_KeyDown);
            // 
            // beginStep3
            // 
            this.beginStep3.Enabled = false;
            this.beginStep3.Location = new System.Drawing.Point(673, 116);
            this.beginStep3.Name = "beginStep3";
            this.beginStep3.Size = new System.Drawing.Size(165, 42);
            this.beginStep3.TabIndex = 15;
            this.beginStep3.Text = "Star 3 - Begin Planetary Gen";
            this.beginStep3.UseVisualStyleBackColor = true;
            this.beginStep3.Click += new System.EventHandler(this.beginStep3_Click);
            // 
            // optLabel
            // 
            this.optLabel.AutoSize = true;
            this.optLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLabel.Location = new System.Drawing.Point(21, 264);
            this.optLabel.Name = "optLabel";
            this.optLabel.Size = new System.Drawing.Size(93, 25);
            this.optLabel.TabIndex = 12;
            this.optLabel.Text = "Options";
            // 
            // numStars
            // 
            this.numStars.Location = new System.Drawing.Point(130, 179);
            this.numStars.Name = "numStars";
            this.numStars.Size = new System.Drawing.Size(84, 20);
            this.numStars.TabIndex = 11;
            this.numStars.TextChanged += new System.EventHandler(this.numStars_TextChanged);
            // 
            // numStarLbl
            // 
            this.numStarLbl.AutoSize = true;
            this.numStarLbl.Location = new System.Drawing.Point(28, 180);
            this.numStarLbl.Name = "numStarLbl";
            this.numStarLbl.Size = new System.Drawing.Size(90, 13);
            this.numStarLbl.TabIndex = 10;
            this.numStarLbl.Text = "# of Primary Stars";
            // 
            // inpSysName
            // 
            this.inpSysName.Location = new System.Drawing.Point(113, 117);
            this.inpSysName.Name = "inpSysName";
            this.inpSysName.Size = new System.Drawing.Size(102, 20);
            this.inpSysName.TabIndex = 9;
            this.inpSysName.Text = "DEFAULT";
            // 
            // sysNameLbl
            // 
            this.sysNameLbl.AutoSize = true;
            this.sysNameLbl.Location = new System.Drawing.Point(23, 124);
            this.sysNameLbl.Name = "sysNameLbl";
            this.sysNameLbl.Size = new System.Drawing.Size(72, 13);
            this.sysNameLbl.TabIndex = 8;
            this.sysNameLbl.Text = "System Name";
            // 
            // gigayear
            // 
            this.gigayear.AutoSize = true;
            this.gigayear.Location = new System.Drawing.Point(180, 145);
            this.gigayear.Name = "gigayear";
            this.gigayear.Size = new System.Drawing.Size(25, 13);
            this.gigayear.TabIndex = 7;
            this.gigayear.Text = "GYr";
            // 
            // sysAgeLabel
            // 
            this.sysAgeLabel.AutoSize = true;
            this.sysAgeLabel.Location = new System.Drawing.Point(26, 152);
            this.sysAgeLabel.Name = "sysAgeLabel";
            this.sysAgeLabel.Size = new System.Drawing.Size(63, 13);
            this.sysAgeLabel.TabIndex = 4;
            this.sysAgeLabel.Text = "System Age";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(23, 44);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(566, 13);
            this.noteLabel.TabIndex = 3;
            this.noteLabel.Text = "Some notes: Once you click Step 3, all star details are locked in, and can no lon" +
    "ger be edited. Please keep this in mind";
            // 
            // beginStep2
            // 
            this.beginStep2.Enabled = false;
            this.beginStep2.Location = new System.Drawing.Point(674, 63);
            this.beginStep2.Name = "beginStep2";
            this.beginStep2.Size = new System.Drawing.Size(165, 42);
            this.beginStep2.TabIndex = 2;
            this.beginStep2.Text = "Step 2 - Begin Star Gen";
            this.beginStep2.UseVisualStyleBackColor = true;
            this.beginStep2.Click += new System.EventHandler(this.genPlanets_Click);
            // 
            // beginGen
            // 
            this.beginGen.Location = new System.Drawing.Point(673, 15);
            this.beginGen.Name = "beginGen";
            this.beginGen.Size = new System.Drawing.Size(166, 42);
            this.beginGen.TabIndex = 1;
            this.beginGen.Text = "Begin Generation";
            this.beginGen.UseVisualStyleBackColor = true;
            this.beginGen.Click += new System.EventHandler(this.beginGen_Click);
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Location = new System.Drawing.Point(23, 15);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(307, 13);
            this.welcome.TabIndex = 0;
            this.welcome.Text = "Welcome to the GURPS 4th ed Space Solar System Generator!";
            // 
            // stars
            // 
            this.stars.Controls.Add(this.star2SCOrbRad);
            this.stars.Controls.Add(this.star1SCOrbRad);
            this.stars.Controls.Add(this.star2OrbRad);
            this.stars.Controls.Add(this.star1OrbRad);
            this.stars.Controls.Add(this.star2SCName);
            this.stars.Controls.Add(this.star1SCName);
            this.stars.Controls.Add(this.star2Name);
            this.stars.Controls.Add(this.star1Name);
            this.stars.Controls.Add(this.star0Name);
            this.stars.Controls.Add(this.star2SCTemp);
            this.stars.Controls.Add(this.star2SCLumin);
            this.stars.Controls.Add(this.star2SCMass);
            this.stars.Controls.Add(this.star2SCPropLbl);
            this.stars.Controls.Add(this.star1SCTemp);
            this.stars.Controls.Add(this.star1SCLumin);
            this.stars.Controls.Add(this.star1SCMass);
            this.stars.Controls.Add(this.star1SCPropLbl);
            this.stars.Controls.Add(this.star2Temp);
            this.stars.Controls.Add(this.star2Lumin);
            this.stars.Controls.Add(this.star2Mass);
            this.stars.Controls.Add(this.star2PropLbl);
            this.stars.Controls.Add(this.star1Temp);
            this.stars.Controls.Add(this.star1Lumin);
            this.stars.Controls.Add(this.star1Mass);
            this.stars.Controls.Add(this.star1PropLbl);
            this.stars.Controls.Add(this.star0Temp);
            this.stars.Controls.Add(this.star0Lumin);
            this.stars.Controls.Add(this.star0Mass);
            this.stars.Controls.Add(this.star0PropLbl);
            this.stars.Controls.Add(this.starOutput);
            this.stars.Location = new System.Drawing.Point(4, 22);
            this.stars.Name = "stars";
            this.stars.Padding = new System.Windows.Forms.Padding(3);
            this.stars.Size = new System.Drawing.Size(849, 523);
            this.stars.TabIndex = 0;
            this.stars.Text = "Stars";
            this.stars.UseVisualStyleBackColor = true;
            // 
            // star2SCOrbRad
            // 
            this.star2SCOrbRad.Location = new System.Drawing.Point(667, 494);
            this.star2SCOrbRad.Name = "star2SCOrbRad";
            this.star2SCOrbRad.Size = new System.Drawing.Size(178, 25);
            this.star2SCOrbRad.TabIndex = 29;
            this.star2SCOrbRad.Text = "Change Orbital Radius";
            this.star2SCOrbRad.UseVisualStyleBackColor = true;
            this.star2SCOrbRad.Visible = false;
            this.star2SCOrbRad.Click += new System.EventHandler(this.star2SCOrbRad_Click);
            // 
            // star1SCOrbRad
            // 
            this.star1SCOrbRad.Location = new System.Drawing.Point(665, 389);
            this.star1SCOrbRad.Name = "star1SCOrbRad";
            this.star1SCOrbRad.Size = new System.Drawing.Size(178, 25);
            this.star1SCOrbRad.TabIndex = 28;
            this.star1SCOrbRad.Text = "Change Orbital Radius";
            this.star1SCOrbRad.UseVisualStyleBackColor = true;
            this.star1SCOrbRad.Visible = false;
            this.star1SCOrbRad.Click += new System.EventHandler(this.star1SCOrbRad_Click);
            // 
            // star2OrbRad
            // 
            this.star2OrbRad.Location = new System.Drawing.Point(667, 276);
            this.star2OrbRad.Name = "star2OrbRad";
            this.star2OrbRad.Size = new System.Drawing.Size(176, 25);
            this.star2OrbRad.TabIndex = 27;
            this.star2OrbRad.Text = "Change Orbital Radius";
            this.star2OrbRad.UseVisualStyleBackColor = true;
            this.star2OrbRad.Visible = false;
            this.star2OrbRad.Click += new System.EventHandler(this.star2OrbRad_Click);
            // 
            // star1OrbRad
            // 
            this.star1OrbRad.Location = new System.Drawing.Point(669, 169);
            this.star1OrbRad.Name = "star1OrbRad";
            this.star1OrbRad.Size = new System.Drawing.Size(175, 26);
            this.star1OrbRad.TabIndex = 26;
            this.star1OrbRad.Text = "Change Orbital Radius";
            this.star1OrbRad.UseVisualStyleBackColor = true;
            this.star1OrbRad.Visible = false;
            this.star1OrbRad.Click += new System.EventHandler(this.star1OrbRad_Click);
            // 
            // star2SCName
            // 
            this.star2SCName.Location = new System.Drawing.Point(777, 462);
            this.star2SCName.Name = "star2SCName";
            this.star2SCName.Size = new System.Drawing.Size(69, 25);
            this.star2SCName.TabIndex = 25;
            this.star2SCName.Text = "Chg Name";
            this.star2SCName.UseVisualStyleBackColor = true;
            this.star2SCName.Visible = false;
            this.star2SCName.Click += new System.EventHandler(this.star2SCName_Click);
            // 
            // star1SCName
            // 
            this.star1SCName.Location = new System.Drawing.Point(776, 358);
            this.star1SCName.Name = "star1SCName";
            this.star1SCName.Size = new System.Drawing.Size(69, 25);
            this.star1SCName.TabIndex = 24;
            this.star1SCName.Text = "Chg Name";
            this.star1SCName.UseVisualStyleBackColor = true;
            this.star1SCName.Visible = false;
            this.star1SCName.Click += new System.EventHandler(this.star1SCName_Click);
            // 
            // star2Name
            // 
            this.star2Name.Location = new System.Drawing.Point(781, 243);
            this.star2Name.Name = "star2Name";
            this.star2Name.Size = new System.Drawing.Size(69, 25);
            this.star2Name.TabIndex = 23;
            this.star2Name.Text = "Chg Name";
            this.star2Name.UseVisualStyleBackColor = true;
            this.star2Name.Visible = false;
            this.star2Name.Click += new System.EventHandler(this.star2Name_Click);
            // 
            // star1Name
            // 
            this.star1Name.Location = new System.Drawing.Point(782, 138);
            this.star1Name.Name = "star1Name";
            this.star1Name.Size = new System.Drawing.Size(68, 25);
            this.star1Name.TabIndex = 22;
            this.star1Name.Text = "Chg Name";
            this.star1Name.UseVisualStyleBackColor = true;
            this.star1Name.Visible = false;
            this.star1Name.Click += new System.EventHandler(this.star1Name_Click);
            // 
            // star0Name
            // 
            this.star0Name.Location = new System.Drawing.Point(779, 51);
            this.star0Name.Name = "star0Name";
            this.star0Name.Size = new System.Drawing.Size(67, 25);
            this.star0Name.TabIndex = 21;
            this.star0Name.Text = "Chg Name";
            this.star0Name.UseVisualStyleBackColor = true;
            this.star0Name.Click += new System.EventHandler(this.star0Name_Click);
            // 
            // star2SCTemp
            // 
            this.star2SCTemp.Location = new System.Drawing.Point(666, 462);
            this.star2SCTemp.Name = "star2SCTemp";
            this.star2SCTemp.Size = new System.Drawing.Size(110, 26);
            this.star2SCTemp.TabIndex = 20;
            this.star2SCTemp.Text = "Chg Temperature";
            this.star2SCTemp.UseVisualStyleBackColor = true;
            this.star2SCTemp.Visible = false;
            this.star2SCTemp.Click += new System.EventHandler(this.star2SCTemp_Click);
            // 
            // star2SCLumin
            // 
            this.star2SCLumin.Location = new System.Drawing.Point(748, 433);
            this.star2SCLumin.Name = "star2SCLumin";
            this.star2SCLumin.Size = new System.Drawing.Size(99, 23);
            this.star2SCLumin.TabIndex = 19;
            this.star2SCLumin.Text = "Chg Luminosity";
            this.star2SCLumin.UseVisualStyleBackColor = true;
            this.star2SCLumin.Visible = false;
            this.star2SCLumin.Click += new System.EventHandler(this.star2SCLumin_Click);
            // 
            // star2SCMass
            // 
            this.star2SCMass.Location = new System.Drawing.Point(667, 433);
            this.star2SCMass.Name = "star2SCMass";
            this.star2SCMass.Size = new System.Drawing.Size(75, 23);
            this.star2SCMass.TabIndex = 18;
            this.star2SCMass.Text = "Chg Mass";
            this.star2SCMass.UseVisualStyleBackColor = true;
            this.star2SCMass.Visible = false;
            this.star2SCMass.Click += new System.EventHandler(this.star2SCMass_Click);
            // 
            // star2SCPropLbl
            // 
            this.star2SCPropLbl.AutoSize = true;
            this.star2SCPropLbl.Location = new System.Drawing.Point(666, 417);
            this.star2SCPropLbl.Name = "star2SCPropLbl";
            this.star2SCPropLbl.Size = new System.Drawing.Size(159, 13);
            this.star2SCPropLbl.TabIndex = 17;
            this.star2SCPropLbl.Text = "Star 3 Subcompanion Properties";
            this.star2SCPropLbl.Visible = false;
            // 
            // star1SCTemp
            // 
            this.star1SCTemp.Location = new System.Drawing.Point(667, 358);
            this.star1SCTemp.Name = "star1SCTemp";
            this.star1SCTemp.Size = new System.Drawing.Size(106, 26);
            this.star1SCTemp.TabIndex = 16;
            this.star1SCTemp.Text = "Chg Temperature";
            this.star1SCTemp.UseVisualStyleBackColor = true;
            this.star1SCTemp.Visible = false;
            this.star1SCTemp.Click += new System.EventHandler(this.star1SCTemp_Click);
            // 
            // star1SCLumin
            // 
            this.star1SCLumin.Location = new System.Drawing.Point(738, 329);
            this.star1SCLumin.Name = "star1SCLumin";
            this.star1SCLumin.Size = new System.Drawing.Size(107, 23);
            this.star1SCLumin.TabIndex = 15;
            this.star1SCLumin.Text = "Chg Luminosity";
            this.star1SCLumin.UseVisualStyleBackColor = true;
            this.star1SCLumin.Visible = false;
            this.star1SCLumin.Click += new System.EventHandler(this.star1SCLumin_Click);
            // 
            // star1SCMass
            // 
            this.star1SCMass.Location = new System.Drawing.Point(665, 329);
            this.star1SCMass.Name = "star1SCMass";
            this.star1SCMass.Size = new System.Drawing.Size(73, 23);
            this.star1SCMass.TabIndex = 14;
            this.star1SCMass.Text = "Chg Mass";
            this.star1SCMass.UseVisualStyleBackColor = true;
            this.star1SCMass.Visible = false;
            this.star1SCMass.Click += new System.EventHandler(this.star1SCMass_Click);
            // 
            // star1SCPropLbl
            // 
            this.star1SCPropLbl.AutoSize = true;
            this.star1SCPropLbl.Location = new System.Drawing.Point(663, 313);
            this.star1SCPropLbl.Name = "star1SCPropLbl";
            this.star1SCPropLbl.Size = new System.Drawing.Size(159, 13);
            this.star1SCPropLbl.TabIndex = 13;
            this.star1SCPropLbl.Text = "Star 2 Subcompanion Properties";
            this.star1SCPropLbl.Visible = false;
            // 
            // star2Temp
            // 
            this.star2Temp.Location = new System.Drawing.Point(666, 243);
            this.star2Temp.Name = "star2Temp";
            this.star2Temp.Size = new System.Drawing.Size(112, 26);
            this.star2Temp.TabIndex = 12;
            this.star2Temp.Text = "Chg Temperature";
            this.star2Temp.UseVisualStyleBackColor = true;
            this.star2Temp.Visible = false;
            this.star2Temp.Click += new System.EventHandler(this.star2Temp_Click);
            // 
            // star2Lumin
            // 
            this.star2Lumin.Location = new System.Drawing.Point(746, 214);
            this.star2Lumin.Name = "star2Lumin";
            this.star2Lumin.Size = new System.Drawing.Size(99, 23);
            this.star2Lumin.TabIndex = 11;
            this.star2Lumin.Text = "Chg Luminosity";
            this.star2Lumin.UseVisualStyleBackColor = true;
            this.star2Lumin.Visible = false;
            this.star2Lumin.Click += new System.EventHandler(this.star2Lumin_Click);
            // 
            // star2Mass
            // 
            this.star2Mass.Location = new System.Drawing.Point(667, 214);
            this.star2Mass.Name = "star2Mass";
            this.star2Mass.Size = new System.Drawing.Size(78, 23);
            this.star2Mass.TabIndex = 10;
            this.star2Mass.Text = "Chg Mass";
            this.star2Mass.UseVisualStyleBackColor = true;
            this.star2Mass.Visible = false;
            this.star2Mass.Click += new System.EventHandler(this.star2Mass_Click);
            // 
            // star2PropLbl
            // 
            this.star2PropLbl.AutoSize = true;
            this.star2PropLbl.Location = new System.Drawing.Point(668, 198);
            this.star2PropLbl.Name = "star2PropLbl";
            this.star2PropLbl.Size = new System.Drawing.Size(85, 13);
            this.star2PropLbl.TabIndex = 9;
            this.star2PropLbl.Text = "Star 3 Properties";
            this.star2PropLbl.Visible = false;
            // 
            // star1Temp
            // 
            this.star1Temp.Location = new System.Drawing.Point(667, 137);
            this.star1Temp.Name = "star1Temp";
            this.star1Temp.Size = new System.Drawing.Size(112, 26);
            this.star1Temp.TabIndex = 8;
            this.star1Temp.Text = "Chg Temperature";
            this.star1Temp.UseVisualStyleBackColor = true;
            this.star1Temp.Visible = false;
            this.star1Temp.Click += new System.EventHandler(this.star1Temp_Click);
            // 
            // star1Lumin
            // 
            this.star1Lumin.Location = new System.Drawing.Point(749, 107);
            this.star1Lumin.Name = "star1Lumin";
            this.star1Lumin.Size = new System.Drawing.Size(99, 23);
            this.star1Lumin.TabIndex = 7;
            this.star1Lumin.Text = "Chg Luminosity";
            this.star1Lumin.UseVisualStyleBackColor = true;
            this.star1Lumin.Visible = false;
            this.star1Lumin.Click += new System.EventHandler(this.star1Lumin_Click);
            // 
            // star1Mass
            // 
            this.star1Mass.Location = new System.Drawing.Point(667, 108);
            this.star1Mass.Name = "star1Mass";
            this.star1Mass.Size = new System.Drawing.Size(77, 23);
            this.star1Mass.TabIndex = 6;
            this.star1Mass.Text = "Chg Mass";
            this.star1Mass.UseVisualStyleBackColor = true;
            this.star1Mass.Visible = false;
            this.star1Mass.Click += new System.EventHandler(this.star1Mass_Click);
            // 
            // star1PropLbl
            // 
            this.star1PropLbl.AutoSize = true;
            this.star1PropLbl.Location = new System.Drawing.Point(664, 91);
            this.star1PropLbl.Name = "star1PropLbl";
            this.star1PropLbl.Size = new System.Drawing.Size(85, 13);
            this.star1PropLbl.TabIndex = 5;
            this.star1PropLbl.Text = "Star 2 Properties";
            this.star1PropLbl.Visible = false;
            // 
            // star0Temp
            // 
            this.star0Temp.Location = new System.Drawing.Point(666, 51);
            this.star0Temp.Name = "star0Temp";
            this.star0Temp.Size = new System.Drawing.Size(112, 26);
            this.star0Temp.TabIndex = 4;
            this.star0Temp.Text = "Chg Temperature";
            this.star0Temp.UseVisualStyleBackColor = true;
            this.star0Temp.Click += new System.EventHandler(this.star0Temp_Click);
            // 
            // star0Lumin
            // 
            this.star0Lumin.Location = new System.Drawing.Point(747, 22);
            this.star0Lumin.Name = "star0Lumin";
            this.star0Lumin.Size = new System.Drawing.Size(99, 23);
            this.star0Lumin.TabIndex = 3;
            this.star0Lumin.Text = "Chg Luminosity";
            this.star0Lumin.UseVisualStyleBackColor = true;
            this.star0Lumin.Click += new System.EventHandler(this.star0Lumin_Click);
            // 
            // star0Mass
            // 
            this.star0Mass.Location = new System.Drawing.Point(666, 23);
            this.star0Mass.Name = "star0Mass";
            this.star0Mass.Size = new System.Drawing.Size(75, 23);
            this.star0Mass.TabIndex = 2;
            this.star0Mass.Text = "Chg Mass";
            this.star0Mass.UseVisualStyleBackColor = true;
            this.star0Mass.Click += new System.EventHandler(this.star0Mass_Click);
            // 
            // star0PropLbl
            // 
            this.star0PropLbl.AutoSize = true;
            this.star0PropLbl.Location = new System.Drawing.Point(668, 6);
            this.star0PropLbl.Name = "star0PropLbl";
            this.star0PropLbl.Size = new System.Drawing.Size(85, 13);
            this.star0PropLbl.TabIndex = 1;
            this.star0PropLbl.Text = "Star 1 Properties";
            // 
            // starOutput
            // 
            this.starOutput.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.starOutput.Dock = System.Windows.Forms.DockStyle.Left;
            this.starOutput.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starOutput.Location = new System.Drawing.Point(3, 3);
            this.starOutput.Multiline = true;
            this.starOutput.Name = "starOutput";
            this.starOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.starOutput.Size = new System.Drawing.Size(658, 517);
            this.starOutput.TabIndex = 0;
            this.starOutput.WordWrap = false;
            // 
            // Planets
            // 
            this.Planets.Controls.Add(this.planetGrid);
            this.Planets.Location = new System.Drawing.Point(4, 22);
            this.Planets.Name = "Planets";
            this.Planets.Size = new System.Drawing.Size(849, 523);
            this.Planets.TabIndex = 2;
            this.Planets.Text = "Planets";
            this.Planets.UseVisualStyleBackColor = true;
            // 
            // output
            // 
            this.output.Controls.Add(this.saveBtn);
            this.output.Controls.Add(this.outputBox);
            this.output.Controls.Add(this.preOutputLbl);
            this.output.Location = new System.Drawing.Point(4, 22);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(849, 523);
            this.output.TabIndex = 3;
            this.output.Text = "Output";
            this.output.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(716, 5);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(126, 29);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save to File";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(5, 40);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(837, 482);
            this.outputBox.TabIndex = 1;
            // 
            // preOutputLbl
            // 
            this.preOutputLbl.AutoSize = true;
            this.preOutputLbl.Location = new System.Drawing.Point(3, 21);
            this.preOutputLbl.Name = "preOutputLbl";
            this.preOutputLbl.Size = new System.Drawing.Size(48, 13);
            this.preOutputLbl.TabIndex = 0;
            this.preOutputLbl.Text = "Preview:";
            // 
            // chgNotes
            // 
            this.chgNotes.Location = new System.Drawing.Point(4, 22);
            this.chgNotes.Name = "chgNotes";
            this.chgNotes.Padding = new System.Windows.Forms.Padding(3);
            this.chgNotes.Size = new System.Drawing.Size(849, 523);
            this.chgNotes.TabIndex = 5;
            this.chgNotes.Text = "Changes and Notes";
            this.chgNotes.UseVisualStyleBackColor = true;
            // 
            // planetGrid
            // 
            this.planetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planetGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.planetGrid.Location = new System.Drawing.Point(0, 0);
            this.planetGrid.Name = "planetGrid";
            this.planetGrid.Size = new System.Drawing.Size(849, 523);
            this.planetGrid.TabIndex = 0;
            // 
            // StarSystemGurpsGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 556);
            this.Controls.Add(this.tabControl1);
            this.Name = "StarSystemGurpsGen";
            this.Text = "GURPS Space 4e Solar System Generator";
            this.Load += new System.EventHandler(this.StarSystemGurpsGen_Load);
            this.tabControl1.ResumeLayout(false);
            this.sysDetails.ResumeLayout(false);
            this.sysDetails.PerformLayout();
            this.stars.ResumeLayout(false);
            this.stars.PerformLayout();
            this.Planets.ResumeLayout(false);
            this.output.ResumeLayout(false);
            this.output.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planetGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage stars;
        private System.Windows.Forms.TabPage Planets;
        private System.Windows.Forms.TabPage output;
        private System.Windows.Forms.TabPage chgNotes;
        private System.Windows.Forms.TabPage sysDetails;
        private System.Windows.Forms.Label gigayear;
        private System.Windows.Forms.Label sysAgeLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button beginStep2;
        private System.Windows.Forms.Button beginGen;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.ToolTip sysAgeTT;
        private System.Windows.Forms.Label sysNameLbl;
        private System.Windows.Forms.TextBox inpSysName;
        private System.Windows.Forms.TextBox numStars;
        private System.Windows.Forms.Label numStarLbl;
        private System.Windows.Forms.Label optLabel;
        private System.Windows.Forms.Button beginStep3;
        private System.Windows.Forms.TextBox starOutput;
        private System.Windows.Forms.Label star0PropLbl;
        private System.Windows.Forms.Button star0Lumin;
        private System.Windows.Forms.Button star0Mass;
        private System.Windows.Forms.Button star2SCTemp;
        private System.Windows.Forms.Button star2SCLumin;
        private System.Windows.Forms.Button star2SCMass;
        private System.Windows.Forms.Label star2SCPropLbl;
        private System.Windows.Forms.Button star1SCTemp;
        private System.Windows.Forms.Button star1SCLumin;
        private System.Windows.Forms.Button star1SCMass;
        private System.Windows.Forms.Label star1SCPropLbl;
        private System.Windows.Forms.Button star2Temp;
        private System.Windows.Forms.Button star2Lumin;
        private System.Windows.Forms.Button star2Mass;
        private System.Windows.Forms.Label star2PropLbl;
        private System.Windows.Forms.Button star1Temp;
        private System.Windows.Forms.Button star1Lumin;
        private System.Windows.Forms.Button star1Mass;
        private System.Windows.Forms.Label star1PropLbl;
        private System.Windows.Forms.Button star0Temp;
        private System.Windows.Forms.Button star0Name;
        private System.Windows.Forms.Button star2Name;
        private System.Windows.Forms.Button star1Name;
        private System.Windows.Forms.Button star2SCName;
        private System.Windows.Forms.Button star1SCName;
        private System.Windows.Forms.TextBox sysAge;
        private System.Windows.Forms.CheckBox forceGarden;
        private System.Windows.Forms.CheckBox openCluster;
        private System.Windows.Forms.Button star2SCOrbRad;
        private System.Windows.Forms.Button star1SCOrbRad;
        private System.Windows.Forms.Button star2OrbRad;
        private System.Windows.Forms.Button star1OrbRad;
        private System.Windows.Forms.CheckBox forceHighStarMass;
        private System.Windows.Forms.Button resetALLTHETHINGS;
        private System.Windows.Forms.Label preOutputLbl;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button genOutput;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.DataGridView planetGrid;
    }
}