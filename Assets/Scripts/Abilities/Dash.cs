using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ActiveAbility
{
    public float dashSpeed = 2f;

    public override void ApplyEffect()
    {
        isActive = true;
        var p = playerManager.movement;
        var dir = (p.camTarget.forward * p.moveInput.y + p.camTarget.right * p.moveInput.x); dir.y = 0; dir.Normalize();
        if (dir.magnitude == 0) { dir = p.camTarget.forward; dir.y = 0; dir.Normalize(); }
        playerManager.GetComponent<Rigidbody>().AddForce(dir * dashSpeed, mode: ForceMode.Impulse);
        playerManager.activeForm.transform.rotation = Quaternion.LookRotation(dir);
        StartCooldown();
    }
}
