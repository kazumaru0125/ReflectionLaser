using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingState : IPlayerState
    {
    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Shooting State");
        Shoot(player);

        player.SetAnimBool("IsShooting", true);
        }

    public void UpdateState(PlayerController player)
        {
        // ��x��������Idle�ɖ߂�
        player.ChangeState(player.idleState);
        }

    public void ExitState(PlayerController player)
        {
        Debug.Log("Exiting Shooting State");
        }

    private void Shoot(PlayerController player)
        {
        if (player.bulletPrefab != null && player.firePoint != null)
            {
            // �}�E�X�̃��[���h���W���擾
            Vector3 targetPoint = GetMouseWorldPosition(player);

            // ���˕������v�Z�i�^�[�Q�b�g - ���˒n�_�j
            Vector3 shootDirection = (targetPoint - player.firePoint.position).normalized;

            // �e�𐶐�
            GameObject bullet = GameObject.Instantiate(player.bulletPrefab, player.firePoint.position, Quaternion.LookRotation(shootDirection));

            // Rigidbody �Ŕ���
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
                {
                rb.velocity = shootDirection * 10f; // �e�̑��x
                }
            }
        }

    private Vector3 GetMouseWorldPosition(PlayerController player)
        {
        // �J��������}�E�X�ʒu�Ɍ�����Ray���쐬
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast���n�ʂ�I�u�W�F�N�g�ɓ��������ꍇ�A���̈ʒu���^�[�Q�b�g�ɂ���
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
            return hit.point;
            }
        else
            {
            // �����q�b�g���Ȃ������ꍇ�A�J�����O���̓K���Ȓn�_���^�[�Q�b�g�ɂ���
            return ray.GetPoint(100f); // �J��������100���j�b�g�O��
            }
        }
    }
