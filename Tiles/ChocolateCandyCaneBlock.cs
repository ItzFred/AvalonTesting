﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class ChocolateCandyCaneBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Brown);
        Main.tileSolid[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.ChocolateCandyCaneBlock>();
    }
}
