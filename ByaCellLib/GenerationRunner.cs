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

using Entities;
using Interfaces;
using System;

namespace ByaCellLib
{
    public class GenerationRunner : IGenerationRunner
    {
        #region Dependencies
        
        private ILifeValidator _lifeValidator;

        #endregion

        #region Constructor
        
        public GenerationRunner(ILifeValidator lifeValidator)
        {
            _lifeValidator = lifeValidator;
        }

        #endregion

        #region Public Methods
        
        public Cell[,] Run(Cell[,] cells)
        {
            int maxXIndex = cells.GetUpperBound(0);
            int maxYIndex = cells.GetUpperBound(1);

            if (maxXIndex < 2 || maxYIndex < 2)
            {
                throw new ArgumentException("The minimum array size is 3x3.");
            }

            Cell[,] nextGenCells = new Cell[cells.GetLength(0), cells.GetLength(1)];
            Array.Copy(cells, nextGenCells, cells.Length);

            for (int xCoord = 0; xCoord <= maxXIndex; xCoord++)
            {
                for (int yCoord = 0; yCoord <= maxYIndex; yCoord++)
                {
                    bool isAlive = _lifeValidator.IsAlive(cells, cells[xCoord, yCoord]);

                    nextGenCells[xCoord, yCoord].IsAlive = isAlive;
                }
            }

            return nextGenCells;
        } 

        #endregion
    }
}
