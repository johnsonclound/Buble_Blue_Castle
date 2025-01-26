using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warping : MonoBehaviour
{

    public float warpPadding = 0.1f;
    public Transform warpDestination;
    public int warpcooldown = 3;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Anim.SetBool("warping", true);
            WarpPlayer();
            
        }
    }

    void WarpPlayer()
    {
        
        Anim.SetTrigger("warping");
        if (warpDestination != null)
        {

            StartCoroutine(WarpWithAnimation());
        }
        else
        {
            Debug.LogWarning("Warp destination not set!");
        }
    }

    IEnumerator WarpWithAnimation()
    {
        Anim.SetBool("warping", true);
        yield return new WaitForSeconds(0.5f); // Wait for the animation to play partially
        transform.position = warpDestination.position;
        Debug.Log("Player warped to: " + warpDestination.position);
        Anim.SetBool("warping", false);

        // Reset the animation state
        Anim.SetBool("warping", false);
    }
    void warphandle()
    {
        Anim.SetBool("warping", false);
    }
}
