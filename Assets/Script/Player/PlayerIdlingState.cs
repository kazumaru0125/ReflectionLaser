using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlingState : IPlayerState
    {
    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Idle State");

        // player.animator.SetBool("IsMoving", false);

        // State側では
        player.SetAnimBool("IsMoving", false);

        player.SetAnimBool("IsAiming", false);

        player.SetAnimBool("IsShooting", false);


        player.SetAnimBool("IsDead", false);

        }

    public void UpdateState(PlayerController player)
        {
        // 何もしない（待機）
        }

    public void ExitState(PlayerController player)
        {
        Debug.Log("Exiting Idle State");
        }
    private void ResetFlag()
        {

        }


    }
