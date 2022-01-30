using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Being samurai;
    public Being ninja;

    public Being activeForm;

    public PlayerMovement movement;

    private void Awake()
    {
        GameManager.instance.playerManager = this;
        movement = GetComponent<PlayerMovement>();
        activeForm = ninja;
    }

    public void ChangeForm()
    {
        float health = (float)activeForm.currentHealth / activeForm.stats.MaxHealth;
        float armor = (float)activeForm.currentArmor / activeForm.stats.MaxArmor;
        //Trigger particle system
        if (activeForm == samurai)
        {
            activeForm = ninja;
            ninja.gameObject.SetActive(true);
            samurai.gameObject.SetActive(false);
        } else
        {
            activeForm = samurai;
            ninja.gameObject.SetActive(false);
            samurai.gameObject.SetActive(true);
        }
        activeForm.ResetBeing(health, armor);
        GameManager.instance.uiManager.UpdatePlayerArmor(activeForm.currentArmor, activeForm.stats.MaxArmor);
        GameManager.instance.uiManager.UpdatePlayerHealth(activeForm.currentHealth, activeForm.stats.MaxHealth);
    }
}
