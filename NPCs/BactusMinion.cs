using System;
using AvalonTesting.Items.Material;
using AvalonTesting.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class BactusMinion : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bactus Minion");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults()
    {
        NPC.damage = 25;
        NPC.lifeMax = 125;
        NPC.defense = 5;
        NPC.noGravity = true;
        NPC.width = 30;
        NPC.aiStyle = -1;
        NPC.noTileCollide = true;
        NPC.height = 30;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.knockBackResist = 0.8f;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        if (NPC.AnyNPCs(ModContent.NPCType<BacteriumPrime>()))
        {
            if (Main.rand.Next(3) != 0)
            {
                Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height,
                    ModContent.ItemType<Booger>(), Main.rand.Next(1, 4));
            }

            if (Main.rand.Next(3) != 0)
            {
                Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height,
                    ModContent.ItemType<BacciliteOre>(), Main.rand.Next(4, 11));
            }

            if (Main.rand.Next(2) == 0 &&
                Main.player[Player.FindClosest(NPC.position, NPC.width, NPC.height)].statLife <
                Main.player[Player.FindClosest(NPC.position, NPC.width, NPC.height)].statLifeMax2)
            {
                Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height,
                    ItemID.Heart);
            }
        }
    }

    public override void AI()
    {
        if (AvalonTestingGlobalNPC.BoogerBoss < 0)
        {
            NPC.active = false;
            NPC.netUpdate = true;
            return;
        }

        if (NPC.ai[0] == 0f)
        {
            var vector107 = new Vector2(NPC.Center.X, NPC.Center.Y);
            float num880 = Main.npc[AvalonTestingGlobalNPC.BoogerBoss].Center.X - vector107.X;
            float num881 = Main.npc[AvalonTestingGlobalNPC.BoogerBoss].Center.Y - vector107.Y;
            float num882 = (float)Math.Sqrt((num880 * num880) + (num881 * num881));
            if (num882 > 90f)
            {
                num882 = 8f / num882;
                num880 *= num882;
                num881 *= num882;
                NPC.velocity.X = ((NPC.velocity.X * 15f) + num880) / 16f;
                NPC.velocity.Y = ((NPC.velocity.Y * 15f) + num881) / 16f;
                return;
            }

            if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < 8f)
            {
                NPC.velocity.Y = NPC.velocity.Y * 1.05f;
                NPC.velocity.X = NPC.velocity.X * 1.05f;
            }

            if (Main.netMode != NetmodeID.MultiplayerClient && Main.rand.Next(200) == 0)
            {
                NPC.TargetClosest();
                vector107 = new Vector2(NPC.Center.X, NPC.Center.Y);
                num880 = Main.player[NPC.target].Center.X - vector107.X;
                num881 = Main.player[NPC.target].Center.Y - vector107.Y;
                num882 = (float)Math.Sqrt((num880 * num880) + (num881 * num881));
                num882 = 8f / num882;
                NPC.velocity.X = num880 * num882;
                NPC.velocity.Y = num881 * num882;
                NPC.ai[0] = 1f;
                NPC.netUpdate = true;
            }
        }
        else
        {
            var vector108 = new Vector2(NPC.Center.X, NPC.Center.Y);
            float num883 = Main.npc[AvalonTestingGlobalNPC.BoogerBoss].Center.X - vector108.X;
            float num884 = Main.npc[AvalonTestingGlobalNPC.BoogerBoss].Center.Y - vector108.Y;
            float num885 = (float)Math.Sqrt((num883 * num883) + (num884 * num884));
            if (num885 > 700f || NPC.justHit)
            {
                NPC.ai[0] = 0f;
            }
        }
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 8.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }

        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }
}
