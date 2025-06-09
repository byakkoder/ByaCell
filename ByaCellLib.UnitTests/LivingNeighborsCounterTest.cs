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
using System.Drawing;

namespace ByaCellLib.UnitTests
{
    public class LivingNeighborsCounterTest
    {
        #region Dependencies

        private ILivingNeighborsCounter _livingNeighborsCounter;

        #endregion

        #region Test Initialization

        public LivingNeighborsCounterTest()
        {
            _livingNeighborsCounter = new LivingNeighborsCounter();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void CountTest()
        {
            #region Arrange

            Cell cellToEval = new Cell() { Location = new Point(1, 1) };

            Cell[,] sourceGeneration = new Cell[3, 3]
            {
                { new Cell() { IsAlive = true }, new Cell(), new Cell() },
                { new Cell(), cellToEval, new Cell() },
                { new Cell(), new Cell() { IsAlive = true }, new Cell() { IsAlive = true } }
            };

            #endregion

            #region Act

            int livingNeighborsCount = _livingNeighborsCounter.Count(sourceGeneration, cellToEval);

            #endregion

            #region Assert

            Assert.Equal(3, livingNeighborsCount);

            #endregion
        }

        [Fact]
        public void AvoidSameTest()
        {
            #region Arrange

            Cell cellToEval = new Cell() { Location = new Point(1, 1), IsAlive = true };

            Cell[,] sourceGeneration = new Cell[3, 3]
            {
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } },
                { new Cell() { IsAlive = true }, cellToEval, new Cell() { IsAlive = true } },
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } }
            };

            #endregion

            #region Act

            int livingNeighborsCount = _livingNeighborsCounter.Count(sourceGeneration, cellToEval);

            #endregion

            #region Assert

            Assert.Equal(8, livingNeighborsCount);

            #endregion
        }

        [Fact]
        public void LowerLimitTest()
        {
            #region Arrange

            Cell cellToEval = new Cell() { Location = new Point(0, 0), IsAlive = true };

            Cell[,] sourceGeneration = new Cell[3, 3]
            {
                { cellToEval, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } },
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } },
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } }
            };

            #endregion

            #region Act

            int livingNeighborsCount = _livingNeighborsCounter.Count(sourceGeneration, cellToEval);

            #endregion

            #region Assert

            Assert.Equal(3, livingNeighborsCount);

            #endregion
        }

        [Fact]
        public void UpperLimitTest()
        {
            #region Arrange

            Cell cellToEval = new Cell() { Location = new Point(2, 2), IsAlive = true };

            Cell[,] sourceGeneration = new Cell[3, 3]
            {
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } },
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, new Cell() { IsAlive = true } },
                { new Cell() { IsAlive = true }, new Cell() { IsAlive = true }, cellToEval }
            };

            #endregion

            #region Act

            int livingNeighborsCount = _livingNeighborsCounter.Count(sourceGeneration, cellToEval);

            #endregion

            #region Assert

            Assert.Equal(3, livingNeighborsCount);

            #endregion
        }

        [Fact]
        public void MinimumSizeTest()
        {
            #region Arrange

            Cell[,] sourceGeneration = new Cell[2, 2];

            #endregion

            #region Act and Assert

            Assert.Throws<ArgumentException>(() => _livingNeighborsCounter.Count(sourceGeneration, sourceGeneration[0, 0]));

            #endregion
        }

        #endregion
    }
}
