﻿using AvalonTesting.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Weapons.Summon;

class PrimeStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Prime Staff");
        Tooltip.SetDefault("Summons the might of Skeletron to fight for you");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Summon;
        Item.damage = 50;
        Item.shootSpeed = 14f;
        Item.mana = 14;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.knockBack = 6.5f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.PriminiCannon>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item44;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile(source, player.Center.X - 40f, player.Center.Y - 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiCannon>(), damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, player.Center.X + 40f, player.Center.Y - 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiLaser>(), damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, player.Center.X - 40f, player.Center.Y + 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiSaw>(), damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, player.Center.X + 40f, player.Center.Y + 40f, 0f, 0f, ModContent.ProjectileType<Projectiles.Summon.PriminiVice>(), damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }
}
