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
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.isTrigger)
        {
            float damage = collider.gameObject.GetComponentInParent<MonsterBeing>().currentAttack;

            Debug.Log("Player receives " + damage + " damage");
        }
    }
}
