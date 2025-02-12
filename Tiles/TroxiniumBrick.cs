﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class TroxiniumBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Goldenrod);
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.TroxiniumBrick>();
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<Dusts.TroxiniumDust>();
    }
}
