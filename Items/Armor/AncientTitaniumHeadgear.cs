using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class AncientTitaniumHeadgear : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ancient Titanium Headgear");
        Tooltip.SetDefault("10% increased ranged damage\nIncreases maximum mana by 20");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.defense = 7;
        Item.rare = ItemRarityID.Orange;
        Item.width = dims.Width;
        Item.value = 100000;
        Item.height = dims.Height;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == ModContent.ItemType<AncientTitaniumPlateMail>() && legs.type == ModContent.ItemType<AncientTitaniumGreaves>();
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "20% increased melee speed";
        player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
    }

    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 20;
        player.GetDamage(DamageClass.Ranged) += 0.1f;
    }
}
