﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvNightOwl : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Night Owl");
        Description.SetDefault("Increased night vision");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.nightVision = true;
    }
}
