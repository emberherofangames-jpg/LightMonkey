global using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using LightMonkey;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(LightMonkey.LightMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace LightMonkey;

public class LightMonkey : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<LightMonkey>("LightMonkey loaded!");
    }
}

public class LightMonkeyTower : ModTower
{


    public override Il2CppAssets.Scripts.Models.TowerSets.TowerSet TowerSet => Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Magic;

    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 850;
    public override string Description => "Shoots focused beams of pure light.";

    

    public override int TopPathUpgrades => 1;
    public override int MiddlePathUpgrades => 1;
    public override int BottomPathUpgrades => 1;

    


    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.range = 40f;
        var attackModel = towerModel.GetAttackModel();
        attackModel.range = 40f;

        var sunAvatarWeapon = Game.instance.model.GetTowerFromId("SuperMonkey-300").GetAttackModel().weapons;

        attackModel.weapons[0].projectile = sunAvatarWeapon[0].projectile.Duplicate();

        attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
        attackModel.weapons[0].projectile.pierce = 2f;

        attackModel.weapons[0].projectile.pierce = 2f;

        towerModel.SetDisplay<LightMonkeyModel>();


    }

}

public class LightMonkeyModel : ModCustomDisplay
{
    // Points exactly to your asset file inside your project's AssetBundles folder
    public override string AssetBundleName => "lightmonkeybundle";

    
    public override string PrefabName => "LightMonkeyModel";

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        node.transform.localScale = new UnityEngine.Vector3(100f, 100f, 100f);

        node.transform.localPosition = new UnityEngine.Vector3(0f, 0f, 0f);
    }
}
