﻿using System.Linq;
using System.IO;
using NUnit.Framework;
using ShortLegStudio;
using ShortLegStudio.RPG.Characters;
using ShortLegStudio.RPG.Equipment;

namespace RPG.Characters {

	[TestFixture]
	public class ArmorProficiencyTests {
		[Test]
		public void ArmorTypesCanBeDefinedAsProficieny() {
			var prof = new ArmorProficiency("Light");
			var armor = new Armor();
			armor.ArmorType = ArmorType.Light;

			Assert.IsTrue(prof.IsProficient(armor));
			armor.ArmorType = ArmorType.Heavy;

			Assert.IsFalse(prof.IsProficient(armor));
		}


		[Test]
		public void MatchesBasedOnNameIfNotTrainingLevel() {
			var prof = new ArmorProficiency("Hide");
			var armor = new Armor();
			armor.Name = "Leather";
			Assert.IsFalse(prof.IsProficient(armor));
			armor.Name = "Hide";
			Assert.IsTrue(prof.IsProficient(armor));
		}
	}
}