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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ByaCellApp
{
    public partial class GraphGridControl : UserControl
    {
        #region Events
        
        public event Action<Point> OnCellPainted;
        public event Action<Point> OnCellCleaned;
        public event Action<Point> OnPointerHover;
        public event Action<int> OnRender; 

        #endregion

        #region Constants

        private const int CellSize = 10;

        #endregion

        #region Fields
        
        private Size _gridSize;
        private List<Point> _cells;
        private bool _isDrawing;
        private bool _drawIsLocked;
        private Pen _gridPen;

        #endregion

        #region Properties

        public Size GridSize
        {
            get
            {
                return _gridSize;
            }
            set
            {
                _gridSize = value;
                PanGrid.Size = new Size(_gridSize.Width * CellSize + 1, _gridSize.Height * CellSize + 1);
            }
        }

        public bool DrawIsLocked 
        {
            get
            {
                return _drawIsLocked;
            }
            set
            {
                _drawIsLocked = value;
                _isDrawing = false;

                PanGrid.Cursor = _drawIsLocked ? Cursors.Default : Cursors.Hand;                
            } 
        }

        #endregion

        #region Public Methods

        public void CenterView()
        {
            AutoScrollPosition = new Point(PanGrid.Width / 2 - Width / 2, PanGrid.Height / 2 - Height / 2);
        }

        public void DrawCells(List<Point> cells)
        {
            _cells = cells;

            RenderGraphics(cells);
        }

        #endregion

        #region Constructor

        public GraphGridControl()
        {
            InitializeComponent();

            _gridSize = new Size((PanGrid.Width - 1) / CellSize, (PanGrid.Height - 1) / CellSize);
        }

        #endregion

        #region Control Events

        private void GraphGridControl_Load(object sender, EventArgs e)
        {
            _cells = new List<Point>();
            _gridPen = new Pen(Color.DarkSlateGray);
        }

        #endregion

        #region Internal Control Events

        private void PanGrid_Paint(object sender, PaintEventArgs e)
        {
            RenderGraphics(_cells);
        }

        private void PanGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (_drawIsLocked)
            {
                return;
            }

            _isDrawing = true;

            DrawCell(e);
        }

        private void PanGrid_MouseMove(object sender, MouseEventArgs e)
        {
            int xCoord = e.X / CellSize;
            int yCoord = e.Y / CellSize;

            OnPointerHover?.Invoke(new Point(xCoord, yCoord));

            if (_drawIsLocked)
            {
                return;
            }

            if (!_isDrawing)
            {
                return;
            }

            DrawCell(e);
        }

        private void PanGrid_MouseUp(object sender, MouseEventArgs e)
        {
            if (_drawIsLocked)
            {
                return;
            }

            _isDrawing = false;
        }

        #endregion

        #region Private Methods

        private void RenderGraphics(List<Point> cells)
        {
            using (Graphics gridGraphics = PanGrid.CreateGraphics())
            {
                using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
                {
                    using (BufferedGraphics bg = bgc.Allocate(gridGraphics, PanGrid.ClientRectangle))
                    {
                        RenderCells(cells, bg);
                        RenderGrid(bg);

                        bg.Render(gridGraphics);
                    }
                }
            }

            OnRender?.Invoke(_cells.Count);
        }

        private void RenderGrid(BufferedGraphics bufferedGraphics)
        {
            for (int xCoord = 0; xCoord < PanGrid.Width; xCoord += CellSize)
            {
                bufferedGraphics.Graphics.DrawLine(_gridPen, xCoord, 0, xCoord, PanGrid.Height);
            }

            for (int yCoord = 0; yCoord < PanGrid.Height; yCoord += CellSize)
            {
                bufferedGraphics.Graphics.DrawLine(_gridPen, 0, yCoord, PanGrid.Width, yCoord);
            }
        }

        private void RenderCells(List<Point> cells, BufferedGraphics bufferedGraphics)
        {
            cells.ForEach(cell =>
            {
                bufferedGraphics.Graphics.FillRectangle(Brushes.GreenYellow, cell.X * CellSize, cell.Y * CellSize, CellSize, CellSize);
            });
        }

        private void DrawCell(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
            {
                return;
            }

            using (Graphics graphics = PanGrid.CreateGraphics())
            {
                int diffX = e.X % CellSize;
                int x = diffX > 0 ? e.X - diffX : e.X;

                int diffY = e.Y % CellSize;
                int y = diffY > 0 ? e.Y - diffY : e.Y;

                Brush cellBrush = e.Button == MouseButtons.Left ? Brushes.GreenYellow : Brushes.Black;

                Rectangle cellRect = new Rectangle(x, y, CellSize, CellSize);
                graphics.FillRectangle(cellBrush, cellRect);
                graphics.DrawRectangle(_gridPen, cellRect);

                UpdateLivingCellsList(e, x, y);

                OnRender?.Invoke(_cells.Count);
            }
        }

        private void UpdateLivingCellsList(MouseEventArgs e, int x, int y)
        {
            int xCoord = x / CellSize;
            int yCoord = y / CellSize;

            Point point = new Point(xCoord, yCoord);

            if (e.Button == MouseButtons.Left)
            {
                if (!_cells.Contains(point))
                {
                    _cells.Add(point);

                    OnCellPainted?.Invoke(point);
                }
            }
            else
            {
                if (_cells.Contains(point))
                {
                    _cells.Remove(point);

                    OnCellCleaned?.Invoke(point);
                }
            }
        }

        #endregion
    }
}
