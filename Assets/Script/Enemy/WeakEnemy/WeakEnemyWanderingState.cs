using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    private float moveSpeed = 20f; // �ړ����x
    private float moveDuration = 3f; // �����؂�ւ��Ԋu
    private float timer;
    private int direction = 1; // 1=�E, -1=��

    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        timer = moveDuration; // �^�C�}�[������
        direction = 1; // �����������E�ɐݒ�
    }

    public void UpdateState(WeakEnemyCon weakenemy)
    {
        timer -= Time.deltaTime;

        // �����؂�ւ�
        if (timer <= 0)
        {
            direction *= -1; // �������]
            timer = moveDuration; // �^�C�}�[���Z�b�g
        }

        // �ړ�����
        Vector3 movement = new Vector3(direction, 0, 0);
        weakenemy.transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("�����悱����");
    }
}
