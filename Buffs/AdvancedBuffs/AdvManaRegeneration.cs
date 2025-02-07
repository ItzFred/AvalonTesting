﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvManaRegeneration : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Mana Regeneration");
        Description.SetDefault("Increased mana regeneration");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.manaRegenBuff = true;
    }
}
