﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Audio;
using Terraria.UI;
using Terraria.UI.Gamepad;
using Terraria.GameInput;

namespace AvalonTesting.Tiles;

public class ResistantWoodChest : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSpelunker[Type] = true;
        Main.tileContainer[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileOreFinderPriority[Type] = 500;
        TileID.Sets.HasOutlines[Type] = true;
        TileID.Sets.BasicChest[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.Origin = new Point16(0, 1);
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
        TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook((Chest.FindEmptyChest), -1, 0, true);
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook((Chest.AfterPlacement_Hook), -1, 0, false);
        TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        TileObjectData.addTile(Type);
        var name = CreateMapEntryName();
        name.SetDefault("Resistant Wood Chest");
        AddMapEntry(new Color(50, 50, 50), name, MapChestName);
        TileID.Sets.DisableSmartCursor[Type] = true;
        AdjTiles = new int[] { TileID.Containers };
        ContainerName.SetDefault("Resistant Wood Chest");
        ChestDrop = ModContent.ItemType<Items.Placeable.Storage.ResistantWoodChest>();
        DustType = DustID.Wraith;
    }

    public override bool HasSmartInteract() => true;

    public string MapChestName(string name, int i, int j)
    {
        var left = i;
        var top = j;
        var tile = Main.tile[i, j];
        if (tile.TileFrameX % 36 != 0)
        {
            left--;
        }
        if (tile.TileFrameY != 0)
        {
            top--;
        }
        var chest = Chest.FindChest(left, top);
        if (Main.chest[chest].name == "")
        {
            return name;
        }
        else
        {
            return name + ": " + Main.chest[chest].name;
        }
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = 1;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 32, ChestDrop);
        Chest.DestroyChest(i, j);
    }

    public override bool RightClick(int i, int j)
    {
        var player = Main.LocalPlayer;
        var tile = Main.tile[i, j];
        int num39 = tile.TileFrameX / 18;
        num39 %= 3;
        num39 = i - num39;
        tile = Main.tile[i, j];
        int num40 = j - tile.TileFrameY / 18;
        tile = Main.tile[i, j];

        
        Main.mouseRightRelease = false;
        var left = num39;
        var top = num40;
        if (player.sign >= 0)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            player.sign = -1;
            Main.editSign = false;
            Main.npcChatText = "";
        }
        if (Main.editChest)
        {
            SoundEngine.PlaySound(SoundID.MenuTick);
            Main.editChest = false;
            Main.npcChatText = "";
        }
        if (player.editedChestName)
        {
            NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
            player.editedChestName = false;
        }
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            if (left == player.chestX && top == player.chestY && player.chest >= 0)
            {
                player.chest = -1;
                Recipe.FindRecipes();
                SoundEngine.PlaySound(SoundID.MenuClose);
            }
            else
            {
                NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top, 0f, 0f, 0, 0, 0);
                Main.stackSplit = 600;
            }
        }
        else
        {
            player.piggyBankProjTracker.Clear();
            player.voidLensChest.Clear();
            var chest = Chest.FindChest(left, top);
            if (chest != -1)
            {
                Main.stackSplit = 600;
                if (chest == player.chest)
                {
                    player.chest = -1;
                    SoundEngine.PlaySound(SoundID.MenuClose);
                }
                else if (chest != player.chest && player.chest == -1)
                {
                    player.OpenChest(left, top, chest);
                    SoundEngine.PlaySound(SoundID.MenuOpen);
                }
                else
                {
                    player.OpenChest(left, top, chest);
                    SoundEngine.PlaySound(SoundID.MenuTick);
                }
                Recipe.FindRecipes();
                
            }
        }
        return true;
    }
    public override void MouseOver(int i, int j)
    {
        var player = Main.LocalPlayer;
        var tile = Main.tile[i, j];
        var left = i;
        var top = j;
        if (tile.TileFrameX % 36 != 0)
        {
            left--;
        }
        if (tile.TileFrameY != 0)
        {
            top--;
        }
        var chest = Chest.FindChest(left, top);
        player.cursorItemIconID = -1;
        if (chest < 0)
        {
            player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
        }
        else
        {
            player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Resistant Wood Chest";
            if (player.cursorItemIconText == "Resistant Wood Chest")
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Storage.ResistantWoodChest>();
                player.cursorItemIconText = "";
            }
        }
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
    }

    public override void MouseOverFar(int i, int j)
    {
        MouseOver(i, j);
        var player = Main.LocalPlayer;
        if (player.cursorItemIconText == "")
        {
            player.cursorItemIconEnabled = false;
            player.cursorItemIconID = 0;
        }
    }
}
