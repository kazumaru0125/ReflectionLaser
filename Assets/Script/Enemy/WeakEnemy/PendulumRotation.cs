using UnityEngine;

public class PendulumRotation : MonoBehaviour
{
    float minAngle = -30f;  // 最小角度（左）
    float maxAngle = 50f;   // 最大角度（右）
    float speed = 5f;       // スイング速度（周期）

    void Update()
    {
        // 現在のY/Z軸回転を保持
        float currentY = transform.eulerAngles.y;
        float currentZ = transform.eulerAngles.z;

        // -1?1 の振り子波を生成
        float t = Mathf.Sin(Time.time * speed);

        // -1?1 → 0?1 に変換
        float normalizedT = (t + 1f) / 2f;

        // X軸の角度を補間
        float angleX = Mathf.Lerp(minAngle, maxAngle, normalizedT);

        // X軸のみ振り子、Y/Z軸は元のまま
        transform.rotation = Quaternion.Euler(angleX, currentY, currentZ);
    }
}
