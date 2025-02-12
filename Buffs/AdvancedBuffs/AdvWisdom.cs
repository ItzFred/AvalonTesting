﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvWisdom : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Wisdom");
        Description.SetDefault("-4% magic damage, +120 mana");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Magic) -= 0.04f;
        player.statManaMax2 += 120;
    }
}
