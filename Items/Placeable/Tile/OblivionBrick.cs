using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Tile;

class OblivionBrick : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivion Brick");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.OblivionBrick>();
        Item.rare = ItemRarityID.Lime;
        Item.width = dims.Width;
        Item.useTime = 10;
        Item.useTurn = true;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.value = 0;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}
