﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace AvalonTesting.Items.Weapons.Ranged;

class Thompson : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Thompson");
        //Tooltip.SetDefault("");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.damage = 9;
        Item.autoReuse = true;
        Item.shootSpeed = 10f;
        Item.useAmmo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.rare = ItemRarityID.Green;
        Item.noMelee = true;
        Item.width = dims.Width;
        Item.useTime = 5;
        Item.knockBack = 1f;
        Item.shoot = ProjectileID.Bullet;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.value = Item.sellPrice(0, 2);
        Item.reuseDelay = 5;
        Item.useAnimation = 5;
        Item.height = dims.Height;
        //item.UseSound = SoundID.Item11;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-12, 0);
    }
    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        SoundEngine.PlaySound(SoundID.Item11 with { Volume = 0.9f, Pitch = 0.4f }, player.Center);
        Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        velocity = perturbedSpeed;
    }
}
