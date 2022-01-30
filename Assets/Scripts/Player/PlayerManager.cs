using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Being samurai;
    public Being ninja;

    public Being activeForm;

    public PlayerMovement movement;

    float armorTimer;

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
        armorTimer = 0;
    }

    private void Update()
    {
        if(activeForm.currentArmor < activeForm.stats.MaxArmor)
        {
            armorTimer += Time.deltaTime;
            if(armorTimer >= 1.0f)
            {
                armorTimer -= 1.0f;
                activeForm.currentArmor++;

                GameManager.instance.uiManager.UpdatePlayerArmor(activeForm.currentArmor, activeForm.stats.MaxArmor);
            }
        }
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
            GameManager.instance.uiManager.ChangeFace(false);
            ninja.gameObject.SetActive(true);
            samurai.gameObject.SetActive(false);
        } else
        {
            activeForm = samurai;
            postProcess.SetActive(false);
            GameManager.instance.uiManager.ChangeFace(true);
            ninja.gameObject.SetActive(false);
            samurai.gameObject.SetActive(true);
        }
        activeForm.ResetBeing(health, armor);
        GameManager.instance.uiManager.UpdatePlayerArmor(activeForm.currentArmor, activeForm.stats.MaxArmor);
        GameManager.instance.uiManager.UpdatePlayerHealth(activeForm.currentHealth, activeForm.stats.MaxHealth);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.isTrigger)
        {
            int damage = collider.gameObject.GetComponentInParent<MonsterBeing>().currentAttack;

            Debug.Log("Player receives " + damage + " damage");

            if(activeForm.currentArmor > 0)
            {
                int toreduce = Mathf.Min(activeForm.currentArmor, damage);
                activeForm.currentArmor -= toreduce;
                damage -= toreduce;
            }

            if(damage > 0)
            {
                activeForm.currentHealth -= damage;

                if(activeForm.currentHealth <= 0)
                {
                    activeForm.SetAnimatorTrigger("die");
                }
            }

            GameManager.instance.uiManager.UpdatePlayerHealth(activeForm.currentHealth, activeForm.stats.MaxHealth);
            GameManager.instance.uiManager.UpdatePlayerArmor(activeForm.currentArmor, activeForm.stats.MaxArmor);

        }
    }
}
