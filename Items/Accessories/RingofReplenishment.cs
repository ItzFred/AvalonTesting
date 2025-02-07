﻿using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

internal class RingofReplenishment : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ring of Replenishment");
        Tooltip.SetDefault(
            "Automatically use mana and stamina potions when needed\nIncreases maximum stamina by 60\nReduces the cooldown of healing potions\nProvides life, mana, and stamina regeneration");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = Item.sellPrice(0, 9);
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient(ModContent.ItemType<RestorationBand>())
            .AddIngredient(ModContent.ItemType<StaminaFlower>()).AddIngredient(ItemID.CharmofMyths)
            .AddIngredient(ItemID.ManaFlower).AddTile(TileID.TinkerersWorkbench).Register();
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<ExxoStaminaPlayer>().StatStamMax2 += 60;
        player.manaFlower = true;
        player.GetModPlayer<ExxoStaminaPlayer>().StamFlower = true;
        player.pStone = true;
        player.lifeRegen += 2;
        player.manaRegen++;
        player.GetModPlayer<ExxoStaminaPlayer>().StaminaRegenCost = 1600;
    }
}
