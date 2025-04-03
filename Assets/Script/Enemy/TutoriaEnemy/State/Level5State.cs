using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5State : ITutorialEnemy
{
    private Vector3 moveDirection;
    private float changeDirectionTime;
    private const float changeInterval = 2f; // 2�b���Ƃɕ����ύX
    private const float speed = 2f;
    private Transform player; // �v���C���[��Transform

    public void EnterState(TutorialEnemyController enemy)
    {
        enemy.health = 50; // HP��ݒ�
        enemy.SetColor(new Color(0.5f, 0f, 0.5f)); // ���F�ɐݒ�
        player = GameObject.FindWithTag("Player")?.transform; // �v���C���[��Transform���擾
        ChangeDirection(enemy);
    }

    public void UpdateState(TutorialEnemyController enemy)
    {
        // `N`�L�[�������ꂽ��̗͂�0�ɂ���
        if (Input.GetKeyDown(KeyCode.N))
        {
            enemy.health = 0;
        }

        // �̗͂�0�ɂȂ�����^�C�g���V�[���֐؂�ւ�
        if (enemy.health <= 0)
        {
            SceneManager.LoadScene("TitleScene");
            return;
        }

        // ��莞�Ԃ��ƂɈړ�������ύX
        if (Time.time >= changeDirectionTime)
        {
            ChangeDirection(enemy);
        }

        // ���̕����Ɉړ�
        enemy.transform.position += moveDirection * speed * Time.deltaTime;
    }

    public void ExitState(TutorialEnemyController enemy)
    {
        // ��Ԃ𔲂���ۂ̏����i���ɕK�v�Ȃ��j
    }

    private void ChangeDirection(TutorialEnemyController enemy)
    {
        if (player == null)
        {
            // �v���C���[��������Ȃ��ꍇ�̓����_���ړ�
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
        else
        {
            // �v���C���[�Ɍ����� or ��������
            Vector3 toPlayer = (player.position - enemy.transform.position).normalized;
            if (Random.value > 0.5f)
            {
                moveDirection = toPlayer; // �߂Â�
            }
            else
            {
                moveDirection = -toPlayer; // ��������
            }
        }
        changeDirectionTime = Time.time + changeInterval;
    }
}
