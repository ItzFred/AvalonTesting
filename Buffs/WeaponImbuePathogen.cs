using Terraria;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class WeaponImbuePathogen : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Weapon Imbue: Infection");
        Description.SetDefault("Melee attacks inflict Infected on your targets");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.meleeEnchant = 9;
    }
}
