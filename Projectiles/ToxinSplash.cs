using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvalonTesting.Projectiles;

public class ToxinSplash : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Toxin Splash");
    }
    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.light = 0.2f;
        Projectile.penetrate = -1;
        Projectile.tileCollide = true;
        Projectile.ignoreWater = true;
        Projectile.timeLeft = 300;
    }
    public override bool OnTileCollide(Vector2 oldVelocity) { return false; }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        target.AddBuff(BuffID.Poisoned, 300);
    }
}
