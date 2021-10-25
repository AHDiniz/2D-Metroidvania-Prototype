using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField] private bool slowDown = false;

    void Update()
    {
        if (slowDown) Time.timeScale = .1f;
        else Time.timeScale = 1;
    }
}
