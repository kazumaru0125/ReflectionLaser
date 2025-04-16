using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    // 移動関連パラメータ
    private float moveSpeed = 10f;       // 移動速度（単位：m/s）
    private int direction = 1;          // 移動方向（1:右方向, -1:左方向）
    private float targetX;              // 現在の目標X座標

    // ステート開始時処理
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        direction = 1;
        targetX = 30f; // 初期目標を右端に設定
        UpdateRotation(weakenemy);
    }

    // 毎フレーム更新処理
    public void UpdateState(WeakEnemyCon weakenemy)
    {
        // 現在位置と目標位置の差分計算
        float step = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(targetX, weakenemy.transform.position.y, weakenemy.transform.position.z);

        // 目標位置へ移動
        weakenemy.transform.position = Vector3.MoveTowards(
            weakenemy.transform.position,
            targetPosition,
            step
        );

        // 目標位置到達チェック
        if (Mathf.Approximately(weakenemy.transform.position.x, targetX))
        {
            // 方向転換処理
            direction *= -1;
            targetX = (direction == 1) ? 30f : -30f;
            UpdateRotation(weakenemy);
        }
    }

    // オブジェクトの回転更新
    private void UpdateRotation(WeakEnemyCon weakenemy)
    {
        float targetYRotation = direction == 1 ? 90f : 270f;
        weakenemy.transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }

    // ステート終了時処理
    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("いいよこいよ");
    }
}
