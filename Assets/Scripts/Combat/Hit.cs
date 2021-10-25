using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hit", menuName = "Player Attacks/Hit", order = 1)]
public class Hit : ScriptableObject
{
    [Header("Properties References")]
    [SerializeField] private string animationName;
    [SerializeField] private string inputButtonName;
    
    [Header("Time Control")]
    [SerializeField] private float hitDuration;
    [SerializeField] private float timeToReset;
    
    [Header("Stats")]
    [SerializeField] private int damage;

    [Header("Audio Data")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip whiffSound;

    public string AnimationName { get => animationName; }
    public string InputButtonName { get => inputButtonName; }
    
    public float HitDuration { get => hitDuration; }
    public float TimeToReset { get => timeToReset; }
    
    public int Damage { get => damage; }

    public AudioClip HitSound { get => hitSound; }
    public AudioClip WhiffSound { get => whiffSound; }
}
