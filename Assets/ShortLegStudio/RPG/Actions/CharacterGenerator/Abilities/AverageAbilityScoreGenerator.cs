﻿//-----------------------------------------------------------------------
// <copyright file="AverageAbilityScoreGenerator.cs" company="Short Leg Studio, LLC">
//     Copyright (c) Short Leg Studio, LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ShortLegStudio.RPG.Mechanics.CharacterGenerator.Abilities
{
    using ShortLegStudio;
    using ShortLegStudio.RPG.Characters;

    /// <summary>
    /// Generates ability scores with just your basic average score. Useful for a base line or to
    /// make sure things are initialized properly
    /// </summary>
    public class AverageAbilityScoreGenerator : IAbilityScoreGenerator
    {
        /// <summary>
        /// The average score.
        /// </summary>
        private const int AverageScore = 10;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ShortLegStudio.RPG.Mechanics.CharacterGenerator.Abilities.AverageAbilityScoreGenerator"/> class.
        /// </summary>
        public AverageAbilityScoreGenerator()
        {
        }

        /// <summary>
        /// Assigns the ability scores to the character
        /// </summary>
        /// <param name="abilities">Abilities to assign score to.</param>
        public void AssignAbilities(AbilityScores abilities)
        {
            foreach (var e in EnumHelpers.GetValues<AbilityScoreTypes>())
            {
                abilities.SetScore(e, AverageScore);
            }
        }
    }
}