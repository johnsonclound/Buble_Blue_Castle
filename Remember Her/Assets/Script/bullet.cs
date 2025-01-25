using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
