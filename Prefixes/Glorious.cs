﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Prefixes;

public class Glorious : ArmorPrefix
{
    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Generic) += 0.04f;
        player.statDefense++;
    }
}
