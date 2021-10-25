using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private HitBox hitBox;
    [SerializeField] private Combo[] combos;

    private Animator animator;
    
    private List<string> currentComboInputs = new List<string>();
    private Hit currentHit, nextHit;
    private bool doingACombo = false, canHit = true, resetCombo = false;
    private float comboTimer = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetButtonDown("Attack1") || Input.GetButtonDown("Attack2") && !canHit)
        {
            resetCombo = true;
        }

        for (int i = 0; i < combos.Length; ++i)
        {
            if (combos[i].Hits.Length > currentComboInputs.Count)
            {
                if (Input.GetButtonDown(combos[i].Hits[currentComboInputs.Count].InputButtonName))
                {
                    if (currentComboInputs.Count == 0)
                    {
                        PlayHitAnimation(combos[i].Hits[currentComboInputs.Count]);
                        break;
                    }
                    else
                    {
                        bool comboMatch = false;
                        for (int j = 0; j < currentComboInputs.Count; ++j)
                        {
                            if (currentComboInputs[j] != combos[i].Hits[j].InputButtonName) break;
                            else comboMatch = true;
                        }

                        if (comboMatch && canHit)
                        {
                            nextHit = combos[i].Hits[currentComboInputs.Count];
                            canHit = false;
                            break;
                        }
                    }
                }
            }
        }

        if (doingACombo)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer >= currentHit.HitDuration && !canHit)
            {
                PlayHitAnimation(nextHit);
                if (resetCombo)
                {
                    canHit = false;
                    Invoke("ResetCombo", currentHit.HitDuration);
                }
            }
            if (comboTimer >= currentHit.TimeToReset) ResetCombo();
        }
    }

    private void PlayHitAnimation(Hit hit)
    {
        comboTimer = 0f;
        animator.Play(hit.AnimationName);
        doingACombo = true;
        currentComboInputs.Add(hit.InputButtonName);
        currentHit = hit;
        hitBox.SetAttack(hit);
        canHit = true;
    }

    private void ResetCombo()
    {
        doingACombo = false;
        comboTimer = 0f;
        currentComboInputs.Clear();
        animator.Rebind();
        canHit = true;
    }
}
