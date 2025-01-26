using UnityEngine;
using System;
using System.Collections;

public class DelayHandler : MonoBehaviour
{
    public void ExecuteAfterDelay(float delay, Action onComplete)
    {
        Debug.Log($"CaLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");
        StartCoroutine(DelayCoroutine(delay, onComplete));
    }

    private IEnumerator DelayCoroutine(float delay, Action onComplete)
    {
        Debug.Log($"Niggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
        yield return new WaitForSeconds(delay);
        onComplete?.Invoke();
    }
}