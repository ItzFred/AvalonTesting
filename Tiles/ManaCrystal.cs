﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class ManaCrystal : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(113, 99, 99));
        AnimationFrameHeight = 38;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.DrawYOffset = 2;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.addTile(Type);
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 300;
        Main.tileFrameImportant[Type] = true;
        DustType = DustID.Ice;
        HitSound = SoundID.Shatter;
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter > 6)
        {
            frameCounter = 0;
            frame++;
            if (frame >= 7)
            {
                frame = 0;
            }
        }
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 16, ItemID.ManaCrystal);
    }
}
