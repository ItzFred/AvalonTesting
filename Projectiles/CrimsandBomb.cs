using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles;

public class CrimsandBomb : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crimsand Bomb");
    }

    public override void SetDefaults()
    {
        Projectile.width = 20;
        Projectile.height = 20;
        Projectile.friendly = true;
        Projectile.penetrate = -1;

        Projectile.timeLeft = 300;

        DrawOffsetX = 5;
        DrawOriginOffsetY = 5;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.ai[1] != 0)
        {
            return true;
        }
        return false;
    }

    public override void AI()
    {
        if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
        {
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
            Projectile.position = Projectile.Center;
            Projectile.width = 250;
            Projectile.height = 250;
            Projectile.Center = Projectile.position;
            Projectile.damage = 250;
            Projectile.knockBack = 10f;
        }
        else
        {
            if (Main.rand.NextBool())
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2 - 6)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
            }
        }
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] > 5f)
        {
            Projectile.ai[0] = 10f;
            if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
            {
                Projectile.velocity.X = Projectile.velocity.X * 0.97f;
                {
                    Projectile.velocity.X = Projectile.velocity.X * 0.99f;
                }
                if ((double)Projectile.velocity.X > -0.01 && (double)Projectile.velocity.X < 0.01)
                {
                    Projectile.velocity.X = 0f;
                    Projectile.netUpdate = true;
                }
            }
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        Projectile.rotation += Projectile.velocity.X * 0.1f;
        return;
    }

    public override void Kill(int timeLeft)
    {
        if (Main.myPlayer != Projectile.owner)
        {
            return;
        }
        int choice = Main.rand.Next(1);
        if (choice == 0)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
        }

        int num = Main.rand.Next(1);
        if (num == 0)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
        }

        int num2 = Main.rand.Next(1);
        if (num2 == 0)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
        }

        int num3 = Main.rand.Next(1);
        if (num3 == 0)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
        }

        int num4 = Main.rand.Next(1);
        if (num4 == 0)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ProjectileID.CrimsandBallFalling, 24, 1f, Main.myPlayer, 0f, 0f);
        }
        for (int i = 0; i < 50; i++)
        {
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dustIndex].velocity *= 1.4f;
        }
        for (int i = 0; i < 80; i++)
        {
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
            Main.dust[dustIndex].noGravity = true;
            Main.dust[dustIndex].velocity *= 5f;
            dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dustIndex].velocity *= 3f;
        }
        for (int g = 0; g < 2; g++)
        {
            int goreIndex = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[goreIndex].scale = 1.5f;
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
            goreIndex = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[goreIndex].scale = 1.5f;
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
            goreIndex = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[goreIndex].scale = 1.5f;
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
            goreIndex = Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[goreIndex].scale = 1.5f;
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
        }
        Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
        Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
        Projectile.width = 10;
        Projectile.height = 10;
        Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
        Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);

        {
            int explosionRadius = 4;
            {
                explosionRadius = 5;
            }
            int minTileX = (int)(Projectile.position.X / 16f - (float)explosionRadius);
            int maxTileX = (int)(Projectile.position.X / 16f + (float)explosionRadius);
            int minTileY = (int)(Projectile.position.Y / 16f - (float)explosionRadius);
            int maxTileY = (int)(Projectile.position.Y / 16f + (float)explosionRadius);
            if (minTileX < 0)
            {
                minTileX = 0;
            }
            if (maxTileX > Main.maxTilesX)
            {
                maxTileX = Main.maxTilesX;
            }
            if (minTileY < 0)
            {
                minTileY = 0;
            }
            if (maxTileY > Main.maxTilesY)
            {
                maxTileY = Main.maxTilesY;
            }
            bool canKillWalls = false;
            for (int x = minTileX; x <= maxTileX; x++)
            {
                for (int y = minTileY; y <= maxTileY; y++)
                {
                    float diffX = Math.Abs((float)x - Projectile.position.X / 16f);
                    float diffY = Math.Abs((float)y - Projectile.position.Y / 16f);
                    double distance = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                    if (distance < (double)explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].WallType == 0)
                    {
                        canKillWalls = true;
                        break;
                    }
                }
            }
            AchievementsHelper.CurrentlyMining = true;
            for (int i = minTileX; i <= maxTileX; i++)
            {
                for (int j = minTileY; j <= maxTileY; j++)
                {
                    float diffX = Math.Abs((float)i - Projectile.position.X / 16f);
                    float diffY = Math.Abs((float)j - Projectile.position.Y / 16f);
                    double distanceToTile = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                    if (distanceToTile < (double)explosionRadius)
                    {
                        bool canKillTile = true;
                        if (Main.tile[i, j] != null && Main.tile[i, j].HasTile)
                        {
                            canKillTile = true;
                            if (Main.tileDungeon[(int)Main.tile[i, j].TileType] || Main.tile[i, j].TileType == 88 || Main.tile[i, j].TileType == 21 || Main.tile[i, j].TileType == 26 || Main.tile[i, j].TileType == 107 || Main.tile[i, j].TileType == 108 || Main.tile[i, j].TileType == 111 || Main.tile[i, j].TileType == 226 || Main.tile[i, j].TileType == 237 || Main.tile[i, j].TileType == 221 || Main.tile[i, j].TileType == 222 || Main.tile[i, j].TileType == 223 || Main.tile[i, j].TileType == 211 || Main.tile[i, j].TileType == 404)
                            {
                                canKillTile = false;
                            }
                            if (!Main.hardMode && Main.tile[i, j].TileType == 58)
                            {
                                canKillTile = false;
                            }
                            if (!TileLoader.CanExplode(i, j))
                            {
                                canKillTile = false;
                            }
                            if (canKillTile)
                            {
                                WorldGen.KillTile(i, j, false, false, false);
                                if (!Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
                                {
                                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
                                }
                            }
                        }
                        if (canKillTile)
                        {
                            for (int x = i - 1; x <= i + 1; x++)
                            {
                                for (int y = j - 1; y <= j + 1; y++)
                                {
                                    if (Main.tile[x, y] != null && Main.tile[x, y].WallType > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].WallType))
                                    {
                                        WorldGen.KillWall(x, y, false);
                                        if (Main.tile[x, y].WallType == 0 && Main.netMode != NetmodeID.SinglePlayer)
                                        {
                                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            AchievementsHelper.CurrentlyMining = false;
        }
    }
}
