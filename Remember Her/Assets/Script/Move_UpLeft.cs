using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_UpLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject goal;
    public GameObject goal2;
    public float speed;
    private bool firstGoalReached = false;

    void Update()
    {
        if (!firstGoalReached)
        {
            MoveToFirstGoal();
        }
        else
        {
            MoveToSecondGoal();
        }
    }

    void MoveToFirstGoal()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, goal.transform.position, speed * Time.deltaTime);

        if (obj.transform.position == goal.transform.position)
        {
            firstGoalReached = true;
        }
    }

    void MoveToSecondGoal()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, goal2.transform.position, speed * Time.deltaTime);
        if (obj.transform.position == goal2.transform.position)
        {
            firstGoalReached = false;
        }
    }
}
