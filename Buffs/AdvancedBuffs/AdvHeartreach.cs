﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvHeartreach : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Heartreach");
        Description.SetDefault("Increased heart pickup range");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeMagnet = true;
    }
}
