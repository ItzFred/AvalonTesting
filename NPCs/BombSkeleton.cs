﻿using System;
using AvalonTesting.Items.Banners;
using AvalonTesting.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class BombSkeleton : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bomb Skeleton");
        Main.npcFrameCount[NPC.type] = 15;
        var debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new[] { BuffID.Confused, BuffID.Poisoned },
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 90;
        NPC.lifeMax = 1000;
        NPC.defense = 50;
        NPC.width = 18;
        NPC.aiStyle = 3;
        NPC.value = 40000f;
        NPC.height = 40;
        NPC.knockBackResist = 0.05f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<BombSkeletonBanner>();
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.35f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }

    public override void OnKill()
    {
        float num2 = 13f;
        var vector = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
        int num3 = 120;
        int num4 = ModContent.ProjectileType<SkeletonHeadbomb>();
        float num5 =
            (float)Math.Atan2(vector.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)),
                vector.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
        int num6 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector.X, vector.Y,
            (float)(Math.Cos(num5) * num2 * -1.0), (float)(Math.Sin(num5) * num2 * -1.0), num4, num3, 0f, 0);
        Main.projectile[num6].velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * 8f;
        NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<BombBones>(),
            NPC.whoAmI);
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.Y == 0f)
        {
            if (NPC.direction == 1)
            {
                NPC.spriteDirection = 1;
            }

            if (NPC.direction == -1)
            {
                NPC.spriteDirection = -1;
            }

            if (NPC.velocity.X == 0f)
            {
                NPC.frame.Y = 0;
                NPC.frameCounter = 0.0;
            }
            else
            {
                NPC.frameCounter += Math.Abs(NPC.velocity.X) * 2f;
                NPC.frameCounter += 1.0;
                if (NPC.frameCounter > 6.0)
                {
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                    NPC.frameCounter = 0.0;
                }

                if (NPC.frame.Y / frameHeight >= Main.npcFrameCount[NPC.type])
                {
                    NPC.frame.Y = frameHeight * 2;
                }
            }
        }
        else
        {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = 0;
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        Main.hardMode && ModContent.GetInstance<AvalonTestingWorld>().SuperHardmode &&
        spawnInfo.Player.ZoneRockLayerHeight
            ? 0.1f * AvalonTestingGlobalNPC.EndoSpawnRate
            : 0f;
}
