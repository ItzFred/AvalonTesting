using AvalonTesting.Items.Placeable.Crafting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class DarkSlimeWorkbench : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileTable[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
        TileObjectData.addTile(Type);
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        var name = CreateMapEntryName();
        name.SetDefault("Dark Slime Work Bench");
        AddMapEntry(new Color(191, 142, 111), name);
        TileID.Sets.DisableSmartCursor[Type] = true;
        AdjTiles = new int[] { TileID.WorkBenches };
        DustType = DustID.UnholyWater;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<DarkSlimeWorkBench>());
    }
}
