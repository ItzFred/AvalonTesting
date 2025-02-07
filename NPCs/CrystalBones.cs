﻿using System;
using AvalonTesting.Items.Banners;
using AvalonTesting.Items.Placeable.Tile;
using AvalonTesting.Players;
using AvalonTesting.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class CrystalBones : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crystal Bones");
        Main.npcFrameCount[NPC.type] = 15;
    }

    public override void SetDefaults()
    {
        NPC.damage = 122;
        NPC.lifeMax = 3500;
        NPC.defense = 15;
        NPC.lavaImmune = true;
        NPC.width = 18;
        NPC.aiStyle = 3;
        NPC.value = 50000f;
        NPC.height = 40;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath2;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<CrystalBonesBanner>();
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.7f);
        NPC.damage = (int)(NPC.damage * 0.5f);
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
            NPC.frame.Y = frameHeight;
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        Main.hardMode && spawnInfo.Player.GetModPlayer<ExxoBiomePlayer>().ZoneCrystal
            ? 0.8f * AvalonTestingGlobalNPC.EndoSpawnRate
            : 0f;

    public override void OnKill()
    {
        for (int i = 0; i < 8; i++)
        {
            float speedX = NPC.velocity.X + (Main.rand.Next(-51, 51) * 0.2f);
            float speedY = NPC.velocity.Y + (Main.rand.Next(-51, 51) * 0.2f);
            int proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position, new Vector2(speedX, speedY),
                ModContent.ProjectileType<CrystalShard>(), 100, 0.3f);
            Main.projectile[proj].timeLeft = 300;
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) =>
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrystalStoneBlock>(), 1, 10, 15));

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("CrystalBonesHead").Type);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("CrystalBonesArm").Type);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("CrystalBonesArm").Type);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("CrystalBonesLeg").Type);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("CrystalBonesLeg").Type);
        }
    }
}
