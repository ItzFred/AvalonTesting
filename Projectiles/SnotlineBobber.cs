﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles;

public class SnotlineBobber : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Snotline Bobber");
    }

    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.BobberWooden);
        DrawOriginOffsetY = -8; // Adjusts the draw position
    }

    public override void ModifyFishingLine(ref Vector2 lineOriginOffset, ref Color lineColor)
    {
        lineOriginOffset = new Vector2(46, -33);
        lineColor = new Color(139, 143, 18);
    }
}
