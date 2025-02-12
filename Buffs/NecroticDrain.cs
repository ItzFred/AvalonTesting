﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class NecroticDrain : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Necrotic Drain");
        Description.SetDefault("Rapidly wasting away");
        Main.debuff[Type] = true;
    }
}
