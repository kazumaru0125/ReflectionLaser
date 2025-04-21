using UnityEngine;

public class MuzzleFlash : MonoBehaviour
    {
    [SerializeField] private ParticleSystem muzzleFlash;

    void Update()
        {
        if (Input.GetMouseButtonDown(1))
            {
            // �G�t�F�N�g�����̃I�u�W�F�N�g�̈ʒu�ɍ��킹��i�K�v�ɉ����āj
            muzzleFlash.transform.position = transform.position;

            // �G�t�F�N�g�Đ�
            muzzleFlash.Play();
            }
        }
    }
