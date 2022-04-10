using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Ammo;

public class Canister : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 9;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 14;
        Item.height = 18;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.value = 10;
        Item.rare = ItemRarityID.Red;
        Item.shoot = ModContent.ProjectileType<Projectiles.FleshFire>();
        Item.ammo = Item.type;
    }
}