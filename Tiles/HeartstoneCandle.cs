﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class HeartstoneCandle : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 36;
        TileObjectData.newTile.CoordinateHeights = new int[] { 20 };
        TileObjectData.newTile.DrawYOffset = -4;
        TileObjectData.addTile(Type);
        ItemDrop = ModContent.ItemType<Items.Placeable.Light.HeartstoneCandle>();
        DustType = 7;
        Main.tileLighted[Type] = true;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Heartstone Candelabra");
        AddMapEntry(new Color(253, 221, 3), name);
        DustType = DustID.Confetti_Pink;
    }

    public override void MouseOver(int i, int j)
    {
        Player player = Main.player[Main.myPlayer];
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Light.HeartstoneCandle>();
    }

    public override bool RightClick(int i, int j)
    {
        WorldGen.KillTile(i, j);
        if (!Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
        }
        return true;
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX == 0)
        {
            r = 0.9f;
            g = 0.5f;
            b = 0.7f;
        }
    }

    public override void HitWire(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        int topY = j - tile.TileFrameY / 18;
        short frameAdjustment = (short)(tile.TileFrameX > 0 ? -18 : 18);
        Main.tile[i, topY].TileFrameX += frameAdjustment;
        Wiring.SkipWire(i, topY);
        NetMessage.SendTileSquare(-1, i, topY + 1, 1, TileChangeType.None);
    }
}
