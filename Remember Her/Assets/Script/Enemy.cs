using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Takedamages
{
    public float health;
    public float currHealth;
    private Animator Anim;
    public Collider2D Cr;
    public bool ded = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        currHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void diehandle()
    {
        Destroy(this.gameObject);
    }

    public void Takedamages(float damage)
    {
        currHealth -= damage;
        if (currHealth > 0)
        {
            Anim.SetTrigger("Attacked");
        }
        else
        {
            Anim.SetBool("isded", true);

            //Debug.Log("enemy is dead");
        }
    }
   
}

