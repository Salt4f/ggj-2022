using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : ActiveAbility
{
    protected override void Initialize() { }
    
    public override void ApplyEffect()
    {
        isActive = true;
        playerManager.ChangeForm();
        StartCooldown();
    }

}
