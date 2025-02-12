﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace AvalonTesting.Items.Other;

class MechanicalWhoopieCushion : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechanical Whoopie Cushion");
        Tooltip.SetDefault("'Contains mechanical farts only'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.rare = ModContent.RarityType<Rarities.AvalonRarity>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 30;
        Item.useStyle = 10;
        Item.value = 69;
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }

    public override bool? UseItem(Player player)
    {
        SoundEngine.PlaySound(new SoundStyle($"{nameof(AvalonTesting)}/Sounds/Item/MechanicalFart"));
        return true;
    }
}
