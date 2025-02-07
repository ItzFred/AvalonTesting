﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles.Ancient;

public class AncientWorkbench : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(168, 178, 204), LanguageManager.Instance.GetText("Ancient Work Bench"));
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.DrawYOffset = 2;
        TileObjectData.addTile(Type);
        Main.tileObsidianKill[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = false;
        DustType = DustID.Marble;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.Crafting.AncientWorkbench>());
    }
}
