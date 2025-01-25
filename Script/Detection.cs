using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public List<Collider2D> detection = new List<Collider2D>();
    Collider2D cd_2d;

    public Animator animator;

    public void set_animater(Animator a)
    {
        animator = a;
    }

    void Start()
    {
        cd_2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        detection.Add(collider);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        detection.Remove(collider);
    }

    public void Check() {
        IsPlayer();
    }


    public void IsPlayer()
    {
        if (detection.Count > 0 && detection[0].name.Equals("Player"))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
}
