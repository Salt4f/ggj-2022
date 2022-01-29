using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster_IdleBehaviour : StateMachineBehaviour
{
    float idleSeconds, currentSeconds;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleSeconds = Utils.getRandomFloat(2.0f, 8.0f);
        currentSeconds = 0.0f;

        animator.SetBool("detected", false);
        animator.SetBool("inRange", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(animator.transform.position, Utils.getPlayerPos()) < 10.0f)
        {
            animator.SetBool("detected", true);
            if(Vector3.Distance(animator.transform.position, Utils.getPlayerPos()) < 1.0f)
            {
                animator.SetBool("inRange", true);
            }
            return;
        }

        currentSeconds += Time.fixedDeltaTime;
        if(currentSeconds >= idleSeconds)
        {
            animator.SetBool("wanderToggle", true);
        }
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
