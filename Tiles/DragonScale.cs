using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class DragonScale : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.MediumSpringGreen);
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileFrameImportant[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.DragonScale>();
        DustType = DustID.MagicMirror;
    }
}
