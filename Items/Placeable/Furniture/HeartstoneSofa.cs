using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Placeable.Furniture;

class HeartstoneSofa : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Heartstone Sofa");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.HeartstoneSofa>();
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 300;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
}
