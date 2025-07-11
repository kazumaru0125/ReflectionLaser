using UnityEngine;

public class TitleZoomState : ITitleCameraState
    {
    private float zoomTargetZ = 6f; // �Y�[���C�����Z���ʒu�i�߂Â��j
    private float zoomSpeed = 1f; // �Y�[�����x
    private bool zoomComplete = false; // �Y�[���C�������t���O

    public void EnterState(TitleCameraController camera)
        {
        Debug.Log("Entering Zoom Camera State");
        zoomComplete = false; // �Y�[���C�����������Ă��Ȃ���ԂŊJ�n
        }

    public void UpdateState(TitleCameraController camera)
        {
        // ���݂̃J�����ʒu
        Vector3 currentPosition = camera.transform.position;

        // Z���̈ʒu���^�[�Q�b�g�ɋ߂Â���
        float newZ = Mathf.Lerp(currentPosition.z, zoomTargetZ, Time.deltaTime * zoomSpeed);

        // �V�����ʒu��ݒ�AX����Y���͂��̂܂�
        Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y, newZ);

        // �Y�[���C���̓������X���[�Y�Ɏ��s����
        camera.transform.position = targetPosition;

        // �Y�[���C���������������ǂ������`�F�b�N
        if (!zoomComplete && Mathf.Abs(camera.transform.position.z - zoomTargetZ) < 0.1f)
            {
            zoomComplete = true;
            Debug.Log("Zoom Complete! Returning to Default Camera State");

            // �Y�[���C��������������A�f�t�H���g�J������ԂɑJ��
            camera.ChangeState(new TitleDefaultState());
            }
        }

    public void ExitState(TitleCameraController camera)
        {
        Debug.Log("Exiting Zoom Camera State");
        }
    }
