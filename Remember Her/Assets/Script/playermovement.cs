using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour, Takedamages
{
    // Start is called before the first frame update
    public Animator Animator;
    public float acceleration;
    public float GroundSpeed;
    private float xInput;
    private float yInput;
    public Rigidbody2D RB;
    public float Jumpspeed;
    bool jump = false;

    [SerializeField] bool onPer;
    [SerializeField] bool onGua;
    [SerializeField] float DurationGua;
    bool sucper = false;

    bool isattacking = false;
    public GameObject attackpoint;
    public float radius;
    public LayerMask enemies;
    public float damage;

    public float Hp;
    public float currHp;

    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    [Range(0f, 1f)]
    public float groundDecay;
    public bool grounded;

    Musichandling musicmanager;

    private void Awake()
    {
        musicmanager = GameObject.FindGameObjectWithTag("Music").GetComponent<Musichandling>();
    }
    void Start()
    {
        currHp = Hp;
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        MovewithInput();
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        Handlejump();
        if (Input.GetMouseButtonDown(0))
        {
            isattacking = true;
            Animator.SetBool("isattacking", isattacking);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("10 damage");
            StartCoroutine(EnemyAttack());
        }

        if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(CountGuard());
            StartCoroutine(CountP());
            Animator.SetBool("isblocking", true);
        }

        
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
            float newSpeed = Mathf.Clamp(RB.velocity.x + increment, -GroundSpeed, GroundSpeed);

            RB.velocity = new Vector2(newSpeed, RB.velocity.y);

            Animator.SetFloat("speed", Mathf.Abs(increment));

            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1, 1);
        }

    }
    void Handlejump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            
            jump = true;
            Animator.SetBool("isjumping", jump);
            RB.velocity = new Vector2(RB.velocity.x, Jumpspeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        //Debug.Log(RB.velocity.y);
        if(grounded && RB.velocity.y == 0 )
        {
            jump = false;
            Animator.SetBool("isjumping", jump);
        }
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && RB.velocity.y == 0)
        {
            RB.velocity *= groundDecay;
        }
    }

    void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackpoint.transform.position, radius, enemies);

    foreach(Collider2D enemyGameObject in enemy)
        {
            musicmanager.Playmusic(musicmanager.Boss);
            Debug.Log("hit enemy!");
            //enemyGameObject.GetComponent<Enemy>().health -= damage;
            enemyGameObject.GetComponent<Takedamages>().Takedamages(damage);
        }
    }
    
    public void endattack()
    {
        isattacking = false;
        Animator.SetBool("isattacking", isattacking);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint.transform.position, radius);
    }

    public void Takedamages(float damage)
    {
        if (sucper)
        {
            damage = 0;
            currHp -= damage;
            sucper = false;
        }
        else if (onGua)
        {
            float chipp = damage * 0.3f;
            Debug.Log(chipp);
            currHp -= chipp;
            if (currHp > 0 && damage > 0)
            {
                Animator.SetTrigger("Attacked");
            }
            else
            {
                Animator.SetBool("isded", true);
            }
        }
        else
        {
            currHp -= damage;
            if (currHp > 0 && damage > 0)
            {
                Animator.SetTrigger("Attacked");
            }
            else
            {
                Animator.SetBool("isded", true);
            }
        }
        
    }

    public void endblocking()
    {
        Animator.SetBool("isblocking", false);
    }
    IEnumerator CountP()
    {
        onPer = true;
        yield return new WaitForSeconds(0.1f);
        onPer = false;
    }
    IEnumerator CountGuard()
    {
        onGua = true;
        yield return new WaitForSeconds(DurationGua);
        onGua = false;
    }
    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Enemy Attack 10 dmg");
        this.Takedamages(10);
        if (onGua)
        {
            if (onPer)
            {
                Animator.SetBool("Perfect", true);
                sucper = true;
                Debug.Log("P G");
            }
            else if (!onPer)
            {

                Debug.Log("N G");
            }
        }
        else
        {
            Debug.Log("C't bloack");
        }
    }

    public void unperfect()
    {
        Animator.SetBool("Perfect", false);
    }
}
