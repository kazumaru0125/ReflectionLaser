using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyCon : MonoBehaviour
{
    private IWeakEnemyState currentState;

    public WeakEnemyIdlengState    idleState   = new WeakEnemyIdlengState();
    public WeakEnemyWanderingState wanderState = new WeakEnemyWanderingState();

    void Start()
    {
        // 初期状態の設定
        currentState = idleState;
        currentState?.EnterState(this);
    }

    void Update()
    {
        // 左クリック検知
        if (Input.GetMouseButton(0))
        {
            // 状態遷移ロジック
            if (currentState != wanderState)
            {
                ChangeState(wanderState);
            }
        }
        else
        {
            ChangeState(idleState);
        }

        // 現在の状態の更新処理
        currentState?.UpdateState(this);
    }

    public void ChangeState(IWeakEnemyState newState)
    {
        if (newState != null && currentState != newState)
        {
            currentState?.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}
