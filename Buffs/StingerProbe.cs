﻿using AvalonTesting.Items.Accessories;
using AvalonTesting.Players;
using AvalonTesting.Projectiles.Summon;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class StingerProbe : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stinger Probe");
        Description.SetDefault("'Don't get too close!'");
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.dead || !player.active)
        {
            return;
        }

        if (player.GetModPlayer<ExxoBuffPlayer>().StingerProbeTimer < 300)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<StingerProbeMinion>()] < 4)
            {
                player.GetModPlayer<ExxoBuffPlayer>().StingerProbeTimer++;
            }

            return;
        }

        if (player.whoAmI != Main.myPlayer)
        {
            return;
        }

        int damage = -1;
        for (int i = 3; i < player.armor.Length; i++)
        {
            if (player.armor[i].type == ModContent.ItemType<AIController>())
            {
                damage = player.armor[i].damage;
                break;
            }
        }

        if (damage == -1)
        {
            return;
        }
        
        Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero,
            ModContent.ProjectileType<StingerProbeMinion>(), damage, 0f,
            player.whoAmI);
        player.GetModPlayer<ExxoBuffPlayer>().StingerProbeTimer = 0;
    }
}
