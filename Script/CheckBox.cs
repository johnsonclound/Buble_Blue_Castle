using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
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
        IsWall();
    }

    public void IsWall()
    {
        if (detection.Count > 0 && detection[0].name.Equals("Wall"))
        {
            animator.SetBool("Wall", true);
        }
        else
        {
            animator.SetBool("Wall", false);
        }
    }
}
