using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBeing : Being
{
    public MonsterStats monsterStats;

    public Animator animator;

    public NavMeshAgent agent;

    public PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerManager = GameManager.instance.playerManager;

        Initialize();
    }

    public virtual void Initialize() {}

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnDamaged(int damage)
    {
        Debug.Log("Monster receives " + damage + " damage");

        if(monsterStats.HasDamageReaction)
        {
            animator.SetTrigger("attacked");
        }

        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            animator.SetBool("dead", true);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.isTrigger && collider.tag == "Player")
        {
            int damage = playerManager.activeForm.currentAttack;
            OnDamaged(damage);            
        }
    }
}
