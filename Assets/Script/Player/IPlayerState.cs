using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �C���^�[�t�F�[�X
public interface IPlayerState
    {
    //�J�n
    void EnterState(PlayerController player);
    //�X�e�[�g��Update�𓮂���
    void UpdateState(PlayerController player);
    //�I��
    void ExitState(PlayerController player);
    }
