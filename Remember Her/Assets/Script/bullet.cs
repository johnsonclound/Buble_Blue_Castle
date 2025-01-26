using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 3;
    [SerializeField] private float damage = 20f;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player collision
            GameObject player = collision.gameObject;
            player.GetComponent < Takedamages >().Takedamages(damage);
            Debug.Log("Hit Player");
        }
    }
}
