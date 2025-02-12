﻿using System.Collections.Generic;
using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs.AdvancedBuffs;

public class AdvShockwave : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Shockwave");
        Description.SetDefault("Enemies take damage when you land");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        int sw = Main.screenWidth;
        int sh = Main.screenHeight;
        int sx = (int)Main.screenPosition.X;
        int sy = (int)Main.screenPosition.Y;

        int fall_dist = 0;
        if (player.velocity.Y == 0f) // detect landing from a fall
        {
            fall_dist = (int)(((int)(player.position.Y / 16f) - player.GetModPlayer<ExxoBuffPlayer>().OldFallStart) *
                              player.gravDir);
        }

        Vector2 p_pos = player.position + (new Vector2(player.width, player.height) / 2f);
        int numOfNPCs = 0;
        if (fall_dist > 3) // just fell
        {
            for (int o = 0; o < Main.npc.Length; o++)
            {
                // iterate through NPCs
                NPC N = Main.npc[o];
                var list = new List<NPC>();
                if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1)
                {
                    continue;
                }

                if (N.position.X >= sx && N.position.X <= sx + sw && N.position.Y >= sy && N.position.Y <= sy + sh)
                {
                    list.Add(N);
                }

                var n_pos = new Vector2(N.position.X + (N.width * 0.5f),
                    N.position.Y + (N.height * 0.5f)); // NPC location
                int HitDir = -1;
                if (n_pos.X > p_pos.X)
                {
                    HitDir = 1;
                }

                if (N.position.X >= sx && N.position.X <= sx + sw && N.position.Y >= sy && N.position.Y <= sy + sh)
                {
                    // on screen
                    numOfNPCs++;
                    int multiplier = 2;
                    if (player.GetModPlayer<ExxoBuffPlayer>().EarthInsignia && Main.hardMode)
                    {
                        multiplier = 6;
                    }
                    else if (!player.GetModPlayer<ExxoBuffPlayer>().EarthInsignia && Main.hardMode)
                    {
                        multiplier = 4;
                    }
                    else if (player.GetModPlayer<ExxoBuffPlayer>().EarthInsignia && !Main.hardMode)
                    {
                        multiplier = 3;
                    }
                    else if (!player.GetModPlayer<ExxoBuffPlayer>().EarthInsignia && !Main.hardMode)
                    {
                        multiplier = 2;
                    }

                    N.StrikeNPC(multiplier * fall_dist, 5f, HitDir);
                    if (Main.netMode != 0)
                    {
                        NetMessage.SendData(28, -1, -1, null, o, multiplier * fall_dist, 10f,
                            HitDir); // for multiplayer support
                    }

                    if (player.IsOnGround() && numOfNPCs == list.Count - 1)
                    {
                        break;
                    }
                    // optionally add debuff here
                } // END on screen
            } // END iterate through NPCs
        } // END just fell
    }
}
