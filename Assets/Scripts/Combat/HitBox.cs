using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitBox : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;

    private int damage;
    private AudioClip hitSound;
    private AudioClip whiffSound;

    private AudioSource source;

    public int Damage { get => damage; }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetAttack(Hit hit)
    {
        damage = hit.Damage;
        hitSound = hit.HitSound;
        whiffSound = hit.WhiffSound;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == enemyLayer)
        {
            source.clip = hitSound;
            source.Play();
        }
    }
}
