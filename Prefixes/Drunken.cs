﻿using Terraria.ModLoader;

namespace AvalonTesting.Prefixes;

public class Drunken : ModPrefix
{
    public Drunken()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Melee; } }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 0.9f;
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        knockbackMult = 0.93f;
        damageMult = 1.25f;
        critBonus = -2;
        useTimeMult = 1.1f;
        scaleMult = 1.3f;
    }
}
