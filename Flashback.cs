using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace LightMonkey;

public class Flashback : ModUpgrade<LightMonkeyTower>
{
    public override int Path => 2; // Bottom Path
    public override int Tier => 1;
    public override int Cost => 300;
    public override string Description => "Light lingers on bloons it strikes, briefly slowing their movement if they survive the hit.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();

        // Reordered to match your compiler's exact signature:
        // (string, float, float, string, int, string, bool, bool, EffectModel, bool, bool, bool, int, int, bool)
        var flashbackSlow = new Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.SlowModel(
            "FlashbackSlow", // 1. string id
            0.9f,            // 2. float speed (0.9f = 10% slow)
            2f,              // 3. float lifespan (2 seconds)
            "",              // 4. string overlayType
            0,               // 5. int layerLimit (0 means normal bloons only, ignores MOABs)
            "",              // 6. string (Changed from bool to string)
            false,           // 7. bool
            false,           // 8. bool (Changed from null to bool)
            null,            // 9. EffectModel (Changed from bool to null EffectModel)
            false,           // 10. bool
            false,           // 11. bool
            false,           // 12. bool (Changed from float to bool)
            0,               // 13. int
            0,               // 14. int (Changed from bool to int)
            false            // 15. bool
        );

        // Inject this perfectly structured model directly into your projectile
        attackModel.weapons[0].projectile.AddBehavior(flashbackSlow);
    }


}

