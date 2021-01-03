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
    partial class GraphGridControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanGrid = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanGrid
            // 
            this.PanGrid.Location = new System.Drawing.Point(3, 3);
            this.PanGrid.Name = "PanGrid";
            this.PanGrid.Size = new System.Drawing.Size(501, 501);
            this.PanGrid.TabIndex = 0;
            this.PanGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.PanGrid_Paint);
            this.PanGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanGrid_MouseDown);
            this.PanGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanGrid_MouseMove);
            this.PanGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanGrid_MouseUp);
            // 
            // GraphGridControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.PanGrid);
            this.Name = "GraphGridControl";
            this.Size = new System.Drawing.Size(600, 520);
            this.Load += new System.EventHandler(this.GraphGridControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanGrid;
    }
}
