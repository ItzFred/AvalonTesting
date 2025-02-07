using System.Linq;
using AvalonTesting.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Buffs;

public class BlessingofAvalon : ModBuff
{
    private static readonly int[] DontRemove =
    {
        BuffID.Horrified, BuffID.TheTongue, BuffID.MoonLeech, BuffID.PotionSickness, BuffID.ManaSickness,
        BuffID.Merfolk, BuffID.Werewolf, BuffID.ChaosState, ModContent.BuffType<CurseofIcarus>()
    };

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blessing of Avalon");
        Description.SetDefault("You are immune to almost all debuffs"
                               + "\nYour stats are greatly increased");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        for (int i = 0; i < player.buffType.Length; i++)
        {
            int buffID = player.buffType[i];
            if (Main.debuff[buffID])
            {
                /*if (buffID != BuffID.Horrified || 
                    buffID != BuffID.TheTongue || 
                    buffID != BuffID.MoonLeech || 
                    buffID != BuffID.PotionSickness ||
                    buffID != BuffID.ManaSickness ||
                    buffID != BuffID.Merfolk ||
                    buffID != BuffID.Werewolf ||
                    buffID != BuffID.ChaosState ||
                    buffID != ModContent.BuffType<CurseofIcarus>())*/
                if (!DontRemove.Contains(buffID))
                {
                    player.ClearBuff(buffID);
                }
            }
        }

        player.GetDamage(DamageClass.Generic) += 0.2f;
        player.GetCritChance(DamageClass.Melee) += 10;
        player.GetCritChance(DamageClass.Magic) += 10;
        player.GetCritChance(DamageClass.Ranged) += 10;
        player.GetCritChance(DamageClass.Throwing) += 10;
        player.GetModPlayer<ExxoPlayer>().CritDamageMult += 0.3f;
        player.statDefense += 10;
        player.lifeRegen += 3;
        player.manaRegen += 3;
        player.GetArmorPenetration(DamageClass.Generic) += 10;
        player.manaCost -= 0.2f;
    }
}
