﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using ShortLegStudio.RPG.Characters;
using ShortLegStudio.RPG.Characters.Generators;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class CharacterSheetTests {
	CharacterSheet character;

	[SetUp]
	public void SetupCharacter() {

	}

    [Test]
    public void CharactersHaveVitalStats() {
		var sheet = new CharacterSheet ();
		sheet.Name = "Foobar";
		sheet.Alignment = CharacterAlignment.LawfulGood;
		sheet.Height = 72;
		sheet.Weight = 150;
		Assert.AreEqual ("Foobar", sheet.Name);
		Assert.AreEqual (CharacterAlignment.LawfulGood, sheet.Alignment);
		Assert.AreEqual (72, sheet.Height);
		Assert.AreEqual (150, sheet.Weight);
		Assert.AreEqual (1, sheet.Level);
    }

	[Test]
	public void CharactersCanRollSomeStats() {
		var sheet = new CharacterSheet ();

		sheet.SetAbilityScores(AbilityScoreGenerator.RandomStandardHeroScores());
		Assert.IsNotNull (sheet.GetAbility (AbilityScoreTypes.Strength));
		Assert.IsNotNull (sheet.GetAbility (AbilityScoreTypes.Charisma));
		Assert.IsNotNull (sheet.GetAbility (AbilityScoreTypes.Intelligence));

	}

	[Test]
	public void CharactersCanHaveAbilitiesSet() {
		var sheet = new CharacterSheet ();
		var abilityScore = new AbilityScore (AbilityScoreTypes.Strength, 15);
		sheet.SetAbility (abilityScore);
		Assert.AreEqual (sheet.GetAbility(AbilityScoreTypes.Strength), abilityScore);
	}

	[Test]
	public void SettingTheSameAbilityScoreOverwrites() {
		var sheet = new CharacterSheet ();
		var score1 = new AbilityScore (AbilityScoreTypes.Strength, 15);
		var score2 = new AbilityScore (AbilityScoreTypes.Strength, 17);

		sheet.SetAbility (score1);
		sheet.SetAbility (score2);
		Assert.AreEqual(score2, sheet.GetAbility(AbilityScoreTypes.Strength));
	}

	[Test]
	public void YouMayGetTheAbilityModifier() {
		var sheet = new CharacterSheet ();
		var score = new AbilityScore (AbilityScoreTypes.Charisma, 5);
		sheet.SetAbility (score);

		Assert.AreEqual (score.BaseModifier, sheet.GetAbilityModifier (AbilityScoreTypes.Charisma));
	}

	[Test]
	public void YouMaySetAbilityScores() {
		var sheet = new CharacterSheet ();
		sheet.SetAbility (AbilityScoreTypes.Charisma, 12);
		Assert.AreEqual (12, sheet.GetAbilityScore (AbilityScoreTypes.Charisma));
	}

	[Test]
	public void SetAllTheSkills() {
		var skills = new List<Skill> ();
		skills.Add (new Skill ("Climb", AbilityScoreTypes.Strength, false));
		skills.Add (new Skill ("Disable Device", AbilityScoreTypes.Dexterity, true));

		var sheet = new CharacterSheet ();
		sheet.SetAbilityScores (AbilityScoreGenerator.RandomStandardHeroScores ());
		sheet.SetSkills (skills);
		var strength = sheet.GetAbilityModifier (AbilityScoreTypes.Strength);

		Assert.AreEqual (strength, sheet.GetSkillValue ("Climb"));
		Assert.AreEqual (int.MinValue, sheet.GetSkillValue ("Disable Device"));
	}

	[Test]
	public void CalculatesSkillPointsBasedOnClassAndIntelligence() {
		var sheet = new CharacterSheet ();
		var fighter = new Class ();
		fighter.SkillPoints = 2;
		sheet.SetAbility (AbilityScoreTypes.Intelligence, 14);
		sheet.Class = fighter;
		Assert.AreEqual (4, sheet.GetSkillPointsPerLevel());
	}

	[Test]
	public void SettingRaceLoadsTraits() {
		var sheet = new CharacterSheet ();

		//Set up the trait
		var trait = new Trait ();
		trait.Name = "Elfy";
		Trait.SetTraits (new List<Trait> () { trait });

		//Set up the race
		var elf = new Race ();
		elf.Traits.Add ("Elfy");

		sheet.SetRace (elf);
		Assert.IsTrue(sheet.Traits.Any(x => x == trait));
		Trait.SetTraits (null);
	}

	[Test]
	public void AddTraitTriggersModifiedEvent() {
		bool called = false;

		CharacterSheet sheet = new CharacterSheet ();
		sheet.Modified += (object sender, CharacterSheetEventArgs e) => {
			called = true;
		};

		//Set up the trait
		var trait = new Trait ();
		trait.Name = "Elfy";
		Trait.SetTraits (new List<Trait> () { trait });

		sheet.AddTrait ("Elfy");

		//Make sure the event was called
		Assert.IsTrue (called);
	}

	[Test]
	public void AccessAllSkillAdjustments() {
		var sheet = new CharacterSheet ();
		var trait = new Trait ();
		trait.SkillModifiers.Add(
			new SkillAdjustment(
				"Trait Adj",
				3,
				"Heal"
			)
		);

		trait.SkillModifiers.Add(
			new SkillAdjustment(
				"Trait Adj",
				3,
				"Heal"
			)
		);

		trait.SkillModifiers.Add(
			new SkillAdjustment(
				"Trait Adj",
				3,
				"Fly"
			)
		);
		sheet.AddTrait (trait);

		var adjustments = sheet.FindSkillAdjustments ("Heal");
		Assert.AreEqual (2, adjustments.Count);

	}
}