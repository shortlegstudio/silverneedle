﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using ShortLegStudio.RPG.Characters;
using ShortLegStudio.RPG.Mechanics.CharacterGenerator;
using System.Linq;
using System.Collections.Generic;
using ShortLegStudio.RPG.Equipment;
using ShortLegStudio;
using ShortLegStudio.RPG.Equipment.Gateways;


namespace RPG.Mechanics.CharacterGenerator {
	[TestFixture]
	public class EquipMeleeAndRangedWeaponTests {
		[Test]
		public void CharactersGetARangedAndMeleeWeaponTheyAreProficientIn() {
			//Bad test, but good enough for now
			for (int i = 0; i < 1000; i++) {
				var inventory = new Inventory ();
				var repo = new EquipMeleeAndRangedWeapon (new WeaponTestRepo ());
				var proficiencies = new WeaponProficiency[] { new WeaponProficiency("simple"), new WeaponProficiency("martial") };
				repo.AssignWeapons (inventory, proficiencies);
				Assert.AreEqual (inventory.Weapons.Count (), 2);
				Assert.IsTrue (inventory.Weapons.Any (x => x.Type == WeaponType.Ranged));
				Assert.IsTrue (inventory.Weapons.Any (x => x.Type != WeaponType.Ranged));
				Assert.IsFalse(inventory.Weapons.Any(x => x.Level == WeaponTrainingLevel.Exotic));
			}
		}

		private class WeaponTestRepo : IWeaponGateway {
			public IEnumerable<Weapon> All() {
				var weapons = new List<Weapon> ();
				var wpn1 = new Weapon ("Mace", 0f, "1d6", 
					DamageTypes.Bludgeoning, 20, 2, 0, 
					WeaponType.OneHanded, WeaponGroup.Hammers, 
					WeaponTrainingLevel.Simple);
				var wpn2 = new Weapon ("Bow", 0, "1d6", 
					DamageTypes.Piercing, 20, 2, 0, 
					WeaponType.Ranged, WeaponGroup.Bows, 
					WeaponTrainingLevel.Martial);
				var wpn3 = new Weapon ("Never Pick", 0, "1d6", 
					DamageTypes.Piercing, 20, 2, 0, 
					WeaponType.Ranged, WeaponGroup.Bows, 
					WeaponTrainingLevel.Exotic);
				weapons.Add (wpn1);
				weapons.Add (wpn2);
				weapons.Add (wpn3);
				return weapons;
			}

			public IEnumerable<Weapon> FindByProficient(IEnumerable<WeaponProficiency> p) {
				return All().Where(x => p.IsProficient(x));
			}
		}
	}
}