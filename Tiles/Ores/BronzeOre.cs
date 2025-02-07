﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class BronzeOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(121, 50, 42), LanguageManager.Instance.GetText("Bronze"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1100;
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 215;
        Main.tileBlockLight[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.BronzeOre>();
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<Dusts.BronzeDust>();
    }
}
