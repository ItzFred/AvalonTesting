﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

// TODO: IMPLEMENT
public class SnotOrb : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Snot Orb");
        Description.SetDefault("The snot orb provides light");
        Main.buffNoTimeDisplay[Type] = true;
        Main.lightPet[Type] = true;
    }

    // public override void Update(Player player, ref int buffIndex)
    // {
    //     player.buffTime[buffIndex] = 18000;
    //     if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SnotOrb>()] <= 0 &&
    //         player.whoAmI == Main.myPlayer)
    //     {
    //         Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
    //             player.position.Y + (player.height / 2),
    //             0f, 0f, ModContent.ProjectileType<Projectiles.SnotOrb>(), 0, 0f, player.whoAmI);
    //     }
    // }
}
