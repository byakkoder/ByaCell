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
using System.Drawing;

namespace ByaCellLib
{
    public class BaseWorldGenerator : IBaseWorldGenerator
    {
        #region Public Methods
        
        public Cell[,] Generate(Size worldSize)
        {
            if (worldSize.Width <= 0 || worldSize.Height <= 0)
            {
                throw new ArgumentException("Invalid size for world generation.");
            }

            Cell[,] world = new Cell[worldSize.Width, worldSize.Height];

            for (int xCoord = 0; xCoord < worldSize.Width; xCoord++)
            {
                for (int yCoord = 0; yCoord < worldSize.Height; yCoord++)
                {
                    world[xCoord, yCoord] = new Cell() { Location = new Point(xCoord, yCoord) };
                }
            }

            return world;
        } 

        #endregion
    }
}
