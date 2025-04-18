using UnityEngine;

public class NoEyeController : MonoBehaviour
{
    private INoEyeState currentState;              // ���݂̏��


    void Start()
    {
        ChangeState(new StandNoEye());             // ������Ԃ�ݒ�

    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̏�Ԃ��X�V
        currentState?.UpdateState(this);

    }

    // ��Ԃ�ύX����
    public void ChangeState(INoEyeState newState)
    {
        currentState = newState;       // �V������Ԃɐ؂�ւ�
        currentState.EnterState(this); // �V������Ԃ̊J�n���������s
    }
}
