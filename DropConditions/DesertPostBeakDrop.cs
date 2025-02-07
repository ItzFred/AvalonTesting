﻿using AvalonTesting.Systems;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace AvalonTesting.DropConditions;

public class DesertPostBeakDrop : IItemDropRuleCondition, IProvideItemConditionDescription
{
    public bool CanDrop(DropAttemptInfo info)
    {
        return ModContent.GetInstance<DownedBossSystem>().DownedDesertBeak && info.player.ZoneDesert;
    }

    public bool CanShowItemDropInUI()
    {
        return ModContent.GetInstance<DownedBossSystem>().DownedDesertBeak;
    }

    public string GetConditionDescription()
    {
        return null;
    }
}
