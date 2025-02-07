using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class TropicalWood : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(200, 200, 200));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.TropicalWood>();
        DustType = DustID.SnowBlock;
    }
}
