﻿using AvalonTesting.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Weapons.Summon;

public class TitaniumDaggerStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Titanium Dagger Staff");
        Tooltip.SetDefault("Summons an titanium dagger to fight for you");
        ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
        ItemID.Sets.LockOnIgnoresCollision[Item.type] = false;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.width = dims.Width;
        Item.height = dims.Height;

        Item.damage = 27;
        Item.mana = 8;
        Item.rare = ItemRarityID.LightRed;
        Item.useTime = 30;
        Item.knockBack = 5.5f;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = Item.sellPrice(0, 3, 40);
        Item.useAnimation = 30;
        Item.UseSound = SoundID.Item44;

        Item.DamageType = DamageClass.Summon;
        Item.noMelee = true;
        Item.buffType = ModContent.BuffType<TitaniumDagger>();
        Item.shoot = ModContent.ProjectileType<Projectiles.Summon.TitaniumDagger>();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
                               int type, int damage, float knockback)
    {
        player.AddBuff(Item.buffType, 2);
        player.SpawnMinionOnCursor(source, player.whoAmI, type, damage, knockback);
        return false;
    }

    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient(ItemID.TitaniumBar, 22).AddTile(TileID.Anvils).Register();
    }
}
