﻿using System;
using System.Collections.Generic;

namespace ShortLegStudio.RPG.Characters {
	public interface ISkillModifier {
		IList<SkillAdjustment> SkillModifiers { get; }
	}
}
