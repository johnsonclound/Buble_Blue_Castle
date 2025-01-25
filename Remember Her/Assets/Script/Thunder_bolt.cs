using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_bolt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] attackSet;
    public float cooldownDuration = 2f;

    private bool isSequenceRunning = false;

    private void Start()
    {
        StartCoroutine(Sequnce_of_attack());
    }
    private IEnumerator Sequnce_of_attack()
    {
        int rndAttack = Random.Range(0, attackSet.Length);
        attackSet[rndAttack].SetActive(false);
        attackSet[rndAttack].SetActive(true);
        yield return true;
        
    }
}
