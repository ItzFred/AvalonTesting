﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Tools;

class SonicScrewdriverMkII : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sonic Screwdriver Mk II");
        Tooltip.SetDefault("Reveals treasures, ores, and mobs\nTells time and shows position");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.rare = ItemRarityID.LightPurple;
        Item.width = dims.Width;
        Item.useTime = 70;
        Item.value = Item.sellPrice(0, 4, 0, 0);
        Item.useStyle = ItemUseStyleID.Thrust;
        Item.useAnimation = 70;
        Item.height = dims.Height;
        Item.UseSound = new SoundStyle($"{nameof(AvalonTesting)}/Sounds/Item/SonicScrewdriver");
    }
}
