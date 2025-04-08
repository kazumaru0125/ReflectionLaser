using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IWeakEnemyインターフェース

public interface IWeakEnemyState
{
    //開始
    void EnterState(WeakEnemyCon weakenemy);

    void UpdateState(WeakEnemyCon weakenemy);

    void ExitState(WeakEnemyCon weakenemy);
}