using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    MonsterBeing monster;
    Animator animator;
    float timer;
    Transform player;

    void Awake()
    {
        monster = this.GetComponent<MonsterBeing>();
        animator = this.GetComponent<Animator>();
        timer = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(transform.forward, player.position - transform.position);

        bool inSight = (angle <= monster.monsterStats.FieldOfView / 2.0f) && (Vector3.Distance(transform.position, player.position) <= monster.monsterStats.DistanceOfView);
        animator.SetBool("inSight", inSight);

        bool inRange = inSight && (Vector3.Distance(transform.position, player.position) <= monster.monsterStats.DistanceOfAttack);
        animator.SetBool("inRange", inRange);
    }

    void OnDrawGizmos()
    {
        monster = this.GetComponent<MonsterBeing>();

        float front = Mathf.Acos((Mathf.PI / 180) * monster.monsterStats.FieldOfView / 2.0f);
        float side = Mathf.Asin((Mathf.PI / 180) * monster.monsterStats.FieldOfView / 2.0f);

        Gizmos.DrawRay(transform.position, (transform.forward * front + transform.right * side).normalized * monster.monsterStats.DistanceOfView);
        Gizmos.DrawRay(transform.position, (transform.forward * front + -transform.right * side).normalized * monster.monsterStats.DistanceOfView);
    }
}
