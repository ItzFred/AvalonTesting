﻿using AvalonTesting.Buffs;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AvalonTesting.Gores;

public class IcyExplosionGore3 : ModGore
{
    public override bool Update(Gore gore)
    {
        foreach (NPC n in Main.npc)
        {
            if (n.getRect().Intersects(new Rectangle((int)gore.position.X, (int)gore.position.Y, 32, 32)))
            {
                n.AddBuff(ModContent.BuffType<IcySlowdown>(), 60 * 10);
            }
        }
        gore.velocity *= 0.98f;
        gore.scale -= 0.007f;
        if (gore.scale < 0.1)
        {
            gore.scale = 0.1f;
            gore.alpha = 255;
        }
        return true;
    }
}
