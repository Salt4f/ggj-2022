using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster_RunBehaviour : StateMachineBehaviour
{
    private const float runVelocity = 0.6f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("detected", true);
        animator.SetBool("inRange", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(animator.transform.position, Utils.getPlayerPos()) > 10.0f)
        {
            animator.SetBool("detected", false);
            return;
        }

        if(Vector3.Distance(animator.transform.position, Utils.getPlayerPos()) < 1.0f)
        {
            animator.SetBool("inRange", true);
            return;
        }

        Vector3 direction = (Utils.getPlayerPos() - animator.transform.position).normalized;
        animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);

        
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, Utils.getPlayerPos(), Time.fixedDeltaTime * runVelocity);


        /*
        Vector3 direction = (Utils.getPlayerPos() - animator.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        if(Quaternion.Angle(animator.transform.rotation, rotation) < 0.1f)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, Utils.getPlayerPos(), Time.fixedDeltaTime * 0.8f);
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
