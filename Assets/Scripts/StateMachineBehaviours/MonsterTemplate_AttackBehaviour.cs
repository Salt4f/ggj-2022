using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTemplate_AttackBehaviour : StateMachineBehaviour
{
    MonsterBeing monster;
    private Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<MonsterBeing>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        animator.SetFloat("speed", monster.stats.AttackSpeed / animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.length);

        monster.agent.SetDestination(animator.transform.position);
        monster.agent.isStopped = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = (player.position - animator.transform.position).normalized;
        animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);

        /*
        Quaternion rotation = Quaternion.LookRotation(direction);

        if(Quaternion.Angle(animator.transform.rotation, rotation) > 0.01f)
        {
            animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, Time.fixedDeltaTime * 2.0f);
        }
        */
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("speed", 1.0f);
    }

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
