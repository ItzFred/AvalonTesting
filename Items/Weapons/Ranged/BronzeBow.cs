using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Items.Weapons.Ranged;

class BronzeBow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bronze Bow");
    }
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.TinBow);
    }
}