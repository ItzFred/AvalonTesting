﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

class ChaosEye : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Chaos Eye");
        Tooltip.SetDefault("Critical strike chance increases as your health drops\n8% increased critical strike chance");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = 3450000;
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().chaosCharm = true;
        player.GetCritChance(DamageClass.Generic) += 8;
    }
}
