﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Weapons.Ranged;

class CaesiumRepeater : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Caesium Crossbow");
        Tooltip.SetDefault("Converts wooden arrows into hellfire arrows");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item5;
        Item.UseSound = SoundID.Item5;
        Item.damage = 53;
        Item.autoReuse = true;
        Item.useAmmo = AmmoID.Arrow;
        Item.shootSpeed = 16f;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Pink;
        Item.width = dims.Width;
        Item.useTime = 16;
        Item.knockBack = 2.75f;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = 75000;
        Item.useAnimation = 16;
        Item.height = dims.Height;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-3, 0);
    }
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        if (type == ProjectileID.WoodenArrowFriendly)
        {
            type = ProjectileID.HellfireArrow;
        }
    }
}
