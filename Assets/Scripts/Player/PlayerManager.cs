using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Being samurai;
    public Being ninja;

    public Being activeForm;

    public PlayerMovement movement;

    ParticleSystem ps;
    [SerializeField]
    GameObject postProcess;

    private void Awake()
    {
        GameManager.instance.playerManager = this;
        movement = GetComponent<PlayerMovement>();
        ps = GetComponent<ParticleSystem>();
        activeForm = ninja;
    }

    private void Start()
    {
        ChangeForm(false);
    }

    public void ChangeForm(bool particleSystem)
    {
        float health = (float)activeForm.currentHealth / activeForm.stats.MaxHealth;
        float armor = (float)activeForm.currentArmor / activeForm.stats.MaxArmor;
        if (particleSystem) ps.Play();
        if (activeForm == samurai)
        {
            activeForm = ninja;
            postProcess.SetActive(true);
            ninja.gameObject.SetActive(true);
            samurai.gameObject.SetActive(false);
        } else
        {
            activeForm = samurai;
            postProcess.SetActive(false);
            ninja.gameObject.SetActive(false);
            samurai.gameObject.SetActive(true);
        }
        activeForm.ResetBeing(health, armor);
        GameManager.instance.uiManager.UpdatePlayerArmor(activeForm.currentArmor, activeForm.stats.MaxArmor);
        GameManager.instance.uiManager.UpdatePlayerHealth(activeForm.currentHealth, activeForm.stats.MaxHealth);
    }
}
