﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Accessories;

public class AlchemicalSkull : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Alchemical Skull");
        Tooltip.SetDefault("Increases spawn rate and Attackers also take damage"
                           + "\nThe wearer can walk on water and lava"
                           + "\nGrants immunity to knockback and fire blocks");
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 8;
        Item.rare = ItemRarityID.LightRed;
        Item.width = dims.Width;
        Item.accessory = true;
        Item.value = 150000;
        Item.height = dims.Height;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.waterWalk = player.waterWalk2 = player.enemySpawns = player.noKnockback = player.fireWalk = true;
        player.thorns = 1f;
    }
}
