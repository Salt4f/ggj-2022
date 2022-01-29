using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour
{
    public Stats stats;

    public float currentHealth;
    public float currentArmor;
    public float currentAttack;

    Animator anim;

    void Awake()
    {
        currentAttack = stats.Attack;
        currentHealth = stats.MaxHealth;
        currentArmor = stats.MaxArmor;

        anim = GetComponent<Animator>();
    }

    public void SetAnimatorTrigger(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }
}
