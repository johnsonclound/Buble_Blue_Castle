using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To : MonoBehaviour
{
    public GameObject obj;
    public GameObject goal;
    public float speed;

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, goal.transform.position, speed * Time.deltaTime);
    }
}