using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCameraState : ICameraState
    {
    private float zoomSpeed = 10f;
    private float zoomDistance = 0.5f; // ズーム時の距離（銃の先端にカメラを配置）
    private float sensitivity = 2.0f; // マウス感度
    private float pitch = 0f; // FPS視点のカメラの上下角度
    private Vector3 weaponOffset = new Vector3(0f, 0.4f, 0f); // 銃の位置調整（銃を持った位置）

    public void EnterState(CameraController camera)
        {
        Debug.Log("Entering Zoom Camera State");
        pitch = 0f;  // 銃を構えたときの上下の角度
        }

    public void UpdateState(CameraController camera)
        {
        if (camera.target != null)
            {
            // 銃を構えたときのカメラ位置（プレイヤーの頭部位置から前方へズーム）
            Vector3 zoomPosition = camera.target.position + Vector3.up * 1.7f - camera.target.forward * zoomDistance + weaponOffset;
            camera.transform.position = Vector3.Lerp(camera.transform.position, zoomPosition, Time.deltaTime * zoomSpeed);

            // マウスの位置に合わせてカメラを回転（上下と左右）
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // 水平方向回転
            camera.transform.RotateAround(camera.target.position, Vector3.up, mouseX);

            // 垂直方向回転（ピッチを調整）
            pitch -= mouseY; // マウスで上下視点を変更
            pitch = Mathf.Clamp(pitch, -60f, 60f); // 上下視点の制限

            // 上下方向に回転
            camera.transform.localRotation = Quaternion.Euler(pitch, camera.transform.eulerAngles.y, 0);
            }

        // 左クリックを離したら通常カメラに戻す
        if (Input.GetMouseButtonUp(0))
            {
            camera.ChangeState(new FollowCameraState());
            }
        }

    public void ExitState(CameraController camera)
        {
        Debug.Log("Exiting Zoom Camera State");
        }
    }
