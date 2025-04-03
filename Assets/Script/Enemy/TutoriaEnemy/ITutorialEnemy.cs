using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITutorialEnemy
    {
    void EnterState(TutorialEnemyController enemy);
    void UpdateState(TutorialEnemyController enemy);
    void ExitState(TutorialEnemyController enemy);
    }
