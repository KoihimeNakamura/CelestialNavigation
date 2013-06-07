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
            ((System.ComponentModel.ISupportInitialize)(this.dgvStars)).BeginInit();
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
            this.dgvStars.Size = new System.Drawing.Size(1039, 166);
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
            this.btnReset.Location = new System.Drawing.Point(208, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 19);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // CelestialNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 579);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblSysAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSysName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStars);
            this.Controls.Add(this.btnGenPlanets);
            this.Controls.Add(this.btnGenStars);
            this.Name = "CelestialNavigation";
            this.Text = "CelestialNavigation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStars)).EndInit();
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
    }
}