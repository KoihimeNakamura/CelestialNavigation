namespace StarSystemGurpsGen
{
    partial class CelestialNavigation
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
            this.btnGenStars = new System.Windows.Forms.Button();
            this.btnGenPlanets = new System.Windows.Forms.Button();
            this.dgvStars = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSysName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSysAge = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberPlanets = new System.Windows.Forms.Label();
            this.dgvPlanets = new System.Windows.Forms.DataGridView();
            this.chkEmptyDisplay = new System.Windows.Forms.CheckBox();
            this.btnViewFull = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenStars
            // 
            this.btnGenStars.Location = new System.Drawing.Point(1, 3);
            this.btnGenStars.Name = "btnGenStars";
            this.btnGenStars.Size = new System.Drawing.Size(97, 22);
            this.btnGenStars.TabIndex = 0;
            this.btnGenStars.Text = "Generate Stars";
            this.btnGenStars.UseVisualStyleBackColor = true;
            this.btnGenStars.Click += new System.EventHandler(this.btnGenStars_Click);
            // 
            // btnGenPlanets
            // 
            this.btnGenPlanets.Location = new System.Drawing.Point(101, 4);
            this.btnGenPlanets.Name = "btnGenPlanets";
            this.btnGenPlanets.Size = new System.Drawing.Size(105, 20);
            this.btnGenPlanets.TabIndex = 1;
            this.btnGenPlanets.Text = "Generate Planets";
            this.btnGenPlanets.UseVisualStyleBackColor = true;
            this.btnGenPlanets.Click += new System.EventHandler(this.btnGenPlanets_Click);
            // 
            // dgvStars
            // 
            this.dgvStars.AllowUserToAddRows = false;
            this.dgvStars.AllowUserToDeleteRows = false;
            this.dgvStars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStars.Location = new System.Drawing.Point(3, 48);
            this.dgvStars.Name = "dgvStars";
            this.dgvStars.ReadOnly = true;
            this.dgvStars.Size = new System.Drawing.Size(1268, 166);
            this.dgvStars.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "System Name:";
            // 
            // lblSysName
            // 
            this.lblSysName.AutoSize = true;
            this.lblSysName.Location = new System.Drawing.Point(87, 31);
            this.lblSysName.Name = "lblSysName";
            this.lblSysName.Size = new System.Drawing.Size(0, 13);
            this.lblSysName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "System Age:";
            // 
            // lblSysAge
            // 
            this.lblSysAge.AutoSize = true;
            this.lblSysAge.Location = new System.Drawing.Point(491, 32);
            this.lblSysAge.Name = "lblSysAge";
            this.lblSysAge.Size = new System.Drawing.Size(0, 13);
            this.lblSysAge.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(323, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 19);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number of Planets:";
            // 
            // lblNumberPlanets
            // 
            this.lblNumberPlanets.AutoSize = true;
            this.lblNumberPlanets.Location = new System.Drawing.Point(110, 226);
            this.lblNumberPlanets.Name = "lblNumberPlanets";
            this.lblNumberPlanets.Size = new System.Drawing.Size(0, 13);
            this.lblNumberPlanets.TabIndex = 9;
            // 
            // dgvPlanets
            // 
            this.dgvPlanets.AllowUserToAddRows = false;
            this.dgvPlanets.AllowUserToDeleteRows = false;
            this.dgvPlanets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanets.Location = new System.Drawing.Point(4, 250);
            this.dgvPlanets.Name = "dgvPlanets";
            this.dgvPlanets.ReadOnly = true;
            this.dgvPlanets.Size = new System.Drawing.Size(1267, 294);
            this.dgvPlanets.TabIndex = 10;
            // 
            // chkEmptyDisplay
            // 
            this.chkEmptyDisplay.AutoSize = true;
            this.chkEmptyDisplay.Location = new System.Drawing.Point(984, 231);
            this.chkEmptyDisplay.Name = "chkEmptyDisplay";
            this.chkEmptyDisplay.Size = new System.Drawing.Size(130, 17);
            this.chkEmptyDisplay.TabIndex = 11;
            this.chkEmptyDisplay.Text = "Display Empty Orbitals";
            this.chkEmptyDisplay.UseVisualStyleBackColor = true;
            this.chkEmptyDisplay.CheckedChanged += new System.EventHandler(this.chkEmptyDisplay_CheckedChanged);
            // 
            // btnViewFull
            // 
            this.btnViewFull.Location = new System.Drawing.Point(212, 3);
            this.btnViewFull.Name = "btnViewFull";
            this.btnViewFull.Size = new System.Drawing.Size(105, 20);
            this.btnViewFull.TabIndex = 12;
            this.btnViewFull.Text = "View Full Output";
            this.btnViewFull.UseVisualStyleBackColor = true;
            this.btnViewFull.Click += new System.EventHandler(this.btnViewFull_Click);
            // 
            // CelestialNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 579);
            this.Controls.Add(this.btnViewFull);
            this.Controls.Add(this.chkEmptyDisplay);
            this.Controls.Add(this.dgvPlanets);
            this.Controls.Add(this.lblNumberPlanets);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblSysAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSysName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStars);
            this.Controls.Add(this.btnGenPlanets);
            this.Controls.Add(this.btnGenStars);
            this.Name = "CelestialNavigation";
            this.Text = "Celestial Navigation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenStars;
        private System.Windows.Forms.Button btnGenPlanets;
        private System.Windows.Forms.DataGridView dgvStars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSysName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSysAge;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberPlanets;
        private System.Windows.Forms.DataGridView dgvPlanets;
        private System.Windows.Forms.CheckBox chkEmptyDisplay;
        private System.Windows.Forms.Button btnViewFull;
    }
}