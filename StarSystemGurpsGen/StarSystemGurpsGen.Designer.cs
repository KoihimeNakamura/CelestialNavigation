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
            this.step3OutputToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSysName = new System.Windows.Forms.Label();
            this.sysName = new System.Windows.Forms.TextBox();
            this.btnGenRandom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStar1 = new System.Windows.Forms.Label();
            this.lblSysAge = new System.Windows.Forms.Label();
            this.btnOrbits1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.outputToFileToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.outputToFileToolStripMenuItem.Text = "Output to File";
            this.outputToFileToolStripMenuItem.Click += new System.EventHandler(this.outputToFileToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // generationToolStripMenuItem
            // 
            this.generationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.step1CoreSystemToolStripMenuItem,
            this.step2DetermineSafeOrbitalsToolStripMenuItem,
            this.step3OutputToFileToolStripMenuItem});
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
            this.step2DetermineSafeOrbitalsToolStripMenuItem.Click += new System.EventHandler(this.step2DetermineSafeOrbitalsToolStripMenuItem_Click);
            // 
            // step3OutputToFileToolStripMenuItem
            // 
            this.step3OutputToFileToolStripMenuItem.Name = "step3OutputToFileToolStripMenuItem";
            this.step3OutputToFileToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.step3OutputToFileToolStripMenuItem.Text = "Step 3 - Output To File";
            this.step3OutputToFileToolStripMenuItem.Click += new System.EventHandler(this.step3OutputToFileToolStripMenuItem_Click);
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
            this.lblStar1.Location = new System.Drawing.Point(68, 64);
            this.lblStar1.Name = "lblStar1";
            this.lblStar1.Size = new System.Drawing.Size(401, 47);
            this.lblStar1.TabIndex = 6;
            this.lblStar1.Text = "Star 1:";
            this.lblStar1.Visible = false;
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
            // btnOrbits1
            // 
            this.btnOrbits1.Location = new System.Drawing.Point(596, 62);
            this.btnOrbits1.Name = "btnOrbits1";
            this.btnOrbits1.Size = new System.Drawing.Size(97, 24);
            this.btnOrbits1.TabIndex = 13;
            this.btnOrbits1.Text = "Display Orbits";
            this.btnOrbits1.UseVisualStyleBackColor = true;
            this.btnOrbits1.Visible = false;
            this.btnOrbits1.Click += new System.EventHandler(this.btnOrbits_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(706, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // StarSystemGurpsGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 617);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOrbits1);
            this.Controls.Add(this.lblSysAge);
            this.Controls.Add(this.lblStar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenRandom);
            this.Controls.Add(this.sysName);
            this.Controls.Add(this.lblSysName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StarSystemGurpsGen";
            this.Text = "Celestial Navigation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StarSystemGurpsGen_FormClosed);
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
        private System.Windows.Forms.ToolStripMenuItem outputToFileToolStripMenuItem;
        private System.Windows.Forms.Label lblSysName;
        private System.Windows.Forms.TextBox sysName;
        private System.Windows.Forms.Button btnGenRandom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStar1;
        private System.Windows.Forms.Label lblSysAge;
        private System.Windows.Forms.Button btnOrbits1;
        private System.Windows.Forms.ToolStripMenuItem step3OutputToFileToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}