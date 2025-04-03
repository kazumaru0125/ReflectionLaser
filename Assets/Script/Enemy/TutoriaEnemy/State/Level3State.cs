using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3State : ITutorialEnemy
    {
    private float initialY; // ����Y�ʒu��ۑ�

    public void EnterState(TutorialEnemyController enemy)
        {
        enemy.health = 30;
        enemy.SetColor(Color.yellow); // ���F�ɐݒ�

        // �����ʒu��2�グ��
        enemy.transform.position += new Vector3(0, 2, 0);

        // ����Y�ʒu���L�^�i��̈ړ��v�Z�Ɏg���j
        initialY = enemy.transform.position.y;
        }

    public void UpdateState(TutorialEnemyController enemy)
        {
        // �㉺�ړ��̏����i�����ʒu����ɂ���j
        float moveSpeed = 2f;
        float moveRange = 5f; // �㉺�ړ��͈̔�
        float moveOffset = Mathf.PingPong(Time.time * moveSpeed, moveRange);

        enemy.transform.position = new Vector3(
            enemy.transform.position.x,
            initialY + moveOffset, // ����Y + PingPong�ړ�
            enemy.transform.position.z
        );
        }

    public void ExitState(TutorialEnemyController enemy)
        {
        // ��ԑJ�ڎ��̃N���[���A�b�v�i�K�v�Ȃ�ǉ��j
        }
    }
