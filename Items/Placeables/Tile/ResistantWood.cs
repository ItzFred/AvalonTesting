﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeables.Tile;

class ResistantWood : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Resistant Wood");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.ResistantWood>();
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.useTurn = true;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }

    public override bool? CanBurnInLava()
    {
        return false;
    }
}