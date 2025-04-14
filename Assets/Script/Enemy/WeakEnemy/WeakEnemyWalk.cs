using UnityEngine;

[RequireComponent(typeof(WeakEnemyWanderingState))]
public class WeakEnemyWalk : MonoBehaviour
{
    [Header("�X���ݒ�")]
    [SerializeField] private float maxTiltAngle = 50f; // �ő�X���p�x
    [SerializeField] private float tiltSpeed = 5f;    // �X�����x
    [SerializeField] private float returnSpeed = 3f;  // �߂葬�x

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
        // �ړ���Ԃ��擾�i���z�v���p�e�B��z��j
        isMoving = wanderingState != null && wanderingState.;

        if (isMoving)
        {
            // �ړ������ɉ������X���p�x���v�Z
            float moveDirection = wanderingState.CurrentDirection;
            float targetAngle = Mathf.Lerp(-30f, maxTiltAngle, (moveDirection + 1) / 2f);
            targetRotation = Quaternion.Euler(targetAngle, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            // �ړ���~���̓f�t�H���g��]
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
