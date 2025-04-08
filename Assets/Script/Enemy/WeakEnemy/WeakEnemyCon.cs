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
        // ������Ԃ̐ݒ�
        currentState = idleState;
        currentState?.EnterState(this);
    }

    void Update()
    {
        // ���N���b�N���m
        if (Input.GetMouseButton(0))
        {
            // ��ԑJ�ڃ��W�b�N
            if (currentState != wanderState)
            {
                ChangeState(wanderState);
            }
        }
        else
        {
            ChangeState(idleState);
        }

        // ���݂̏�Ԃ̍X�V����
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
