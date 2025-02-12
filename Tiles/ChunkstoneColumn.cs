﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class ChunkstoneColumn : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(73, 51, 36));
        ItemDrop = ModContent.ItemType<Items.Placeable.Beam.ChunkstoneColumn>();
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(CanPlaceAlter, -1, 0, processedCoordinates: true);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacement, -1, 0, processedCoordinates: false);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Tink;
        DustType = ModContent.DustType<Dusts.ContagionDust>();
    }
    public override bool CanPlace(int i, int j)
    {
        return (Main.tile[i, j - 1].HasTile || Main.tile[i, j + 1].HasTile || Main.tile[i, j].WallType != 0 && !Main.tile[i, j].HasTile);
    }
    public int CanPlaceAlter(int i, int j, int type, int style, int direction, int alternate)
    {
        return 1;
    }
    public static int AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
    {
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            NetMessage.SendTileSquare(Main.myPlayer, i, j, 1, 1);
        }
        return 1;
    }
}
