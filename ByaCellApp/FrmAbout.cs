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

using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ByaCell
{
    public partial class FrmAbout : Form
    {
        #region Constructor
        
        public FrmAbout()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events

        private void FrmAbout_Load(object sender, System.EventArgs e)
        {
            AssemblyName currentAssemblyName = Assembly.GetExecutingAssembly().GetName();

            int major = currentAssemblyName.Version.Major;
            int minor = currentAssemblyName.Version.Minor;
            int patch = currentAssemblyName.Version.Build;

            RtbAbout.Text = RtbAbout.Text.Replace("{version}", $"{major}.{minor}.{patch}");
        }

        #endregion

        #region Control Events

        private void RtbAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        #endregion        
    }
}
