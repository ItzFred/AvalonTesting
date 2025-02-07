﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class AstralProjecting : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Astral Projecting");
        Description.SetDefault(
            "You are immune to damage, but cannot attack anything - touch mobs to inflict a debuff on them");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.immune = true;
        player.immuneAlpha = 130;
        player.noItems = true;
        player.thorns = 0f;

        if (player.whoAmI != Main.myPlayer)
        {
            return;
        }

        foreach (NPC n in Main.npc)
        {
            if (n.townNPC || n.dontTakeDamage)
            {
                continue;
            }

            if (player.getRect().Intersects(n.getRect()))
            {
                n.AddBuff(ModContent.BuffType<AstralCurse>(), 60 * 45);
            }
        }
    }
}
