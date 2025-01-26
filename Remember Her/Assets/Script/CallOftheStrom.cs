using UnityEngine;

public class CallOfTheStorm : StateMachineBehaviour
{
    private GameObject player;
    private DelayHandler delayHandler;
    private Animator ani;
    private string[] fire;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        ani = animator.GetComponent<Animator>();
        fire = new string[] { "Fire_right", "Fire_left" };

        // Ensure DelayHandler exists on the player GameObject
        delayHandler = player.GetComponent<DelayHandler>();
        if (delayHandler == null)
        {
            delayHandler = player.AddComponent<DelayHandler>();
        }

        Move_To moveTo = player.GetComponent<Move_To>();
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
        Transform thunderBolt = player.transform.Find("Thunder_bolt");
        if (thunderBolt != null)
        {
            thunderBolt.gameObject.SetActive(true);
        }

        // Additional delayed logic if needed
        delayHandler.ExecuteAfterDelay(10f, OnDelayedFunction);
        
    }

    private void changetoright() {
        ani.SetBool(fire[Random.Range(0, fire.Length)], true);
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
        Move_To moveTo = player.GetComponent<Move_To>();
        if (moveTo != null)
        {
            moveTo.enabled = false;
        }

        // Deactivate the Thunder_bolt child object
        Transform thunderBolt = player.transform.Find("Thunder_bolt");
        if (thunderBolt != null)
        {
            thunderBolt.gameObject.SetActive(false);
        }
    }
}