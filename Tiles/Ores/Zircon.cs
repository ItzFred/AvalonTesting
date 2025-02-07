﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class Zircon : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(102, 66, 43), LanguageManager.Instance.GetText("Zircon"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Material.Zircon>();
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 900;
        HitSound = SoundID.Tink;
        MinPick = 55;
    }

    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}
