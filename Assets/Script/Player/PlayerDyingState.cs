using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDyingState : IPlayerState
    {
    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Dyuing State €–SŒxˆ—ŠJn");
        player.SetAnimBool("IsDead", true);
        }

    public void UpdateState(PlayerController player)
        {
    
        }

    public void ExitState(PlayerController player)
        {
        Debug.Log("ExitingDyuing State €–SŒxˆ—I—¹");
        player.SetAnimBool("IsDead", false);
        }
    }
