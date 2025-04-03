using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4State : ITutorialEnemy
    {
    private Vector3[] trianglePoints;
    private int currentTargetIndex = 0;
    private float speed = 3f;
    private float switchTime = 2.5f; // 頂点間の移動時間
    private float timer = 0f;

    public void EnterState(TutorialEnemyController enemy)
        {
        enemy.health = 40;
        enemy.SetColor(Color.red);

        // 大きく上の方で三角形の頂点を設定
        trianglePoints = new Vector3[]
        {
            new Vector3(-4f, 4f, enemy.transform.position.z),
            new Vector3(4f, 4f, enemy.transform.position.z),
            new Vector3(0f, 8f, enemy.transform.position.z)
        };

        enemy.transform.position = trianglePoints[0];
        currentTargetIndex = 1;
        timer = 0f;
        }

    public void UpdateState(TutorialEnemyController enemy)
        {
        timer += Time.deltaTime;

        if (timer >= switchTime)
            {
            timer = 0f;
            currentTargetIndex = (currentTargetIndex + 1) % trianglePoints.Length;
            }

        enemy.transform.position = Vector3.MoveTowards(
            enemy.transform.position,
            trianglePoints[currentTargetIndex],
            speed * Time.deltaTime
        );
        }

    public void ExitState(TutorialEnemyController enemy)
        {
        // 特に処理なし
        }
    }