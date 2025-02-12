﻿using System;
using AvalonTesting.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class GuardianCorruptor : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Guardian Corruptor");
        Main.npcFrameCount[NPC.type] = 3;
        var debuffData = new NPCDebuffImmunityData { SpecificallyImmuneTo = new[] { BuffID.Confused } };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void SetDefaults()
    {
        NPC.damage = 95;
        NPC.scale = 0.9f;
        NPC.lifeMax = 700;
        NPC.defense = 40;
        NPC.noGravity = true;
        NPC.width = 70;
        NPC.aiStyle = -1;
        NPC.npcSlots = 1f;
        NPC.value = 6500f;
        NPC.timeLeft = 1750;
        NPC.height = 100;
        NPC.knockBackResist = 0.15f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) =>
        npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, 1, 1, 3));

    public override void AI()
    {
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest();
        }

        float num1169 = 4.2f;
        float num1170 = 0.022f;
        var vector156 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
        float num1171 = Main.player[NPC.target].position.X + (Main.player[NPC.target].width / 2);
        float num1172 = Main.player[NPC.target].position.Y + (Main.player[NPC.target].height / 2);
        num1171 = (int)(num1171 / 8f) * 8;
        num1172 = (int)(num1172 / 8f) * 8;
        vector156.X = (int)(vector156.X / 8f) * 8;
        vector156.Y = (int)(vector156.Y / 8f) * 8;
        num1171 -= vector156.X;
        num1172 -= vector156.Y;
        float num1173 = (float)Math.Sqrt((num1171 * num1171) + (num1172 * num1172));
        float num1174 = num1173;
        if (num1173 == 0f)
        {
            num1171 = NPC.velocity.X;
            num1172 = NPC.velocity.Y;
        }
        else
        {
            num1173 = num1169 / num1173;
            num1171 *= num1173;
            num1172 *= num1173;
        }

        NPC.ai[0] += 1f;
        if (NPC.ai[0] > 0f)
        {
            NPC.velocity.Y = NPC.velocity.Y + 0.023f;
        }
        else
        {
            NPC.velocity.Y = NPC.velocity.Y - 0.023f;
        }

        if (NPC.ai[0] < -100f || NPC.ai[0] > 100f)
        {
            NPC.velocity.X = NPC.velocity.X + 0.023f;
        }
        else
        {
            NPC.velocity.X = NPC.velocity.X - 0.023f;
        }

        if (NPC.ai[0] > 200f)
        {
            NPC.ai[0] = -200f;
        }

        if (num1174 < 150f)
        {
            NPC.velocity.X = NPC.velocity.X + (num1171 * 0.007f);
            NPC.velocity.Y = NPC.velocity.Y + (num1172 * 0.007f);
        }

        if (Main.player[NPC.target].dead)
        {
            num1171 = NPC.direction * num1169 / 2f;
            num1172 = -num1169 / 2f;
        }

        if (NPC.velocity.X < num1171)
        {
            NPC.velocity.X = NPC.velocity.X + num1170;
            if (NPC.velocity.X < 0f && num1171 > 0f)
            {
                NPC.velocity.X = NPC.velocity.X + num1170;
            }
        }
        else if (NPC.velocity.X > num1171)
        {
            NPC.velocity.X = NPC.velocity.X - num1170;
            if (NPC.velocity.X > 0f && num1171 < 0f)
            {
                NPC.velocity.X = NPC.velocity.X - num1170;
            }
        }

        if (NPC.velocity.Y < num1172)
        {
            NPC.velocity.Y = NPC.velocity.Y + num1170;
            if (NPC.velocity.Y < 0f && num1172 > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y + num1170;
            }
        }
        else if (NPC.velocity.Y > num1172)
        {
            NPC.velocity.Y = NPC.velocity.Y - num1170;
            if (NPC.velocity.Y > 0f && num1172 < 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y - num1170;
            }
        }

        NPC.rotation = (float)Math.Atan2(num1172, num1171) - 1.57f;
        float num1179 = 0.7f;
        if (NPC.collideX)
        {
            NPC.netUpdate = true;
            NPC.velocity.X = NPC.oldVelocity.X * -num1179;
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
            NPC.velocity.Y = NPC.oldVelocity.Y * -num1179;
            if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1.5)
            {
                NPC.velocity.Y = 2f;
            }

            if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1.5)
            {
                NPC.velocity.Y = -2f;
            }
        }
        else if (Main.rand.Next(20) == 0)
        {
            int num1182 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (NPC.height * 0.25f)), NPC.width,
                (int)(NPC.height * 0.5f), DustID.CorruptGibs, NPC.velocity.X, 2f, 75, NPC.color, NPC.scale);
            Dust? dust52 = Main.dust[num1182];
            dust52.velocity.X = dust52.velocity.X * 0.5f;
            Dust? dust53 = Main.dust[num1182];
            dust53.velocity.Y = dust53.velocity.Y * 0.1f;
        }
        else if (Main.rand.Next(40) == 0)
        {
            int num1183 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (NPC.height * 0.25f)), NPC.width,
                (int)(NPC.height * 0.5f), DustID.Blood, NPC.velocity.X, 2f);
            Dust? dust54 = Main.dust[num1183];
            dust54.velocity.X = dust54.velocity.X * 0.5f;
            Dust? dust55 = Main.dust[num1183];
            dust55.velocity.Y = dust55.velocity.Y * 0.1f;
        }

        if (NPC.wet)
        {
            if (NPC.velocity.Y > 0f)
            {
                NPC.velocity.Y = NPC.velocity.Y * 0.95f;
            }

            NPC.velocity.Y = NPC.velocity.Y - 0.3f;
            if (NPC.velocity.Y < -2f)
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
                    Player? player5 = Main.player[NPC.target];
                    var vector158 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
                    float num1191 =
                        (float)Math.Atan2(vector158.Y - (player5.position.Y + (player5.height * 0.5f) + 40f),
                            vector158.X - (player5.position.X + (player5.width * 0.5f) + 40f));
                    int number2 = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.position.X + (NPC.width / 2),
                        NPC.position.Y + (NPC.height * 0.5f), -(float)Math.Cos(num1191) * 7f,
                        -(float)Math.Sin(num1191) * 7f, ModContent.ProjectileType<VileSpit>(), 70, 1f, NPC.target);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), number2);
                    }

                    float num1192 =
                        (float)Math.Atan2(vector158.Y - (player5.position.Y + (player5.height * 0.5f) - 40f),
                            vector158.X - (player5.position.X + (player5.width * 0.5f) - 40f));
                    int num1193 = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.position.X + (NPC.width / 2),
                        NPC.position.Y + (NPC.height * 0.5f), -(float)Math.Cos(num1192), -(float)Math.Sin(num1192),
                        ModContent.ProjectileType<VileSpit>(), 70, 1f, NPC.target);
                    Projectile? expr_4284B_cp_0 = Main.projectile[num1193];
                    expr_4284B_cp_0.velocity.X = expr_4284B_cp_0.velocity.X * 7f;
                    Projectile? expr_4286B_cp_0 = Main.projectile[num1193];
                    expr_4286B_cp_0.velocity.Y = expr_4286B_cp_0.velocity.Y * 7f;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num1193);
                    }

                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)(NPC.position.X + (NPC.width / 2) + NPC.velocity.X),
                        (int)(NPC.position.Y + (NPC.height / 2) + NPC.velocity.Y), NPCID.VileSpit);
                }

                NPC.localAI[0] = 0f;
            }
        }

        if (((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f) || (NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f) ||
             (NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f) || (NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f)) &&
            !NPC.justHit)
        {
            NPC.netUpdate = true;
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("GuardianCorruptor1").Type, 0.9f);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("GuardianCorruptor2").Type, 0.9f);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("GuardianCorruptor3").Type, 0.9f);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity,
                Mod.Find<ModGore>("GuardianCorruptor4").Type, 0.9f);
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        spawnInfo.Player.ZoneCorrupt && !spawnInfo.Player.InPillarZone() && Main.hardMode &&
        ModContent.GetInstance<AvalonTestingWorld>().SuperHardmode
            ? 0.066f * AvalonTestingGlobalNPC.EndoSpawnRate
            : 0f;
}
