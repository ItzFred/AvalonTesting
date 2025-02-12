﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

class ManaCompromise : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mana Compromise");
        Tooltip.SetDefault("Increases maximum mana by 100\n10% decreased magic damage and 7% decreased mana usage");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 6, 70, 0);
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statManaMax2 += 100;
        player.GetDamage(DamageClass.Magic) -= 0.1f;
        player.manaCost -= 0.07f;
    }
}
