﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles;

public class SunCharm : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sun Charm");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Projectile.aiStyle = -1;
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.damage = 0;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        if (Projectile.active)
        {
            Main.dayTime = true;
            Main.time = 0.0;
            Main.eclipse = true;
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("A solar eclipse is happening!", 50, 255, 130);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("A solar eclipse is happening!"), new Color(50, 255, 130));
            }
        }
        Projectile.active = false;
        return;
    }
}
