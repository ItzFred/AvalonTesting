﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

internal class BagofIck : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bag of Ick");
        Tooltip.SetDefault("Icky particles cover you when you move");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Green;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.vanity = true;
        Item.value = Item.sellPrice(0, 1);
        Item.height = dims.Height;
        Item.GetGlobalItem<AvalonTestingGlobalItemInstance>().UpdateInvisibleVanity = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        if (!hideVisual)
        {
            UpdateVanity(player);
        }
    }

    public override void UpdateVanity(Player player)
    {
        if (!(player.velocity.Length() > 0))
        {
            return;
        }

        int dust1 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.CorruptGibs, 0f, 0f, 100,
            Color.White, 0.9f);
        Main.dust[dust1].noGravity = true;
        int dust2 = Dust.NewDust(player.position, player.width - 20, player.height, DustID.CorruptGibs, 0f, 0f, 100,
            Color.White, 1.5f);
        Main.dust[dust2].noGravity = true;
    }
}
