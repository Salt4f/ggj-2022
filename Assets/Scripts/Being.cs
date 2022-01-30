using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour
{
    public Stats stats;

    public int currentHealth;
    public int currentArmor;
    public int currentAttack;

    Animator anim;

    void Awake()
    {
        currentAttack = stats.Attack;
        currentHealth = stats.MaxHealth;
        currentArmor = stats.MaxArmor;

        anim = GetComponentInChildren<Animator>();
    }

    public void ResetBeing(float? healthPercentage = null, float? armorPercentage = null)
    {
        if (healthPercentage != null)
        {
            currentHealth = Mathf.CeilToInt(healthPercentage.Value * stats.MaxHealth);
        } else { currentHealth = stats.MaxHealth; }
        if (armorPercentage != null)
        {
            currentArmor = Mathf.CeilToInt(armorPercentage.Value * stats.MaxArmor);
        } else { currentArmor = stats.MaxArmor; }
        currentAttack = stats.Attack;
    }

    public void SetAnimatorTrigger(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }

    public void SetAnimationBool(string boolValue, bool value)
    {
        anim.SetBool(boolValue, value);
    }
}
