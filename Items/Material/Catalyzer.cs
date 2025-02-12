using AvalonTesting.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Material;

internal class Catalyzer : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Catalyzer");
        Tooltip.SetDefault("Used to convert items to their counterparts");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Catalyzer>();
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 99;
        Item.value = 50000;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }

    public override void AddRecipes()
    {
        Mod.CreateRecipe(ModContent.ItemType<Catalyzer>())
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddIngredient(ModContent.ItemType<Sulphur>(), 30)
            .AddRecipeGroup("IronBar", 15)
            .AddRecipeGroup("AvalonTesting:WorkBenches")
            .AddTile(TileID.Anvils)
            .Register();
    }
}
