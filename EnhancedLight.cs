using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;

namespace LightMonkey;

public class EnhancedLight : ModUpgrade<LightMonkeyTower>
{
    

    public override string Name => "Enhanced Light";
    public override int Path => 0;
    public override int Tier => 1;
    public override int Cost => 500;
    public override string Description => "Refined light energy pierces deeper and travels faster.";

    public override string Icon => "EnhancedLight-Icon";
    public override string Portrait => "EnhancedLight-Portrait";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();

        
        attackModel.weapons[0].projectile.pierce = 4f;

        
        attackModel.weapons[0].rate = 0.8f;

        
        var adoraProjectile = Game.instance.model.GetTowerFromId("Adora").GetAttackModel().weapons[0].projectile;
        attackModel.weapons[0].projectile.display = adoraProjectile.display;
    }
}
