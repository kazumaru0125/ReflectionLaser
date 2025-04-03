using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2State : ITutorialEnemy
    {
    public void EnterState(TutorialEnemyController enemy)
        {
        enemy.health = 20;
        // Initialize movement speed or direction

        enemy.SetColor(Color.green); // â©óŒêFÇ…ê›íË
        }

    public void UpdateState(TutorialEnemyController enemy)
        {
        // Move left and right logic
        float moveSpeed = 2f;
        float moveDirection = Mathf.PingPong(Time.time * moveSpeed, 5f); // Example for left-right movement
        enemy.transform.position = new Vector3(moveDirection, enemy.transform.position.y, enemy.transform.position.z);
        }

    public void ExitState(TutorialEnemyController enemy)
        {
        // Clean-up if needed when transitioning out of Level 2
        }
    }
