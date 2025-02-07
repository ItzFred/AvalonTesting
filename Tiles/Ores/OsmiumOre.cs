﻿using AvalonTesting.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class OsmiumOre : ModTile
{
    public override void SetStaticDefaults()
    {
        MineResist = 2f;
        AddMapEntry(new Color(0, 148, 255), LanguageManager.Instance.GetText("Osmium"));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 430;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1150;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.OsmiumOre>();
        HitSound = SoundID.Tink;
        MinPick = 60;
        DustType = ModContent.DustType<OsmiumDust>();
    }
}
