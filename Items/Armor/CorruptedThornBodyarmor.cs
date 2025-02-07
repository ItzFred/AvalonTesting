﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Armor;

[AutoloadEquip(EquipType.Body)]
class CorruptedThornBodyarmor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corrupted Thorn Bodyarmor");
        Tooltip.SetDefault("10% increased critical strike chance" +
                           "\n20% increased critical damage" +
                           "\nMax life increased by 40");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 18;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 1, 90, 0);
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Spike, 25)
            .AddIngredient(ModContent.ItemType<Material.CorruptShard>(), 25)
            .AddIngredient(ModContent.ItemType<Placeable.Bar.CaesiumBar>(), 25)
            .AddIngredient(ItemID.SoulofNight, 20).AddTile(TileID.MythrilAnvil).Register();
    }
    public override void UpdateEquip(Player player)
    {
        player.GetCritChance(DamageClass.Magic) += 10;
        player.GetCritChance(DamageClass.Melee) += 10;
        player.GetCritChance(DamageClass.Ranged) += 10;
        player.GetCritChance(DamageClass.Throwing) += 10;
        player.Avalon().CritDamageMult += 0.2f;
        player.statLifeMax2 += 40;
    }
}
