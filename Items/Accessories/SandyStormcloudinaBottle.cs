﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

class SandyStormcloudinaBottle : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sandy Stormcloud in a Bottle");
        Tooltip.SetDefault("The holder can quadruple jump");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.hasJumpOption_Cloud = true;
        player.hasJumpOption_Blizzard = true;
        player.hasJumpOption_Sandstorm = true;
    }
}
