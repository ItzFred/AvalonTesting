﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class BacteriaInfection : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bacteria Infection");
        Description.SetDefault("Yuck!");
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.lifeRegen -= 24;
    }
}
