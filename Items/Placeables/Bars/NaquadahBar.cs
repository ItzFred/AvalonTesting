﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeables.Bars;

class NaquadahBar : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Naquadah Bar");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.PlacedBars>();
        Item.placeStyle = 10;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.value = Item.sellPrice(0, 0, 56, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}