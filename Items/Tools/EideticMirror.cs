﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Tools;

class EideticMirror : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Team Mirror");
        Tooltip.SetDefault("Teleports you to a team member in multiplayer\nCan also be used as a magic mirror");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightPurple;
        Item.width = dims.Width;
        Item.useTime = 90;
        Item.useTurn = true;
        Item.value = Item.sellPrice(0, 2, 0, 0);
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useAnimation = 90;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item6;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1).AddIngredient(ItemID.MagicMirror).AddRecipeGroup("AvalonTesting:GoldBar", 10).AddIngredient(ModContent.ItemType<Material.BloodshotLens>(), 4).AddTile(TileID.Anvils).ReplaceResult(ModContent.ItemType<EideticMirror>());

        //recipe = new ModRecipe(mod);
        //recipe.AddIngredient(ItemID.MagicMirror);
        //recipe.AddIngredient(ItemID.PlatinumBar, 10);
        //recipe.AddIngredient(ModContent.ItemType<Material.BloodshotLens>(), 3);
        //recipe.AddTile(TileID.Anvils);
        //recipe.SetResult(ModContent.ItemType<EideticMirror>());
        //recipe.AddRecipe();
    }
    public override bool CanUseItem(Player player)
    {
        return true;
    }
    public override void UseStyle(Player player, Rectangle r)
    {
        if (Main.rand.Next(2) == 0)
        {
            Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.1f);
        }
        if (player.itemTime == 0)
        {
            player.itemTime = Item.useTime;
        }
        else if (player.itemTime == Item.useTime / 2)
        {
            for (int num345 = 0; num345 < 70; num345++)
            {
                Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
            }
            player.grappling[0] = -1;
            player.grapCount = 0;
            for (int num346 = 0; num346 < 1000; num346++)
            {
                if (Main.projectile[num346].active && Main.projectile[num346].owner == player.whoAmI && Main.projectile[num346].aiStyle == 7)
                {
                    Main.projectile[num346].Kill();
                }
            }
            player.Spawn(PlayerSpawnContext.RecallFromItem);
            for (int num347 = 0; num347 < 70; num347++)
            {
                Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.5f);
            }
        }
    }
}
