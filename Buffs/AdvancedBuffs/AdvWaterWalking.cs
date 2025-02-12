﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvWaterWalking : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Water Walking");
        Description.SetDefault("Press DOWN to enter water");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.waterWalk = true;
    }
}
