namespace StarSystemGurpsGen
{
    partial class CreatePlanets
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
            this.moonOpts = new System.Windows.Forms.GroupBox();
            this.bookMoon = new System.Windows.Forms.RadioButton();
            this.extendHigh = new System.Windows.Forms.RadioButton();
            this.extendNorm = new System.Windows.Forms.RadioButton();
            this.bookHigh = new System.Windows.Forms.RadioButton();
            this.chkExpandAsteroidBelt = new System.Windows.Forms.CheckBox();
            this.chkDisplayTidalData = new System.Windows.Forms.CheckBox();
            this.onlyGarden = new System.Windows.Forms.CheckBox();
            this.frcStableActivity = new System.Windows.Forms.CheckBox();
            this.noMarginAtm = new System.Windows.Forms.CheckBox();
            this.highRVM = new System.Windows.Forms.CheckBox();
            this.ignoreTides = new System.Windows.Forms.CheckBox();
            this.overrideMoons = new System.Windows.Forms.CheckBox();
            this.overridePressure = new System.Windows.Forms.CheckBox();
            this.chkMoreAccurateO2Catastrophe = new System.Windows.Forms.CheckBox();
            this.chkMoreLargeGardens = new System.Windows.Forms.CheckBox();
            this.btnGenPlanets = new System.Windows.Forms.Button();
            this.numAtmPressure = new System.Windows.Forms.NumericUpDown();
            this.lblAtm = new System.Windows.Forms.Label();
            this.numMoons = new System.Windows.Forms.NumericUpDown();
            this.lblMoons = new System.Windows.Forms.Label();
            this.chkConGasGiant = new System.Windows.Forms.CheckBox();
            this.chkHigherHabitability = new System.Windows.Forms.CheckBox();
            this.chkOverrideTilt = new System.Windows.Forms.CheckBox();
            this.chkKeepAxialTiltUnder45 = new System.Windows.Forms.CheckBox();
            this.numTilt = new System.Windows.Forms.NumericUpDown();
            this.lblDegrees = new System.Windows.Forms.Label();
            this.moonOpts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAtmPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTilt)).BeginInit();
            this.SuspendLayout();
            // 
            // moonOpts
            // 
            this.moonOpts.Controls.Add(this.bookMoon);
            this.moonOpts.Controls.Add(this.extendHigh);
            this.moonOpts.Controls.Add(this.extendNorm);
            this.moonOpts.Controls.Add(this.bookHigh);
            this.moonOpts.Location = new System.Drawing.Point(12, 12);
            this.moonOpts.Name = "moonOpts";
            this.moonOpts.Size = new System.Drawing.Size(528, 17);
            this.moonOpts.TabIndex = 1;
            this.moonOpts.TabStop = false;
            this.moonOpts.Text = "Moon Orbit Options";
            // 
            // bookMoon
            // 
            this.bookMoon.AutoSize = true;
            this.bookMoon.Checked = true;
            this.bookMoon.Location = new System.Drawing.Point(107, 0);
            this.bookMoon.Name = "bookMoon";
            this.bookMoon.Size = new System.Drawing.Size(83, 17);
            this.bookMoon.TabIndex = 23;
            this.bookMoon.TabStop = true;
            this.bookMoon.Text = "By the Book";
            this.bookMoon.UseVisualStyleBackColor = true;
            // 
            // extendHigh
            // 
            this.extendHigh.AutoSize = true;
            this.extendHigh.Location = new System.Drawing.Point(428, 0);
            this.extendHigh.Name = "extendHigh";
            this.extendHigh.Size = new System.Drawing.Size(98, 17);
            this.extendHigh.TabIndex = 3;
            this.extendHigh.Text = "Extended, High";
            this.extendHigh.UseVisualStyleBackColor = true;
            // 
            // extendNorm
            // 
            this.extendNorm.AutoSize = true;
            this.extendNorm.Location = new System.Drawing.Point(313, 0);
            this.extendNorm.Name = "extendNorm";
            this.extendNorm.Size = new System.Drawing.Size(109, 17);
            this.extendNorm.TabIndex = 2;
            this.extendNorm.Text = "Extended, Normal";
            this.extendNorm.UseVisualStyleBackColor = true;
            // 
            // bookHigh
            // 
            this.bookHigh.AutoSize = true;
            this.bookHigh.Location = new System.Drawing.Point(196, 0);
            this.bookHigh.Name = "bookHigh";
            this.bookHigh.Size = new System.Drawing.Size(111, 17);
            this.bookHigh.TabIndex = 1;
            this.bookHigh.Text = "By the Book, High";
            this.bookHigh.UseVisualStyleBackColor = true;
            // 
            // chkExpandAsteroidBelt
            // 
            this.chkExpandAsteroidBelt.AutoSize = true;
            this.chkExpandAsteroidBelt.Location = new System.Drawing.Point(18, 35);
            this.chkExpandAsteroidBelt.Name = "chkExpandAsteroidBelt";
            this.chkExpandAsteroidBelt.Size = new System.Drawing.Size(136, 17);
            this.chkExpandAsteroidBelt.TabIndex = 5;
            this.chkExpandAsteroidBelt.Text = "Expanded Asteroid Belt";
            this.chkExpandAsteroidBelt.UseVisualStyleBackColor = true;
            // 
            // chkDisplayTidalData
            // 
            this.chkDisplayTidalData.AutoSize = true;
            this.chkDisplayTidalData.Location = new System.Drawing.Point(18, 58);
            this.chkDisplayTidalData.Name = "chkDisplayTidalData";
            this.chkDisplayTidalData.Size = new System.Drawing.Size(148, 17);
            this.chkDisplayTidalData.TabIndex = 6;
            this.chkDisplayTidalData.Text = "Always Display Tidal Data";
            this.chkDisplayTidalData.UseVisualStyleBackColor = true;
            // 
            // onlyGarden
            // 
            this.onlyGarden.AutoSize = true;
            this.onlyGarden.Location = new System.Drawing.Point(18, 265);
            this.onlyGarden.Name = "onlyGarden";
            this.onlyGarden.Size = new System.Drawing.Size(203, 17);
            this.onlyGarden.TabIndex = 21;
            this.onlyGarden.Text = "Force Garden generation over Ocean";
            this.onlyGarden.UseVisualStyleBackColor = true;
            // 
            // frcStableActivity
            // 
            this.frcStableActivity.AutoSize = true;
            this.frcStableActivity.Location = new System.Drawing.Point(18, 196);
            this.frcStableActivity.Name = "frcStableActivity";
            this.frcStableActivity.Size = new System.Drawing.Size(123, 17);
            this.frcStableActivity.TabIndex = 20;
            this.frcStableActivity.Text = "Force Stable Activity";
            this.frcStableActivity.UseVisualStyleBackColor = true;
            // 
            // noMarginAtm
            // 
            this.noMarginAtm.AutoSize = true;
            this.noMarginAtm.Location = new System.Drawing.Point(18, 173);
            this.noMarginAtm.Name = "noMarginAtm";
            this.noMarginAtm.Size = new System.Drawing.Size(142, 17);
            this.noMarginAtm.TabIndex = 19;
            this.noMarginAtm.Text = "No Marginal Atmosphere";
            this.noMarginAtm.UseVisualStyleBackColor = true;
            // 
            // highRVM
            // 
            this.highRVM.AutoSize = true;
            this.highRVM.Location = new System.Drawing.Point(18, 150);
            this.highRVM.Name = "highRVM";
            this.highRVM.Size = new System.Drawing.Size(110, 17);
            this.highRVM.TabIndex = 18;
            this.highRVM.Text = "High RVM Values";
            this.highRVM.UseVisualStyleBackColor = true;
            // 
            // ignoreTides
            // 
            this.ignoreTides.AutoSize = true;
            this.ignoreTides.Location = new System.Drawing.Point(18, 127);
            this.ignoreTides.Name = "ignoreTides";
            this.ignoreTides.Size = new System.Drawing.Size(204, 17);
            this.ignoreTides.TabIndex = 17;
            this.ignoreTides.Text = "Ignore Lunar Tides on Garden Worlds";
            this.ignoreTides.UseVisualStyleBackColor = true;
            // 
            // overrideMoons
            // 
            this.overrideMoons.AutoSize = true;
            this.overrideMoons.Location = new System.Drawing.Point(18, 104);
            this.overrideMoons.Name = "overrideMoons";
            this.overrideMoons.Size = new System.Drawing.Size(243, 17);
            this.overrideMoons.TabIndex = 14;
            this.overrideMoons.Text = "Override Generated Moons on Garden Worlds";
            this.overrideMoons.UseVisualStyleBackColor = true;
            this.overrideMoons.CheckedChanged += new System.EventHandler(this.overrideMoons_CheckedChanged);
            // 
            // overridePressure
            // 
            this.overridePressure.AutoSize = true;
            this.overridePressure.Location = new System.Drawing.Point(18, 81);
            this.overridePressure.Name = "overridePressure";
            this.overridePressure.Size = new System.Drawing.Size(163, 17);
            this.overridePressure.TabIndex = 13;
            this.overridePressure.Text = "Override Generated Pressure";
            this.overridePressure.UseVisualStyleBackColor = true;
            this.overridePressure.CheckedChanged += new System.EventHandler(this.overridePressure_CheckedChanged);
            // 
            // chkMoreAccurateO2Catastrophe
            // 
            this.chkMoreAccurateO2Catastrophe.AutoSize = true;
            this.chkMoreAccurateO2Catastrophe.Location = new System.Drawing.Point(19, 220);
            this.chkMoreAccurateO2Catastrophe.Name = "chkMoreAccurateO2Catastrophe";
            this.chkMoreAccurateO2Catastrophe.Size = new System.Drawing.Size(231, 17);
            this.chkMoreAccurateO2Catastrophe.TabIndex = 22;
            this.chkMoreAccurateO2Catastrophe.Text = "More accurate Oxygen Catrastrophe Timing";
            this.chkMoreAccurateO2Catastrophe.UseVisualStyleBackColor = true;
            // 
            // chkMoreLargeGardens
            // 
            this.chkMoreLargeGardens.AutoSize = true;
            this.chkMoreLargeGardens.Location = new System.Drawing.Point(18, 242);
            this.chkMoreLargeGardens.Name = "chkMoreLargeGardens";
            this.chkMoreLargeGardens.Size = new System.Drawing.Size(307, 17);
            this.chkMoreLargeGardens.TabIndex = 23;
            this.chkMoreLargeGardens.Text = "Better Chances of Large(Garden) over Large(Ocean) worlds";
            this.chkMoreLargeGardens.UseVisualStyleBackColor = true;
            // 
            // btnGenPlanets
            // 
            this.btnGenPlanets.Location = new System.Drawing.Point(208, 349);
            this.btnGenPlanets.Name = "btnGenPlanets";
            this.btnGenPlanets.Size = new System.Drawing.Size(104, 24);
            this.btnGenPlanets.TabIndex = 25;
            this.btnGenPlanets.Text = "Generate Planets";
            this.btnGenPlanets.UseVisualStyleBackColor = true;
            this.btnGenPlanets.Click += new System.EventHandler(this.btnGenPlanets_Click);
            // 
            // numAtmPressure
            // 
            this.numAtmPressure.DecimalPlaces = 2;
            this.numAtmPressure.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numAtmPressure.Location = new System.Drawing.Point(187, 78);
            this.numAtmPressure.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numAtmPressure.Name = "numAtmPressure";
            this.numAtmPressure.Size = new System.Drawing.Size(87, 20);
            this.numAtmPressure.TabIndex = 26;
            this.numAtmPressure.Visible = false;
            // 
            // lblAtm
            // 
            this.lblAtm.AutoSize = true;
            this.lblAtm.Location = new System.Drawing.Point(280, 82);
            this.lblAtm.Name = "lblAtm";
            this.lblAtm.Size = new System.Drawing.Size(29, 13);
            this.lblAtm.TabIndex = 27;
            this.lblAtm.Text = "atms";
            // 
            // numMoons
            // 
            this.numMoons.Location = new System.Drawing.Point(267, 101);
            this.numMoons.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numMoons.Name = "numMoons";
            this.numMoons.Size = new System.Drawing.Size(45, 20);
            this.numMoons.TabIndex = 28;
            this.numMoons.Visible = false;
            // 
            // lblMoons
            // 
            this.lblMoons.AutoSize = true;
            this.lblMoons.Location = new System.Drawing.Point(318, 105);
            this.lblMoons.Name = "lblMoons";
            this.lblMoons.Size = new System.Drawing.Size(38, 13);
            this.lblMoons.TabIndex = 29;
            this.lblMoons.Text = "moons";
            // 
            // chkConGasGiant
            // 
            this.chkConGasGiant.AutoSize = true;
            this.chkConGasGiant.Location = new System.Drawing.Point(18, 288);
            this.chkConGasGiant.Name = "chkConGasGiant";
            this.chkConGasGiant.Size = new System.Drawing.Size(209, 17);
            this.chkConGasGiant.TabIndex = 30;
            this.chkConGasGiant.Text = "Better Conventional Gas Giant Chance";
            this.chkConGasGiant.UseVisualStyleBackColor = true;
            // 
            // chkHigherHabitability
            // 
            this.chkHigherHabitability.AutoSize = true;
            this.chkHigherHabitability.Location = new System.Drawing.Point(18, 311);
            this.chkHigherHabitability.Name = "chkHigherHabitability";
            this.chkHigherHabitability.Size = new System.Drawing.Size(208, 17);
            this.chkHigherHabitability.TabIndex = 31;
            this.chkHigherHabitability.Text = "Override GURPS limit of +8 Habitability";
            this.chkHigherHabitability.UseVisualStyleBackColor = true;
            // 
            // chkOverrideTilt
            // 
            this.chkOverrideTilt.AutoSize = true;
            this.chkOverrideTilt.Location = new System.Drawing.Point(369, 35);
            this.chkOverrideTilt.Name = "chkOverrideTilt";
            this.chkOverrideTilt.Size = new System.Drawing.Size(108, 17);
            this.chkOverrideTilt.TabIndex = 32;
            this.chkOverrideTilt.Text = "Override Axial Tilt";
            this.chkOverrideTilt.UseVisualStyleBackColor = true;
            this.chkOverrideTilt.CheckedChanged += new System.EventHandler(this.chkOverrideTilt_CheckedChanged);
            // 
            // chkKeepAxialTiltUnder45
            // 
            this.chkKeepAxialTiltUnder45.AutoSize = true;
            this.chkKeepAxialTiltUnder45.Location = new System.Drawing.Point(369, 58);
            this.chkKeepAxialTiltUnder45.Name = "chkKeepAxialTiltUnder45";
            this.chkKeepAxialTiltUnder45.Size = new System.Drawing.Size(181, 17);
            this.chkKeepAxialTiltUnder45.TabIndex = 33;
            this.chkKeepAxialTiltUnder45.Text = "Keep Axial Tilt Under 45 degrees";
            this.chkKeepAxialTiltUnder45.UseVisualStyleBackColor = true;
            // 
            // numTilt
            // 
            this.numTilt.Location = new System.Drawing.Point(487, 32);
            this.numTilt.Name = "numTilt";
            this.numTilt.Size = new System.Drawing.Size(53, 20);
            this.numTilt.TabIndex = 34;
            // 
            // lblDegrees
            // 
            this.lblDegrees.AutoSize = true;
            this.lblDegrees.Location = new System.Drawing.Point(546, 34);
            this.lblDegrees.Name = "lblDegrees";
            this.lblDegrees.Size = new System.Drawing.Size(45, 13);
            this.lblDegrees.TabIndex = 35;
            this.lblDegrees.Text = "degrees";
            // 
            // CreatePlanets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 395);
            this.Controls.Add(this.lblDegrees);
            this.Controls.Add(this.numTilt);
            this.Controls.Add(this.chkKeepAxialTiltUnder45);
            this.Controls.Add(this.chkOverrideTilt);
            this.Controls.Add(this.chkHigherHabitability);
            this.Controls.Add(this.chkConGasGiant);
            this.Controls.Add(this.lblMoons);
            this.Controls.Add(this.numMoons);
            this.Controls.Add(this.lblAtm);
            this.Controls.Add(this.numAtmPressure);
            this.Controls.Add(this.btnGenPlanets);
            this.Controls.Add(this.chkMoreLargeGardens);
            this.Controls.Add(this.chkMoreAccurateO2Catastrophe);
            this.Controls.Add(this.onlyGarden);
            this.Controls.Add(this.frcStableActivity);
            this.Controls.Add(this.noMarginAtm);
            this.Controls.Add(this.highRVM);
            this.Controls.Add(this.ignoreTides);
            this.Controls.Add(this.overrideMoons);
            this.Controls.Add(this.overridePressure);
            this.Controls.Add(this.moonOpts);
            this.Controls.Add(this.chkExpandAsteroidBelt);
            this.Controls.Add(this.chkDisplayTidalData);
            this.Name = "CreatePlanets";
            this.Text = "Dialog: Create Planets";
            this.moonOpts.ResumeLayout(false);
            this.moonOpts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAtmPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTilt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox moonOpts;
        private System.Windows.Forms.RadioButton extendHigh;
        private System.Windows.Forms.RadioButton extendNorm;
        private System.Windows.Forms.RadioButton bookHigh;
        private System.Windows.Forms.CheckBox chkExpandAsteroidBelt;
        private System.Windows.Forms.CheckBox chkDisplayTidalData;
        private System.Windows.Forms.CheckBox onlyGarden;
        private System.Windows.Forms.CheckBox frcStableActivity;
        private System.Windows.Forms.CheckBox noMarginAtm;
        private System.Windows.Forms.CheckBox highRVM;
        private System.Windows.Forms.CheckBox ignoreTides;
        private System.Windows.Forms.CheckBox overrideMoons;
        private System.Windows.Forms.CheckBox overridePressure;
        private System.Windows.Forms.RadioButton bookMoon;
        private System.Windows.Forms.CheckBox chkMoreAccurateO2Catastrophe;
        private System.Windows.Forms.CheckBox chkMoreLargeGardens;
        private System.Windows.Forms.Button btnGenPlanets;
        private System.Windows.Forms.NumericUpDown numAtmPressure;
        private System.Windows.Forms.Label lblAtm;
        private System.Windows.Forms.NumericUpDown numMoons;
        private System.Windows.Forms.Label lblMoons;
        private System.Windows.Forms.CheckBox chkConGasGiant;
        private System.Windows.Forms.CheckBox chkHigherHabitability;
        private System.Windows.Forms.CheckBox chkOverrideTilt;
        private System.Windows.Forms.CheckBox chkKeepAxialTiltUnder45;
        private System.Windows.Forms.NumericUpDown numTilt;
        private System.Windows.Forms.Label lblDegrees;
    }
}