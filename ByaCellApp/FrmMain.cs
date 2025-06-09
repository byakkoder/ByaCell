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

using Bootstrapper;
using ByaCell;
using ByaCell.Properties;
using ByaCellApp.Mappers;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace ByaCellApp
{
    public partial class FrmMain : Form
    {
        #region Dependencies

        private IGenerationRunner _generationRunner;
        private IBaseWorldGenerator _baseWorldGenerator;
        private PopulationMapper _populationMapper;

        #endregion

        #region Fields
        
        private Cell[,] _world;
        private List<Point> _population;
        private int _generationCounter = 0;

        #endregion

        #region Constructor
        
        public FrmMain(
            IGenerationRunner generationRunner,
            IBaseWorldGenerator baseWorldGenerator)
        {
            _generationRunner = generationRunner;
            _baseWorldGenerator = baseWorldGenerator;

            InitializeComponent();
        }

        #endregion

        #region Form Events
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _populationMapper = new PopulationMapper();

            GdcWorld.OnCellPainted += GdcWorld_OnCellPainted;
            GdcWorld.OnCellCleaned += GdcWorld_OnCellCleaned;
            GdcWorld.OnPointerHover += GdcWorld_OnPointerHover;
            GdcWorld.OnRender += GdcWorld_OnRender;

            InitializeWorld();            
        }

        #endregion

        #region Control Events

        private void TmrConwayRunner_Tick(object sender, EventArgs e)
        {
            RunConwayLife();
        }

        private void BtnInitialize_Click(object sender, EventArgs e)
        {
            TmrConwayRunner.Enabled = false;
            InitializeWorld();
            UpdateBtnStartText();
            GdcWorld.DrawIsLocked = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            GdcWorld.DrawIsLocked = true;
            TmrConwayRunner.Enabled = !TmrConwayRunner.Enabled;

            UpdateBtnStartText();
        }

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            int speed = 1000 - TbSpeed.Value;

            TmrConwayRunner.Interval = speed == 0 ? 1 : speed;
        }

        private void GdcWorld_OnCellPainted(Point point)
        {
            _world[point.X, point.Y].IsAlive = true;
        }

        private void GdcWorld_OnCellCleaned(Point point)
        {
            _world[point.X, point.Y].IsAlive = false;
        }

        private void GdcWorld_OnPointerHover(Point cellLocation)
        {
            LblLocation.Text = string.Format(Resources.Location, cellLocation.X, cellLocation.Y);
        }

        private void GdcWorld_OnRender(int population)
        {
            LblPopulation.Text = string.Format(Resources.Population, population);
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        #endregion

        #region Private Methods

        private void InitializeWorld()
        {
            _world = _baseWorldGenerator.Generate(GdcWorld.GridSize);
            _generationCounter = 0;

            DrawPopulation();
            UpdateGenDisplay();
            GdcWorld.CenterView();
        }

        private void RunConwayLife()
        {            
            _world = _generationRunner.Run(_world);
            _generationCounter++;

            DrawPopulation();
            UpdateGenDisplay();
        }

        private void DrawPopulation()
        {
            _population = _populationMapper.Map(_world);            
            GdcWorld.DrawCells(_population);            
        }

        private void UpdateBtnStartText()
        {
            BtnStart.Text = TmrConwayRunner.Enabled ? Resources.PauseSimulation : Resources.RunSimulation;
        }

        private void UpdateGenDisplay()
        {
            LblGeneration.Text = string.Format(Resources.Generation, _generationCounter);
        }

        #endregion
    }
}
