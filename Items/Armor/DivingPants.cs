﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
class DivingPants : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Diving Pants");
        Tooltip.SetDefault("Greatly extends underwater breathing\n10% increased damage while in water");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 3;
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 0, 20, 0);
        Item.height = dims.Height;
    }

    public override void UpdateEquip(Player player)
    {
        player.breathMax *= 3; //TODO: fix.
        if (player.wet)
        {
            player.GetDamage(DamageClass.Generic) += 0.1f;
        }
    }
}
