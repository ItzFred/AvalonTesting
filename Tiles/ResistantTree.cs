﻿using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class ResistantTree : ModTree
{
    public override TreePaintingSettings TreeShaderSettings => new();
    public override void SetStaticDefaults() => GrowsOnTileId = new[] { ModContent.TileType<Impgrass>() };

    public override void SetTreeFoliageSettings(Tile tile, int xoffset, ref int treeFrame, ref int floorY,
                                                ref int topTextureFrameWidth,
                                                ref int topTextureFrameHeight)
    {
    }

    public override Asset<Texture2D> GetTexture() => AvalonTesting.Mod.Assets.Request<Texture2D>("Tiles/ResistantTree");

    public override Asset<Texture2D> GetBranchTextures() =>
        AvalonTesting.Mod.Assets.Request<Texture2D>("Tiles/ResistantTreeBranches");

    public override Asset<Texture2D> GetTopTextures() =>
        AvalonTesting.Mod.Assets.Request<Texture2D>("Tiles/ResistantTreeTop");

    public override int DropWood() => ModContent.ItemType<Items.Placeable.Tile.ResistantWood>();

    public override int CreateDust() => DustID.Wraith;
}
