﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ancient;

public class AncientAdamantiteBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(202, 66, 133));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1750;
        Main.tileBlockLight[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.Ancient.AncientAdamantiteBrick>();
        HitSound = SoundID.Tink;
        DustType = DustID.Adamantite;
    }
}
