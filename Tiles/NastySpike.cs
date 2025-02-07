﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class NastySpike : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(89, 69, 53), LanguageManager.Instance.GetText("Nasty Spike"));
        Main.tileSolid[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.NastySpike>();
        DustType = DustID.ScourgeOfTheCorruptor;
        HitSound = SoundID.Tink;
    }
}
