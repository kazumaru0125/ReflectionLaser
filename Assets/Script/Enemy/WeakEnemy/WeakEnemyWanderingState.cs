using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    // �ړ��֘A�p�����[�^
    private float moveSpeed = 10f;       // �ړ����x�i�P�ʁFm/s�j
    private float moveDuration = 2f;    // �����]���Ԋu�i�b�j
    private float moveRange = 40f;       // �ړ��\�͈́istartPosition����̋����j
    private float timer;                // �����]���p�^�C�}�[
    private int direction = 1;          // �ړ������i1:�E����, -1:�������j
    private Vector3 startPosition;      // �ړ��J�n�ʒu

    // �X�e�[�g�J�n������
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        timer = moveDuration;
        direction = 1;
        startPosition = weakenemy.transform.position;
        UpdateRotation(weakenemy);
    }

    // ���t���[���X�V����
    public void UpdateState(WeakEnemyCon weakenemy)
    {
        // �ړ��͈͐����`�F�b�N
        if (Vector3.Distance(startPosition, weakenemy.transform.position) >= moveRange)
        {
            direction *= -1;
            UpdateRotation(weakenemy);
            startPosition = weakenemy.transform.position;
        }

        // �^�C�}�[�X�V
        timer -= Time.deltaTime;

        // �����]������
        if (timer <= 0)
        {
            direction *= -1;
            UpdateRotation(weakenemy);
            timer = moveDuration;
        }

        MoveForward(weakenemy);
    }

    // �I�u�W�F�N�g�̉�]�X�V
    private void UpdateRotation(WeakEnemyCon weakenemy)
    {
        float targetYRotation = direction == 1 ? 90f : 270f;
        weakenemy.transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }

    // �O���ړ�����
    private void MoveForward(WeakEnemyCon weakenemy)
    {
        weakenemy.transform.Translate(
            Vector3.forward * moveSpeed * Time.deltaTime,
            Space.Self
        );
    }

    // �X�e�[�g�I��������
    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("�����悱����");
    }
}
