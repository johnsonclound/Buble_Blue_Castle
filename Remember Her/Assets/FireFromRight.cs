using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireFromRight : StateMachineBehaviour
{
    private GameObject player;
    private DelayHandler delayHandler;
    private Animator ani;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;

        // Ensure DelayHandler exists on the player GameObject
        delayHandler = player.GetComponent<DelayHandler>();
        if (delayHandler == null)
        {
            delayHandler = player.AddComponent<DelayHandler>();
        }

        Move_UpRight moveTo = player.GetComponent<Move_UpRight>();
        if (moveTo != null)
        {
            moveTo.enabled = true;
        }
        // Delay the entire attack sequence
        delayHandler.ExecuteAfterDelay(2f, ExecuteAttack);
        delayHandler.ExecuteAfterDelay(14f, changetoright);
    }
    private void ExecuteAttack()
    {
        // Enable the Move_To script


        // Activate the Thunder_bolt child object
        Transform Fuuka = player.transform.Find("Fuuka");
        if (Fuuka != null)
        {
            Fuuka.gameObject.SetActive(true);
        }

        // Additional delayed logic if needed
        delayHandler.ExecuteAfterDelay(10f, OnDelayedFunction);
    }
    private void changetoright()
    {
        ani.SetBool("isThunderbolt", true);
    }
    private void OnDelayedFunction()
    {
        Debug.Log("Delayed function called");
        // Add any other final delayed logic here
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ani.SetBool("isThunderbolt", false);
        // Disable the Move_To script
        Debug.Log("WHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        Move_UpRight moveTo = player.GetComponent<Move_UpRight>();
        if (moveTo != null)
        {
            moveTo.enabled = false;
        }

        // Deactivate the Thunder_bolt child object
        Transform thunderBolt = player.transform.Find("Fuuka");
        if (thunderBolt != null)
        {
            thunderBolt.gameObject.SetActive(false);
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
