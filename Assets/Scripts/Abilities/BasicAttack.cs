using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : ActiveAbility
{
    public override void ApplyEffect()
    {
        isActive = true;
        playerManager.activeForm.SetAnimatorTrigger(triggerName);
        StartCooldown();
    }
}
