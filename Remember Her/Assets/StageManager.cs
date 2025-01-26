using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isThunderbolt", true);
        //StartCoroutine(waiter());
        //anim.SetBool("isThunderbolt", false);
    }

    // Update is called once per frame
    void Update()
    {
        /*StartCoroutine(waiter());
        anim.SetBool("Fire_right", true);
        StartCoroutine(waiter());
        anim.SetBool("Fire_right", false);*/
    }
    private IEnumerator waiter() { 
        yield return new WaitForSeconds(10f);
    }
    void Endanime()
    {

    }
}
