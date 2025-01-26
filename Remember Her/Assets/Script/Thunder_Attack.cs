/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_Attack : MonoBehaviour
{
    [SerializeField] GameObject thunder_Attack;
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
     StartCoroutine(warning_effect(warning));
    }
    IEnumerator warning_effect(GameObject warn_in_process)
    {
        float _duration_warning =  duration_warning * 5;
        for(int i = 0; i < _duration_warning; i ++)
        {
            warn_in_process.SetActive(false);
            //thunder_Attack[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            warn_in_process.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            yield return true;
        }
        thunder_Attack.SetActive(true);
        this.gameObject.SetActive(false);
    }
    void Attack()
    {

    }
}
*/
using System.Collections;
using UnityEngine;

public class ThunderAttack : MonoBehaviour
{
    public GameObject warning; // Warning object (e.g., triangle or line)
    public GameObject thunder; // Thunder object
    public float warningDuration = 2f; // Duration to flash the warning before thunder strikes
    public float flashInterval = 0.2f; // Time interval for flashing the warning

    public void StartAttack()
    {
        Debug.Log($"Warningstatus{warning != null}");
        StartCoroutine(AttackSequence());
    }

    private IEnumerator AttackSequence()
    {
        // Step 1: Flash the warning for the specified duration
        Debug.Log($"Warningstatus{warning != null}");
        Debug.Log($"Warning   :     {warning}");
        if (warning != null)
        {
            float elapsed = 0f;
            while (elapsed < warningDuration)
            {
                Debug.Log("I warn ya");
                // Toggle warning visibility
                warning.SetActive(!warning.activeSelf);

                // Wait for the flash interval
                yield return new WaitForSeconds(flashInterval);

                elapsed += flashInterval;
            }

            // Ensure warning is hidden after flashing
            warning.SetActive(false);
        }

        // Step 2: Strike the thunder
        if (thunder != null)
        {
            thunder.SetActive(true);
            Debug.Log("Thunder strikes!");
        }

        // Optional: Wait and disable thunder after a short duration
        yield return new WaitForSeconds(1f); // Time to display the thunder
        if (thunder != null)
        {
            thunder.SetActive(false);
        }

        Debug.Log($"{gameObject.name} attack is complete.");
        
    }
}

