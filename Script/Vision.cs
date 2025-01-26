using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public List<Collider2D> all_vision = new List<Collider2D>();
    Collider2D cd_2d;

    void Start()
    {
        cd_2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("Player"))
        {
            all_vision.Add(collider);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        all_vision.Remove(collider);
    }
}
