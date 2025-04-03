using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5State : ITutorialEnemy
{
    private Vector3 moveDirection;
    private float changeDirectionTime;
    private const float changeInterval = 2f; // 2秒ごとに方向変更
    private const float speed = 2f;
    private Transform player; // プレイヤーのTransform

    public void EnterState(TutorialEnemyController enemy)
    {
        enemy.health = 50; // HPを設定
        enemy.SetColor(new Color(0.5f, 0f, 0.5f)); // 紫色に設定
        player = GameObject.FindWithTag("Player")?.transform; // プレイヤーのTransformを取得
        ChangeDirection(enemy);
    }

    public void UpdateState(TutorialEnemyController enemy)
    {
        // `N`キーが押されたら体力を0にする
        if (Input.GetKeyDown(KeyCode.N))
        {
            enemy.health = 0;
        }

        // 体力が0になったらタイトルシーンへ切り替え
        if (enemy.health <= 0)
        {
            SceneManager.LoadScene("TitleScene");
            return;
        }

        // 一定時間ごとに移動方向を変更
        if (Time.time >= changeDirectionTime)
        {
            ChangeDirection(enemy);
        }

        // その方向に移動
        enemy.transform.position += moveDirection * speed * Time.deltaTime;
    }

    public void ExitState(TutorialEnemyController enemy)
    {
        // 状態を抜ける際の処理（特に必要なし）
    }

    private void ChangeDirection(TutorialEnemyController enemy)
    {
        if (player == null)
        {
            // プレイヤーが見つからない場合はランダム移動
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
        else
        {
            // プレイヤーに向かう or 遠ざかる
            Vector3 toPlayer = (player.position - enemy.transform.position).normalized;
            if (Random.value > 0.5f)
            {
                moveDirection = toPlayer; // 近づく
            }
            else
            {
                moveDirection = -toPlayer; // 遠ざかる
            }
        }
        changeDirectionTime = Time.time + changeInterval;
    }
}
