using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �C���^�[�t�F�[�X
public interface IPlayerState
    {
    void EnterState(PlayerController player);
    void UpdateState(PlayerController player);
    void ExitState(PlayerController player);
    }
