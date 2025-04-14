using UnityEngine;
using System.Collections;

public class WeakEnemyWanderingState : IWeakEnemyState
{
    // �ړ��֘A�p�����[�^
    private float moveSpeed = 10f;       // �ړ����x�i�P�ʁFm/s�j
    private float moveDuration = 2f;    // �����]���Ԋu�i�b�j
    private float moveRange = 15f;       // �ړ��\�͈́istartPosition����̋����j
    private float timer;                // �����]���p�^�C�}�[
    private int direction = 1;          // �ړ������i1:�E����, -1:�������j
    private Vector3 startPosition;      // �ړ��J�n�ʒu
    private bool isLookingAround = false; // ����낫��듮�쒆�t���O

    // ����낫��듮��p�����[�^�iInspector�Œ����\�j
    [Header("����낫���ݒ�")]
    [SerializeField] private float lookSpeed = 46f;    // ��U�葬�x�i�x/�b�j
    [SerializeField] private float lookDuration = 2.5f; // ��U�莝�����ԁi�b�j
    [SerializeField] private float lookAngle = 30f;    // ��U��p�x�͈́i�}�p�x�j

    // �X�e�[�g�J�n������
    public void EnterState(WeakEnemyCon weakenemy)
    {
        Debug.Log("1919114514"); // �f�o�b�O�p���ʃR�[�h
        timer = moveDuration;    // �^�C�}�[������
        direction = 1;           // �����������E�ɐݒ�
        startPosition = weakenemy.transform.position; // �J�n�ʒu�����݈ʒu�ŏ�����
        UpdateRotation(weakenemy); // ������]��ݒ�
    }

    // ���t���[���X�V����
    public void UpdateState(WeakEnemyCon weakenemy)
    {
        if (isLookingAround) return;

        // �ړ��͈͐����`�F�b�N�i���E�ɓ��B�����炷���ɏ����j
        if (Vector3.Distance(startPosition, weakenemy.transform.position) >= moveRange)
        {
            weakenemy.StartCoroutine(LookAroundRoutine(weakenemy));
            return; // �����ɏ������I��
        }

        // �^�C�}�[�X�V
        timer -= Time.deltaTime;

        // �^�C�}�[�o�߂��͈͓��̏ꍇ�̂ݕ����]��
        if (timer <= 0 && Vector3.Distance(startPosition, weakenemy.transform.position) < moveRange)
        {
            direction *= -1;
            UpdateRotation(weakenemy);
            timer = moveDuration;
        }

        MoveForward(weakenemy);
    }

    // ����낫��듮�샋�[�`��
    private IEnumerator LookAroundRoutine(WeakEnemyCon weakenemy)
    {
        isLookingAround = true;
        int currentDirection = direction;
        yield return ReturnToBoundary(weakenemy);

        float baseAngle = currentDirection == 1 ? 90f : 270f;
        float elapsed = 0f;

        // �p�����[�^�����ꂽ��U�蓮��
        while (elapsed < lookDuration)
        {
            float angle = Mathf.PingPong(Time.time * lookSpeed, lookAngle * 2) - lookAngle;
            weakenemy.transform.rotation = Quaternion.Euler(0f, baseAngle + angle, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        direction = currentDirection * -1;
        UpdateRotation(weakenemy);
        startPosition = weakenemy.transform.position;
        timer = moveDuration;
        isLookingAround = false;
    }


    // ���E�ʒu�ւ̕��A����
    private IEnumerator ReturnToBoundary(WeakEnemyCon weakenemy)
    {
        // ���݂̕����ɉ��������E�ʒu���v�Z
        Vector3 boundaryDirection = (direction == 1) ? Vector3.right : Vector3.left;
        Vector3 targetPos = startPosition + boundaryDirection * moveRange;

        // �ڕW�ʒu�ɓ��B����܂ňړ�
        while (Vector3.Distance(weakenemy.transform.position, targetPos) > 0.1f)
        {
            // ���炩�ɖڕW�ʒu�ɋ߂Â�
            Vector3 newPos = Vector3.MoveTowards(
                weakenemy.transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            weakenemy.transform.position = newPos; // �ʒu�X�V
            yield return null; // 1�t���[���ҋ@
        }
    }

    // �I�u�W�F�N�g�̉�]�X�V
    private void UpdateRotation(WeakEnemyCon weakenemy)
    {
        // �����ɉ�����Y����]�p�x��ݒ�
        float targetYRotation = direction == 1 ? 90f : 270f;
        weakenemy.transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }

    // �O���ړ�����
    private void MoveForward(WeakEnemyCon weakenemy)
    {
        // ���[�J�����W�n�őO���iZ�������j�Ɉړ�
        weakenemy.transform.Translate(
            Vector3.forward * moveSpeed * Time.deltaTime,
            Space.Self
        );
    }

    // �X�e�[�g�I��������
    public void ExitState(WeakEnemyCon weakenemy)
    {
        Debug.Log("�����悱����"); // �I�����b�Z�[�W
        weakenemy.StopAllCoroutines(); // �S�R���[�`�����~
    }
}
