using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    private int runningID, jumpingID, groundedID;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        runningID = Animator.StringToHash("Running");
        jumpingID = Animator.StringToHash("Jumping");
        groundedID = Animator.StringToHash("Grounded");
    }

    void Update()
    {
        if (playerController.DirInput != Vector2.zero) animator.SetBool(runningID, true);
        else animator.SetBool(runningID, false);

        animator.SetBool(jumpingID, Input.GetButton("Jump"));
        animator.SetBool(groundedID, playerController.Grounded);
    }
}
