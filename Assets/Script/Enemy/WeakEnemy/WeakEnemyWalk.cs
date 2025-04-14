using UnityEngine;

[RequireComponent(typeof(WeakEnemyWanderingState))]
public class WeakEnemyWalk : MonoBehaviour
{
    [Header("傾き設定")]
    [SerializeField] private float maxTiltAngle = 50f; // 最大傾き角度
    [SerializeField] private float tiltSpeed = 5f;    // 傾き速度
    [SerializeField] private float returnSpeed = 3f;  // 戻り速度

    private WeakEnemyWanderingState wanderingState;
    private Quaternion targetRotation;
    private bool isMoving = false;

    void Start()
    {
        wanderingState = GetComponent<WeakEnemyWanderingState>();
        targetRotation = Quaternion.identity;
    }

    void Update()
    {
        UpdateTilt();
        ApplyRotation();
    }

    private void UpdateTilt()
    {
        // 移動状態を取得（仮想プロパティを想定）
        isMoving = wanderingState != null && wanderingState.;

        if (isMoving)
        {
            // 移動方向に応じた傾き角度を計算
            float moveDirection = wanderingState.CurrentDirection;
            float targetAngle = Mathf.Lerp(-30f, maxTiltAngle, (moveDirection + 1) / 2f);
            targetRotation = Quaternion.Euler(targetAngle, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            // 移動停止時はデフォルト回転
            targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    private void ApplyRotation()
    {
        float speed = isMoving ? tiltSpeed : returnSpeed;
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            speed * Time.deltaTime
        );
    }
}
