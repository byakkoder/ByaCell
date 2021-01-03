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

using Unity;

namespace Bootstrapper
{
    public static class DIContainerManager
    {
        #region Fields
        
        private static IUnityContainer _unityContainer;

        #endregion

        #region Public Methods
        
        public static IUnityContainer GetContainer()
        {
            if (_unityContainer == null)
            {
                _unityContainer = new UnityContainer();
            }

            return _unityContainer;
        } 

        #endregion
    }
}
