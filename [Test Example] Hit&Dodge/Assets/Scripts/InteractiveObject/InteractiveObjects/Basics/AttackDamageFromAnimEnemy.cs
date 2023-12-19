using System.Collections;
using System.Collections.Generic;
using InteractiveObjects.Handlers;
using UnityEngine;

namespace InteractiveObjects.Basics
{
    public class AttackDamageFromAnimEnemy : StateMachineBehaviour
    {
        [SerializeField] private int damageAmount = 2;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            HealthHandler playerHealth =
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<HealthHandler>();

            if (playerHealth != null)
            {
                playerHealth.InflictDamageOnPlayer(damageAmount);
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

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
}