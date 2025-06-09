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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace Bootstrapper
{
    public static class DIInitializer
    {
        #region Fields

        private static bool _isInitialized;

        #endregion

        #region Properties

        public static IServiceProvider ServiceProvider { get; private set; }

        #endregion

        #region Public Methods

        public static void Initialize(List<Type> additionalTransientDependencies)
        {
            if (_isInitialized)
            {
                return;
            }

            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices(services => services
                .AddScoped<IBaseWorldGenerator, BaseWorldGenerator>()
                .AddScoped<IGenerationRunner, GenerationRunner>()
                .AddScoped<ILifeValidator, LifeValidator>()
                .AddScoped<ILivingNeighborsCounter, LivingNeighborsCounter>());

            additionalTransientDependencies.ForEach(dependencyType =>
                builder.ConfigureServices(services => services.AddTransient(dependencyType)));

            var host = builder.Build();

            ServiceProvider = host.Services;

            _isInitialized = true;
        } 

        #endregion
    }
}
