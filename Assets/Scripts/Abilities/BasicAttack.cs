using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : ActiveAbility
{
    protected override void Initialize()
    {
        cooldown = playerManager.activeForm.stats.AttackSpeed;
    }

    public override void ApplyEffect()
    {
        isActive = true;
        playerManager.activeForm.SetAnimatorTrigger(triggerName);
        StartCooldown();
    }

}
