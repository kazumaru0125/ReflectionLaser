using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
    {
    private Animator animator;

    void Start()
        {
        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();
        }

    void Update()
        {
        // ���͂�����Έړ����Ɣ���iWASD�Ή��j
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMoving = horizontal != 0 || vertical != 0;

        // �A�j���[�V�����̐؂�ւ��iIsMoving��Animator�Őݒ肵���p�����[�^���j
        animator.SetBool("IsMoving", isMoving);
        }
    }
