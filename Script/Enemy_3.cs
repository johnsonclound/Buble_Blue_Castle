using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour, Move_Ment
{
    private int count;
    public int count_now;
    private float time;
    public float time_now;
    public float speed;
    private System.Random ramdom;
    public int number_random;
    public Detection detection;
    public CheckBox checkbox;
    public Vision vision;
    public Animator animator;
    public Rigidbody2D rb_2d;
    public enum Walk_Direction { Right, Left, Up, Down }
    private Walk_Direction _walk_direction;
    private Vector2 walk;
    public void move()
    {
        detection.Check();
        checkbox.Check();
        if (animator.GetBool("Run") && !animator.GetBool("Attack"))
        {
            rb_2d.velocity = new Vector2(walk.x * speed, rb_2d.velocity.y);
        }

        if (animator.GetBool("Wall"))
        {
            Flip_Direction();
        }
    }
    public void set_move()
    {
        if (animator.GetBool("Run"))
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }
    public void Flip_Direction()
    {
        if (WalkDirection == Walk_Direction.Left)
        {
            WalkDirection = Walk_Direction.Right;
        }
        else
        {
            WalkDirection = Walk_Direction.Left;
        }
        detection.Check();
        checkbox.Check();
    }
    public void Follow_Object()
    {
        if (vision.all_vision.Count > 0 && vision.all_vision[0].transform.localPosition.x > gameObject.transform.localPosition.x && WalkDirection == Walk_Direction.Left)
        {
            Flip_Direction();
        }
        else if (vision.all_vision.Count > 0 && vision.all_vision[0].transform.localPosition.x < gameObject.transform.localPosition.x && WalkDirection == Walk_Direction.Right)
        {
            Flip_Direction();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb_2d = GetComponent<Rigidbody2D>();
        detection.set_animater(animator);
        checkbox.set_animater(animator);
        walk = Vector2.right;
        time = time_now;
        count = count_now;
        ramdom = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        Count();
        move();
        Follow_Object();
    }

    void Count()
    {
        time_now -= 0.1f;
        if (time_now <= 0)
        {
            count_now -= 1;
            time_now = time;
        }

        if (count_now <= 0)
        {
            count_now = count;
            number_random = ramdom.Next(1, 5);
            set_move();
        }
    }

    public Walk_Direction WalkDirection
    {
        get { return _walk_direction; }
        set
        {
            if (_walk_direction != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value != Walk_Direction.Right)
                {
                    walk = Vector2.left;
                }
                else
                {
                    walk = Vector2.right;
                }
            }
            _walk_direction = value;
        }
    }
}
