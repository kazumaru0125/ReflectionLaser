using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlingState : IPlayerState
{
    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Idle State");
        }

    public void UpdateState(PlayerController player)
        {
        // 何もしない（待機）
        }

    public void ExitState(PlayerController player)
        {
        Debug.Log("Exiting Idle State");
        }
    }
