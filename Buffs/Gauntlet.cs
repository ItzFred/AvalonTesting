using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class Gauntlet : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gauntlet");
        Description.SetDefault("-6 defense, +12% melee damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense -= 6;
        player.GetDamage(DamageClass.Melee) += 0.12f;
    }
}
