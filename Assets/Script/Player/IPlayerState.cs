using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// インターフェース
public interface IPlayerState
    {
    void EnterState(PlayerController player);
    void UpdateState(PlayerController player);
    void ExitState(PlayerController player);
    }
