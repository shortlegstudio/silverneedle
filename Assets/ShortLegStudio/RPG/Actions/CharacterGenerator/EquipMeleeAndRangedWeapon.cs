﻿//-----------------------------------------------------------------------
// <copyright file="EquipMeleeAndRangedWeapon.cs" company="Short Leg Studio, LLC">
//     Copyright (c) Short Leg Studio, LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ShortLegStudio.RPG.Mechanics.CharacterGenerator
{
    using System.Collections.Generic;
    using System.Linq;
    using ShortLegStudio;
    using ShortLegStudio.RPG.Characters;
    using ShortLegStudio.RPG.Equipment;
    using ShortLegStudio.RPG.Equipment.Gateways;

    /// <summary>
    /// Equip melee and ranged weapon selects the weapons for this character to prepare (and purchase)
    /// </summary>
    public class EquipMeleeAndRangedWeapon
    {
        /// <summary>
        /// The weapon gateway.
        /// </summary>
        private IWeaponGateway weaponGateway;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ShortLegStudio.RPG.Mechanics.CharacterGenerator.EquipMeleeAndRangedWeapon"/> class.
        /// </summary>
        /// <param name="weapons">Weapons available for purchase</param>
        public EquipMeleeAndRangedWeapon(IWeaponGateway weapons)
        {
            this.weaponGateway = weapons;
        }

        /// <summary>
        /// Assigns the weapons.
        /// </summary>
        /// <param name="inv">Inventory to assign to.</param>
        /// <param name="proficiencies">Proficiencies for this character.</param>
        public void AssignWeapons(Inventory inv, IEnumerable<WeaponProficiency> proficiencies)
        {
            var melee = this.weaponGateway.FindByProficient(proficiencies).Where(x => x.Type != WeaponType.Ranged).ToList();
            var ranged = this.weaponGateway.FindByProficient(proficiencies).Where(x => x.Type == WeaponType.Ranged).ToList();

            inv.AddGear(melee.ChooseOne());
            inv.AddGear(ranged.ChooseOne());
        }
    }
}