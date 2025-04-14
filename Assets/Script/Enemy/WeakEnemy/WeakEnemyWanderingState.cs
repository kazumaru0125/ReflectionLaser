using UnityEngine;
using System.Collections;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    // 移動関連パラメータ
    private float moveSpeed = 10f;       // 移動速度（単位：m/s）
    private float moveDuration = 2f;    // 方向転換間隔（秒）
    private float moveRange = 15f;       // 移動可能範囲（startPositionからの距離）
    private float timer;                // 方向転換用タイマー
    private int direction = 1;          // 移動方向（1:右方向, -1:左方向）
    private Vector3 startPosition;      // 移動開始位置
    private bool isLookingAround = false; // きょろきょろ動作中フラグ

    // きょろきょろ動作パラメータ（Inspectorで調整可能）
    [Header("きょろきょろ設定")]
    [SerializeField] private float lookSpeed = 46f;    // 首振り速度（度/秒）
    [SerializeField] private float lookDuration = 2.5f; // 首振り持続時間（秒）
    [SerializeField] private float lookAngle = 30f;    // 首振り角度範囲（±角度）

    // ステート開始時処理
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514"); // デバッグ用識別コード
        timer = moveDuration;    // タイマー初期化
        direction = 1;           // 初期方向を右に設定
        startPosition = weakenemy.transform.position; // 開始位置を現在位置で初期化
        UpdateRotation(weakenemy); // 初期回転を設定
    }

    // 毎フレーム更新処理
    public void UpdateState(WeakEnemyCon weakenemy)
    {
        if (isLookingAround) return;

        // 移動範囲制限チェック（境界に到達したらすぐに処理）
        if (Vector3.Distance(startPosition, weakenemy.transform.position) >= moveRange)
        {
            weakenemy.StartCoroutine(LookAroundRoutine(weakenemy));
            return; // 即座に処理を終了
        }

        // タイマー更新
        timer -= Time.deltaTime;

        // タイマー経過かつ範囲内の場合のみ方向転換
        if (timer <= 0 && Vector3.Distance(startPosition, weakenemy.transform.position) < moveRange)
        {
            direction *= -1;
            UpdateRotation(weakenemy);
            timer = moveDuration;
        }

        MoveForward(weakenemy);
    }

    // きょろきょろ動作ルーチン
    private IEnumerator LookAroundRoutine(WeakEnemyCon weakenemy)
    {
        isLookingAround = true;
        int currentDirection = direction;
        yield return ReturnToBoundary(weakenemy);

        float baseAngle = currentDirection == 1 ? 90f : 270f;
        float elapsed = 0f;

        // パラメータ化された首振り動作
        while (elapsed < lookDuration)
        {
            float angle = Mathf.PingPong(Time.time * lookSpeed, lookAngle * 2) - lookAngle;
            weakenemy.transform.rotation = Quaternion.Euler(0f, baseAngle + angle, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        direction = currentDirection * -1;
        UpdateRotation(weakenemy);
        startPosition = weakenemy.transform.position;
        timer = moveDuration;
        isLookingAround = false;
    }


    // 境界位置への復帰処理
    private IEnumerator ReturnToBoundary(WeakEnemyCon weakenemy)
    {
        // 現在の方向に応じた境界位置を計算
        Vector3 boundaryDirection = (direction == 1) ? Vector3.right : Vector3.left;
        Vector3 targetPos = startPosition + boundaryDirection * moveRange;

        // 目標位置に到達するまで移動
        while (Vector3.Distance(weakenemy.transform.position, targetPos) > 0.1f)
        {
            // 滑らかに目標位置に近づく
            Vector3 newPos = Vector3.MoveTowards(
                weakenemy.transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            weakenemy.transform.position = newPos; // 位置更新
            yield return null; // 1フレーム待機
        }
    }

    // オブジェクトの回転更新
    private void UpdateRotation(WeakEnemyCon weakenemy)
    {
        // 方向に応じたY軸回転角度を設定
        float targetYRotation = direction == 1 ? 90f : 270f;
        weakenemy.transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }

    // 前方移動処理
    private void MoveForward(WeakEnemyCon weakenemy)
    {
        // ローカル座標系で前方（Z軸方向）に移動
        weakenemy.transform.Translate(
            Vector3.forward * moveSpeed * Time.deltaTime,
            Space.Self
        );
    }

    // ステート終了時処理
    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("いいよこいよ"); // 終了メッセージ
        weakenemy.StopAllCoroutines(); // 全コルーチンを停止
    }
}
