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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ByaCellLib.Test
{
    [TestClass]
    public class LifeValidatorTest
    {
        #region Dependencies
        
        private ILifeValidator _lifeValidator;
        private Mock<ILivingNeighborsCounter> _livingNeighborsCounter; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _livingNeighborsCounter = new Mock<ILivingNeighborsCounter>();

            _lifeValidator = new LifeValidator(_livingNeighborsCounter.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
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

            Assert.IsTrue(alive, "The cell is dead!");

            #endregion
        }

        [TestMethod]
        [DataRow(1, DisplayName = "One Neighbor")]
        [DataRow(2, DisplayName = "Two Neighbors")]
        [DataRow(4, DisplayName = "Four Neighbors")]
        [DataRow(5, DisplayName = "Five Neighbors")]
        [DataRow(6, DisplayName = "Six Neighbors")]
        [DataRow(7, DisplayName = "Seven Neighbors")]
        [DataRow(8, DisplayName = "Eight Neighbors")]
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

            Assert.IsFalse(alive, "The cell is dead!");

            #endregion
        }

        [TestMethod]
        [DataRow(2, DisplayName = "Two Neighbors")]
        [DataRow(3, DisplayName = "Three Neighbors")]
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

            Assert.IsTrue(alive, "The cell is dead!");

            #endregion
        }

        [TestMethod]
        [DataRow(0, DisplayName = "No Neighbors")]
        [DataRow(1, DisplayName = "One Neighbor")]
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

            Assert.IsFalse(alive, "The cell is alive!");

            #endregion
        }

        [TestMethod]
        [DataRow(4, DisplayName = "Four Neighbors")]
        [DataRow(5, DisplayName = "Five Neighbors")]
        [DataRow(6, DisplayName = "Six Neighbors")]
        [DataRow(7, DisplayName = "Seven Neighbors")]
        [DataRow(8, DisplayName = "Eight Neighbors")]
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

            Assert.IsFalse(alive, "The cell is alive!");

            #endregion
        }

        #endregion
    }
}
