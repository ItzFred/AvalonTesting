﻿using AvalonTesting.Items.Placeable.Bar;
using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Armor;

[AutoloadEquip(EquipType.Head)]
internal class DivineLightHuntingHorns : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Divine Light Hunting Horns");
        Tooltip.SetDefault("25% increased ranged damage");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 10;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 2, 10);
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.PixieDust, 20)
            .AddIngredient(ModContent.ItemType<CaesiumBar>(), 20)
            .AddIngredient(ItemID.SoulofLight, 10).AddTile(TileID.MythrilAnvil).Register();
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<DivineLightJerkin>() &&
               legs.type == ModContent.ItemType<DivineLightTreads>();
    }

    public override void UpdateArmorSet(Player player)
    {
        ExxoPlayer modPlayer = player.Avalon();
        player.setBonus = "Reckoning: your reckoning level increases as you attack enemies, up to a maximum of ten"
                          + "\nThe greater your reckoning level, the greater your ranged critical strike chance"
                          + "\nYour reckoning level decreases gradually over time"
                          + "\nReckoning Level: " + modPlayer.reckoningLevel;
        modPlayer.reckoning = true;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += 0.25f;
    }
}
