﻿using System;
using AvalonTesting.Items.Banners;
using AvalonTesting.Items.Material;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.NPCs;

public class BloodshotEye : ModNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloodshot Eye");
        Main.npcFrameCount[NPC.type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.damage = 25;
        NPC.lifeMax = 110;
        NPC.defense = 5;
        NPC.width = 48;
        NPC.aiStyle = 2;
        NPC.value = 150f;
        NPC.height = 34;
        NPC.knockBackResist = 0.4f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath6;
        NPC.buffImmune[BuffID.Confused] = true;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<BloodshotEyeBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) =>
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
            new FlavorTextBestiaryInfoElement("The bloodiest of eyes, this creature exists in a state of fear."),
        });

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(new CommonDrop(ModContent.ItemType<BloodshotLens>(), 100, 1, 1, 45));
        npcLoot.Add(ItemDropRule.Common(ItemID.BlackLens, 33));
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.65f);
        NPC.damage = (int)(NPC.damage * 0.6f);
    }

    public override void FindFrame(int frameHeight)
    {
        if (NPC.velocity.X > 0f)
        {
            NPC.spriteDirection = 1;
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
        }

        if (NPC.velocity.X < 0f)
        {
            NPC.spriteDirection = -1;
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 3.14f;
        }

        NPC.frameCounter += 1.0;
        if (NPC.frameCounter >= 8.0)
        {
            NPC.frame.Y = NPC.frame.Y + frameHeight;
            NPC.frameCounter = 0.0;
        }

        if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
        {
            NPC.frame.Y = 0;
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BloodshotEye1").Type);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BloodshotEye2").Type);
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) => Main.bloodMoon && !spawnInfo.Player.InPillarZone()
        ? 0.121f * AvalonTestingGlobalNPC.EndoSpawnRate
        : 0f;
}
