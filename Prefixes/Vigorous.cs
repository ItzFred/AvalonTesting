﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Prefixes;

public class Vigorous : ModPrefix
{
    public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }

    public override void Apply(Item item)
    {
        Main.player[Main.myPlayer].GetAttackSpeed(DamageClass.Melee) += 0.03f;
        Main.player[Main.myPlayer].GetDamage(DamageClass.Melee) += 0.03f;
        Main.player[Main.myPlayer].GetDamage(DamageClass.Ranged) += 0.03f;
        Main.player[Main.myPlayer].GetDamage(DamageClass.Magic) += 0.03f;
        Main.player[Main.myPlayer].GetDamage(DamageClass.Summon) += 0.03f;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
    }
}
