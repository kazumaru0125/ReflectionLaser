using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    private float moveSpeed = 10f; // �ړ����x
    private float moveDuration = 2f; // �����؂�ւ��Ԋu
    private float timer;
    private int direction = 1; // 1=�E, -1=��
                               // ������]�ݒ�i�E�����j
    

    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        timer = moveDuration; // �^�C�}�[������
        direction = 1; // �����������E�ɐݒ�
        weakenemy.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public void UpdateState(WeakEnemyCon weakenemy)
    {
        timer -= Time.deltaTime;

        // �����؂�ւ�
        if (timer <= 0)
        {
            // Y����]�𔽓]�i90�x ? 270�x�j
            float targetYRotation = direction == 1 ? 90f : 270f;
            weakenemy.transform.rotation = Quaternion.Euler(
                0f,
                targetYRotation,
                0f
            );

            direction *= -1; // �������]
            timer = moveDuration; // �^�C�}�[���Z�b�g 
        }

        // �ړ�����
        Vector3 movement = new Vector3(0, 0, direction);
        weakenemy.transform.Translate(movement * moveSpeed * Time.deltaTime);

    }

    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("�����悱����");
    }
}
