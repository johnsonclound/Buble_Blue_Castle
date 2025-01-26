using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_bolt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] attackSet;
    public float cooldownDuration = 1f;
    private bool isSequenceRunning = false;

    private void Start()
    {   
            StartCoroutine(Sequnce_of_attack());
    }
    private IEnumerator Sequnce_of_attack()
    {
        if (isSequenceRunning)
            yield break;

        isSequenceRunning = true;

        for (int i = 0; i < 2; i++)
        {
            Debug.Log("${Loop}");
            int rndAttack = Random.Range(0, attackSet.Length);

            attackSet[rndAttack].SetActive(true);
            Debug.Log($"Activated Attack: {attackSet[rndAttack].name}");
            yield return new WaitForSeconds(4f); // Proper wait
            attackSet[rndAttack].SetActive(false);

            yield return new WaitForSeconds(cooldownDuration);
        }

        isSequenceRunning = false;
    }
}
