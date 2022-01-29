using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBeing : Being
{
    public MonsterStats monsterStats;

    private Animator animator;

    public NavMeshAgent agent;

    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerManager = GameManager.instance.playerManager; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.isTrigger)
        {
            float damage = playerManager.activeForm.currentAttack;

            Debug.Log("Monster receives " + damage + " damage");

            if(true) // Check receives dmg
            {
                animator.SetTrigger("attacked");
            }

            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                animator.SetBool("dead", true);
            }
        }
    }
}
