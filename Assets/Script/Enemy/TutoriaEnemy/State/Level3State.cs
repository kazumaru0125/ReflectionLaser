using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3State : ITutorialEnemy
    {
    private float initialY; // 初期Y位置を保存

    public void EnterState(TutorialEnemyController enemy)
        {
        enemy.health = 30;
        enemy.SetColor(Color.yellow); // 黄色に設定

        // 初期位置を2上げる
        enemy.transform.position += new Vector3(0, 2, 0);

        // 初期Y位置を記録（後の移動計算に使う）
        initialY = enemy.transform.position.y;
        }

    public void UpdateState(TutorialEnemyController enemy)
        {
        // 上下移動の処理（初期位置を基準にする）
        float moveSpeed = 2f;
        float moveRange = 5f; // 上下移動の範囲
        float moveOffset = Mathf.PingPong(Time.time * moveSpeed, moveRange);

        enemy.transform.position = new Vector3(
            enemy.transform.position.x,
            initialY + moveOffset, // 初期Y + PingPong移動
            enemy.transform.position.z
        );
        }

    public void ExitState(TutorialEnemyController enemy)
        {
        // 状態遷移時のクリーンアップ（必要なら追加）
        }
    }
