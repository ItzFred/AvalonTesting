using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles;

public class IckyCactus : ModCactus
{
    public override void SetStaticDefaults() => GrowsOnTileId = new[] { ModContent.TileType<Snotsand>() };

    public override Asset<Texture2D> GetTexture() => AvalonTesting.Mod.Assets.Request<Texture2D>("Tiles/IckyCactus");

    public override Asset<Texture2D> GetFruitTexture() => Asset<Texture2D>.Empty;
}
