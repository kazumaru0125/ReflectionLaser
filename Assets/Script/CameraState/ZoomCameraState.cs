using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCameraState : ICameraState
    {
    private float zoomSpeed = 10f;
    private float zoomDistance = 0.5f; // �Y�[�����̋����i�e�̐�[�ɃJ������z�u�j
    private float sensitivity = 2.0f; // �}�E�X���x
    private float pitch = 0f; // FPS���_�̃J�����̏㉺�p�x
    private Vector3 weaponOffset = new Vector3(0f, 0.4f, 0f); // �e�̈ʒu�����i�e���������ʒu�j

    public void EnterState(CameraController camera)
        {
        Debug.Log("Entering Zoom Camera State");
        pitch = 0f;  // �e���\�����Ƃ��̏㉺�̊p�x
        }

    public void UpdateState(CameraController camera)
        {
        if (camera.target != null)
            {
            // �e���\�����Ƃ��̃J�����ʒu�i�v���C���[�̓����ʒu����O���փY�[���j
            Vector3 zoomPosition = camera.target.position + Vector3.up * 1.7f - camera.target.forward * zoomDistance + weaponOffset;
            camera.transform.position = Vector3.Lerp(camera.transform.position, zoomPosition, Time.deltaTime * zoomSpeed);

            // �}�E�X�̈ʒu�ɍ��킹�ăJ��������]�i�㉺�ƍ��E�j
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // ����������]
            camera.transform.RotateAround(camera.target.position, Vector3.up, mouseX);

            // ����������]�i�s�b�`�𒲐��j
            pitch -= mouseY; // �}�E�X�ŏ㉺���_��ύX
            pitch = Mathf.Clamp(pitch, -60f, 60f); // �㉺���_�̐���

            // �㉺�����ɉ�]
            camera.transform.localRotation = Quaternion.Euler(pitch, camera.transform.eulerAngles.y, 0);
            }

        // ���N���b�N�𗣂�����ʏ�J�����ɖ߂�
        if (Input.GetMouseButtonUp(0))
            {
            camera.ChangeState(new FollowCameraState());
            }
        }

    public void ExitState(CameraController camera)
        {
        Debug.Log("Exiting Zoom Camera State");
        }
    }
