using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combo", menuName = "Player Attacks/Combo", order = 1)]
public class Combo : ScriptableObject
{
    [SerializeField] private Hit[] hits;

    public Hit[] Hits { get => hits; }
}
