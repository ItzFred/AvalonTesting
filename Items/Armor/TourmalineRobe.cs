﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class TourmalineRobe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Tourmaline Robe");
        Tooltip.SetDefault("Increases maximum mana by 100\nReduces mana usage by 15%");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 5;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 50, 0) * 3;
        Item.height = dims.Height;
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<TourmalineRobe>() && (head.type == ItemID.WizardHat || head.type == ItemID.MagicHat);
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.Robe).AddIngredient(ModContent.ItemType<Placeable.Tile.Tourmaline>(), 10).AddTile(TileID.Loom).Register();
    }
    public override void UpdateArmorSet(Player player)
    {
        if (player.head == 14)
        {
            player.setBonus = "10% increased magic critical strike chance";
            player.GetCritChance(DamageClass.Magic) += 10;
        }
        else if (player.head == 159)
        {
            player.setBonus = "Increases maximum mana by 60";
            player.statManaMax2 += 60;
        }
    }
    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 100;
        player.manaCost -= 0.15f;
    }
}
