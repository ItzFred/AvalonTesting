﻿using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class HerbologyBench : ModTile
{
    public override void SetStaticDefaults()
    {
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.addTile(Type);
        TileID.Sets.HasOutlines[Type] = true;
        Main.tileFrameImportant[Type] = true;
        AddMapEntry(new Color(153, 77, 86), LanguageManager.Instance.GetText("Herbology Bench"));
        AdjTiles = new int[] { TileID.Bottles };
        TileID.Sets.DisableSmartCursor[Type] = true;
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
    }

    public override bool RightClick(int i, int j)
    {
        //Main.playerInventory = true;

        //Main.LocalPlayer.GetModPlayer<ExxoPlayer>().herb = !Main.LocalPlayer.GetModPlayer<ExxoPlayer>().herb;
        //Main.LocalPlayer.GetModPlayer<ExxoPlayer>().herbX = i;
        //Main.LocalPlayer.GetModPlayer<ExxoPlayer>().herbY = j;

        return true;
    }
    public override void MouseOver(int i, int j)
    {
        Player player = Main.player[Main.myPlayer];
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Crafting.HerbologyBench>();
    }
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 64, 32, ModContent.ItemType<Items.Placeable.Crafting.HerbologyBench>());
    }
}
