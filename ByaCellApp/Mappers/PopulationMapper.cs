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
using System.Collections.Generic;
using System.Drawing;

namespace ByaCellApp.Mappers
{
    public class PopulationMapper
    {
        public List<Point> Map(Cell[,] world)
        {
            List<Point> population = new List<Point>();

            int maxXIndex = world.GetUpperBound(0);
            int maxYIndex = world.GetUpperBound(1);

            for (int xCoord = 0; xCoord <= maxXIndex; xCoord++)
            {
                for (int yCoord = 0; yCoord <= maxYIndex; yCoord++)
                {
                    if (!world[xCoord, yCoord].IsAlive)
                    {
                        continue;
                    }

                    population.Add(world[xCoord, yCoord].Location);
                }
            }

            return population;
        }
    }
}
