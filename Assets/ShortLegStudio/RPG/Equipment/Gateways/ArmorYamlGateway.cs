﻿using System;
using ShortLegStudio.Enchilada;
using ShortLegStudio.RPG.Equipment;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShortLegStudio.RPG.Equipment.Gateways {
	public class ArmorYamlGateway : EntityGateway<Armor> {
		private IList<Armor> _armors;

		public ArmorYamlGateway (YamlNodeWrapper yaml) {
			LoadFromYaml (yaml);
		}

		public System.Collections.Generic.IEnumerable<Armor> All () {
			return _armors;
		}

		public Armor GetArmorByName(string name) {
			return _armors.FirstOrDefault (x => x.Name == name);
		}

		private void LoadFromYaml(YamlNodeWrapper yaml) {
			_armors = new List<Armor> ();

			foreach (var node in yaml.Children()) {
				var armor = new Armor (
					node.GetString("name"),
					node.GetInteger("armor_class"),
					node.GetFloat("weight"),
					node.GetInteger("maximum_dexterity_bonus"),
					node.GetInteger("armor_check_penalty"),
					node.GetInteger("arcane_spell_failure_chance")
				);

				_armors.Add (armor);
			}
		}
	}
}

