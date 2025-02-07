﻿using AvalonTesting.Items.Accessories;
using AvalonTesting.Items.Material;
using AvalonTesting.Items.Placeable.Bar;
using AvalonTesting.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Systems;
public class RecipeSystem : ModSystem
{
    public override void AddRecipeGroups()
    {
        if (RecipeGroup.recipeGroupIDs.ContainsKey("Wood"))
        {
            int index = RecipeGroup.recipeGroupIDs["Wood"];
            RecipeGroup group0 = RecipeGroup.recipeGroups[index];
            group0.ValidItems.Add(ModContent.ItemType<DarkMatterWood>());
            group0.ValidItems.Add(ModContent.ItemType<Coughwood>());
            group0.ValidItems.Add(ModContent.ItemType<TropicalWood>());
            group0.ValidItems.Add(ModContent.ItemType<ResistantWood>());
        }

        var groupWings = new RecipeGroup(() => "Any Wings", new int[]
        {
            ItemID.DemonWings,
            ItemID.AngelWings,
            ItemID.ButterflyWings,
            ItemID.FairyWings,
            ItemID.HarpyWings,
            ItemID.BoneWings,
            ItemID.FlameWings,
            ItemID.FrozenWings,
            ItemID.GhostWings,
            ItemID.LeafWings,
            ItemID.BatWings,
            ItemID.BeeWings,
            ItemID.TatteredFairyWings,
            ItemID.SpookyWings,
            ItemID.FestiveWings,
            ItemID.BeetleWings,
            ItemID.FinWings,
            ItemID.FishronWings,
            ItemID.WingsNebula,
            ItemID.WingsSolar,
            ItemID.WingsStardust,
            ItemID.WingsVortex,
            ItemID.FinWings,
            ItemID.MothronWings,
            ItemID.BetsyWings,
            ItemID.SteampunkWings,
            ModContent.ItemType<ContagionWings>(),
            ModContent.ItemType<CrimsonWings>(),
            ModContent.ItemType<CorruptionWings>(),
            ModContent.ItemType<HolyWings>(),
            ModContent.ItemType<EtherealWings>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:Wings", groupWings);
        var groupWorkBenches = new RecipeGroup(() => "Any Work Bench", new int[]
        {
            ItemID.WorkBench,
            ItemID.EbonwoodWorkBench,
            ItemID.BlueDungeonWorkBench,
            ItemID.SteampunkWorkBench,
            ItemID.SpookyWorkBench,
            ItemID.SlimeWorkBench,
            ItemID.SkywareWorkbench,
            ItemID.ShadewoodWorkBench,
            ItemID.RichMahoganyWorkBench,
            ItemID.PumpkinWorkBench,
            ItemID.PinkDungeonWorkBench,
            ItemID.PearlwoodWorkBench,
            ItemID.PalmWoodWorkBench,
            ItemID.ObsidianWorkBench,
            ItemID.MushroomWorkBench,
            ItemID.MeteoriteWorkBench,
            ItemID.MartianWorkBench,
            ItemID.MarbleWorkBench,
            ItemID.LivingWoodWorkBench,
            ItemID.LihzahrdWorkBench,
            ItemID.HoneyWorkBench,
            ItemID.GreenDungeonWorkBench,
            ItemID.GraniteWorkBench,
            ItemID.GoldenWorkbench,
            ItemID.GlassWorkBench,
            ItemID.FrozenWorkBench,
            ItemID.FleshWorkBench,
            ItemID.DynastyWorkBench,
            ItemID.CrystalWorkbench,
            ItemID.CactusWorkBench,
            ItemID.BorealWoodWorkBench,
            ItemID.BoneWorkBench,
            ItemID.GothicWorkBench,
            ModContent.ItemType<Items.Placeable.Crafting.CoughwoodWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.DarkSlimeWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.HeartstoneWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.OrangeDungeonWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.ResistantWoodWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.VertebraeWorkBench>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:WorkBenches", groupWorkBenches);

        var groupHerbs = new RecipeGroup(() => "Any Herb", new int[]
        {
            ItemID.Blinkroot,
            ItemID.Fireblossom,
            ItemID.Deathweed,
            ItemID.Shiverthorn,
            ItemID.Waterleaf,
            ItemID.Moonglow,
            ItemID.Daybloom,
            ModContent.ItemType<Bloodberry>(),
            ModContent.ItemType<Sweetstem>(),
            ModContent.ItemType<Barfbush>(),
            ModContent.ItemType<Holybird>(),
            //ModContent.ItemType<Items.TwilightPlume>(),
        });
        RecipeGroup.RegisterGroup("AvalonTesting:Herbs", groupHerbs);

        var groupTier1Watch = new RecipeGroup(() => "Any Copper Watch", new int[]
        {
            ItemID.CopperWatch,
            ItemID.TinWatch,
            ModContent.ItemType<BronzeWatch>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:Tier1Watch", groupTier1Watch);

        var groupTier2Watch = new RecipeGroup(() => "Any Silver Watch", new int[]
        {
            ItemID.SilverWatch,
            ItemID.TungstenWatch,
            ModContent.ItemType<ZincWatch>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:Tier2Watch", groupTier2Watch);

        var groupTier3Watch = new RecipeGroup(() => "Any Gold Watch", new int[]
        {
            ItemID.GoldWatch,
            ItemID.PlatinumWatch,
            ModContent.ItemType<BismuthWatch>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:Tier3Watch", groupTier3Watch);

        var groupGoldBar = new RecipeGroup(() => "Any Gold Bar", new int[]
        {
            ItemID.GoldBar,
            ItemID.PlatinumBar,
            ModContent.ItemType<BismuthBar>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:GoldBar", groupGoldBar);

        if (RecipeGroup.recipeGroupIDs.ContainsKey("IronBar"))
        {
            int index = RecipeGroup.recipeGroupIDs["IronBar"];
            RecipeGroup groupWood = RecipeGroup.recipeGroups[index];
            groupWood.ValidItems.Add(ModContent.ItemType<NickelBar>());
        }

        var groupCopperBar = new RecipeGroup(() => "Any Copper Bar", new int[]
        {
            ItemID.CopperBar,
            ItemID.TinBar,
            ModContent.ItemType<BronzeBar>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:CopperBar", groupCopperBar);

        var groupSilverBar = new RecipeGroup(() => "Any Silver Bar", new int[]
        {
            ItemID.SilverBar,
            ItemID.TungstenBar,
            ModContent.ItemType<ZincBar>()
        });
        RecipeGroup.RegisterGroup("AvalonTesting:SilverBar", groupSilverBar);
    }
}
