﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class SpiritPoppy : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(0, 0, 200), LanguageManager.Instance.GetText("Spirit Poppy"));
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.addTile(Type);
        Main.tileObsidianKill[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileFrameImportant[Type] = true;
        HitSound = SoundID.Shatter;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 16,
            ModContent.ItemType<Items.Consumables.SpiritPoppy>());
    }
}
