﻿using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Prefixes;

public abstract class ArmorPrefix : ModPrefix
{
    public static bool IsArmor(Item item)
    {
        return item.maxStack == 1 && !item.vanity && (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1);
    }
    public virtual void UpdateEquip(Player player)
    {
    }
}
