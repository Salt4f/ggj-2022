using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverArmor : ActiveAbility
{
    protected override void Initialize() { }
    
    public override void ApplyEffect()
    {
        isActive = true;
        playerManager.activeForm.currentArmor += Mathf.Clamp(100, 0, playerManager.activeForm.stats.MaxArmor);
        GameManager.instance.uiManager.UpdatePlayerArmor(playerManager.activeForm.currentArmor, playerManager.activeForm.stats.MaxArmor);
        StartCooldown();
    }

}
