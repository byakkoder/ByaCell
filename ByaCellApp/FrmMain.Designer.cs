/************************************************************************
 ByaCell - Cellular Automata App
 Copyright (C) 2021 John García

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <https://www.gnu.org/licenses/>.

 For more details, see README.md.
************************************************************************/


namespace ByaCellApp
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.BtnInitialize = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.TmrConwayRunner = new System.Windows.Forms.Timer(this.components);
            this.LblGeneration = new System.Windows.Forms.Label();
            this.TbSpeed = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PanStatusBar = new System.Windows.Forms.Panel();
            this.LblPopulation = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.GdcWorld = new ByaCellApp.GraphGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.TbSpeed)).BeginInit();
            this.PanStatusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnInitialize
            // 
            this.BtnInitialize.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInitialize.Location = new System.Drawing.Point(12, 40);
            this.BtnInitialize.Name = "BtnInitialize";
            this.BtnInitialize.Size = new System.Drawing.Size(199, 38);
            this.BtnInitialize.TabIndex = 1;
            this.BtnInitialize.Text = "Stop and Clear";
            this.BtnInitialize.UseVisualStyleBackColor = true;
            this.BtnInitialize.Click += new System.EventHandler(this.BtnInitialize_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(217, 40);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(199, 38);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "Run Life Simulation";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TmrConwayRunner
            // 
            this.TmrConwayRunner.Interval = 500;
            this.TmrConwayRunner.Tick += new System.EventHandler(this.TmrConwayRunner_Tick);
            // 
            // LblGeneration
            // 
            this.LblGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblGeneration.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGeneration.Location = new System.Drawing.Point(618, 37);
            this.LblGeneration.Name = "LblGeneration";
            this.LblGeneration.Size = new System.Drawing.Size(299, 38);
            this.LblGeneration.TabIndex = 3;
            this.LblGeneration.Text = "Generation: 0";
            this.LblGeneration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TbSpeed
            // 
            this.TbSpeed.Location = new System.Drawing.Point(421, 47);
            this.TbSpeed.Maximum = 1000;
            this.TbSpeed.Name = "TbSpeed";
            this.TbSpeed.Size = new System.Drawing.Size(181, 56);
            this.TbSpeed.TabIndex = 4;
            this.TbSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.TbSpeed, "Speed");
            this.TbSpeed.Value = 500;
            this.TbSpeed.Scroll += new System.EventHandler(this.TbSpeed_Scroll);
            // 
            // PanStatusBar
            // 
            this.PanStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanStatusBar.Controls.Add(this.LblPopulation);
            this.PanStatusBar.Controls.Add(this.LblLocation);
            this.PanStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanStatusBar.Location = new System.Drawing.Point(0, 683);
            this.PanStatusBar.Name = "PanStatusBar";
            this.PanStatusBar.Padding = new System.Windows.Forms.Padding(2);
            this.PanStatusBar.Size = new System.Drawing.Size(929, 38);
            this.PanStatusBar.TabIndex = 5;
            // 
            // LblPopulation
            // 
            this.LblPopulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPopulation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPopulation.Location = new System.Drawing.Point(186, 2);
            this.LblPopulation.Name = "LblPopulation";
            this.LblPopulation.Size = new System.Drawing.Size(739, 32);
            this.LblPopulation.TabIndex = 1;
            this.LblPopulation.Text = "Population: 0";
            this.LblPopulation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblLocation
            // 
            this.LblLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblLocation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLocation.Location = new System.Drawing.Point(2, 2);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(184, 32);
            this.LblLocation.TabIndex = 0;
            this.LblLocation.Text = "(X=0, Y=0)";
            this.LblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuExit});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(46, 24);
            this.MnuFile.Text = "&File";
            // 
            // MnuExit
            // 
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.Size = new System.Drawing.Size(116, 26);
            this.MnuExit.Text = "&Exit";
            this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // MnuHelp
            // 
            this.MnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuAbout});
            this.MnuHelp.Name = "MnuHelp";
            this.MnuHelp.Size = new System.Drawing.Size(55, 24);
            this.MnuHelp.Text = "&Help";
            // 
            // MnuAbout
            // 
            this.MnuAbout.Name = "MnuAbout";
            this.MnuAbout.Size = new System.Drawing.Size(186, 26);
            this.MnuAbout.Text = "&About ByaCell";
            this.MnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // GdcWorld
            // 
            this.GdcWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GdcWorld.AutoScroll = true;
            this.GdcWorld.BackColor = System.Drawing.Color.Black;
            this.GdcWorld.DrawIsLocked = false;
            this.GdcWorld.GridSize = new System.Drawing.Size(300, 200);
            this.GdcWorld.Location = new System.Drawing.Point(12, 84);
            this.GdcWorld.Name = "GdcWorld";
            this.GdcWorld.Size = new System.Drawing.Size(905, 581);
            this.GdcWorld.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 721);
            this.Controls.Add(this.PanStatusBar);
            this.Controls.Add(this.LblGeneration);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnInitialize);
            this.Controls.Add(this.GdcWorld);
            this.Controls.Add(this.TbSpeed);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "ByaCell - Cellular Automata App (Conway\'s Life)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TbSpeed)).EndInit();
            this.PanStatusBar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphGridControl GdcWorld;
        private System.Windows.Forms.Button BtnInitialize;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Timer TmrConwayRunner;
        private System.Windows.Forms.Label LblGeneration;
        private System.Windows.Forms.TrackBar TbSpeed;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel PanStatusBar;
        private System.Windows.Forms.Label LblPopulation;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuHelp;
        private System.Windows.Forms.ToolStripMenuItem MnuAbout;
        private System.Windows.Forms.ToolStripMenuItem MnuFile;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
    }
}