﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

class DullingTalisman : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dulling Talisman");
        Tooltip.SetDefault("Provides life regeneration");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.lifeRegen = 2;
        Item.defense = 10;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 63, 0);
        Item.accessory = true;
        Item.height = dims.Height;
    }
}
