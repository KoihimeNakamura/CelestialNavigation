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
            this.sysAgeTT = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step1CoreSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step2DetermineSafeOrbitalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step3PopulateOrbitalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSysName = new System.Windows.Forms.Label();
            this.sysName = new System.Windows.Forms.TextBox();
            this.btnGenRandom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStar1 = new System.Windows.Forms.Label();
            this.lblStar2 = new System.Windows.Forms.Label();
            this.lblStar3 = new System.Windows.Forms.Label();
            this.lblSubStar2 = new System.Windows.Forms.Label();
            this.lblSubStar3 = new System.Windows.Forms.Label();
            this.lblSysAge = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generationToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputToFileToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // outputToFileToolStripMenuItem
            // 
            this.outputToFileToolStripMenuItem.Name = "outputToFileToolStripMenuItem";
            this.outputToFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.outputToFileToolStripMenuItem.Text = "Output to File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // generationToolStripMenuItem
            // 
            this.generationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.step1CoreSystemToolStripMenuItem,
            this.step2DetermineSafeOrbitalsToolStripMenuItem,
            this.step3PopulateOrbitalsToolStripMenuItem});
            this.generationToolStripMenuItem.Name = "generationToolStripMenuItem";
            this.generationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.generationToolStripMenuItem.Text = "Generation";
            // 
            // step1CoreSystemToolStripMenuItem
            // 
            this.step1CoreSystemToolStripMenuItem.Name = "step1CoreSystemToolStripMenuItem";
            this.step1CoreSystemToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.step1CoreSystemToolStripMenuItem.Text = "Step 1 - Core System";
            this.step1CoreSystemToolStripMenuItem.Click += new System.EventHandler(this.step1CoreSystemToolStripMenuItem_Click);
            // 
            // step2DetermineSafeOrbitalsToolStripMenuItem
            // 
            this.step2DetermineSafeOrbitalsToolStripMenuItem.Name = "step2DetermineSafeOrbitalsToolStripMenuItem";
            this.step2DetermineSafeOrbitalsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.step2DetermineSafeOrbitalsToolStripMenuItem.Text = "Step 2 - Determine Safe Orbitals";
            // 
            // step3PopulateOrbitalsToolStripMenuItem
            // 
            this.step3PopulateOrbitalsToolStripMenuItem.Name = "step3PopulateOrbitalsToolStripMenuItem";
            this.step3PopulateOrbitalsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.step3PopulateOrbitalsToolStripMenuItem.Text = "Step 3 - Populate Orbitals";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // lblSysName
            // 
            this.lblSysName.AutoSize = true;
            this.lblSysName.Location = new System.Drawing.Point(15, 31);
            this.lblSysName.Name = "lblSysName";
            this.lblSysName.Size = new System.Drawing.Size(72, 13);
            this.lblSysName.TabIndex = 2;
            this.lblSysName.Text = "System Name";
            // 
            // sysName
            // 
            this.sysName.Location = new System.Drawing.Point(98, 31);
            this.sysName.Name = "sysName";
            this.sysName.Size = new System.Drawing.Size(176, 20);
            this.sysName.TabIndex = 3;
            // 
            // btnGenRandom
            // 
            this.btnGenRandom.Location = new System.Drawing.Point(297, 31);
            this.btnGenRandom.Name = "btnGenRandom";
            this.btnGenRandom.Size = new System.Drawing.Size(155, 20);
            this.btnGenRandom.TabIndex = 4;
            this.btnGenRandom.Text = "Generate Random Name";
            this.btnGenRandom.UseVisualStyleBackColor = true;
            this.btnGenRandom.Click += new System.EventHandler(this.btnGenRandom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stars:";
            this.label1.Visible = false;
            // 
            // lblStar1
            // 
            this.lblStar1.Location = new System.Drawing.Point(68, 62);
            this.lblStar1.Name = "lblStar1";
            this.lblStar1.Size = new System.Drawing.Size(401, 62);
            this.lblStar1.TabIndex = 6;
            this.lblStar1.Text = "Star 1:";
            this.lblStar1.Visible = false;
            // 
            // lblStar2
            // 
            this.lblStar2.Location = new System.Drawing.Point(68, 124);
            this.lblStar2.Name = "lblStar2";
            this.lblStar2.Size = new System.Drawing.Size(401, 76);
            this.lblStar2.TabIndex = 7;
            this.lblStar2.Text = "Star 2:";
            this.lblStar2.Visible = false;
            // 
            // lblStar3
            // 
            this.lblStar3.Location = new System.Drawing.Point(68, 200);
            this.lblStar3.Name = "lblStar3";
            this.lblStar3.Size = new System.Drawing.Size(401, 74);
            this.lblStar3.TabIndex = 8;
            this.lblStar3.Text = "Star 3:";
            this.lblStar3.Visible = false;
            this.lblStar3.Click += new System.EventHandler(this.lblStar3_Click);
            // 
            // lblSubStar2
            // 
            this.lblSubStar2.Location = new System.Drawing.Point(68, 274);
            this.lblSubStar2.Name = "lblSubStar2";
            this.lblSubStar2.Size = new System.Drawing.Size(401, 74);
            this.lblSubStar2.TabIndex = 9;
            this.lblSubStar2.Text = "Subcompanion of Star 2:";
            this.lblSubStar2.Visible = false;
            // 
            // lblSubStar3
            // 
            this.lblSubStar3.Location = new System.Drawing.Point(68, 348);
            this.lblSubStar3.Name = "lblSubStar3";
            this.lblSubStar3.Size = new System.Drawing.Size(401, 79);
            this.lblSubStar3.TabIndex = 10;
            this.lblSubStar3.Text = "Subcompanion of Star 3:";
            this.lblSubStar3.Visible = false;
            // 
            // lblSysAge
            // 
            this.lblSysAge.AutoSize = true;
            this.lblSysAge.Location = new System.Drawing.Point(485, 31);
            this.lblSysAge.Name = "lblSysAge";
            this.lblSysAge.Size = new System.Drawing.Size(97, 13);
            this.lblSysAge.TabIndex = 11;
            this.lblSysAge.Text = "System Age: Unset";
            // 
            // StarSystemGurpsGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 556);
            this.Controls.Add(this.lblSysAge);
            this.Controls.Add(this.lblSubStar3);
            this.Controls.Add(this.lblSubStar2);
            this.Controls.Add(this.lblStar3);
            this.Controls.Add(this.lblStar2);
            this.Controls.Add(this.lblStar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenRandom);
            this.Controls.Add(this.sysName);
            this.Controls.Add(this.lblSysName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StarSystemGurpsGen";
            this.Text = "GURPS Space 4e Solar System Generator";
            this.Load += new System.EventHandler(this.StarSystemGurpsGen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip sysAgeTT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step1CoreSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step2DetermineSafeOrbitalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step3PopulateOrbitalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToFileToolStripMenuItem;
        private System.Windows.Forms.Label lblSysName;
        private System.Windows.Forms.TextBox sysName;
        private System.Windows.Forms.Button btnGenRandom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStar1;
        private System.Windows.Forms.Label lblStar2;
        private System.Windows.Forms.Label lblStar3;
        private System.Windows.Forms.Label lblSubStar2;
        private System.Windows.Forms.Label lblSubStar3;
        private System.Windows.Forms.Label lblSysAge;
    }
}