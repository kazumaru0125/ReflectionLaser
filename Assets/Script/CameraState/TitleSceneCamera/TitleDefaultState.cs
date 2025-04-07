using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDefaultState : ITitleCameraState
    {
    private Vector3 originalPosition;

    public void EnterState(TitleCameraController camera)
        {
        Debug.Log("Entering Default Camera State");
        // 現在のカメラ位置を記録
        originalPosition = camera.transform.position;
        }

    public void UpdateState(TitleCameraController camera)
        {
        // 左クリックでズーム状態に切り替え
        if (Input.GetMouseButtonDown(0))
            {
            camera.ChangeState(new TitleZoomState());
            }

        // 右クリックで元の位置に戻る
        if (Input.GetMouseButtonDown(1))
            {
            camera.transform.position = originalPosition;
            }
        }

    public void ExitState(TitleCameraController camera)
        {
        Debug.Log("Exiting Default Camera State");
        }
    }
