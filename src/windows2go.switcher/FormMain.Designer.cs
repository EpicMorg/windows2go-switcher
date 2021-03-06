﻿namespace windows2go.switcher {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripRegValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRegValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(487, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuStripHelp
            // 
            this.menuStripHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemHelp,
            this.toolStripSeparator1,
            this.menuStripItemAbout});
            this.menuStripHelp.Name = "menuStripHelp";
            this.menuStripHelp.Size = new System.Drawing.Size(44, 20);
            this.menuStripHelp.Text = "Help";
            // 
            // menuStripItemHelp
            // 
            this.menuStripItemHelp.Name = "menuStripItemHelp";
            this.menuStripItemHelp.Size = new System.Drawing.Size(107, 22);
            this.menuStripItemHelp.Text = "Help";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // menuStripItemAbout
            // 
            this.menuStripItemAbout.Name = "menuStripItemAbout";
            this.menuStripItemAbout.Size = new System.Drawing.Size(107, 22);
            this.menuStripItemAbout.Text = "About";
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.buttonSet);
            this.groupBox.Controls.Add(this.labelState);
            this.groupBox.Location = new System.Drawing.Point(12, 27);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(463, 173);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Current state:";
            // 
            // buttonSet
            // 
            this.buttonSet.Enabled = false;
            this.buttonSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSet.Location = new System.Drawing.Point(6, 124);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(451, 41);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "Set Some State";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // labelState
            // 
            this.labelState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelState.Location = new System.Drawing.Point(6, 16);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(451, 105);
            this.labelState.TabIndex = 0;
            this.labelState.Text = "state";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRegValue,
            this.toolStripStatusLabelRegValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 203);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripRegValue
            // 
            this.toolStripRegValue.Image = global::windows2go.switcher.Properties.Resources.Icon8;
            this.toolStripRegValue.Name = "toolStripRegValue";
            this.toolStripRegValue.Size = new System.Drawing.Size(161, 17);
            this.toolStripRegValue.Text = "PortableOperatingSystem:";
            // 
            // toolStripStatusLabelRegValue
            // 
            this.toolStripStatusLabelRegValue.Image = global::windows2go.switcher.Properties.Resources.cancel;
            this.toolStripStatusLabelRegValue.Name = "toolStripStatusLabelRegValue";
            this.toolStripStatusLabelRegValue.Size = new System.Drawing.Size(16, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 225);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows2go Switcher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemAbout;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripRegValue;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRegValue;
    }
}

