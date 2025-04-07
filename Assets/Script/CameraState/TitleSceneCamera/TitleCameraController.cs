using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraController : MonoBehaviour
    {

    private ITitleCameraState titleCurrentState;
    // Start is called before the first frame update
    private void Start()
        {
        // ������Ԃ�ݒ�i�Ǐ]�J�����j
        ChangeState(new TitleDefaultState());
        }

    private void Update()
        {
        if (titleCurrentState != null)
            {
            titleCurrentState.UpdateState(this);
            }
        }

    public void ChangeState(ITitleCameraState newState)
        {
        if (titleCurrentState != null)
            {
            titleCurrentState.ExitState(this);
            }

        titleCurrentState = newState;
        titleCurrentState.EnterState(this);
        }
    }
