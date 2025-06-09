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
    public class BaseWorldGeneratorTest
    {
        #region Dependencies

        private IBaseWorldGenerator _baseWorldGenerator;

        #endregion

        #region Test Initialization

        public BaseWorldGeneratorTest()
        {
            _baseWorldGenerator = new BaseWorldGenerator();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void GenerateTest()
        {
            #region Arrange

            Size worldSize = new Size(300, 200);

            #endregion

            #region Act

            Cell[,] world = _baseWorldGenerator.Generate(worldSize);

            #endregion

            #region Assert

            Assert.Equal(300, world.GetLength(0));
            Assert.Equal(200, world.GetLength(1));
            Assert.Equal(60000, world.Length);
            Assert.Equal(new Point(50, 20), world[50, 20].Location);

            #endregion
        }

        [Fact]
        public void ZeroSizeTest()
        {
            #region Arrange

            Size worldSize = new Size(0, 0);

            #endregion

            #region Act and Assert

            Assert.Throws<ArgumentException>(() => _baseWorldGenerator.Generate(worldSize));

            #endregion
        }

        [Fact]
        public void WrongSizeTest()
        {
            #region Arrange

            Size worldSize = new Size(-200, -100);

            #endregion

            #region Act and Assert

            Assert.Throws<ArgumentException>(() => _baseWorldGenerator.Generate(worldSize));

            #endregion
        }

        #endregion
    }
}
