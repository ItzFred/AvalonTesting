﻿using AvalonTesting.Dusts;
using AvalonTesting.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class CaesiumOre : ModTile
{
    public override void SetStaticDefaults()
    {
        MineResist = 5f;
        AddMapEntry(new Color(86, 190, 74), LanguageManager.Instance.GetText("Caesium"));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 720;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.CaesiumOre>();
        HitSound = SoundID.Tink;
        MinPick = 200;
        DustType = ModContent.DustType<CaesiumDust>();

        TileID.Sets.HellSpecial[Type] = true;
        TileID.Sets.DoesntGetReplacedWithTileReplacement[Type] = true;
        TileID.Sets.ChecksForMerge[Type] = true;
        TileID.Sets.OreMergesWithMud[Type] = true;
        TileID.Sets.Ore[Type] = true;
    }

    public override bool CanExplode(int i, int j)
    {
        return false;
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (j > Main.maxTilesY - 190 && i > Main.maxTilesX - (Main.maxTilesX / 5))
        {
            if ((Main.tile[i, j].HasTile && !Main.tile[i, j - 1].HasTile) ||
                (Main.tile[i, j].HasTile && !Main.tile[i, j + 1].HasTile) ||
                (Main.tile[i, j].HasTile && !Main.tile[i - 1, j].HasTile) ||
                (Main.tile[i, j].HasTile && !Main.tile[i + 1, j].HasTile))
            {
                if (Main.rand.Next(7000) == 0)
                {
                    Projectile.NewProjectile(Projectile.GetSource_None(), new Vector2(i, j) * 16,
                        new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f)),
                        ModContent.ProjectileType<CaesiumGas>(), 0, 0);
                }
            }
        }
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (j > Main.maxTilesY - 190 && i > Main.maxTilesX - (Main.maxTilesX / 5))
        {
            if (Main.rand.Next(27) == 0)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_None(), new Vector2(i, j) * 16,
                    new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f)),
                    ModContent.ProjectileType<CaesiumGas>(), 0, 0);
            }
        }
    }
}
