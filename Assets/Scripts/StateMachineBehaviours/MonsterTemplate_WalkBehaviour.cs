using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterTemplate_WalkBehaviour : StateMachineBehaviour
{
    MonsterBeing monster;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<MonsterBeing>();
        Vector3 target = Utils.getNextPosition(animator.transform, Utils.getRandomFloat(monster.monsterStats.MinWanderDistance, monster.monsterStats.MaxWanderDistance));

        monster.agent.isStopped = false;
        monster.agent.speed = monster.stats.MovementSpeed * 0.33f;
        monster.agent.SetDestination(target);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector3 direction = (target - animator.transform.position).normalized;
        //animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);

        Vector3 direction = (monster.agent.destination - animator.transform.position).normalized;
        animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);

        if(monster.agent.remainingDistance < 0.01f)
        {
            animator.SetBool("isWalking", false);
        }

        /*
        if(Quaternion.Angle(animator.transform.rotation, rotation) < 0.01f)
        {
            if(Vector3.Distance(animator.transform.position, targetPosition) < 0.1)
            {
                animator.SetBool("wanderToggle", false);
            }
            else
            {
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, targetPosition, Time.fixedDeltaTime * 0.2f);
            }

        }
        else
        {
            animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, Time.fixedDeltaTime * 1.5f);
        }
        */
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
