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

namespace ByaCellLib
{
    public class LifeValidator : ILifeValidator
    {
        #region Dependencies
        
        private ILivingNeighborsCounter _livingNeighborsCounter;

        #endregion

        #region Constructor
        
        public LifeValidator(ILivingNeighborsCounter livingNeighborsCounter)
        {
            _livingNeighborsCounter = livingNeighborsCounter;
        }

        #endregion

        #region Public Methods
        
        public bool IsAlive(Cell[,] cells, Cell cell)
        {
            int livingNeighborsCount = _livingNeighborsCounter.Count(cells, cell);

            return livingNeighborsCount == 3 || cell.IsAlive && livingNeighborsCount == 2;
        } 

        #endregion
    }
}
