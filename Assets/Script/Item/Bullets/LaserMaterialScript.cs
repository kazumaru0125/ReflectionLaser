using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaterialScript : MonoBehaviour
    {
    // Bullet�I�u�W�F�N�g�̎Q��
    public GameObject bullet;

    // Particle�̈ړ����x��I�t�Z�b�g��ݒ�ł���悤�ɂ���
    public Vector3 offset;

    // Update is called once per frame
    void Update()
        {
        // Bullet���ݒ肳��Ă���΂��̈ʒu�ɒǏ]
        if (bullet != null)
            {
            // Bullet�̈ʒu�ɍ��킹��Particle���ړ�
            transform.position = bullet.transform.position + offset;
            }
        }
    }
