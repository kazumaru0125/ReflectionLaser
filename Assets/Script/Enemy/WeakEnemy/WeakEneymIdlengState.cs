using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyIdlengState : IWeakEnemyState
{
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("YAJU&U");
    }

   public void UpdateState(WeakEnemyCon weakenemy)
    {

    }

    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("Ç†Å[Ç†ÅOÅ`Å`Å`Å`Å`");
    }
}
