using System.Collections;
using UnityEngine;

public class AttackSet1 : MonoBehaviour
{
    public GameObject[] thunderAttacks; // Array of thunder attack objects (children of this object)
    public float delayBetweenAttacks = 1f; // Time delay between attacks

    private void OnEnable()
    {
        StartCoroutine(StartAttackSequence());
    }

    private IEnumerator StartAttackSequence()
    {
        // Loop through each thunder attack in the array
        foreach (GameObject thunderAttack in thunderAttacks)
        {
            // Activate the thunder attack and its warning
            thunderAttack.SetActive(true);

            // If thunder attack has a custom script for behavior, call StartAttack()
            ThunderAttack attackScript = thunderAttack.GetComponent<ThunderAttack>();
            attackScript.StartAttack();
            // Wait for the specified delay before triggering the next attack
            yield return new WaitForSeconds(delayBetweenAttacks);
            yield return true;
        }
        yield return true;
        Debug.Log("All attacks in the sequence are complete.");
    }
}