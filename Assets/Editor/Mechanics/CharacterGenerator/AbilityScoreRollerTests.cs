﻿using NUnit.Framework;
using ShortLegStudio.RPG.Mechanics.CharacterGenerator;
using ShortLegStudio.RPG.Characters;

[TestFixture]
public class AbilityScoreRollerTests {
	[Test]
	public void CharactersCanRollSomeStats() {
		var abilities = new AbilityScores ();
		var roller = new AbilityScoreGenerator ();
		roller.RandomStandardHeroScores (abilities);

		Assert.GreaterOrEqual (abilities.GetScore (AbilityScoreTypes.Strength), 3);
		Assert.GreaterOrEqual (abilities.GetScore (AbilityScoreTypes.Charisma), 3);
		Assert.GreaterOrEqual (abilities.GetScore (AbilityScoreTypes.Intelligence), 3);

	}

	[Test]
	public void CreateAverageScores() {
		var abilities = new AbilityScores ();
		var roller = new AbilityScoreGenerator ();
		roller.CreateAverageCharacter (abilities);
		Assert.AreEqual (10, abilities.GetScore (AbilityScoreTypes.Strength));
		Assert.AreEqual (10, abilities.GetScore (AbilityScoreTypes.Dexterity));
		Assert.AreEqual (10, abilities.GetScore (AbilityScoreTypes.Constitution));
		Assert.AreEqual (10, abilities.GetScore (AbilityScoreTypes.Intelligence));
		Assert.AreEqual (10, abilities.GetScore (AbilityScoreTypes.Wisdom));
		Assert.AreEqual (10, abilities.GetScore (AbilityScoreTypes.Charisma));

	}
}
