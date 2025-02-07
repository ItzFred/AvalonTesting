﻿using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Consumables;

class TeleportScroll : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Teleport Scroll");
        Tooltip.SetDefault("Unlocks stamina teleport");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.width = dims.Width;
        Item.useTime = 20;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.UseSound = new SoundStyle($"{nameof(AvalonTesting)}/Sounds/Item/Scroll");
        Item.useAnimation = 20;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Book).AddIngredient(ModContent.ItemType<Material.ChaosDust>(), 15).AddIngredient(ItemID.SoulofSight, 5).AddIngredient(ModContent.ItemType<StaminaCrystal>()).AddTile(TileID.Bookcases).Register();
    }
    public override bool CanUseItem(Player player)
    {
        return !player.GetModPlayer<ExxoStaminaPlayer>().TeleportUnlocked;
    }
    public override bool? UseItem(Player player)
    {
        player.GetModPlayer<ExxoStaminaPlayer>().TeleportUnlocked = true;
        return true;
    }
}
