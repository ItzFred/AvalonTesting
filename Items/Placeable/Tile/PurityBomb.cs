﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Tile;

class PurityBomb : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Purity Bomb");
        Tooltip.SetDefault("Converts tiles to the Purity in a large radius");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.maxStack = 999;
        Item.mech = true;
        Item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
        Item.placeStyle = 0;
        Item.consumable = true;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}
