using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AvalonTesting.Tiles;

public class HeartstoneChandelier : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.Width = 3;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.Origin = new Point16(1, 0);
        TileObjectData.addTile(Type);
        DustType = -1;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        Main.tileLighted[Type] = true;
        var name = CreateMapEntryName();
        name.SetDefault("Heartstone Chandelier");
        AddMapEntry(new Color(235, 166, 135), name);
        DustType = DustID.Confetti_Pink;
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

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.Light.HeartstoneChandelier>());
    }

    public override void HitWire(int i, int j)
    {
        int x = i - Main.tile[i, j].TileFrameX / 18 % 3;
        int y = j - Main.tile[i, j].TileFrameY / 18 % 3;
        for (int l = x; l < x + 3; l++)
        {
            for (int m = y; m < y + 3; m++)
            {
                if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
                {
                    if (Main.tile[l, m].TileFrameX < 54)
                    {
                        Main.tile[l, m].TileFrameX += 54;
                    }
                    else
                    {
                        Main.tile[l, m].TileFrameX -= 54;
                    }
                }
            }
        }
        if (Wiring.running)
        {
            Wiring.SkipWire(x, y);
            Wiring.SkipWire(x, y + 1);
            Wiring.SkipWire(x, y + 2);
            Wiring.SkipWire(x + 1, y);
            Wiring.SkipWire(x + 1, y + 1);
            Wiring.SkipWire(x + 1, y + 2);
            Wiring.SkipWire(x + 2, y);
            Wiring.SkipWire(x + 2, y + 1);
            Wiring.SkipWire(x + 2, y + 2);
        }
        NetMessage.SendTileSquare(-1, x, y + 1, 3);
    }
}
