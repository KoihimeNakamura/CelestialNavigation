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
            // 
            // btnGenPlanets
            // 
            this.btnGenPlanets.Location = new System.Drawing.Point(101, 4);
            this.btnGenPlanets.Name = "btnGenPlanets";
            this.btnGenPlanets.Size = new System.Drawing.Size(105, 20);
            this.btnGenPlanets.TabIndex = 1;
            this.btnGenPlanets.Text = "Generate Planets";
            this.btnGenPlanets.UseVisualStyleBackColor = true;
            // 
            // dgvStars
            // 
            this.dgvStars.AllowUserToAddRows = false;
            this.dgvStars.AllowUserToDeleteRows = false;
            this.dgvStars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStars.Location = new System.Drawing.Point(3, 27);
            this.dgvStars.Name = "dgvStars";
            this.dgvStars.ReadOnly = true;
            this.dgvStars.Size = new System.Drawing.Size(770, 166);
            this.dgvStars.TabIndex = 2;
            // 
            // CelestialNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 579);
            this.Controls.Add(this.dgvStars);
            this.Controls.Add(this.btnGenPlanets);
            this.Controls.Add(this.btnGenStars);
            this.Name = "CelestialNavigation";
            this.Text = "CelestialNavigation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenStars;
        private System.Windows.Forms.Button btnGenPlanets;
        private System.Windows.Forms.DataGridView dgvStars;
    }
}