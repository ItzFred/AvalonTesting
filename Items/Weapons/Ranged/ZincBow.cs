﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Weapons.Ranged;

class ZincBow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Zinc Bow");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item5;
        Item.damage = 12;
        Item.scale = 1f;
        Item.shootSpeed = 6.5f;
        Item.useAmmo = AmmoID.Arrow;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true; /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
        Item.width = dims.Width;
        Item.useTime = 25;
        Item.knockBack = 0f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 4500;
        Item.useAnimation = 25;
        Item.height = dims.Height;
    }
}
