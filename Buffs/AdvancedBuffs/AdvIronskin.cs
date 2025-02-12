﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvIronskin : ModBuff
{
    private const int DefenseIncrease = 12;

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Ironskin");
        Description.SetDefault($"Increases defense by {DefenseIncrease}");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += DefenseIncrease;
    }
}
