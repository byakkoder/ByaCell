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
using System;

namespace ByaCellLib.Test
{
    [TestClass]
    public class GenerationRunnerTest
    {
        #region Dependencies
        
        private IGenerationRunner _generationRunner;
        private Mock<ILifeValidator> _lifeValidator; 

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void Initialize()
        {
            _lifeValidator = new Mock<ILifeValidator>();

            _generationRunner = new GenerationRunner(_lifeValidator.Object);
        }

        #endregion

        #region Test Methods
        
        [TestMethod]
        public void RunTest()
        {
            #region Arrange
            
            Cell[,] sourceGeneration = new Cell[3, 3]
            {
                { new Cell(), new Cell(), new Cell() },
                { new Cell(), new Cell(), new Cell() },
                { new Cell(), new Cell(), new Cell() }
            };

            _lifeValidator.Setup(x => x.IsAlive(sourceGeneration, sourceGeneration[1, 1])).Returns(true);

            #endregion

            #region Act
            
            Cell[,] newGeneration = _generationRunner.Run(sourceGeneration);

            #endregion

            #region Assert
            
            Assert.AreEqual(9, newGeneration.Length);
            Assert.AreEqual(3, newGeneration.GetLength(0));
            Assert.AreEqual(3, newGeneration.GetLength(1));
            Assert.AreNotSame(newGeneration, sourceGeneration);
            _lifeValidator.Verify(x => x.IsAlive(sourceGeneration, It.IsAny<Cell>()), Times.Exactly(9));
            Assert.AreEqual(true, newGeneration[1, 1].IsAlive); 

            #endregion
        }

        [TestMethod]
        public void WrongSizeTest()
        {
            #region Arrange
            
            Cell[,] sourceGeneration = new Cell[2, 2]
            {
                { new Cell(), new Cell() },
                { new Cell(), new Cell() }
            };

            #endregion

            #region Act and Assert
            
            Assert.ThrowsException<ArgumentException>(() => _generationRunner.Run(sourceGeneration)); 

            #endregion
        } 

        #endregion
    }
}
