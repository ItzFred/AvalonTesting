﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvSummoning : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Summoning");
        Description.SetDefault("Increased max number of minions");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.maxMinions += 2;
    }
}
