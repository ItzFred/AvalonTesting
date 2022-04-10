﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Walls;

public class DarkMatterStoneWall : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(51, 4, 88));
        soundType = SoundID.NPCKilled;
        soundStyle = 1;
        DustType = DustID.UnholyWater;
    }
}