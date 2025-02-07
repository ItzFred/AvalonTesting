﻿using AvalonTesting.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.BossBags;

public class DragonLordBossBag : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Treasure Bag");
        Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.consumable = true;
        Item.width = 36;
        Item.height = 34;
        Item.rare = ItemRarityID.Purple;
        Item.expert = true;
    }

    public override bool CanRightClick()
    {
        return true;
    }

    public override void OpenBossBag(Player player)
    {
        player.TryGettingDevArmor(player.GetSource_OpenItem(Item.type));

        player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<DragonScale>(), Main.rand.Next(10, 21));
        player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Accessories.DragonsBondage>());
        int rand = Main.rand.Next(5);
        if (rand == 0) player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Accessories.DragonStone>());
        else if (rand == 1) player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Weapons.Melee.Infernasword>());
        else if (rand == 2) player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Weapons.Ranged.QuadroCannon>());
        else if (rand == 3) player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Weapons.Magic.MagmafrostBolt>());
        else if (rand == 4) player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Weapons.Summon.ReflectorStaff>());
    }

    public override int BossBagNPC => ModContent.NPCType<NPCs.DragonLordHead>();
}
