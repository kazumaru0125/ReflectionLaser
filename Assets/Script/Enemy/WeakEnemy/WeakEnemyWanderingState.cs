using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    private float moveSpeed = 20f; // 移動速度
    private float moveDuration = 3f; // 方向切り替え間隔
    private float timer;
    private int direction = 1; // 1=右, -1=左

    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        timer = moveDuration; // タイマー初期化
        direction = 1; // 初期方向を右に設定
    }

    public void UpdateState(WeakEnemyCon weakenemy)
    {
        timer -= Time.deltaTime;

        // 方向切り替え
        if (timer <= 0)
        {
            direction *= -1; // 方向反転
            timer = moveDuration; // タイマーリセット
        }

        // 移動処理
        Vector3 movement = new Vector3(direction, 0, 0);
        weakenemy.transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("いいよこいよ");
    }
}
