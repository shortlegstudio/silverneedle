﻿//-----------------------------------------------------------------------
// <copyright file="IWeaponGateway.cs" company="Short Leg Studio, LLC">
//     Copyright (c) Short Leg Studio, LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ShortLegStudio.RPG.Equipment.Gateways
{
    using System.Collections.Generic;
    using ShortLegStudio.RPG.Characters;

    /// <summary>
    /// Weapon gateways provide access to weapon data
    /// </summary>
    public interface IWeaponGateway
    {
        /// <summary>
        /// All this instance.
        /// </summary>
        /// <returns>All weapons loaded</returns>
        IEnumerable<Weapon> All();

        /// <summary>
        /// Finds weapons by proficiencies.
        /// </summary>
        /// <returns>The by proficient.</returns>
        /// <param name="proficiencies">Proficiencies to find by.</param>
        IEnumerable<Weapon> FindByProficient(IEnumerable<WeaponProficiency> proficiencies);
    }
}