﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class Frozen : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frozen");
        Description.SetDefault("I can't move!");
        Main.debuff[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.controlUp = false;
        player.controlDown = false;
        player.controlLeft = false;
        player.controlRight = false;
        player.controlJump = false;
        player.noItems = true;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.velocity.X = 0;
        npc.velocity.Y = 0;
    }
}
