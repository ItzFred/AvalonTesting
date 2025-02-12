﻿using AvalonTesting.Items.Material;
using AvalonTesting.Items.Placeable.Bar;
using AvalonTesting.Players;
using AvalonTesting.Rarities;
using AvalonTesting.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
internal class BlahsWings : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blah's Wings");
        Tooltip.SetDefault(
            "Allows flight and slow fall and the wearer can run incredibly fast\nThe wearer has a chance to dodge attacks and negates fall damage\nOther various effects");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 4;
        Item.rare = ModContent.RarityType<BlahRarity>();
        Item.width = dims.Width;
        Item.value = Item.sellPrice(2);
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient(ModContent.ItemType<Placeable.Tile.Phantoplasm>(), 40)
            .AddIngredient(ModContent.ItemType<SuperhardmodeBar>(), 20)
            .AddIngredient(ModContent.ItemType<SoulofTorture>(), 25).AddIngredient(ModContent.ItemType<InertiaBoots>())
            .AddIngredient(ModContent.ItemType<GuardianBoots>()).AddIngredient(ItemID.PhilosophersStone)
            .AddIngredient(ModContent.ItemType<SouloftheGolem>()).AddIngredient(ModContent.ItemType<ForsakenRelic>())
            .AddIngredient(ModContent.ItemType<BubbleBoost>()).AddIngredient(ModContent.ItemType<LuckyPapyrus>())
            .AddTile(ModContent.TileType<SolariumAnvil>()).Register();
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().blahWings = true;
        player.GetModPlayer<ExxoBuffPlayer>().NoSticky = true;
        player.pStone = true;
        player.Avalon().bubbleBoost = true;
        player.Avalon().trapImmune =
            player.Avalon().heartGolem =
                player.Avalon().ethHeart =
                    player.Avalon().longInvince2 = true;
        player.wingTime = 1000;
        if (player.immune)
        {
            player.GetCritChance(DamageClass.Generic) += 7;
            player.GetDamage(DamageClass.Generic) += 0.07f;
        }

        player.accRunSpeed = 10.29f;
        player.rocketBoots = 2;
        player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
        player.noFallDmg = true;
        player.blackBelt = true;
        player.iceSkate = true;

        if (player.controlUp && player.controlJump)
        {
            player.velocity.Y = player.velocity.Y - (1f * player.gravDir);
            if (player.gravDir == 1f)
            {
                if (player.velocity.Y > 0f)
                {
                    player.velocity.Y = player.velocity.Y - 1f;
                }
                else if (player.velocity.Y > -Player.jumpSpeed)
                {
                    player.velocity.Y = player.velocity.Y - 0.5f;
                }

                if (player.velocity.Y < -Player.jumpSpeed * 6f)
                {
                    player.velocity.Y = -Player.jumpSpeed * 6f;
                }
            }
            else
            {
                if (player.velocity.Y < 0f)
                {
                    player.velocity.Y = player.velocity.Y + 1f;
                }
                else if (player.velocity.Y < Player.jumpSpeed)
                {
                    player.velocity.Y = player.velocity.Y + 0.5f;
                }

                if (player.velocity.Y > Player.jumpSpeed * 6f)
                {
                    player.velocity.Y = Player.jumpSpeed * 6f;
                }
            }
        }

        if (player.controlLeft)
        {
            if (player.velocity.X > -5f)
            {
                player.velocity.X = player.velocity.X - 0.31f;
            }

            if (player.velocity.X < -5f && player.velocity.X > -10f)
            {
                player.velocity.X = player.velocity.X - 0.29f;
            }
        }

        if (player.controlRight)
        {
            if (player.velocity.X < 5f)
            {
                player.velocity.X = player.velocity.X + 0.31f;
            }

            if (player.velocity.X > 5f && player.velocity.X < 10f)
            {
                player.velocity.X = player.velocity.X + 0.29f;
            }
        }

        if (player.velocity.X > 6f || player.velocity.X < -6f)
        {
            var newColor2 = default(Color);
            int num2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height,
                DustID.Torch, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor2, 2f);
            Main.dust[num2].noGravity = true;
        }

        player.wallSpeed += 4.5f;
        player.tileSpeed += 4.5f;
    }
}
