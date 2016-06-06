﻿using System;
using System.Collections.Generic;

namespace ShortLegStudio.RPG.Characters {
	public class SizeStats : ISizeStats, IModifiesStats {
		const int STEALTH_MODIFIER = 4;
		const int FLY_MODIFIER = 2;

		public CharacterSize Size { get; private set; }
		public int Height { get; private set; }
		public int Weight { get; private set; }
		public int SizeModifier { get; private set; }
		public System.Collections.Generic.IList<BasicStatModifier> Modifiers { get; private set; }

		//Accessories to common attributes modified
		private BasicStatModifier StealthAdj { get; set; }
		private BasicStatModifier FlyAdj { get; set; }

		public SizeStats() : this(CharacterSize.Medium, 72, 180) { }
		public SizeStats(CharacterSize size) : this(size, 72, 180) { }
		public SizeStats (CharacterSize size, int height, int weight) {
			SetupSkillModifiers ();
			SetSize (size, height, weight);
		}

		public void SetSize (CharacterSize size, int height, int weight)
		{
			Size = size;
			Height = height;
			Weight = weight;
			SizeModifier = (int)size;

			UpdateStealth ();
			UpdateFly ();
		}


		private void SetupSkillModifiers() {
			StealthAdj = new BasicStatModifier ("Stealth", 0, "size", "Size");
			FlyAdj = new BasicStatModifier ("Fly", 0, "size", "Size");

			Modifiers = new List<BasicStatModifier> ();
			Modifiers.Add (StealthAdj);
			Modifiers.Add (FlyAdj);
		}

		private void UpdateStealth() {
			//Small = 4, Tiny = 8, Diminuitive = 12, fine = 16
			//Large = -4....
			StealthAdj.Modifier = GetSkillMultiplier() * STEALTH_MODIFIER;
		}

		private void UpdateFly() {
			FlyAdj.Modifier = GetSkillMultiplier () * FLY_MODIFIER;
		}

		private int GetSkillMultiplier() {
			//8 == 4
			//4 == 3
			//2 == 2
			//1 == 1
			int mod = (int)Size;
			if (Math.Abs (mod) == 8) {
				mod = 4 * Math.Sign (mod);
			} else if (Math.Abs (mod) == 4) {
				mod = 3 * Math.Sign (mod);
			}

			return mod;
		}
	}
}

