using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagement : MonoBehaviour
{
    [SerializeField] private string keyTag;

    private bool hasKey;

    public bool HasKey { get => hasKey; }

    private void OnTriggerEnter2d(Collider2D trigger)
    {
        if (trigger.gameObject.tag == keyTag)
        {
            hasKey = true;
            Debug.Log(hasKey);
            Destroy(trigger.gameObject);
        }
    }
}
