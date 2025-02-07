﻿using AvalonTesting.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

// TODO: LAVA MERMAN
internal class BestialBand : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bestial Band");
        Tooltip.SetDefault(
            "Turns the holder into merfolk upon entering water\nTurns the holder into varefolk upon entering lava\nTurns the holder into a werewolf at night\nMinor increase to all stats");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 2;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 10);
        Item.accessory = true;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.GetModPlayer<ExxoBuffPlayer>().AccLavaMerman = true;
        player.fireWalk = true;
        player.ignoreWater = true;
        player.accMerman = true;
        player.accFlipper = true;
        player.wolfAcc = true;
        player.lavaImmune = true;
        player.waterWalk = true;
        player.lifeRegen += 2;
        player.statDefense += 4;
        player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
        player.GetDamage(DamageClass.Generic) += 0.1f;
        player.GetCritChance(DamageClass.Generic) += 2;
        player.pickSpeed -= 0.15f;
        player.GetKnockback(DamageClass.Summon) += 0.5f;
    }
}
