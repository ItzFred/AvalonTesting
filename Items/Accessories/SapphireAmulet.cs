﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

class SapphireAmulet : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sapphire Amulet");
        Tooltip.SetDefault("Increases maximum mana by 40");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Blue;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 0, 30);
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statManaMax2 += 40;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Sapphire, 12).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
    }
}
