﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class CurseofIcarus : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Curse of Icarus");
        Description.SetDefault("Your wings are broken");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
        Main.buffNoSave[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.Avalon().curseOfIcarus = true;
    }
}
