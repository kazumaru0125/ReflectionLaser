using UnityEngine;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    // �ړ��֘A�p�����[�^
    private float moveSpeed = 10f;       // �ړ����x�i�P�ʁFm/s�j
    private int direction = 1;          // �ړ������i1:�E����, -1:�������j
    private float targetX;              // ���݂̖ڕWX���W

    // �X�e�[�g�J�n������
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514");
        direction = 1;
        targetX = 30f; // �����ڕW���E�[�ɐݒ�
        UpdateRotation(weakenemy);
    }

    // ���t���[���X�V����
    public void UpdateState(WeakEnemyCon weakenemy)
    {
        // ���݈ʒu�ƖڕW�ʒu�̍����v�Z
        float step = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(targetX, weakenemy.transform.position.y, weakenemy.transform.position.z);

        // �ڕW�ʒu�ֈړ�
        weakenemy.transform.position = Vector3.MoveTowards(
            weakenemy.transform.position,
            targetPosition,
            step
        );

        // �ڕW�ʒu���B�`�F�b�N
        if (Mathf.Approximately(weakenemy.transform.position.x, targetX))
        {
            // �����]������
            direction *= -1;
            targetX = (direction == 1) ? 30f : -30f;
            UpdateRotation(weakenemy);
        }
    }

    // �I�u�W�F�N�g�̉�]�X�V
    private void UpdateRotation(WeakEnemyCon weakenemy)
    {
        float targetYRotation = direction == 1 ? 90f : 270f;
        weakenemy.transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }

    // �X�e�[�g�I��������
    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("�����悱����");
    }
}
