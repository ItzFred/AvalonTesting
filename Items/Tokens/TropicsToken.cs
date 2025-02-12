﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Tokens;

class TropicsToken : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tropics Token");
        Tooltip.SetDefault("Used to make things\nGathered in the Tropics");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.rare = ItemRarityID.Blue;
        Item.maxStack = 999;
        Item.value = 0;
        Item.height = dims.Height;
    }
}
