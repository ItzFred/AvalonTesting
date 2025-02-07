using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class Wisdom : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Wisdom");
        Description.SetDefault("-8% magic damage, +60 mana");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statManaMax2 += 60;
        player.GetDamage(DamageClass.Magic) -= 0.08f;
    }
}
