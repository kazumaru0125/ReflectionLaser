using UnityEngine;

public class PlayerControllerXP : MonoBehaviour
{
    private IPlayerStateXP currentState;              // ���݂̏��


    void Start()
    {
        ChangeState(new StandPlayerXP());             // ������Ԃ�ݒ�

    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̏�Ԃ��X�V
        currentState?.UpdateState(this);

    }

    // ��Ԃ�ύX����
    public void ChangeState(IPlayerStateXP newState)
    {
        currentState = newState;       // �V������Ԃɐ؂�ւ�
        currentState.EnterState(this); // �V������Ԃ̊J�n���������s
    }
}
