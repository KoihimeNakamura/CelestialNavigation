namespace StarSystemGurpsGen
{
    partial class StarAlter
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numInitMass = new System.Windows.Forms.NumericUpDown();
            this.numCurrMass = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInitLumin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCurrLumin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCurrLumGR = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInnerFormation = new System.Windows.Forms.Label();
            this.lblOuterFormation = new System.Windows.Forms.Label();
            this.lblSnowLine = new System.Windows.Forms.Label();
            this.lblStellarRadius = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStellarColor = new System.Windows.Forms.Label();
            this.chkFlareStar = new System.Windows.Forms.CheckBox();
            this.lblEndMain = new System.Windows.Forms.Label();
            this.lblEndSubGiant = new System.Windows.Forms.Label();
            this.lblEndGiantPhase = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.lblEffTempGR = new System.Windows.Forms.Label();
            this.txtEffTemp = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblCurrentStage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrbitalParent = new System.Windows.Forms.TextBox();
            this.lblPeriapsis = new System.Windows.Forms.Label();
            this.lblApapsis = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numEccent = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlOrbital = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numInitMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEccent)).BeginInit();
            this.pnlOrbital.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(51, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Init Mass:";
            // 
            // numInitMass
            // 
            this.numInitMass.DecimalPlaces = 2;
            this.numInitMass.Enabled = false;
            this.numInitMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInitMass.Location = new System.Drawing.Point(74, 32);
            this.numInitMass.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numInitMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numInitMass.Name = "numInitMass";
            this.numInitMass.Size = new System.Drawing.Size(47, 20);
            this.numInitMass.TabIndex = 3;
            this.numInitMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numCurrMass
            // 
            this.numCurrMass.DecimalPlaces = 2;
            this.numCurrMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCurrMass.Location = new System.Drawing.Point(294, 32);
            this.numCurrMass.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numCurrMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numCurrMass.Name = "numCurrMass";
            this.numCurrMass.Size = new System.Drawing.Size(45, 20);
            this.numCurrMass.TabIndex = 5;
            this.numCurrMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numCurrMass.Leave += new System.EventHandler(this.numCurrMass_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Curr Mass:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "solar masses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "solar masses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Init Luminosity:";
            // 
            // txtInitLumin
            // 
            this.txtInitLumin.Enabled = false;
            this.txtInitLumin.Location = new System.Drawing.Point(96, 63);
            this.txtInitLumin.Name = "txtInitLumin";
            this.txtInitLumin.Size = new System.Drawing.Size(129, 20);
            this.txtInitLumin.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "solar luminosities";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Curr Luminosity:";
            // 
            // txtCurrLumin
            // 
            this.txtCurrLumin.Location = new System.Drawing.Point(96, 83);
            this.txtCurrLumin.Name = "txtCurrLumin";
            this.txtCurrLumin.Size = new System.Drawing.Size(129, 20);
            this.txtCurrLumin.TabIndex = 12;
            this.txtCurrLumin.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrLumin_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "solar luminosities";
            // 
            // lblCurrLumGR
            // 
            this.lblCurrLumGR.AutoSize = true;
            this.lblCurrLumGR.Location = new System.Drawing.Point(333, 86);
            this.lblCurrLumGR.Name = "lblCurrLumGR";
            this.lblCurrLumGR.Size = new System.Drawing.Size(99, 13);
            this.lblCurrLumGR.TabIndex = 14;
            this.lblCurrLumGR.Text = "Acceptable Range:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(564, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 24);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(564, 37);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 27);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInnerFormation
            // 
            this.lblInnerFormation.AutoSize = true;
            this.lblInnerFormation.Location = new System.Drawing.Point(7, 293);
            this.lblInnerFormation.Name = "lblInnerFormation";
            this.lblInnerFormation.Size = new System.Drawing.Size(156, 13);
            this.lblInnerFormation.TabIndex = 17;
            this.lblInnerFormation.Text = "Inner Radius of Formation Zone";
            // 
            // lblOuterFormation
            // 
            this.lblOuterFormation.AutoSize = true;
            this.lblOuterFormation.Location = new System.Drawing.Point(6, 315);
            this.lblOuterFormation.Name = "lblOuterFormation";
            this.lblOuterFormation.Size = new System.Drawing.Size(158, 13);
            this.lblOuterFormation.TabIndex = 18;
            this.lblOuterFormation.Text = "Outer Radius of Formation Zone";
            // 
            // lblSnowLine
            // 
            this.lblSnowLine.AutoSize = true;
            this.lblSnowLine.Location = new System.Drawing.Point(7, 337);
            this.lblSnowLine.Name = "lblSnowLine";
            this.lblSnowLine.Size = new System.Drawing.Size(57, 13);
            this.lblSnowLine.TabIndex = 19;
            this.lblSnowLine.Text = "Snow Line";
            // 
            // lblStellarRadius
            // 
            this.lblStellarRadius.AutoSize = true;
            this.lblStellarRadius.Location = new System.Drawing.Point(6, 269);
            this.lblStellarRadius.Name = "lblStellarRadius";
            this.lblStellarRadius.Size = new System.Drawing.Size(69, 13);
            this.lblStellarRadius.TabIndex = 20;
            this.lblStellarRadius.Text = "Star\'s Radius";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Effective Temperature:";
            // 
            // lblStellarColor
            // 
            this.lblStellarColor.AutoSize = true;
            this.lblStellarColor.Location = new System.Drawing.Point(6, 155);
            this.lblStellarColor.Name = "lblStellarColor";
            this.lblStellarColor.Size = new System.Drawing.Size(66, 13);
            this.lblStellarColor.TabIndex = 22;
            this.lblStellarColor.Text = "Stellar Color:";
            // 
            // chkFlareStar
            // 
            this.chkFlareStar.AutoSize = true;
            this.chkFlareStar.Location = new System.Drawing.Point(10, 181);
            this.chkFlareStar.Name = "chkFlareStar";
            this.chkFlareStar.Size = new System.Drawing.Size(71, 17);
            this.chkFlareStar.TabIndex = 23;
            this.chkFlareStar.Text = "Flare Star";
            this.chkFlareStar.UseVisualStyleBackColor = true;
            // 
            // lblEndMain
            // 
            this.lblEndMain.AutoSize = true;
            this.lblEndMain.Location = new System.Drawing.Point(389, 295);
            this.lblEndMain.Name = "lblEndMain";
            this.lblEndMain.Size = new System.Drawing.Size(116, 13);
            this.lblEndMain.TabIndex = 24;
            this.lblEndMain.Text = "End of Main Sequence";
            // 
            // lblEndSubGiant
            // 
            this.lblEndSubGiant.AutoSize = true;
            this.lblEndSubGiant.Location = new System.Drawing.Point(389, 315);
            this.lblEndSubGiant.Name = "lblEndSubGiant";
            this.lblEndSubGiant.Size = new System.Drawing.Size(121, 13);
            this.lblEndSubGiant.TabIndex = 25;
            this.lblEndSubGiant.Text = "End of Sub Giant Phase";
            // 
            // lblEndGiantPhase
            // 
            this.lblEndGiantPhase.AutoSize = true;
            this.lblEndGiantPhase.Location = new System.Drawing.Point(389, 337);
            this.lblEndGiantPhase.Name = "lblEndGiantPhase";
            this.lblEndGiantPhase.Size = new System.Drawing.Size(99, 13);
            this.lblEndGiantPhase.TabIndex = 26;
            this.lblEndGiantPhase.Text = "End of Giant Phase";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Current Age:";
            // 
            // numAge
            // 
            this.numAge.DecimalPlaces = 2;
            this.numAge.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numAge.Location = new System.Drawing.Point(82, 129);
            this.numAge.Maximum = new decimal(new int[] {
            1380,
            0,
            0,
            131072});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(50, 20);
            this.numAge.TabIndex = 28;
            this.numAge.Leave += new System.EventHandler(this.numAge_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(138, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "GYr";
            // 
            // lblEffTempGR
            // 
            this.lblEffTempGR.AutoSize = true;
            this.lblEffTempGR.Location = new System.Drawing.Point(333, 109);
            this.lblEffTempGR.Name = "lblEffTempGR";
            this.lblEffTempGR.Size = new System.Drawing.Size(99, 13);
            this.lblEffTempGR.TabIndex = 30;
            this.lblEffTempGR.Text = "Acceptable Range:";
            // 
            // txtEffTemp
            // 
            this.txtEffTemp.Location = new System.Drawing.Point(127, 106);
            this.txtEffTemp.Name = "txtEffTemp";
            this.txtEffTemp.Size = new System.Drawing.Size(117, 20);
            this.txtEffTemp.TabIndex = 31;
            this.txtEffTemp.Validating += new System.ComponentModel.CancelEventHandler(this.txtEffTemp_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(248, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "K";
            // 
            // lblCurrentStage
            // 
            this.lblCurrentStage.AutoSize = true;
            this.lblCurrentStage.Location = new System.Drawing.Point(389, 275);
            this.lblCurrentStage.Name = "lblCurrentStage";
            this.lblCurrentStage.Size = new System.Drawing.Size(75, 13);
            this.lblCurrentStage.TabIndex = 33;
            this.lblCurrentStage.Text = "Current Stage:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Orbital Parent:";
            // 
            // txtOrbitalParent
            // 
            this.txtOrbitalParent.Enabled = false;
            this.txtOrbitalParent.Location = new System.Drawing.Point(84, 6);
            this.txtOrbitalParent.Name = "txtOrbitalParent";
            this.txtOrbitalParent.Size = new System.Drawing.Size(152, 20);
            this.txtOrbitalParent.TabIndex = 35;
            // 
            // lblPeriapsis
            // 
            this.lblPeriapsis.AutoSize = true;
            this.lblPeriapsis.Location = new System.Drawing.Point(361, 12);
            this.lblPeriapsis.Name = "lblPeriapsis";
            this.lblPeriapsis.Size = new System.Drawing.Size(52, 13);
            this.lblPeriapsis.TabIndex = 36;
            this.lblPeriapsis.Text = "Periapsis:";
            // 
            // lblApapsis
            // 
            this.lblApapsis.AutoSize = true;
            this.lblApapsis.Location = new System.Drawing.Point(361, 38);
            this.lblApapsis.Name = "lblApapsis";
            this.lblApapsis.Size = new System.Drawing.Size(44, 13);
            this.lblApapsis.TabIndex = 37;
            this.lblApapsis.Text = "Apapsis";
            this.lblApapsis.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Orbital Radius:";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(84, 32);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(63, 20);
            this.txtRadius.TabIndex = 39;
            this.txtRadius.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadius_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Eccentricity:";
            // 
            // numEccent
            // 
            this.numEccent.DecimalPlaces = 2;
            this.numEccent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numEccent.Location = new System.Drawing.Point(269, 31);
            this.numEccent.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEccent.Name = "numEccent";
            this.numEccent.Size = new System.Drawing.Size(47, 20);
            this.numEccent.TabIndex = 41;
            this.numEccent.Leave += new System.EventHandler(this.numEccent_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(152, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "AU";
            // 
            // pnlOrbital
            // 
            this.pnlOrbital.Controls.Add(this.label13);
            this.pnlOrbital.Controls.Add(this.label11);
            this.pnlOrbital.Controls.Add(this.numEccent);
            this.pnlOrbital.Controls.Add(this.label10);
            this.pnlOrbital.Controls.Add(this.label12);
            this.pnlOrbital.Controls.Add(this.txtRadius);
            this.pnlOrbital.Controls.Add(this.lblApapsis);
            this.pnlOrbital.Controls.Add(this.lblPeriapsis);
            this.pnlOrbital.Controls.Add(this.txtOrbitalParent);
            this.pnlOrbital.Location = new System.Drawing.Point(9, 197);
            this.pnlOrbital.Name = "pnlOrbital";
            this.pnlOrbital.Size = new System.Drawing.Size(491, 69);
            this.pnlOrbital.TabIndex = 43;
            // 
            // StarAlter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 393);
            this.Controls.Add(this.pnlOrbital);
            this.Controls.Add(this.lblCurrentStage);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtEffTemp);
            this.Controls.Add(this.lblEffTempGR);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblEndGiantPhase);
            this.Controls.Add(this.lblEndSubGiant);
            this.Controls.Add(this.lblEndMain);
            this.Controls.Add(this.chkFlareStar);
            this.Controls.Add(this.lblStellarColor);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblStellarRadius);
            this.Controls.Add(this.lblSnowLine);
            this.Controls.Add(this.lblOuterFormation);
            this.Controls.Add(this.lblInnerFormation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCurrLumGR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCurrLumin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInitLumin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numCurrMass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numInitMass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "StarAlter";
            this.Text = "Alter Star Parameters";
            this.Load += new System.EventHandler(this.StarAlter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numInitMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEccent)).EndInit();
            this.pnlOrbital.ResumeLayout(false);
            this.pnlOrbital.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numInitMass;
        private System.Windows.Forms.NumericUpDown numCurrMass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInitLumin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCurrLumin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCurrLumGR;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInnerFormation;
        private System.Windows.Forms.Label lblOuterFormation;
        private System.Windows.Forms.Label lblSnowLine;
        private System.Windows.Forms.Label lblStellarRadius;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStellarColor;
        private System.Windows.Forms.CheckBox chkFlareStar;
        private System.Windows.Forms.Label lblEndMain;
        private System.Windows.Forms.Label lblEndSubGiant;
        private System.Windows.Forms.Label lblEndGiantPhase;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblEffTempGR;
        private System.Windows.Forms.TextBox txtEffTemp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblCurrentStage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrbitalParent;
        private System.Windows.Forms.Label lblPeriapsis;
        private System.Windows.Forms.Label lblApapsis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numEccent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlOrbital;
    }
}