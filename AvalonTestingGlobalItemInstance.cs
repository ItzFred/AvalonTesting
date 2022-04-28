﻿using System.Collections.Generic;
using System.Linq;
using AvalonTesting.Prefixes;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace AvalonTesting;

public class AvalonTestingGlobalItemInstance : GlobalItem
{
    public static readonly int[] AllowedPrefixes =
    {
        ModContent.PrefixType<Barbaric>(), ModContent.PrefixType<Boosted>(), ModContent.PrefixType<Busted>(),
        ModContent.PrefixType<Bloated>(), ModContent.PrefixType<Disgusting>(), ModContent.PrefixType<Fluidic>(),
        ModContent.PrefixType<Glorious>(), ModContent.PrefixType<Handy>(), ModContent.PrefixType<Insane>(),
        ModContent.PrefixType<Loaded>(), ModContent.PrefixType<Messy>(), ModContent.PrefixType<Mythic>(),
        ModContent.PrefixType<Protective>(), ModContent.PrefixType<Silly>(), ModContent.PrefixType<Slimy>()
    };

    public int HealStamina;
    public bool Tome;
    public bool UpdateInvisibleVanity;
    public bool WasWiring;


    public override bool InstancePerEntity => true;

    public override GlobalItem Clone(Item item, Item itemClone)
    {
        var clone = (AvalonTestingGlobalItemInstance)base.Clone(item, itemClone);
        clone.HealStamina = HealStamina;
        clone.WasWiring = WasWiring;
        clone.Tome = Tome;
        return clone;
    }

    public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
    {
        if (item.IsArmor() && pre == -3)
        {
            return true;
        }

        return base.PrefixChance(item, pre, rand);
    }

    public override int ChoosePrefix(Item item, UnifiedRandom rand)
    {
        return item.IsArmor() ? AllowedPrefixes[rand.Next(AllowedPrefixes.Length)] : base.ChoosePrefix(item, rand);
    }

    public override bool AllowPrefix(Item item, int pre)
    {
        if (!item.IsArmor())
        {
            return base.AllowPrefix(item, pre);
        }

        if (pre is < PrefixID.Hard or >= PrefixID.Legendary)
        {
            return base.AllowPrefix(item, pre);
        }

        pre = AllowedPrefixes[Main.rand.Next(AllowedPrefixes.Length)];
        return base.AllowPrefix(item, pre);
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        TooltipLine tooltipLine = tooltips.FirstOrDefault(x => x.Name == "ItemName" && x.Mod == "Terraria");
        TooltipLine lineKnockback = tooltips.FirstOrDefault(x => x.Name == "Knockback" && x.Mod == "Terraria");
        TooltipLine lineSpeed = tooltips.FirstOrDefault(x => x.Name == "Speed" && x.Mod == "Terraria");
        if (lineKnockback != null)
        {
            if (LanguageManager.Instance.ActiveCulture.LegacyId == (int)GameCulture.CultureName.English)
            {
                if (item.knockBack > 0f && item.knockBack < 1.5f)
                {
                    lineKnockback.Text = "Puny knockback";
                }

                if (item.knockBack > 15f)
                {
                    lineKnockback.Text = "Absurd knockback";
                }

                if (item.knockBack > 17f)
                {
                    lineKnockback.Text = "Ridiculous knockback";
                }

                if (item.knockBack > 19f)
                {
                    lineKnockback.Text = "Godly knockback";
                }
            }
        }

        if (lineSpeed == null)
        {
            return;
        }

        if (LanguageManager.Instance.ActiveCulture.LegacyId != (int)GameCulture.CultureName.English)
        {
            return;
        }

        if (item.useAnimation <= 5f)
        {
            lineSpeed.Text = "Lightning speed";
        }

        if (item.useAnimation >= 58f)
        {
            lineSpeed.Text = "Slowpoke speed";
        }
    }
}
