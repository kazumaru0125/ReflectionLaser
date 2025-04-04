using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraState : ICameraState
    {
    private float yaw = 0f; // ���������̉�]�p�x
    private float pitch = 10f; // �c�����̊p�x�i�Œ�j
    private float sensitivity = 2.0f; // �}�E�X���x
    private Vector3 cameraOffset = new Vector3(0, 1.5f, -3.5f); // TPS���_�̃J�����ʒu

    private List<Renderer> transparentObjects = new List<Renderer>(); // �����ɂ����I�u�W�F�N�g���Ǘ�
    private Dictionary<Renderer, Material[]> originalMaterials = new Dictionary<Renderer, Material[]>(); // ���̃}�e���A����ۑ�

    private float minPitch = -10f; // �ŏ��s�b�`�i�������j
    private float maxPitch = 50f;  // �ő�s�b�`�i������j
    private float maxYaw = 10f;    // �ő�̐�����]�p�x
    private float minYaw = -10f;   // �ŏ��̐�����]�p�x

    public void EnterState(CameraController camera)
        {
        Debug.Log("Entering Follow Camera State");
        }

    public void UpdateState(CameraController camera)
        {
        if (camera.target != null)
            {
            // �}�E�X�̍��E���_��]
            yaw += Input.GetAxis("Mouse X") * sensitivity;

            // yaw�͈̔͂𐧌�
            yaw = Mathf.Clamp(yaw, minYaw, maxYaw);

            // �}�E�X�̏㉺���_��]
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;

            // pitch�͈̔͂𐧌�
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

            // �J�����ʒu���v�Z�iTPS���_�j
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 offsetPosition = rotation * cameraOffset;
            Vector3 targetPosition = camera.target.position + offsetPosition;

            // �v���C���[�̌��ɒǏ]
            camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, Time.deltaTime * camera.smoothSpeed);
            camera.transform.LookAt(camera.target.position + Vector3.up * 1.5f); // �ڐ��̍����ɍ��킹��

            // �I�u�W�F�N�g�𔼓����ɂ��鏈��
            HandleTransparency(camera);
            }

        // �E�N���b�N�ŃY�[���iAIM�j�J�����ɐ؂�ւ�
        if (Input.GetMouseButtonDown(0))
            {
            ResetTransparency(); // �؂�ւ����ɓ����x�����Z�b�g
            camera.ChangeState(new ZoomCameraState());
            }
        }

    public void ExitState(CameraController camera)
        {
        Debug.Log("Exiting Follow Camera State");
        ResetTransparency(); // ��Ԃ𔲂���Ƃ��ɓ����x�����Z�b�g
        }

    private void HandleTransparency(CameraController camera)
        {
        // �ȑO�����ɂ����I�u�W�F�N�g�����ɖ߂�
        ResetTransparency();

        Vector3 cameraPos = camera.transform.position;
        Vector3 targetPos = camera.target.position + Vector3.up * 1.5f;
        Vector3 direction = targetPos - cameraPos;
        float distance = Vector3.Distance(cameraPos, targetPos);

        RaycastHit[] hits = Physics.RaycastAll(cameraPos, direction.normalized, distance);
        foreach (RaycastHit hit in hits)
            {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null && !originalMaterials.ContainsKey(renderer))
                {
                // ���̃}�e���A����ۑ�
                originalMaterials[renderer] = renderer.materials;

                // �������̃}�e���A�����쐬
                Material[] newMaterials = new Material[renderer.materials.Length];
                for (int i = 0; i < renderer.materials.Length; i++)
                    {
                    Material newMat = new Material(renderer.materials[i]);
                    newMat.SetFloat("_Mode", 2); // �������[�h
                    newMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    newMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    newMat.SetInt("_ZWrite", 0);
                    newMat.DisableKeyword("_ALPHATEST_ON");
                    newMat.EnableKeyword("_ALPHABLEND_ON");
                    newMat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    newMat.color = new Color(newMat.color.r, newMat.color.g, newMat.color.b, 0.3f); // �����x 30%
                    newMaterials[i] = newMat;
                    }
                renderer.materials = newMaterials;
                transparentObjects.Add(renderer);
                }
            }
        }

    private void ResetTransparency()
        {
        foreach (Renderer renderer in transparentObjects)
            {
            if (renderer != null && originalMaterials.ContainsKey(renderer))
                {
                renderer.materials = originalMaterials[renderer]; // ���̃}�e���A���ɖ߂�
                }
            }
        transparentObjects.Clear();
        originalMaterials.Clear();
        }
    }
