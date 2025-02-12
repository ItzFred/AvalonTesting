﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Walls;

public class ContagionNaturalWall2 : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(81, 86, 47));
        WallID.Sets.Conversion.HardenedSand[Type] = true;
    }
}