﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvLifeforce : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Lifeforce");
        Description.SetDefault("30% increased max life");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeForce = true;
        player.statLifeMax2 += player.statLifeMax / 100 * 30;
    }
}
