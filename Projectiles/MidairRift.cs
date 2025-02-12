﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using AvalonTesting.Players;
using AvalonTesting.Systems;

namespace AvalonTesting.Projectiles;

public class MidairRift : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rift");
    }

    public override void SetDefaults()
    {
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = -1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.penetrate = -1;
        Projectile.light = 0.7f;
        Projectile.friendly = true;
        Projectile.tileCollide = false;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255);
    }
    public override void AI()
    {
        Projectile.velocity *= 0f;
        Projectile.ai[0]++;
        if (Projectile.ai[1] == 0)
        {
            if (Projectile.ai[0] % 60 == 0)
            {
                Player p = Main.player[Player.FindClosest(Projectile.position, Projectile.width, Projectile.height)];
                if (ModContent.GetInstance<ExxoWorldGen>().WorldEvil == ExxoWorldGen.EvilBiome.Corruption) // corruption world
                {
                    if (p.ZoneCorrupt)
                    {
                        if (Main.rand.Next(2) == 0) // crimson mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Crimslime);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Herpling);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.IchorSticker);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.FloatyGross);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(3);
                                if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Crimera);
                                if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.FaceMonster);
                                if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.BloodCrawler);
                            }
                        }
                        else // contagion mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Ickslime>());
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Cougher>());
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Viris>());
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.GrossyFloat>());
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Bactus>());
                                if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.PyrasiteHead>());
                                //if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                            }
                        }
                    }
                }
                else if (ModContent.GetInstance<ExxoWorldGen>().WorldEvil == ExxoWorldGen.EvilBiome.Contagion) // contagion world
                {
                    if (p.GetModPlayer<ExxoBiomePlayer>().ZoneContagion)
                    {
                        if (Main.rand.Next(2) == 0) // crimson mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Crimslime);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Herpling);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.IchorSticker);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.FloatyGross);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(3);
                                if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Crimera);
                                if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.FaceMonster);
                                if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.BloodCrawler);
                            }
                        }
                        else // corruption mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.CorruptSlime);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Slimer);
                                    if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Corruptor);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.SeekerHead);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.CorruptSlime);
                                    if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Corruptor);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.EaterofSouls);
                                if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.DevourerHead);
                                //if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                            }
                        }
                    }
                }
                else if (WorldGen.crimson) // crimson
                {
                    if (p.ZoneCrimson)
                    {
                        if (Main.rand.Next(2) == 0) // corruption mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.CorruptSlime);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Slimer);
                                    if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Corruptor);
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(3);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.SeekerHead);
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.CorruptSlime);
                                    if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.Corruptor);
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.EaterofSouls);
                                if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, NPCID.DevourerHead);
                                //if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                            }
                        }
                        else // contagion mobs
                        {
                            if (Main.hardMode)
                            {
                                if (p.position.Y < Main.worldSurface)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Ickslime>());
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Cougher>());
                                }
                                else if (p.ZoneRockLayerHeight)
                                {
                                    int t = Main.rand.Next(2);
                                    if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Viris>());
                                    if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.GrossyFloat>());
                                }
                            }
                            else
                            {
                                int t = Main.rand.Next(2);
                                if (t == 0) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.Bactus>());
                                if (t == 1) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)Projectile.position.X, (int)Projectile.position.Y, ModContent.NPCType<NPCs.PyrasiteHead>());
                                //if (t == 2) NPC.NewNPC(Projectile.GetSource_FromThis(), (int)projectile.position.X, (int)projectile.position.Y, NPCID.BloodCrawler);
                            }
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    int num893 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Enchanted_Pink, 0f, 0f, 0, default, 1f);
                    Main.dust[num893].velocity *= 2f;
                    Main.dust[num893].scale = 0.9f;
                    Main.dust[num893].noGravity = true;
                    Main.dust[num893].fadeIn = 3f;
                }
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }
        }
        else if (Projectile.ai[1] == 1)
        {
            Point tile = Projectile.position.ToTileCoordinates();
            for (int x = tile.X - 10; x < tile.X + 10; x++)
            {
                for (int y = tile.Y - 10; x < tile.Y + 10; y++)
                {

                }
            }
        }
        if (Projectile.ai[0] >= 200) Projectile.Kill();
    }
    //public override void Kill(int timeLeft)
    //{
    //    Main.PlaySound(SoundID.Item10, Projectile.position);
    //    for (int num394 = 4; num394 < 24; num394++)
    //    {
    //        float num395 = projectile.oldVelocity.X * (30f / (float)num394);
    //        float num396 = projectile.oldVelocity.Y * (30f / (float)num394);
    //        int num397 = Main.rand.Next(3);
    //        if (num397 == 0)
    //        {
    //            num397 = 15;
    //        }
    //        else if (num397 == 1)
    //        {
    //            num397 = 57;
    //        }
    //        else
    //        {
    //            num397 = 58;
    //        }
    //        int num398 = Dust.NewDust(new Vector2(projectile.position.X - num395, projectile.position.Y - num396), 8, 8, num397, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f, 100, default(Color), 1.8f);
    //        Main.dust[num398].velocity *= 1.5f;
    //        Main.dust[num398].noGravity = true;
    //    }
    //}
}
