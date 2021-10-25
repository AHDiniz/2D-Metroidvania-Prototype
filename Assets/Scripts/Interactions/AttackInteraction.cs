using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask playerAtkMask;
    [SerializeField] private UnityEvent OnInteract;

    private void OnTriggerEnter2d(Collider2D trigger)
    {
        if (trigger.gameObject.layer == playerAtkMask)
        {
            OnInteract.Invoke();
        }
    }
}
