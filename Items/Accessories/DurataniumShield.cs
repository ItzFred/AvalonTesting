﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

class DurataniumShield : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Duratanium Shield");
        Tooltip.SetDefault("Slows the effects of damage over time debuffs");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 2;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.value = 54000;
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.Avalon().duraShield = true;
    }
}
