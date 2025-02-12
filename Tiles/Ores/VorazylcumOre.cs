﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AvalonTesting.Tiles.Ores;

public class VorazylcumOre : ModTile
{
    public override void SetStaticDefaults()
    {
        MineResist = 8f;
        AddMapEntry(new Color(140, 130, 196), LanguageManager.Instance.GetText("Vorazylcum"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 850;
        Main.tileBlockLight[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1900;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.VorazylcumOre>();
        HitSound = SoundID.Tink;
        MinPick = 250;
        DustType = DustID.VilePowder;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (j > Main.rockLayer)
        {
            if (Main.rand.Next(5500) == 0 && Vector2.Distance(Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].position, new Vector2(i * 16, j * 16)) < 12 * 16)
            {
                NPC.NewNPC(NPC.GetSource_NaturalSpawn(), i * 16, j * 16, ModContent.NPCType<NPCs.VorazylcumMiteDigger>());
            }
        }
    }
}
