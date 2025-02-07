﻿using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles;

public class SacredLyreShockwaveNote : ModProjectile
{
    int timer = 0;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lyre Note");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = 21;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.light = 0.8f;
        Projectile.penetrate = -1;
        Projectile.friendly = true;
        Projectile.timeLeft = 840;
        timer = 0;
    }
    public override bool PreAI()
    {
        Lighting.AddLight(Projectile.position, 255 / 255, 72 / 255, 217 / 255);
        return true;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.type == ModContent.ProjectileType<SacredLyreShockwaveNote>())
        {
            //Main.PlaySound(SoundID.Item10, Projectile.position);
            if (timer % 4 == 0)
            {
                Vector2 c = Projectile.Center;
                float rot = (float)Math.Atan2(c.Y - 1, c.X - 1);
                for (float f = 0; f < 3.6f; f += 0.4f)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), c.X, c.Y, (float)(Math.Cos(rot + f) * 4f * -1.0), (float)(Math.Sin(rot + f) * 4f * -1.0), ModContent.ProjectileType<Shockwave>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), c.X, c.Y, (float)(Math.Cos(rot - f) * 4f * -1.0), (float)(Math.Sin(rot - f) * 4f * -1.0), ModContent.ProjectileType<Shockwave>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
                }
            }

            //int p = Projectile.NewProjectile(projectile.position, Vector2.Zero, ModContent.ProjectileType<Shockwave2>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
            //Main.projectile[p].Center = projectile.Center;
            //Main.projectile[p].ai[0] = projectile.Center.X;
            //Main.projectile[p].ai[1] = projectile.Center.Y;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 9f)
            {
                Projectile.position += Projectile.velocity;
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
            }
        }
        return false;
    }
}
