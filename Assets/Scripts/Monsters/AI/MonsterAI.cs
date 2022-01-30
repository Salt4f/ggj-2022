using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    MonsterBeing monster;
    Animator animator;
    Transform player;

    bool following;

    // Start is called before the first frame update
    void Start()
    {
        monster = this.GetComponent<MonsterBeing>();
        animator = this.GetComponent<Animator>();
        player = GameManager.instance.playerManager.activeForm.transform;

        following = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool inSight = false;

        if(!following)
        {
            float angle = Vector3.Angle(transform.forward, player.position - transform.position);

            inSight = (angle <= monster.monsterStats.FieldOfView / 2.0f) && (Vector3.Distance(transform.position, player.position) <= monster.monsterStats.DistanceOfView);
            animator.SetBool("inSight", inSight);
        }
        else
        {
            inSight = (Vector3.Distance(transform.position, player.position) <= monster.monsterStats.DistanceOfView);
        }

        following = inSight;

        bool inRange = inSight && (Vector3.Distance(transform.position, player.position) <= monster.monsterStats.DistanceOfAttack);
        animator.SetBool("inRange", inRange);
    }

    void OnDrawGizmos()
    {
        if(!following)
        {
            monster = this.GetComponent<MonsterBeing>();

            float front = Mathf.Acos((Mathf.PI / 180) * monster.monsterStats.FieldOfView / 2.0f);
            float side = Mathf.Asin((Mathf.PI / 180) * monster.monsterStats.FieldOfView / 2.0f);

            Gizmos.DrawRay(transform.position, (transform.forward * front + transform.right * side).normalized * monster.monsterStats.DistanceOfView);
            Gizmos.DrawRay(transform.position, (transform.forward * front + -transform.right * side).normalized * monster.monsterStats.DistanceOfView);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, monster.monsterStats.DistanceOfView);
        }
    }

    public Vector3 GetNextPosition()
    {
        Battlefield battlefield = GetComponentInParent<Battlefield>();

        if(battlefield)
        {
            return battlefield.GetNextPosition();
        }
        else
        {
            float nextAngle = Utils.GetRandomFloat(10.0f, 40.0f);
            float front = Mathf.Acos((Mathf.PI / 180) * nextAngle);
            float side = Mathf.Asin((Mathf.PI / 180) * nextAngle);
            float x = Utils.GetRandomFloat(0, 1) > 0.5f ? 1.0f : -1.0f;

            Vector3 nextDirection = (transform.forward * front + x * transform.right * side).normalized;

            return transform.position + nextDirection * Utils.GetRandomFloat(monster.monsterStats.MinWanderDistance, monster.monsterStats.MaxWanderDistance);
        }
    }
}
