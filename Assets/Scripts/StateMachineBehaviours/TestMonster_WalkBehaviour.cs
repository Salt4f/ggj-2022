using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster_WalkBehaviour : StateMachineBehaviour
{
    private const float walkVelocity = 0.2f;
    private Vector3 targetPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        targetPosition = animator.transform.position + Quaternion.AngleAxis(360 * Utils.getRandomFloat(0.0f, 1.0f), animator.transform.up) * animator.transform.forward * Utils.getRandomFloat(2.0f, 8.0f);
    
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


        Vector3 direction = (targetPosition - animator.transform.position).normalized;
        animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);

        if(Vector3.Distance(animator.transform.position, targetPosition) < 0.05f)
        {
            animator.SetBool("wanderToggle", false);
        }
        else
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, targetPosition, Time.fixedDeltaTime * walkVelocity);
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
