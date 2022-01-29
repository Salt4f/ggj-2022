using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ActiveAbility : MonoBehaviour
{
    public float cooldown;
    float timer;

    public string triggerName;
    bool isInCooldown;
    protected bool isActive;
    
    protected PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameManager.instance.playerManager;
    }

    private void Update()
    {
        if (isInCooldown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) isInCooldown = false;
        }
    }

    public void OnInput(InputAction.CallbackContext context)
    {
        if (isActive || isInCooldown) return;
        if (context.performed) ApplyEffect();
    }

    public abstract void ApplyEffect();

    public void StartCooldown()
    {
        isActive = false;
        timer = cooldown;
        isInCooldown = true;
    }


}
