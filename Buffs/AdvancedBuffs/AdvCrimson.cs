﻿using AvalonTesting.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvCrimson : ModBuff
{
    private const int FrameInterval = 50;
    private const int MaxDistance = 620;

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Aura Drain");
        Description.SetDefault("On-screen enemies take damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.GetModPlayer<ExxoBuffPlayer>().FrameCount % FrameInterval != 0)
        {
            return;
        }

        foreach (NPC npc in Main.npc)
        {
            if (!npc.townNPC && npc.active && !npc.dontTakeDamage && !npc.friendly && npc.life >= 1 &&
                npc.position.Distance(player.position) < MaxDistance && !npc.boss && npc.realLife < 0 &&
                npc.type != NPCID.GrayGrunt)
            {
                npc.StrikeNPC(2, 0f, 1);
            }
        }
    }
}
