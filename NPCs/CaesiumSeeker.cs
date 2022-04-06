﻿using AvalonTesting.Items.Placeables.Tile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;

namespace AvalonTesting.NPCs;

public class CaesiumSeekerHead : CaesiumSeekerWorm
{
    public override string Texture => "AvalonTesting/NPCs/CaesiumSeekerHead";
    public override void SetDefaults()
    {
        NPC.width = 50;
        NPC.height = 50;
        NPC.aiStyle = 6;
        NPC.scale = 0.8f;
        NPC.netAlways = true;
        NPC.damage = 65;
        NPC.defense = 15;
        NPC.lifeMax = 1800;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.value = 1000;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
        DrawOffsetY = 25;
        //Banner = NPC.type;
        //BannerItem = ModContent.ItemType<Items.Banners.CaesiumSeekerBanner>();
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.player.AvalonBiome().ZoneCaesium && spawnInfo.player.ZoneUnderworldHeight && !NPC.AnyNPCs(NPCID.WallofFlesh)) // && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.WallofSteel>()))
            return 0.6f;
        return 0;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.DownedAllMechBosses(), ModContent.ItemType<CaesiumOre>(), 10, 2, 5));
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (Main.netMode == NetmodeID.Server) return;
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CaesiumSeekerHead").Type, 0.8f);
        }
    }
    public override void Init()
    {
        base.Init();
        head = true;
        minLength = 10;
        maxLength = 18;
    }
}

public class CaesiumSeekerBody : CaesiumSeekerWorm
{
    public override string Texture => "AvalonTesting/NPCs/CaesiumSeekerBody";

    public override void SetDefaults()
    {
        NPC.width = 50;
        NPC.height = 50;
        NPC.aiStyle = 6;
        NPC.netAlways = true;
        NPC.damage = 60;
        NPC.scale = 0.8f;
        NPC.defense = 45;
        NPC.lifeMax = 1800;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
        DrawOffsetY = 25;
    }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (Main.netMode == NetmodeID.Server) return;
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CaesiumSeekerBody").Type, 0.8f);
        }
    }
}

public class CaesiumSeekerTail : CaesiumSeekerWorm
{
    public override string Texture => "AvalonTesting/NPCs/CaesiumSeekerTail";

    public override void SetDefaults()
    {
        NPC.width = 50;
        NPC.height = 50;
        NPC.aiStyle = 6;
        NPC.scale = 0.8f;
        NPC.netAlways = true;
        NPC.damage = 49;
        NPC.defense = 15;
        NPC.lifeMax = 1800;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.behindTiles = true;
        DrawOffsetY = 25;
    }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 0.5f);
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        if (Main.netMode == NetmodeID.Server) return;
        if (NPC.life <= 0)
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("CaesiumSeekerTail").Type, 0.8f);
        }
    }
    public override void Init()
    {
        base.Init();
        tail = true;
    }
}
public abstract class CaesiumSeekerWorm : Worm
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Caesium Seeker");
        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                BuffID.OnFire,
                BuffID.CursedInferno,
                BuffID.Daybreak
            }
        };
        NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
    }

    public override void Init()
    {
        minLength = 10;
        maxLength = 18;
        tailType = ModContent.NPCType<CaesiumSeekerTail>();
        bodyType = ModContent.NPCType<CaesiumSeekerBody>();
        headType = ModContent.NPCType<CaesiumSeekerHead>();
        speed = 15f;
        turnSpeed = 0.15f;
    }
}
public abstract class Worm : ModNPC
{
    /* ai[0] = follower
     * ai[1] = following
     * ai[2] = distanceFromTail
     * ai[3] = head
     */
    public bool head;
    public bool tail;
    public int minLength;
    public int maxLength;
    public int headType;
    public int bodyType;
    public int tailType;
    public bool flies = false;
    public bool directional = false;
    public float speed;
    public float turnSpeed;

    public override void AI()
    {
        if (NPC.localAI[1] == 0f)
        {
            NPC.localAI[1] = 1f;
            Init();
        }
        if (NPC.ai[3] > 0f)
        {
            NPC.realLife = (int)NPC.ai[3];
        }
        if (!head && NPC.timeLeft < 300)
        {
            NPC.timeLeft = 300;
        }
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead)
        {
            NPC.TargetClosest(true);
        }
        if (Main.player[NPC.target].dead && NPC.timeLeft > 300)
        {
            NPC.timeLeft = 300;
        }
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            if (!tail && NPC.ai[0] == 0f)
            {
                if (head)
                {
                    NPC.ai[3] = (float)NPC.whoAmI;
                    NPC.realLife = NPC.whoAmI;
                    NPC.ai[2] = (float)Main.rand.Next(minLength, maxLength + 1);
                    NPC.ai[0] = (float)NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), bodyType, NPC.whoAmI);
                }
                else if (NPC.ai[2] > 0f)
                {
                    NPC.ai[0] = (float)NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), NPC.type, NPC.whoAmI);
                }
                else
                {
                    NPC.ai[0] = (float)NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)(NPC.position.X + (float)(NPC.width / 2)), (int)(NPC.position.Y + (float)NPC.height), tailType, NPC.whoAmI);
                }
                Main.npc[(int)NPC.ai[0]].ai[3] = NPC.ai[3];
                Main.npc[(int)NPC.ai[0]].realLife = NPC.realLife;
                Main.npc[(int)NPC.ai[0]].ai[1] = (float)NPC.whoAmI;
                Main.npc[(int)NPC.ai[0]].ai[2] = NPC.ai[2] - 1f;
                NPC.netUpdate = true;
            }
            if (!head && (!Main.npc[(int)NPC.ai[1]].active || Main.npc[(int)NPC.ai[1]].type != headType && Main.npc[(int)NPC.ai[1]].type != bodyType))
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (!tail && (!Main.npc[(int)NPC.ai[0]].active || Main.npc[(int)NPC.ai[0]].type != bodyType && Main.npc[(int)NPC.ai[0]].type != tailType))
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (!NPC.active && Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, NPC.whoAmI, -1f, 0f, 0f, 0, 0, 0);
            }
        }
        int num180 = (int)(NPC.position.X / 16f) - 1;
        int num181 = (int)((NPC.position.X + (float)NPC.width) / 16f) + 2;
        int num182 = (int)(NPC.position.Y / 16f) - 1;
        int num183 = (int)((NPC.position.Y + (float)NPC.height) / 16f) + 2;
        if (num180 < 0)
        {
            num180 = 0;
        }
        if (num181 > Main.maxTilesX)
        {
            num181 = Main.maxTilesX;
        }
        if (num182 < 0)
        {
            num182 = 0;
        }
        if (num183 > Main.maxTilesY)
        {
            num183 = Main.maxTilesY;
        }
        bool flag18 = flies;
        if (!flag18)
        {
            for (int num184 = num180; num184 < num181; num184++)
            {
                for (int num185 = num182; num185 < num183; num185++)
                {
                    if (Main.tile[num184, num185] != null && (Main.tile[num184, num185].HasUnactuatedTile && (Main.tileSolid[(int)Main.tile[num184, num185].TileType] || Main.tileSolidTop[(int)Main.tile[num184, num185].TileType] && Main.tile[num184, num185].TileFrameY == 0) || Main.tile[num184, num185].LiquidAmount > 64))
                    {
                        Vector2 vector17;
                        vector17.X = (float)(num184 * 16);
                        vector17.Y = (float)(num185 * 16);
                        if (NPC.position.X + (float)NPC.width > vector17.X && NPC.position.X < vector17.X + 16f && NPC.position.Y + (float)NPC.height > vector17.Y && NPC.position.Y < vector17.Y + 16f)
                        {
                            flag18 = true;
                            if (Main.rand.NextBool(100) && NPC.behindTiles && Main.tile[num184, num185].HasUnactuatedTile)
                            {
                                WorldGen.KillTile(num184, num185, true, true, false);
                            }
                            if (Main.netMode != NetmodeID.MultiplayerClient && Main.tile[num184, num185].TileType == 2)
                            {
                                ushort arg_BFCA_0 = Main.tile[num184, num185 - 1].TileType;
                            }
                        }
                    }
                }
            }
        }
        if (!flag18 && head)
        {
            Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height);
            int num186 = 1000;
            bool flag19 = true;
            for (int num187 = 0; num187 < 255; num187++)
            {
                if (Main.player[num187].active)
                {
                    Rectangle rectangle2 = new Rectangle((int)Main.player[num187].position.X - num186, (int)Main.player[num187].position.Y - num186, num186 * 2, num186 * 2);
                    if (rectangle.Intersects(rectangle2))
                    {
                        flag19 = false;
                        break;
                    }
                }
            }
            if (flag19)
            {
                flag18 = true;
            }
        }
        if (directional)
        {
            if (NPC.velocity.X < 0f)
            {
                NPC.spriteDirection = 1;
            }
            else if (NPC.velocity.X > 0f)
            {
                NPC.spriteDirection = -1;
            }
        }
        float num188 = speed;
        float num189 = turnSpeed;
        Vector2 vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
        float num191 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2);
        float num192 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2);
        num191 = (float)((int)(num191 / 16f) * 16);
        num192 = (float)((int)(num192 / 16f) * 16);
        vector18.X = (float)((int)(vector18.X / 16f) * 16);
        vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
        num191 -= vector18.X;
        num192 -= vector18.Y;
        float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
        if (NPC.ai[1] > 0f && NPC.ai[1] < (float)Main.npc.Length)
        {
            try
            {
                vector18 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
                num191 = Main.npc[(int)NPC.ai[1]].position.X + (float)(Main.npc[(int)NPC.ai[1]].width / 2) - vector18.X;
                num192 = Main.npc[(int)NPC.ai[1]].position.Y + (float)(Main.npc[(int)NPC.ai[1]].height / 2) - vector18.Y;
            }
            catch
            {
            }
            NPC.rotation = (float)System.Math.Atan2((double)num192, (double)num191) + 1.57f;
            num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
            int num194 = NPC.width;
            num193 = (num193 - (float)num194) / num193;
            num191 *= num193;
            num192 *= num193;
            NPC.velocity = Vector2.Zero;
            NPC.position.X = NPC.position.X + num191;
            NPC.position.Y = NPC.position.Y + num192;
            if (directional)
            {
                if (num191 < 0f)
                {
                    NPC.spriteDirection = 1;
                }
                if (num191 > 0f)
                {
                    NPC.spriteDirection = -1;
                }
            }
        }
        else
        {
            if (!flag18)
            {
                NPC.TargetClosest(true);
                NPC.velocity.Y = NPC.velocity.Y + 0.11f;
                if (NPC.velocity.Y > num188)
                {
                    NPC.velocity.Y = num188;
                }
                if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)num188 * 0.4)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X - num189 * 1.1f;
                    }
                    else
                    {
                        NPC.velocity.X = NPC.velocity.X + num189 * 1.1f;
                    }
                }
                else if (NPC.velocity.Y == num188)
                {
                    if (NPC.velocity.X < num191)
                    {
                        NPC.velocity.X = NPC.velocity.X + num189;
                    }
                    else if (NPC.velocity.X > num191)
                    {
                        NPC.velocity.X = NPC.velocity.X - num189;
                    }
                }
                else if (NPC.velocity.Y > 4f)
                {
                    if (NPC.velocity.X < 0f)
                    {
                        NPC.velocity.X = NPC.velocity.X + num189 * 0.9f;
                    }
                    else
                    {
                        NPC.velocity.X = NPC.velocity.X - num189 * 0.9f;
                    }
                }
            }
            else
            {
                if (!flies && NPC.behindTiles && NPC.soundDelay == 0)
                {
                    float num195 = num193 / 40f;
                    if (num195 < 10f)
                    {
                        num195 = 10f;
                    }
                    if (num195 > 20f)
                    {
                        num195 = 20f;
                    }
                    NPC.soundDelay = (int)num195;
                    SoundEngine.PlaySound(SoundID.Roar, NPC.position, 1);
                }
                num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                float num196 = System.Math.Abs(num191);
                float num197 = System.Math.Abs(num192);
                float num198 = num188 / num193;
                num191 *= num198;
                num192 *= num198;
                if (ShouldRun())
                {
                    bool flag20 = true;
                    for (int num199 = 0; num199 < 255; num199++)
                    {
                        if (Main.player[num199].active && !Main.player[num199].dead && Main.player[num199].ZoneCorrupt)
                        {
                            flag20 = false;
                        }
                    }
                    if (flag20)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient && (double)(NPC.position.Y / 16f) > (Main.rockLayer + (double)Main.maxTilesY) / 2.0)
                        {
                            NPC.active = false;
                            int num200 = (int)NPC.ai[0];
                            while (num200 > 0 && num200 < 200 && Main.npc[num200].active && Main.npc[num200].aiStyle == NPC.aiStyle)
                            {
                                int num201 = (int)Main.npc[num200].ai[0];
                                Main.npc[num200].active = false;
                                NPC.life = 0;
                                if (Main.netMode == NetmodeID.Server)
                                {
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num200, 0f, 0f, 0f, 0, 0, 0);
                                }
                                num200 = num201;
                            }
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, NPC.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                            }
                        }
                        num191 = 0f;
                        num192 = num188;
                    }
                }
                bool flag21 = false;
                if (NPC.type == NPCID.WyvernHead)
                {
                    if ((NPC.velocity.X > 0f && num191 < 0f || NPC.velocity.X < 0f && num191 > 0f || NPC.velocity.Y > 0f && num192 < 0f || NPC.velocity.Y < 0f && num192 > 0f) && System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y) > num189 / 2f && num193 < 300f)
                    {
                        flag21 = true;
                        if (System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y) < num188)
                        {
                            NPC.velocity *= 1.1f;
                        }
                    }
                    if (NPC.position.Y > Main.player[NPC.target].position.Y || (double)(Main.player[NPC.target].position.Y / 16f) > Main.worldSurface || Main.player[NPC.target].dead)
                    {
                        flag21 = true;
                        if (System.Math.Abs(NPC.velocity.X) < num188 / 2f)
                        {
                            if (NPC.velocity.X == 0f)
                            {
                                NPC.velocity.X = NPC.velocity.X - (float)NPC.direction;
                            }
                            NPC.velocity.X = NPC.velocity.X * 1.1f;
                        }
                        else
                        {
                            if (NPC.velocity.Y > -num188)
                            {
                                NPC.velocity.Y = NPC.velocity.Y - num189;
                            }
                        }
                    }
                }
                if (!flag21)
                {
                    if (NPC.velocity.X > 0f && num191 > 0f || NPC.velocity.X < 0f && num191 < 0f || NPC.velocity.Y > 0f && num192 > 0f || NPC.velocity.Y < 0f && num192 < 0f)
                    {
                        if (NPC.velocity.X < num191)
                        {
                            NPC.velocity.X = NPC.velocity.X + num189;
                        }
                        else
                        {
                            if (NPC.velocity.X > num191)
                            {
                                NPC.velocity.X = NPC.velocity.X - num189;
                            }
                        }
                        if (NPC.velocity.Y < num192)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num189;
                        }
                        else
                        {
                            if (NPC.velocity.Y > num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y - num189;
                            }
                        }
                        if ((double)System.Math.Abs(num192) < (double)num188 * 0.2 && (NPC.velocity.X > 0f && num191 < 0f || NPC.velocity.X < 0f && num191 > 0f))
                        {
                            if (NPC.velocity.Y > 0f)
                            {
                                NPC.velocity.Y = NPC.velocity.Y + num189 * 2f;
                            }
                            else
                            {
                                NPC.velocity.Y = NPC.velocity.Y - num189 * 2f;
                            }
                        }
                        if ((double)System.Math.Abs(num191) < (double)num188 * 0.2 && (NPC.velocity.Y > 0f && num192 < 0f || NPC.velocity.Y < 0f && num192 > 0f))
                        {
                            if (NPC.velocity.X > 0f)
                            {
                                NPC.velocity.X = NPC.velocity.X + num189 * 2f;
                            }
                            else
                            {
                                NPC.velocity.X = NPC.velocity.X - num189 * 2f;
                            }
                        }
                    }
                    else
                    {
                        if (num196 > num197)
                        {
                            if (NPC.velocity.X < num191)
                            {
                                NPC.velocity.X = NPC.velocity.X + num189 * 1.1f;
                            }
                            else if (NPC.velocity.X > num191)
                            {
                                NPC.velocity.X = NPC.velocity.X - num189 * 1.1f;
                            }
                            if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)num188 * 0.5)
                            {
                                if (NPC.velocity.Y > 0f)
                                {
                                    NPC.velocity.Y = NPC.velocity.Y + num189;
                                }
                                else
                                {
                                    NPC.velocity.Y = NPC.velocity.Y - num189;
                                }
                            }
                        }
                        else
                        {
                            if (NPC.velocity.Y < num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y + num189 * 1.1f;
                            }
                            else if (NPC.velocity.Y > num192)
                            {
                                NPC.velocity.Y = NPC.velocity.Y - num189 * 1.1f;
                            }
                            if ((double)(System.Math.Abs(NPC.velocity.X) + System.Math.Abs(NPC.velocity.Y)) < (double)num188 * 0.5)
                            {
                                if (NPC.velocity.X > 0f)
                                {
                                    NPC.velocity.X = NPC.velocity.X + num189;
                                }
                                else
                                {
                                    NPC.velocity.X = NPC.velocity.X - num189;
                                }
                            }
                        }
                    }
                }
            }
            NPC.rotation = (float)System.Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) + 1.57f;
            if (head)
            {
                if (flag18)
                {
                    if (NPC.localAI[0] != 1f)
                    {
                        NPC.netUpdate = true;
                    }
                    NPC.localAI[0] = 1f;
                }
                else
                {
                    if (NPC.localAI[0] != 0f)
                    {
                        NPC.netUpdate = true;
                    }
                    NPC.localAI[0] = 0f;
                }
                if ((NPC.velocity.X > 0f && NPC.oldVelocity.X < 0f || NPC.velocity.X < 0f && NPC.oldVelocity.X > 0f || NPC.velocity.Y > 0f && NPC.oldVelocity.Y < 0f || NPC.velocity.Y < 0f && NPC.oldVelocity.Y > 0f) && !NPC.justHit)
                {
                    NPC.netUpdate = true;
                    return;
                }
            }
        }
        CustomBehavior();
    }

    public virtual void Init()
    {
    }

    public virtual bool ShouldRun()
    {
        return false;
    }

    public virtual void CustomBehavior()
    {
    }

    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return head ? (bool?)null : false;
    }
}
