using UnityEngine;

public class CameraController : MonoBehaviour
    {
    private ICameraState currentState;

    public Transform target; // �Ǐ]�Ώہi�v���C���[�j
    public Vector3 followOffset = new Vector3(0, 2, -5);
    public float smoothSpeed = 10f;

    private void Start()
        {
        // ������Ԃ�ݒ�i�Ǐ]�J�����j
        ChangeState(new FollowCameraState());
        }

    private void Update()
        {
        if (currentState != null)
            {
            currentState.UpdateState(this);
            }
        }

    public void ChangeState(ICameraState newState)
        {
        if (currentState != null)
            {
            currentState.ExitState(this);
            }

        currentState = newState;
        currentState.EnterState(this);
        }
    }
