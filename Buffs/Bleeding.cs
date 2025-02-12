﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class Bleeding : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bleeding");
        Description.SetDefault("Losing life");
        Main.debuff[Type] = true;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        if (npc.lifeRegen > 0)
        {
            npc.lifeRegen = 0;
        }

        int mult = 4;
        if (Main.hardMode)
        {
            mult = 6;
        }

        npc.lifeRegen -= mult * npc.GetGlobalNPC<AvalonTestingGlobalNPCInstance>().BleedStacks;
    }

    public override bool ReApply(NPC npc, int time, int buffIndex)
    {
        if (npc.GetGlobalNPC<AvalonTestingGlobalNPCInstance>().BleedStacks < 3)
        {
            npc.GetGlobalNPC<AvalonTestingGlobalNPCInstance>().BleedStacks++;
        }

        return false;
    }
}
