using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1State : ITutorialEnemy
    {
    public void EnterState(TutorialEnemyController enemy)
        {
        enemy.health = 10; // Set initial health for level 1
                           // Additional initialization if needed
        enemy.SetColor(Color.cyan); // êÖêFÇ…ê›íË
        }

    public void UpdateState(TutorialEnemyController enemy)
        {
        // No action in this state, just idle
        }

    public void ExitState(TutorialEnemyController enemy)
        {
        // Clean-up if needed when transitioning out of Level 1
        }
    }
