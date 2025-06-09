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
using Moq;

namespace ByaCellLib.UnitTests
{
    public class LifeValidatorTest
    {
        #region Dependencies

        private ILifeValidator _lifeValidator;
        private Mock<ILivingNeighborsCounter> _livingNeighborsCounter;

        #endregion

        #region Test Initialization

        public LifeValidatorTest()
        {
            _livingNeighborsCounter = new Mock<ILivingNeighborsCounter>();

            _lifeValidator = new LifeValidator(_livingNeighborsCounter.Object);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ReproductionTest()
        {
            #region Arrange

            Cell[,] cells = new Cell[300, 200];
            Cell cell = new Cell() { IsAlive = false };

            _livingNeighborsCounter.Setup(x => x.Count(cells, cell)).Returns(3);

            #endregion

            #region Act

            bool alive = _lifeValidator.IsAlive(cells, cell);

            #endregion

            #region Assert

            Assert.True(alive, "The cell is dead!");

            #endregion
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void NoReproductionTest(int neighbors)
        {
            #region Arrange

            Cell[,] cells = new Cell[300, 200];
            Cell cell = new Cell() { IsAlive = false };

            _livingNeighborsCounter.Setup(x => x.Count(cells, cell)).Returns(neighbors);

            #endregion

            #region Act

            bool alive = _lifeValidator.IsAlive(cells, cell);

            #endregion

            #region Assert

            Assert.False(alive, "The cell is dead!");

            #endregion
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void StillAliveTest(int neighborsCount)
        {
            #region Arrange

            Cell[,] cells = new Cell[300, 200];
            Cell cell = new Cell() { IsAlive = true };

            _livingNeighborsCounter.Setup(x => x.Count(cells, cell)).Returns(neighborsCount);

            #endregion

            #region Act

            bool alive = _lifeValidator.IsAlive(cells, cell);

            #endregion

            #region Assert

            Assert.True(alive, "The cell is dead!");

            #endregion
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void UnderpopulationTest(int neighborsCount)
        {
            #region Arrange

            Cell[,] cells = new Cell[300, 200];
            Cell cell = new Cell() { IsAlive = true };

            _livingNeighborsCounter.Setup(x => x.Count(cells, cell)).Returns(neighborsCount);

            #endregion

            #region Act

            bool alive = _lifeValidator.IsAlive(cells, cell);

            #endregion

            #region Assert

            Assert.False(alive, "The cell is alive!");

            #endregion
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void OverpopulationTest(int neighborsCount)
        {
            #region Arrange

            Cell[,] cells = new Cell[300, 200];
            Cell cell = new Cell() { IsAlive = true };

            _livingNeighborsCounter.Setup(x => x.Count(cells, cell)).Returns(neighborsCount);

            #endregion

            #region Act

            bool alive = _lifeValidator.IsAlive(cells, cell);

            #endregion

            #region Assert

            Assert.False(alive, "The cell is alive!");

            #endregion
        }

        #endregion
    }
}
