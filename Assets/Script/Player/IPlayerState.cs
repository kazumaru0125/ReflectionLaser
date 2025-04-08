using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// インターフェース
public interface IPlayerState
    {
    //開始
    void EnterState(PlayerController player);
    //ステートのUpdateを動かす
    void UpdateState(PlayerController player);
    //終了
    void ExitState(PlayerController player);
    }
