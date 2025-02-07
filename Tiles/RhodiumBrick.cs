﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class RhodiumBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Pink);
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.RhodiumBrick>();
        HitSound = SoundID.Tink;
        DustType = DustID.t_LivingWood;
    }
}
