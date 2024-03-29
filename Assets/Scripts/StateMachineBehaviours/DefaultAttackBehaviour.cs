using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttackBehaviour : StateMachineBehaviour
{
    MonsterBeing monster;
    private Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<MonsterBeing>();
        player = GameManager.instance.playerManager.activeForm.transform;

        //animator.GetComponentInChildren<BoxCollider>().enabled = true;

        animator.SetFloat("speed", monster.stats.AttackSpeed / animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.length);

        monster.agent.isStopped = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = (player.position.XZPlane() - animator.transform.position.XZPlane()).normalized;
        animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("speed", 1.0f);

        //animator.GetComponentInChildren<BoxCollider>().enabled = false;
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
