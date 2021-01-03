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
    public class LivingNeighborsCounter : ILivingNeighborsCounter
    {
        #region Public Methods
        
        public int Count(Cell[,] cells, Cell cell)
        {
            int livingNeighbors = 0;
            int maxXIndex = cells.GetUpperBound(0);
            int maxYIndex = cells.GetUpperBound(1);

            if (maxXIndex < 2 || maxYIndex < 2)
            {
                throw new ArgumentException("The minimum array size is 3x3.");
            }

            for (int xCoord = cell.Location.X - 1; xCoord <= cell.Location.X + 1; xCoord++)
            {
                for (int yCoord = cell.Location.Y - 1; yCoord <= cell.Location.Y + 1; yCoord++)
                {
                    if (xCoord == cell.Location.X && yCoord == cell.Location.Y ||
                        xCoord < 0 || xCoord > maxXIndex ||
                        yCoord < 0 || yCoord > maxYIndex ||
                        !cells[xCoord, yCoord].IsAlive)
                    {
                        continue;
                    }

                    livingNeighbors++;
                }
            }

            return livingNeighbors;
        } 

        #endregion
    }
}
