﻿using AvalonTesting.Items.Banners;
using AvalonTesting.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class CloudBat : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cloud Bat");
        Main.npcFrameCount[NPC.type] = 5;
    }

    public override void SetDefaults()
    {
        NPC.damage = 80;
        NPC.lifeMax = 1670;
        NPC.defense = 35;
        NPC.width = 10;
        NPC.aiStyle = 14;
        NPC.scale = 1.4f;
        NPC.value = 10000f;
        NPC.knockBackResist = 0.05f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath4;
        NPC.height = 12;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<CloudBatBanner>();
        AnimationType = 49;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
        NPC.damage = (int)(NPC.damage * 0.45f);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        spawnInfo.Player.GetModPlayer<ExxoBiomePlayer>().ZoneSkyFortress
            ? 0.3f * AvalonTestingGlobalNPC.EndoSpawnRate
            : 0f;
}
