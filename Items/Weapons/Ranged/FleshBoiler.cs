﻿using AvalonTesting.Items.Ammo;
using AvalonTesting.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Weapons.Ranged;

public class FleshBoiler : ModItem
{
    public override void SetStaticDefaults() => Tooltip.SetDefault("Uses canisters for ammo");

    public override void SetDefaults()
    {
        Item.damage = 55;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 74;
        Item.height = 34;
        Item.useTime = 4;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 0.6f;
        Item.value = 10000;
        Item.rare = ItemRarityID.Red;
        Item.UseSound = SoundID.Item34;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<FleshFire>();
        Item.shootSpeed = 10f;
        Item.useAmmo = ModContent.ItemType<Canister>();
    }

    // Vanilla Flamethrower uses the commented out code below to prevent shooting while underwater, but this weapon can shoot underwater, so we don't use this code. The projectile also is specifically programmed to survive underwater.
    /*public override bool CanUseItem(Player player)
    {
        return !player.wet;
    }*/
    public override bool CanConsumeAmmo(Item ammo, Player player) =>
        player.itemAnimation >= player.itemAnimationMax - 4;

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
                                          ref int damage, ref float knockback)
    {
        Vector2 muzzleOffset = Vector2.Normalize(velocity) * 54f;
        if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
        {
            position += muzzleOffset;
        }
    }

    public override Vector2? HoldoutOffset() => new Vector2(-7, -3);
}
