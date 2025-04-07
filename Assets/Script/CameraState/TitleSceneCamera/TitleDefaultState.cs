using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDefaultState : ITitleCameraState
    {
    private Vector3 originalPosition;

    public void EnterState(TitleCameraController camera)
        {
        Debug.Log("Entering Default Camera State");
        // ���݂̃J�����ʒu���L�^
        originalPosition = camera.transform.position;
        }

    public void UpdateState(TitleCameraController camera)
        {
        // ���N���b�N�ŃY�[����Ԃɐ؂�ւ�
        if (Input.GetMouseButtonDown(0))
            {
            camera.ChangeState(new TitleZoomState());
            }

        // �E�N���b�N�Ō��̈ʒu�ɖ߂�
        if (Input.GetMouseButtonDown(1))
            {
            camera.transform.position = originalPosition;
            }
        }

    public void ExitState(TitleCameraController camera)
        {
        Debug.Log("Exiting Default Camera State");
        }
    }
