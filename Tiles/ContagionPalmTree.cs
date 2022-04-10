﻿using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

class ContagionPalmTree : ModPalmTree
{
    private Mod mod
    {
        get
        {
            return ModLoader.GetMod("ExxoAvalonOrigins");
        }
    }
    public override int DropWood()
    {
        return ModContent.ItemType<Items.Placeable.Tile.Coughwood>();
    }

    public override Texture2D GetTexture()
    {
        return mod.Assets.Request<Texture2D>("Tiles/ContagionPalmTree").Value;
    }

    public override int CreateDust()
    {
        return ModContent.DustType<Dusts.CoughwoodDust>();
    }
    public override Texture2D GetTopTextures()
    {
        return mod.Assets.Request<Texture2D>("Tiles/ContagionPalmTreeTop").Value;
    }
    //public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
    //{
    //    frameWidth = 80;
    //    frameHeight = 80;
    //    yOffset += 2;
    //    //xOffsetLeft += 16;
    //    return mod.GetTexture("Tiles/ContagionPalmTreeTop");
    //}
}