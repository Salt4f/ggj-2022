using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour
{
    public Stats stats;

    public float currentHealth;
    public float currentArmor;
    public float currentAttack;

    // Start is called before the first frame update
    void Awake()
    {
        currentAttack = stats.Attack;
        currentHealth = stats.MaxHealth;
        currentArmor = stats.MaxArmor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
