﻿using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

internal class BloodyWhetstone : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloody Whetstone");
        Tooltip.SetDefault("Melee attacks inflict bleeding");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 3);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<ExxoBuffPlayer>().BloodyWhetstone = true;
    }
}
