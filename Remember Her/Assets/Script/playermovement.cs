using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float acceleration;
    public float GroundSpeed;

    public float Jumpspeed;

    float xInput;
    float yInput;

    public Rigidbody2D body;

    public BoxCollider2D groundCheck;

    public LayerMask groundMask;

    [Range(0f, 1f)]
    public float groundDecay;
    
    public bool grounded;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
        MovewithInput();
        ApplyFriction();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        getInput();
        Handlejump();
    }

    void getInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void MovewithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {

            float increment = acceleration * xInput;
            float newSpeed = Mathf.Clamp(body.velocity.x + increment, -GroundSpeed, GroundSpeed);
            body.velocity = new Vector2(newSpeed, body.velocity.y);
            body.velocity = new Vector2(newSpeed, body.velocity.y);

            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1, 1);
        }
        
    }
    void Handlejump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, Jumpspeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        
    }

    void ApplyFriction()
    {
        if (grounded && Input.GetAxis("Horizontal") == 0 && body.velocity.y <= 0)
        {
            body.velocity *= groundDecay;
        }
    }
}
