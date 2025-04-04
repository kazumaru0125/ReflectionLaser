using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : IPlayerState
{
    public void EnterState(PlayerController player)
        {
       // Debug.Log("Entered Moving State");
        }

    public void UpdateState(PlayerController player)
        {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveY) * player.moveSpeed * Time.deltaTime;
        player.transform.position += move;
        }

    public void ExitState(PlayerController player)
        {
       // Debug.Log("Exiting Moving State");
        }
    }
