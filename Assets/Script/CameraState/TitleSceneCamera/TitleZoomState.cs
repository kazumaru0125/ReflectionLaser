using UnityEngine;

public class TitleZoomState : ITitleCameraState
    {
    private float zoomTargetZ = 6f; // ズームイン後のZ軸位置（近づく）
    private float zoomSpeed = 1f; // ズーム速度
    private bool zoomComplete = false; // ズームイン完了フラグ

    public void EnterState(TitleCameraController camera)
        {
        Debug.Log("Entering Zoom Camera State");
        zoomComplete = false; // ズームインが完了していない状態で開始
        }

    public void UpdateState(TitleCameraController camera)
        {
        // 現在のカメラ位置
        Vector3 currentPosition = camera.transform.position;

        // Z軸の位置をターゲットに近づける
        float newZ = Mathf.Lerp(currentPosition.z, zoomTargetZ, Time.deltaTime * zoomSpeed);

        // 新しい位置を設定、X軸とY軸はそのまま
        Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y, newZ);

        // ズームインの動きをスムーズに実行する
        camera.transform.position = targetPosition;

        // ズームインが完了したかどうかをチェック
        if (!zoomComplete && Mathf.Abs(camera.transform.position.z - zoomTargetZ) < 0.1f)
            {
            zoomComplete = true;
            Debug.Log("Zoom Complete! Returning to Default Camera State");

            // ズームインが完了したら、デフォルトカメラ状態に遷移
            camera.ChangeState(new TitleDefaultState());
            }
        }

    public void ExitState(TitleCameraController camera)
        {
        Debug.Log("Exiting Zoom Camera State");
        }
    }
