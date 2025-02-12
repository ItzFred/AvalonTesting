﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Potions;

class BlahPotion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah Potion");
        Tooltip.SetDefault("Various effects");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.buffType = ModContent.BuffType<Buffs.Blah>();
        Item.UseSound = SoundID.Item3;
        Item.consumable = false;
        Item.rare = ModContent.RarityType<Rarities.BlahRarity>();
        Item.width = dims.Width;
        Item.useTime = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.maxStack = 1;
        Item.useAnimation = 15;
        Item.height = dims.Height;
        Item.buffTime = 1080000;
    }
}
