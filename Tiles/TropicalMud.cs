using AvalonTesting.Dusts;
using AvalonTesting.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class TropicalMud : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(95, 38, 12));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemDrop = ModContent.ItemType<TropicalMudBlock>();
        DustType = ModContent.DustType<TropicalMudDust>();
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.Mud[Type] = true;
        TileID.Sets.ChecksForMerge[Type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
    }
}
