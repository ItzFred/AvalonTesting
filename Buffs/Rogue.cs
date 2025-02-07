﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class Rogue : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rogue");
        Description.SetDefault("-3% ranged damage, 20% chance to not consume ammo");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Ranged) -= 0.03f;
        player.ammoCost80 = true;
    }
}
