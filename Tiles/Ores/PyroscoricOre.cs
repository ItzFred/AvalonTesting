﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class PyroscoricOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(255, 102, 0), LanguageManager.Instance.GetText("Pyroscoric"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileOreFinderPriority[Type] = 820;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.PyroscoricOre>();
        HitSound = SoundID.Tink;
        DustType = DustID.InfernoFork;
        MinPick = 210;
    }

    public override bool CanExplode(int i, int j)
    {
        return false;
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        float num7 = Main.rand.Next(90, 111) * 0.01f;
        num7 *= Main.essScale;
        r = 0.5f * num7;
        g = 0.2f * num7;
        b = 0.05f * num7;
    }

    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        Tile tile = Main.tile[i, j];
        var zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        if (Main.drawToScreen)
        {
            zero = Vector2.Zero;
        }

        Vector2 pos = new Vector2(i * 16, j * 16) + zero - Main.screenPosition;
        var frame = new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16);
        Main.spriteBatch.Draw(Mod.Assets.Request<Texture2D>("Tiles/Ores/PyroscoricOre_Glow").Value, pos, frame,
            Color.White);
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        Dust.NewDust(new Vector2(j * 16, i * 16), 16, 16, DustID.InfernoFork);

        if (Main.rand.Next(200) == 1)
        {
            int randomSize = Main.rand.Next(1, 4) / 2;
            int num161 = Gore.NewGore(new EntitySource_TileUpdate(i, j), new Vector2(i * 16, j * 16), default,
                Main.rand.Next(61, 64));
            Gore gore30 = Main.gore[num161];
            Gore gore40 = gore30;
            gore40.velocity *= 0.3f;
            gore40.scale *= randomSize;
            Main.gore[num161].velocity.X += Main.rand.Next(-1, 2);
            Main.gore[num161].velocity.Y += Main.rand.Next(-1, 2);
        }

        if (Main.rand.Next(120) == 1)
        {
            int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Torch, 0f, 0f, 0, default, 2f);
            Main.dust[num162].noGravity = true;
            Main.dust[num162].velocity *= 4f;
            Main.dust[num162].noLight = true;
        }

        if (Main.rand.Next(120) == 1)
        {
            int num162 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Smoke, 0f, 0f, 0, default, 1.5f);
            Main.dust[num162].noGravity = true;
            Main.dust[num162].velocity *= 1.5f;
            Main.dust[num162].noLight = true;
        }
    }
}
