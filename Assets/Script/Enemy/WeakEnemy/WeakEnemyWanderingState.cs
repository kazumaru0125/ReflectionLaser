using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    // 移動関連パラメータ
    private float moveSpeed = 10f;       // 移動速度（単位：m/s）
    private float moveDuration = 2f;    // 方向転換間隔（秒）
    private float moveRange = 40f;       // 移動可能範囲（startPositionからの距離）
    private float timer;                // 方向転換用タイマー
    private int direction = 1;          // 移動方向（1:右方向, -1:左方向）
    private Vector3 startPosition;      // 移動開始位置

    // ステート開始時処理
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        timer = moveDuration;
        direction = 1;
        startPosition = weakenemy.transform.position;
        UpdateRotation(weakenemy);
    }

    // 毎フレーム更新処理
    public void UpdateState(WeakEnemyCon weakenemy)
    {
        // 移動範囲制限チェック
        if (Vector3.Distance(startPosition, weakenemy.transform.position) >= moveRange)
        {
            direction *= -1;
            UpdateRotation(weakenemy);
            startPosition = weakenemy.transform.position;
        }

        // タイマー更新
        timer -= Time.deltaTime;

        // 方向転換処理
        if (timer <= 0)
        {
            direction *= -1;
            UpdateRotation(weakenemy);
            timer = moveDuration;
        }

        MoveForward(weakenemy);
    }

    // オブジェクトの回転更新
    private void UpdateRotation(WeakEnemyCon weakenemy)
    {
        float targetYRotation = direction == 1 ? 90f : 270f;
        weakenemy.transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }

    // 前方移動処理
    private void MoveForward(WeakEnemyCon weakenemy)
    {
        weakenemy.transform.Translate(
            Vector3.forward * moveSpeed * Time.deltaTime,
            Space.Self
        );
    }

    // ステート終了時処理
    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("いいよこいよ");
    }
}
