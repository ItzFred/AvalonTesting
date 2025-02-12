﻿using AvalonTesting.Items.Material;
using AvalonTesting.Items.Placeable.Painting;
using AvalonTesting.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.BossBags;

public class OblivionBossBag : ModItem
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

        if (Main.rand.Next(4) == 0)
        {
            player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<CurseofOblivion>(), 1);
        }
        player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Tools.AccelerationDrill>(), 1);
        player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<SoulofTorture>(), Main.rand.Next(60, 121));
        if (Main.rand.Next(5) > 0)
        {
            player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<VictoryPiece>(), 1);
        }
        else
        {
            player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<VictoryPiece>(), 2);
        }
        player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<OblivionOre>(), Main.rand.Next(100, 201));
        if (Main.rand.Next(20) == 0)
        {
            player.QuickSpawnItem(player.GetSource_OpenItem(Item.type), ModContent.ItemType<Accessories.LuckyPapyrus>());
        }
    }

    //public override int BossBagNPC => ModContent.NPCType<NPCs.AncientOblivionHead1>();
}
