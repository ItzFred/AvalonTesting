﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvObsidianSkin : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Obsidian Skin");
        Description.SetDefault("Immune to lava");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lavaImmune = true;
    }
}
