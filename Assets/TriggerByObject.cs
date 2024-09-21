using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Add this for UnityEvent

public class TriggerByObject : MonoBehaviour
{
    public string triggerTag = "Player"; // Tag of the object that can trigger this
    public UnityEvent onTriggerEnter; // Event to invoke when triggered
    public UnityEvent onTriggerStay; // Event to invoke when triggered

    private float lastTriggerTime = 0f;
    public float triggerInterval = 1f; // Interval in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            onTriggerEnter.Invoke(); // Invoke the event when triggered
            Debug.Log($"Triggered by {other.name}");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(triggerTag) && Time.time - lastTriggerTime >= triggerInterval)
        {
            onTriggerStay.Invoke();
            Debug.Log($"Triggered by {other.name}");
            lastTriggerTime = Time.time;
        }
    }
}