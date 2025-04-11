using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    private float moveSpeed = 10f; // 移動速度
    private float moveDuration = 2f; // 方向切り替え間隔
    private float timer;
    private int direction = 1; // 1=右, -1=左
                               // 初期回転設定（右方向）
    

    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        timer = moveDuration; // タイマー初期化
        direction = 1; // 初期方向を右に設定
        weakenemy.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public void UpdateState(WeakEnemyCon weakenemy)
    {
        timer -= Time.deltaTime;

        // 方向切り替え
        if (timer <= 0)
        {
            // Y軸回転を反転（90度 ? 270度）
            float targetYRotation = direction == 1 ? 90f : 270f;
            weakenemy.transform.rotation = Quaternion.Euler(
                0f,
                targetYRotation,
                0f
            );

            direction *= -1; // 方向反転
            timer = moveDuration; // タイマーリセット 
        }

        // 移動処理
        Vector3 movement = new Vector3(0, 0, direction);
        weakenemy.transform.Translate(movement * moveSpeed * Time.deltaTime);

    }

    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("いいよこいよ");
    }
}
