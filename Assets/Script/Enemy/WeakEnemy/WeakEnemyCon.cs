using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyCon : MonoBehaviour
{
    private IWeakEnemyState currentState;

    public WeakEnemyIdlengState    idleState   = new WeakEnemyIdlengState();
    public WeakEnemyWanderingState wanderState = new WeakEnemyWanderingState();

    private bool isClickDown = false;


    // Start is called before the first frame update
    void Start()
    {
        if(idleState!= null)
        {
            currentState = idleState;
            currentState.EnterState(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClickDown = true;
            if (currentState != wanderState && wanderState != null)
            {
                ChangeState(wanderState);
            }
        }
        else
        {
            if (currentState != idleState && idleState != null)
            {
                ChangeState(idleState);
            }
        }
    }

    public void ChangeState(IWeakEnemyState newState)
    {
        if (newState != null && currentState != newState)
        {
            currentState?.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
        else
        {
            Debug.LogWarning("New state is the same as the current state or is null.");
        }
    }
}
