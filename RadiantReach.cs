using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace LightMonkey;

public class RadiantReach : ModUpgrade<LightMonkeyTower>
{
    public override string Name => "Radiant Reach";
    public override int Path => 1;
    public override int Tier => 1;
    public override int Cost => 250;
    public override string Description => "Improved light control extends the effective range of its attacks.";

    public override string Icon => "RadiantReach-Icon";
    public override string Portrait => "RadiantReach-Portrait";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        // 1. Set the visual scanning range to 50
        towerModel.range = 50f;

        // 2. Set the actual weapon firing range to 50
        var attackModel = towerModel.GetAttackModel();
        attackModel.range = 50f;
    }
}
