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

using ByaCellLib;
using Interfaces;
using Unity;

namespace Bootstrapper
{
    public static class UnityDIInitializer
    {
        #region Fields

        private static bool _isInitialized;

        #endregion

        #region Public Methods
        
        public static void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            IUnityContainer unityContainer = DIContainerManager.GetContainer();

            unityContainer.RegisterType<IBaseWorldGenerator, BaseWorldGenerator>();
            unityContainer.RegisterType<IGenerationRunner, GenerationRunner>();
            unityContainer.RegisterType<ILifeValidator, LifeValidator>();
            unityContainer.RegisterType<ILivingNeighborsCounter, LivingNeighborsCounter>();

            _isInitialized = true;
        } 

        #endregion
    }
}
