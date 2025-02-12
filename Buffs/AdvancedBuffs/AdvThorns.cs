﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvThorns : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Thorns");
        Description.SetDefault("Attackers also take full damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.turtleArmor = true;
        player.thorns = 1f;
    }
}
