using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Furniture;

class IceSculpture : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ice Sculpture");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Statues>();
        Item.placeStyle = 2;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 500;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}
