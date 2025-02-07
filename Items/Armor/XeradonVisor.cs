﻿using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class XeradonVisor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Xeradon Visor");
        Tooltip.SetDefault("15% increased mining speed\n15% increased block placement speed");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 10;
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 2);
        Item.height = dims.Height;
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<XeradonArmor>() && legs.type == ModContent.ItemType<XeradonLeggings>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "+5 block range and reduced enemy spawns and aggression\nEmitting light";
        Player.tileRangeX += 5;
        Player.tileRangeY += 5;
        player.GetModPlayer<ExxoBuffPlayer>().AdvancedCalming = true;
        player.aggro -= 250;
        Lighting.AddLight(player.position, 1.5f, 1.5f, 1.5f);
    }
    public override void UpdateEquip(Player player)
    {
        player.wallSpeed += 0.15f;
        player.tileSpeed += 0.15f;
        player.pickSpeed -= 0.15f;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.MiningHelmet).AddIngredient(ItemID.AdamantiteBar, 3).AddIngredient(ItemID.TitaniumBar, 3).AddIngredient(ModContent.ItemType<Placeable.Bar.TroxiniumBar>(), 3).AddTile(TileID.MythrilAnvil).Register();
    }
}
