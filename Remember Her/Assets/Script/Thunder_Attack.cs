using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_Attack : MonoBehaviour
{
    [SerializeField] GameObject[] thunder_Attack;
    // Start is called before the first frame update
    [SerializeField] private GameObject warning;
    [SerializeField] private float duration_warning;
    void Start()
    {
        Warning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Warning()
    {
        StartCoroutine(warning_effect());
    }
    IEnumerator warning_effect()
    {
        float _duration_warning =  duration_warning * 5;
        for(int i = 0; i < _duration_warning; i ++)
        {
            warning.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            warning.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            yield return true;
        }
    }
    void Attack()
    {

    }
}
