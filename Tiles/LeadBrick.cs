﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class LeadBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(62, 82, 114));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemDrop = Mod.Find<ModItem>("LeadBrick").Type;
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        DustType = DustID.Lead;
    }
}