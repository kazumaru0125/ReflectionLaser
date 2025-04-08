using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IWeakEnemy�C���^�[�t�F�[�X

public interface IWeakEnemyState
{
    //�J�n
    void EnterState(WeakEnemyCon weakenemy);

    void UpdateState(WeakEnemyCon weakenemy);

    void ExitState(WeakEnemyCon weakenemy);
}