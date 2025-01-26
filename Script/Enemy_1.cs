using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : MonoBehaviour, Move_Ment
{
    public enum Walk_Direction { Right, Left }
    private Walk_Direction _walk_direction;
    public Animator animator;
    public Rigidbody2D rb_2d;
    public float time;
    public float speed;
    private float time_now;
    private int count_now;
    private Vector2 walk;
    public int count;
    public Vision vision;

    public Detection detection;
    public CheckBox checkbox;

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

    void Start()
    {
        animator = GetComponent<Animator>();
        rb_2d = GetComponent<Rigidbody2D>();
        walk = Vector2.right;
        time_now = time;
        count_now = count;
        detection.set_animater(animator);
        checkbox.set_animater(animator);
    }

    void Update()
    {
        Count();
        move();
        Follow_Object();
    }

    void Count()
    {
        time -= 0.1f;
        if (time <= 0)
        {
            count -= 1;
            time = time_now;
        }

        if (count <= 0)
        {
            count = count_now;
            set_move();
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
}
