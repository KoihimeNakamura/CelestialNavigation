namespace StarSystemGurpsGen
{
    partial class StarOptions
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
            this.primOpt = new System.Windows.Forms.TabControl();
            this.genOpt = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkOneOrbit = new System.Windows.Forms.CheckBox();
            this.chkForceLowStellarEccent = new System.Windows.Forms.CheckBox();
            this.lessStellarEcc = new System.Windows.Forms.CheckBox();
            this.repLowRedWithBrown = new System.Windows.Forms.CheckBox();
            this.overrideAge = new System.Windows.Forms.CheckBox();
            this.lblAgeVal = new System.Windows.Forms.Label();
            this.ageBar = new System.Windows.Forms.TrackBar();
            this.lblAgeSlider = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stelMaxMass = new System.Windows.Forms.NumericUpDown();
            this.stelMinMass = new System.Windows.Forms.NumericUpDown();
            this.lblMaxStellarMass = new System.Windows.Forms.Label();
            this.lblSteMas = new System.Windows.Forms.Label();
            this.stelMasSet = new System.Windows.Forms.CheckBox();
            this.lblStellarMass = new System.Windows.Forms.Label();
            this.lblSteGen = new System.Windows.Forms.Label();
            this.numDigits = new System.Windows.Forms.NumericUpDown();
            this.lblNumDecimal = new System.Windows.Forms.Label();
            this.alwaysTidalData = new System.Windows.Forms.CheckBox();
            this.expandAsBelt = new System.Windows.Forms.CheckBox();
            this.verboseOutput = new System.Windows.Forms.CheckBox();
            this.openCluster = new System.Windows.Forms.CheckBox();
            this.lblGenOpt = new System.Windows.Forms.Label();
            this.forceGarden = new System.Windows.Forms.CheckBox();
            this.moonOpts = new System.Windows.Forms.GroupBox();
            this.extendHigh = new System.Windows.Forms.RadioButton();
            this.extendNorm = new System.Windows.Forms.RadioButton();
            this.bookHigh = new System.Windows.Forms.RadioButton();
            this.bookMoon = new System.Windows.Forms.RadioButton();
            this.satOpt = new System.Windows.Forms.TabPage();
            this.onlyGarden = new System.Windows.Forms.CheckBox();
            this.frcStableActivity = new System.Windows.Forms.CheckBox();
            this.noMarginAtm = new System.Windows.Forms.CheckBox();
            this.highRVM = new System.Windows.Forms.CheckBox();
            this.ignoreTides = new System.Windows.Forms.CheckBox();
            this.numMoons = new System.Windows.Forms.NumericUpDown();
            this.atmPresFld = new System.Windows.Forms.TextBox();
            this.overrideMoons = new System.Windows.Forms.CheckBox();
            this.overridePressure = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appChanges = new System.Windows.Forms.Button();
            this.canChanges = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblNumStars = new System.Windows.Forms.Label();
            this.numStars = new System.Windows.Forms.NumericUpDown();
            this.numStarOverride = new System.Windows.Forms.CheckBox();
            this.primOpt.SuspendLayout();
            this.genOpt.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stelMaxMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stelMinMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).BeginInit();
            this.moonOpts.SuspendLayout();
            this.satOpt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMoons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStars)).BeginInit();
            this.SuspendLayout();
            // 
            // primOpt
            // 
            this.primOpt.Controls.Add(this.genOpt);
            this.primOpt.Controls.Add(this.satOpt);
            this.primOpt.Location = new System.Drawing.Point(3, 0);
            this.primOpt.Name = "primOpt";
            this.primOpt.SelectedIndex = 0;
            this.primOpt.Size = new System.Drawing.Size(736, 434);
            this.primOpt.TabIndex = 0;
            // 
            // genOpt
            // 
            this.genOpt.Controls.Add(this.panel2);
            this.genOpt.Controls.Add(this.lblSteGen);
            this.genOpt.Controls.Add(this.numDigits);
            this.genOpt.Controls.Add(this.lblNumDecimal);
            this.genOpt.Controls.Add(this.alwaysTidalData);
            this.genOpt.Controls.Add(this.expandAsBelt);
            this.genOpt.Controls.Add(this.verboseOutput);
            this.genOpt.Controls.Add(this.openCluster);
            this.genOpt.Controls.Add(this.lblGenOpt);
            this.genOpt.Controls.Add(this.forceGarden);
            this.genOpt.Controls.Add(this.moonOpts);
            this.genOpt.Location = new System.Drawing.Point(4, 22);
            this.genOpt.Name = "genOpt";
            this.genOpt.Padding = new System.Windows.Forms.Padding(3);
            this.genOpt.Size = new System.Drawing.Size(728, 408);
            this.genOpt.TabIndex = 0;
            this.genOpt.Text = "Primary Options";
            this.genOpt.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkOneOrbit);
            this.panel2.Controls.Add(this.chkForceLowStellarEccent);
            this.panel2.Controls.Add(this.lessStellarEcc);
            this.panel2.Controls.Add(this.repLowRedWithBrown);
            this.panel2.Controls.Add(this.overrideAge);
            this.panel2.Controls.Add(this.lblAgeVal);
            this.panel2.Controls.Add(this.ageBar);
            this.panel2.Controls.Add(this.lblAgeSlider);
            this.panel2.Controls.Add(this.numStarOverride);
            this.panel2.Controls.Add(this.lblNumStars);
            this.panel2.Controls.Add(this.numStars);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(10, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 222);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // chkOneOrbit
            // 
            this.chkOneOrbit.AutoSize = true;
            this.chkOneOrbit.Location = new System.Drawing.Point(345, 86);
            this.chkOneOrbit.Name = "chkOneOrbit";
            this.chkOneOrbit.Size = new System.Drawing.Size(107, 17);
            this.chkOneOrbit.TabIndex = 20;
            this.chkOneOrbit.Text = "Ensure One Orbit";
            this.chkOneOrbit.UseVisualStyleBackColor = true;
            // 
            // chkForceLowStellarEccent
            // 
            this.chkForceLowStellarEccent.AutoSize = true;
            this.chkForceLowStellarEccent.Location = new System.Drawing.Point(346, 63);
            this.chkForceLowStellarEccent.Name = "chkForceLowStellarEccent";
            this.chkForceLowStellarEccent.Size = new System.Drawing.Size(190, 17);
            this.chkForceLowStellarEccent.TabIndex = 19;
            this.chkForceLowStellarEccent.Text = "Force Very Low Stellar Eccentricity";
            this.chkForceLowStellarEccent.UseVisualStyleBackColor = true;
            // 
            // lessStellarEcc
            // 
            this.lessStellarEcc.AutoSize = true;
            this.lessStellarEcc.Location = new System.Drawing.Point(345, 39);
            this.lessStellarEcc.Name = "lessStellarEcc";
            this.lessStellarEcc.Size = new System.Drawing.Size(148, 17);
            this.lessStellarEcc.TabIndex = 18;
            this.lessStellarEcc.Text = "Lessen Stellar Eccentricty";
            this.lessStellarEcc.UseVisualStyleBackColor = true;
            // 
            // repLowRedWithBrown
            // 
            this.repLowRedWithBrown.AutoSize = true;
            this.repLowRedWithBrown.Enabled = false;
            this.repLowRedWithBrown.Location = new System.Drawing.Point(345, 16);
            this.repLowRedWithBrown.Name = "repLowRedWithBrown";
            this.repLowRedWithBrown.Size = new System.Drawing.Size(284, 17);
            this.repLowRedWithBrown.TabIndex = 17;
            this.repLowRedWithBrown.Text = "Replace low mass Red Dwarf Stars with Brown Dwarfs";
            this.repLowRedWithBrown.UseVisualStyleBackColor = true;
            // 
            // overrideAge
            // 
            this.overrideAge.AutoSize = true;
            this.overrideAge.Location = new System.Drawing.Point(70, 141);
            this.overrideAge.Name = "overrideAge";
            this.overrideAge.Size = new System.Drawing.Size(143, 17);
            this.overrideAge.TabIndex = 16;
            this.overrideAge.Text = "Override Age Generation";
            this.overrideAge.UseVisualStyleBackColor = true;
            this.overrideAge.CheckedChanged += new System.EventHandler(this.overrideAge_CheckedChanged);
            // 
            // lblAgeVal
            // 
            this.lblAgeVal.AutoSize = true;
            this.lblAgeVal.Location = new System.Drawing.Point(467, 94);
            this.lblAgeVal.Name = "lblAgeVal";
            this.lblAgeVal.Size = new System.Drawing.Size(0, 13);
            this.lblAgeVal.TabIndex = 15;
            // 
            // ageBar
            // 
            this.ageBar.Enabled = false;
            this.ageBar.LargeChange = 100;
            this.ageBar.Location = new System.Drawing.Point(12, 174);
            this.ageBar.Maximum = 1450;
            this.ageBar.Minimum = 10;
            this.ageBar.Name = "ageBar";
            this.ageBar.Size = new System.Drawing.Size(689, 45);
            this.ageBar.SmallChange = 10;
            this.ageBar.TabIndex = 13;
            this.ageBar.TickFrequency = 100;
            this.ageBar.Value = 10;
            this.ageBar.Scroll += new System.EventHandler(this.ageBar_Scroll);
            // 
            // lblAgeSlider
            // 
            this.lblAgeSlider.AutoSize = true;
            this.lblAgeSlider.Location = new System.Drawing.Point(9, 143);
            this.lblAgeSlider.Name = "lblAgeSlider";
            this.lblAgeSlider.Size = new System.Drawing.Size(55, 13);
            this.lblAgeSlider.TabIndex = 14;
            this.lblAgeSlider.Text = "Age Slider";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stelMaxMass);
            this.panel1.Controls.Add(this.stelMinMass);
            this.panel1.Controls.Add(this.lblMaxStellarMass);
            this.panel1.Controls.Add(this.lblSteMas);
            this.panel1.Controls.Add(this.stelMasSet);
            this.panel1.Controls.Add(this.lblStellarMass);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 102);
            this.panel1.TabIndex = 7;
            // 
            // stelMaxMass
            // 
            this.stelMaxMass.DecimalPlaces = 2;
            this.stelMaxMass.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.stelMaxMass.Location = new System.Drawing.Point(111, 82);
            this.stelMaxMass.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.stelMaxMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.stelMaxMass.Name = "stelMaxMass";
            this.stelMaxMass.Size = new System.Drawing.Size(120, 20);
            this.stelMaxMass.TabIndex = 7;
            this.stelMaxMass.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // stelMinMass
            // 
            this.stelMinMass.DecimalPlaces = 2;
            this.stelMinMass.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.stelMinMass.Location = new System.Drawing.Point(111, 49);
            this.stelMinMass.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.stelMinMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.stelMinMass.Name = "stelMinMass";
            this.stelMinMass.Size = new System.Drawing.Size(120, 20);
            this.stelMinMass.TabIndex = 6;
            this.stelMinMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // lblMaxStellarMass
            // 
            this.lblMaxStellarMass.AutoSize = true;
            this.lblMaxStellarMass.Location = new System.Drawing.Point(7, 82);
            this.lblMaxStellarMass.Name = "lblMaxStellarMass";
            this.lblMaxStellarMass.Size = new System.Drawing.Size(87, 13);
            this.lblMaxStellarMass.TabIndex = 5;
            this.lblMaxStellarMass.Text = "Max Stellar Mass";
            // 
            // lblSteMas
            // 
            this.lblSteMas.AutoSize = true;
            this.lblSteMas.Location = new System.Drawing.Point(8, 54);
            this.lblSteMas.Name = "lblSteMas";
            this.lblSteMas.Size = new System.Drawing.Size(84, 13);
            this.lblSteMas.TabIndex = 4;
            this.lblSteMas.Text = "Min Stellar Mass";
            // 
            // stelMasSet
            // 
            this.stelMasSet.AutoSize = true;
            this.stelMasSet.Location = new System.Drawing.Point(10, 28);
            this.stelMasSet.Name = "stelMasSet";
            this.stelMasSet.Size = new System.Drawing.Size(59, 17);
            this.stelMasSet.TabIndex = 1;
            this.stelMasSet.Text = "Enable";
            this.stelMasSet.UseVisualStyleBackColor = true;
            this.stelMasSet.CheckedChanged += new System.EventHandler(this.stelMasSet_CheckedChanged);
            // 
            // lblStellarMass
            // 
            this.lblStellarMass.AutoSize = true;
            this.lblStellarMass.Location = new System.Drawing.Point(7, 8);
            this.lblStellarMass.Name = "lblStellarMass";
            this.lblStellarMass.Size = new System.Drawing.Size(99, 13);
            this.lblStellarMass.TabIndex = 0;
            this.lblStellarMass.Text = "Stellar Mass Range";
            // 
            // lblSteGen
            // 
            this.lblSteGen.AutoSize = true;
            this.lblSteGen.Location = new System.Drawing.Point(20, 164);
            this.lblSteGen.Name = "lblSteGen";
            this.lblSteGen.Size = new System.Drawing.Size(130, 13);
            this.lblSteGen.TabIndex = 17;
            this.lblSteGen.Text = "Stellar Generation Options";
            // 
            // numDigits
            // 
            this.numDigits.Location = new System.Drawing.Point(622, 24);
            this.numDigits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numDigits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDigits.Name = "numDigits";
            this.numDigits.Size = new System.Drawing.Size(56, 20);
            this.numDigits.TabIndex = 12;
            this.numDigits.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumDecimal
            // 
            this.lblNumDecimal.AutoSize = true;
            this.lblNumDecimal.Location = new System.Drawing.Point(468, 24);
            this.lblNumDecimal.Name = "lblNumDecimal";
            this.lblNumDecimal.Size = new System.Drawing.Size(148, 13);
            this.lblNumDecimal.TabIndex = 11;
            this.lblNumDecimal.Text = "Number of Decimals in Output";
            // 
            // alwaysTidalData
            // 
            this.alwaysTidalData.AutoSize = true;
            this.alwaysTidalData.Location = new System.Drawing.Point(189, 135);
            this.alwaysTidalData.Name = "alwaysTidalData";
            this.alwaysTidalData.Size = new System.Drawing.Size(148, 17);
            this.alwaysTidalData.TabIndex = 6;
            this.alwaysTidalData.Text = "Always Display Tidal Data";
            this.alwaysTidalData.UseVisualStyleBackColor = true;
            // 
            // expandAsBelt
            // 
            this.expandAsBelt.AutoSize = true;
            this.expandAsBelt.Location = new System.Drawing.Point(189, 111);
            this.expandAsBelt.Name = "expandAsBelt";
            this.expandAsBelt.Size = new System.Drawing.Size(136, 17);
            this.expandAsBelt.TabIndex = 5;
            this.expandAsBelt.Text = "Expanded Asteroid Belt";
            this.expandAsBelt.UseVisualStyleBackColor = true;
            // 
            // verboseOutput
            // 
            this.verboseOutput.AutoSize = true;
            this.verboseOutput.Location = new System.Drawing.Point(189, 88);
            this.verboseOutput.Name = "verboseOutput";
            this.verboseOutput.Size = new System.Drawing.Size(100, 17);
            this.verboseOutput.TabIndex = 4;
            this.verboseOutput.Text = "Verbose Output";
            this.verboseOutput.UseVisualStyleBackColor = true;
            // 
            // openCluster
            // 
            this.openCluster.AutoSize = true;
            this.openCluster.Location = new System.Drawing.Point(189, 65);
            this.openCluster.Name = "openCluster";
            this.openCluster.Size = new System.Drawing.Size(179, 17);
            this.openCluster.TabIndex = 3;
            this.openCluster.Text = "Is the System in a Open Cluster?";
            this.openCluster.UseVisualStyleBackColor = true;
            // 
            // lblGenOpt
            // 
            this.lblGenOpt.AutoSize = true;
            this.lblGenOpt.Location = new System.Drawing.Point(186, 22);
            this.lblGenOpt.Name = "lblGenOpt";
            this.lblGenOpt.Size = new System.Drawing.Size(83, 13);
            this.lblGenOpt.TabIndex = 2;
            this.lblGenOpt.Text = "General Options";
            // 
            // forceGarden
            // 
            this.forceGarden.AutoSize = true;
            this.forceGarden.Location = new System.Drawing.Point(189, 41);
            this.forceGarden.Name = "forceGarden";
            this.forceGarden.Size = new System.Drawing.Size(248, 17);
            this.forceGarden.TabIndex = 1;
            this.forceGarden.Text = "Force Favorable Conditions for a Garden World";
            this.forceGarden.UseVisualStyleBackColor = true;
            // 
            // moonOpts
            // 
            this.moonOpts.Controls.Add(this.extendHigh);
            this.moonOpts.Controls.Add(this.extendNorm);
            this.moonOpts.Controls.Add(this.bookHigh);
            this.moonOpts.Controls.Add(this.bookMoon);
            this.moonOpts.Location = new System.Drawing.Point(23, 22);
            this.moonOpts.Name = "moonOpts";
            this.moonOpts.Size = new System.Drawing.Size(144, 130);
            this.moonOpts.TabIndex = 0;
            this.moonOpts.TabStop = false;
            this.moonOpts.Text = "Moon Orbit Options";
            // 
            // extendHigh
            // 
            this.extendHigh.AutoSize = true;
            this.extendHigh.Location = new System.Drawing.Point(7, 91);
            this.extendHigh.Name = "extendHigh";
            this.extendHigh.Size = new System.Drawing.Size(98, 17);
            this.extendHigh.TabIndex = 3;
            this.extendHigh.Text = "Extended, High";
            this.extendHigh.UseVisualStyleBackColor = true;
            // 
            // extendNorm
            // 
            this.extendNorm.AutoSize = true;
            this.extendNorm.Location = new System.Drawing.Point(7, 67);
            this.extendNorm.Name = "extendNorm";
            this.extendNorm.Size = new System.Drawing.Size(109, 17);
            this.extendNorm.TabIndex = 2;
            this.extendNorm.Text = "Extended, Normal";
            this.extendNorm.UseVisualStyleBackColor = true;
            // 
            // bookHigh
            // 
            this.bookHigh.AutoSize = true;
            this.bookHigh.Location = new System.Drawing.Point(7, 43);
            this.bookHigh.Name = "bookHigh";
            this.bookHigh.Size = new System.Drawing.Size(111, 17);
            this.bookHigh.TabIndex = 1;
            this.bookHigh.Text = "By the Book, High";
            this.bookHigh.UseVisualStyleBackColor = true;
            // 
            // bookMoon
            // 
            this.bookMoon.AutoSize = true;
            this.bookMoon.Checked = true;
            this.bookMoon.Location = new System.Drawing.Point(7, 19);
            this.bookMoon.Name = "bookMoon";
            this.bookMoon.Size = new System.Drawing.Size(83, 17);
            this.bookMoon.TabIndex = 0;
            this.bookMoon.TabStop = true;
            this.bookMoon.Text = "By the Book";
            this.bookMoon.UseVisualStyleBackColor = true;
            // 
            // satOpt
            // 
            this.satOpt.Controls.Add(this.onlyGarden);
            this.satOpt.Controls.Add(this.frcStableActivity);
            this.satOpt.Controls.Add(this.noMarginAtm);
            this.satOpt.Controls.Add(this.highRVM);
            this.satOpt.Controls.Add(this.ignoreTides);
            this.satOpt.Controls.Add(this.numMoons);
            this.satOpt.Controls.Add(this.atmPresFld);
            this.satOpt.Controls.Add(this.overrideMoons);
            this.satOpt.Controls.Add(this.overridePressure);
            this.satOpt.Controls.Add(this.label3);
            this.satOpt.Controls.Add(this.label2);
            this.satOpt.Location = new System.Drawing.Point(4, 22);
            this.satOpt.Name = "satOpt";
            this.satOpt.Padding = new System.Windows.Forms.Padding(3);
            this.satOpt.Size = new System.Drawing.Size(728, 408);
            this.satOpt.TabIndex = 1;
            this.satOpt.Text = " Satelite Options";
            this.satOpt.UseVisualStyleBackColor = true;
            // 
            // onlyGarden
            // 
            this.onlyGarden.AutoSize = true;
            this.onlyGarden.Location = new System.Drawing.Point(16, 171);
            this.onlyGarden.Name = "onlyGarden";
            this.onlyGarden.Size = new System.Drawing.Size(203, 17);
            this.onlyGarden.TabIndex = 10;
            this.onlyGarden.Text = "Force Garden generation over Ocean";
            this.onlyGarden.UseVisualStyleBackColor = true;
            // 
            // frcStableActivity
            // 
            this.frcStableActivity.AutoSize = true;
            this.frcStableActivity.Location = new System.Drawing.Point(16, 148);
            this.frcStableActivity.Name = "frcStableActivity";
            this.frcStableActivity.Size = new System.Drawing.Size(123, 17);
            this.frcStableActivity.TabIndex = 9;
            this.frcStableActivity.Text = "Force Stable Activity";
            this.frcStableActivity.UseVisualStyleBackColor = true;
            // 
            // noMarginAtm
            // 
            this.noMarginAtm.AutoSize = true;
            this.noMarginAtm.Location = new System.Drawing.Point(16, 125);
            this.noMarginAtm.Name = "noMarginAtm";
            this.noMarginAtm.Size = new System.Drawing.Size(142, 17);
            this.noMarginAtm.TabIndex = 8;
            this.noMarginAtm.Text = "No Marginal Atmosphere";
            this.noMarginAtm.UseVisualStyleBackColor = true;
            // 
            // highRVM
            // 
            this.highRVM.AutoSize = true;
            this.highRVM.Location = new System.Drawing.Point(16, 102);
            this.highRVM.Name = "highRVM";
            this.highRVM.Size = new System.Drawing.Size(110, 17);
            this.highRVM.TabIndex = 7;
            this.highRVM.Text = "High RVM Values";
            this.highRVM.UseVisualStyleBackColor = true;
            // 
            // ignoreTides
            // 
            this.ignoreTides.AutoSize = true;
            this.ignoreTides.Location = new System.Drawing.Point(16, 79);
            this.ignoreTides.Name = "ignoreTides";
            this.ignoreTides.Size = new System.Drawing.Size(204, 17);
            this.ignoreTides.TabIndex = 6;
            this.ignoreTides.Text = "Ignore Lunar Tides on Garden Worlds";
            this.ignoreTides.UseVisualStyleBackColor = true;
            // 
            // numMoons
            // 
            this.numMoons.Location = new System.Drawing.Point(185, 39);
            this.numMoons.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMoons.Name = "numMoons";
            this.numMoons.Size = new System.Drawing.Size(46, 20);
            this.numMoons.TabIndex = 5;
            // 
            // atmPresFld
            // 
            this.atmPresFld.Enabled = false;
            this.atmPresFld.Location = new System.Drawing.Point(185, 11);
            this.atmPresFld.Name = "atmPresFld";
            this.atmPresFld.Size = new System.Drawing.Size(47, 20);
            this.atmPresFld.TabIndex = 4;
            this.atmPresFld.TextChanged += new System.EventHandler(this.atmPresFld_TextChanged);
            this.atmPresFld.Validating += new System.ComponentModel.CancelEventHandler(this.atmPresFld_Validating);
            // 
            // overrideMoons
            // 
            this.overrideMoons.AutoSize = true;
            this.overrideMoons.Location = new System.Drawing.Point(263, 37);
            this.overrideMoons.Name = "overrideMoons";
            this.overrideMoons.Size = new System.Drawing.Size(154, 17);
            this.overrideMoons.TabIndex = 3;
            this.overrideMoons.Text = "Override Generated Moons";
            this.overrideMoons.UseVisualStyleBackColor = true;
            this.overrideMoons.CheckedChanged += new System.EventHandler(this.overrideMoons_CheckedChanged);
            // 
            // overridePressure
            // 
            this.overridePressure.AutoSize = true;
            this.overridePressure.Location = new System.Drawing.Point(263, 11);
            this.overridePressure.Name = "overridePressure";
            this.overridePressure.Size = new System.Drawing.Size(166, 17);
            this.overridePressure.TabIndex = 2;
            this.overridePressure.Text = "Override  Generated Pressure";
            this.overridePressure.UseVisualStyleBackColor = true;
            this.overridePressure.CheckedChanged += new System.EventHandler(this.overridePressure_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Set Moons Over Garden World";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Set Atmospheric Pressure";
            // 
            // appChanges
            // 
            this.appChanges.Location = new System.Drawing.Point(521, 439);
            this.appChanges.Name = "appChanges";
            this.appChanges.Size = new System.Drawing.Size(93, 26);
            this.appChanges.TabIndex = 1;
            this.appChanges.Text = "Apply Changes";
            this.appChanges.UseVisualStyleBackColor = true;
            this.appChanges.Click += new System.EventHandler(this.appChanges_Click);
            // 
            // canChanges
            // 
            this.canChanges.Location = new System.Drawing.Point(629, 440);
            this.canChanges.Name = "canChanges";
            this.canChanges.Size = new System.Drawing.Size(105, 24);
            this.canChanges.TabIndex = 2;
            this.canChanges.Text = "Cancel Changes";
            this.canChanges.UseVisualStyleBackColor = true;
            this.canChanges.Click += new System.EventHandler(this.canChanges_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(456, 439);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblNumStars
            // 
            this.lblNumStars.AutoSize = true;
            this.lblNumStars.Location = new System.Drawing.Point(141, 12);
            this.lblNumStars.Name = "lblNumStars";
            this.lblNumStars.Size = new System.Drawing.Size(53, 13);
            this.lblNumStars.TabIndex = 9;
            this.lblNumStars.Text = "# of Stars";
            // 
            // numStars
            // 
            this.numStars.Enabled = false;
            this.numStars.Location = new System.Drawing.Point(204, 12);
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
            this.numStars.TabIndex = 8;
            this.numStars.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numStarOverride
            // 
            this.numStarOverride.AutoSize = true;
            this.numStarOverride.Location = new System.Drawing.Point(11, 8);
            this.numStarOverride.Name = "numStarOverride";
            this.numStarOverride.Size = new System.Drawing.Size(110, 17);
            this.numStarOverride.TabIndex = 10;
            this.numStarOverride.Text = "Specify # of Stars";
            this.numStarOverride.UseVisualStyleBackColor = true;
            this.numStarOverride.CheckedChanged += new System.EventHandler(this.numStarOverride_CheckedChanged);
            // 
            // StarOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 468);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.canChanges);
            this.Controls.Add(this.appChanges);
            this.Controls.Add(this.primOpt);
            this.Name = "StarOptions";
            this.Text = "StarOptions";
            this.Load += new System.EventHandler(this.StarOptions_Load);
            this.primOpt.ResumeLayout(false);
            this.genOpt.ResumeLayout(false);
            this.genOpt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stelMaxMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stelMinMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).EndInit();
            this.moonOpts.ResumeLayout(false);
            this.moonOpts.PerformLayout();
            this.satOpt.ResumeLayout(false);
            this.satOpt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMoons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl primOpt;
        private System.Windows.Forms.TabPage genOpt;
        private System.Windows.Forms.TabPage satOpt;
        private System.Windows.Forms.Button appChanges;
        private System.Windows.Forms.Button canChanges;
        private System.Windows.Forms.GroupBox moonOpts;
        private System.Windows.Forms.RadioButton extendHigh;
        private System.Windows.Forms.RadioButton extendNorm;
        private System.Windows.Forms.RadioButton bookHigh;
        private System.Windows.Forms.RadioButton bookMoon;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox forceGarden;
        private System.Windows.Forms.Label lblGenOpt;
        private System.Windows.Forms.CheckBox openCluster;
        private System.Windows.Forms.CheckBox alwaysTidalData;
        private System.Windows.Forms.CheckBox expandAsBelt;
        private System.Windows.Forms.CheckBox verboseOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMaxStellarMass;
        private System.Windows.Forms.Label lblSteMas;
        private System.Windows.Forms.CheckBox stelMasSet;
        private System.Windows.Forms.Label lblStellarMass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox overrideMoons;
        private System.Windows.Forms.CheckBox overridePressure;
        private System.Windows.Forms.TextBox atmPresFld;
        private System.Windows.Forms.NumericUpDown numMoons;
        private System.Windows.Forms.CheckBox ignoreTides;
        private System.Windows.Forms.CheckBox highRVM;
        private System.Windows.Forms.CheckBox noMarginAtm;
        private System.Windows.Forms.CheckBox frcStableActivity;
        private System.Windows.Forms.NumericUpDown numDigits;
        private System.Windows.Forms.Label lblNumDecimal;
        private System.Windows.Forms.TrackBar ageBar;
        private System.Windows.Forms.Label lblAgeVal;
        private System.Windows.Forms.Label lblAgeSlider;
        private System.Windows.Forms.CheckBox overrideAge;
        private System.Windows.Forms.Label lblSteGen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox repLowRedWithBrown;
        private System.Windows.Forms.CheckBox onlyGarden;
        private System.Windows.Forms.NumericUpDown stelMaxMass;
        private System.Windows.Forms.NumericUpDown stelMinMass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox lessStellarEcc;
        private System.Windows.Forms.CheckBox chkOneOrbit;
        private System.Windows.Forms.CheckBox chkForceLowStellarEccent;
        private System.Windows.Forms.CheckBox numStarOverride;
        private System.Windows.Forms.Label lblNumStars;
        private System.Windows.Forms.NumericUpDown numStars;
    }
}