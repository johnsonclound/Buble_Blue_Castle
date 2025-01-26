using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Get player's position
        Vector3 playerPosition = player.transform.position;

        // Calculate direction from monster to player
        Vector3 direction = playerPosition - transform.position;

        Vector3 currentScale = transform.localScale;
        // Decide facing direction based on X-axis
        if (direction.x > 0)
            currentScale.x = -Mathf.Abs(currentScale.x); // Face left

        else
            currentScale.x = Mathf.Abs(currentScale.x); ; // Face right
        transform.localScale = currentScale;
    }
}
