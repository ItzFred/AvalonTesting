﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles.Melee;

public class ShatterLance : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shatter Lance");
    }
    public override void SetDefaults()
    {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.aiStyle = 19;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.scale = 1.3f;
        Projectile.hide = true;
        Projectile.ownerHitCheck = true;
        Projectile.DamageType = DamageClass.Melee;
    }
    public float movementFactor
    {
        get => Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }
    public override void AI()
    {
        Player projOwner = Main.player[Projectile.owner];
        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
        Projectile.direction = projOwner.direction;
        Projectile.spriteDirection = -Projectile.direction;
        projOwner.heldProj = Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
        Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
        if (!projOwner.frozen)
        {
            if (movementFactor == 0f)
            {
                movementFactor = 3f;
                Projectile.netUpdate = true;
            }
            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
            {
                movementFactor -= 3.1f;
            }
            else
            {
                movementFactor += 2.8f;
            }
        }
        Projectile.position += Projectile.velocity * movementFactor;
        if (projOwner.itemAnimation == 0)
        {
            Projectile.Kill();
        }
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
        if (Projectile.spriteDirection == -1)
        {
            Projectile.rotation -= MathHelper.ToRadians(90f);
        }
        int num313 = Dust.NewDust(Projectile.position - Projectile.velocity * 3f, Projectile.width, Projectile.height, 70, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 140, default(Color), 1f);
        Main.dust[num313].noGravity = true;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
}