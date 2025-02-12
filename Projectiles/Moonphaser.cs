﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles;

public class Moonphaser : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moonphaser");
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
            Main.moonPhase++;
            if (Main.moonPhase >= 8)
            {
                Main.moonPhase = 0;
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                if (Main.moonPhase == 0)
                {
                    Main.NewText("Moon Phase is now Full.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 1)
                {
                    Main.NewText("Moon Phase is now Last Gibbous.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 2)
                {
                    Main.NewText("Moon Phase is now Last Quarter.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 3)
                {
                    Main.NewText("Moon Phase is now Last Crescent.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 4)
                {
                    Main.NewText("Moon Phase is now New.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 5)
                {
                    Main.NewText("Moon Phase is now First Crescent.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 6)
                {
                    Main.NewText("Moon Phase is now First Quarter.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 7)
                {
                    Main.NewText("Moon Phase is now First Gibbous.", 50, 255, 130);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130);
                    }
                    Projectile.active = false;
                    return;
                }
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                if (Main.moonPhase == 0)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Full."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 1)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Last Gibbous."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 2)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Last Quarter."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 3)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Last Crescent."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 4)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now New."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 5)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now First Crescent."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 6)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now First Quarter."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 7)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now First Gibbous."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                    return;
                }
            }
        }
    }
}
