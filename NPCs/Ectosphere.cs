﻿using System;
using AvalonTesting.Items.Banners;
using AvalonTesting.Items.Placeable.Tile;
using AvalonTesting.Projectiles;
using AvalonTesting.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class Ectosphere : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ectosphere");
        Main.npcFrameCount[NPC.type] = 7;
    }

    public override void SetDefaults()
    {
        NPC.damage = 120;
        NPC.lifeMax = 6000;
        NPC.defense = 10;
        NPC.noGravity = true;
        NPC.width = 46;
        NPC.aiStyle = -1;
        NPC.value = 20000f;
        NPC.height = 46;
        NPC.knockBackResist = 0.5f;
        NPC.HitSound = SoundID.NPCHit36;
        NPC.DeathSound = SoundID.NPCDeath39;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<EctosphereBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) =>
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
            new FlavorTextBestiaryInfoElement(
                "These spectres are heavily armored - they contain a large amount of ectoplasm as a result, however."),
        });

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.7f);
        NPC.damage = (int)(NPC.damage * 0.67f);
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Ectoplasm, 1, 2, 5));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Phantoplasm>(), 4, 3, 6));
    }

    public override void AI()
    {
        NPC.netUpdate = true;
        NPC.ai[1] += 1f;
        NPC.TargetClosest();
        Player? player7 = Main.player[NPC.target];
        float num1221 = 0.022f;
        float num1222 = player7.position.X + (player7.width / 2);
        float num1223 = player7.position.Y + (player7.height / 2);
        var vector164 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
        num1222 = (int)(num1222 / 8f) * 8;
        num1223 = (int)(num1223 / 8f) * 8;
        vector164.X = (int)(vector164.X / 8f) * 8;
        vector164.Y = (int)(vector164.Y / 8f) * 8;
        num1222 -= vector164.X;
        num1223 -= vector164.Y;
        if (player7.position.X + 300f < NPC.position.X || player7.position.X - 300f > NPC.position.X ||
            player7.position.Y + 300f < NPC.position.Y || player7.position.Y - 300f > NPC.position.Y)
        {
            if (player7.position.X + 300f < NPC.position.X)
            {
                if (NPC.velocity.X > -6f)
                {
                    NPC.velocity.X = NPC.velocity.X - 0.2f;
                }
            }
            else if (player7.position.X - 300f > NPC.position.X && NPC.velocity.X < 6f)
            {
                NPC.velocity.X = NPC.velocity.X + 0.2f;
            }

            if (player7.position.Y + 300f < NPC.position.Y)
            {
                if (NPC.velocity.Y > -6f)
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                }
            }
            else if (player7.position.Y - 300f > NPC.position.Y && NPC.velocity.Y < 6f)
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.2f;
            }
        }
        else
        {
            NPC.velocity.X = NPC.velocity.X * 0.95f;
            NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            NPC.ai[2] += 1f;
            if (NPC.ai[2] == 60f)
            {
                NPC.ai[0] = Main.rand.Next(-7, 7);
                NPC.velocity.X = NPC.velocity.X + NPC.ai[0];
                NPC.velocity.Y = NPC.velocity.Y + NPC.ai[0];
                NPC.ai[2] = 0f;
            }
        }

        Vector2 vector165 = NPC.velocity;
        NPC.velocity = Collision.TileCollision(NPC.position, NPC.velocity, NPC.width, NPC.height);
        if (NPC.velocity.X != vector165.X)
        {
            NPC.velocity.X = -vector165.X;
        }

        if (NPC.velocity.Y != vector165.Y)
        {
            NPC.velocity.Y = -vector165.Y;
        }

        if (NPC.type == NPCID.MoonLordHand)
        {
            NPC.rotation = (float)Math.Atan2(num1223, num1222) - 1.57f;
        }

        float num1224 = 0.7f;
        if (NPC.collideX)
        {
            NPC.netUpdate = true;
            NPC.velocity.X = NPC.oldVelocity.X * -num1224;
            if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 2f)
            {
                NPC.velocity.X = 2f;
            }

            if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -2f)
            {
                NPC.velocity.X = -2f;
            }
        }

        if (NPC.collideY)
        {
            NPC.netUpdate = true;
            NPC.velocity.Y = NPC.oldVelocity.Y * -num1224;
            if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1.5)
            {
                NPC.velocity.Y = 2f;
            }

            if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1.5)
            {
                NPC.velocity.Y = -2f;
            }
        }

        if (Main.netMode != NetmodeID.MultiplayerClient && !Main.player[NPC.target].dead)
        {
            if (NPC.justHit)
            {
                NPC.localAI[0] = 0f;
            }

            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] == 180f)
            {
                if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position,
                        Main.player[NPC.target].width, Main.player[NPC.target].height))
                {
                    NPC.localAI[1] = 1f;
                    int num1227 = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X + NPC.velocity.X,
                        NPC.Center.Y + NPC.velocity.Y, 1f, 1f, ModContent.ProjectileType<Ectosoul>(), 75, 3f,
                        NPC.target);
                    Main.projectile[num1227].velocity =
                        Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * 7f;
                }

                NPC.localAI[0] = 0f;
                NPC.localAI[1] = 0f;
            }
        }

        if (!Main.dayTime || !Main.player[NPC.target].dead)
        {
            return;
        }

        NPC.velocity.Y = NPC.velocity.Y - (num1221 * 2f);
        if (NPC.timeLeft > 10)
        {
            NPC.timeLeft = 10;
        }

        if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) ||
             (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) &&
            !NPC.justHit)
        {
            NPC.netUpdate = true;
        }
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.localAI[1] > 0f)
        {
            NPC.frame.Y = frameHeight * 6;
        }
        else
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 6.0)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight;
                NPC.frameCounter = 0.0;
            }

            if (NPC.frame.Y >= frameHeight * (Main.npcFrameCount[NPC.type] - 1))
            {
                NPC.frame.Y = 0;
            }
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        spawnInfo.Player.ZoneDungeon && Main.hardMode && ModContent.GetInstance<DownedBossSystem>().DownedArmageddon &&
        ModContent.GetInstance<AvalonTestingWorld>().SuperHardmode
            ? 0.083f * AvalonTestingGlobalNPC.EndoSpawnRate
            : 0f;
}
