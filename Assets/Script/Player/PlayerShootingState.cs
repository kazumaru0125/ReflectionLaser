using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingState : IPlayerState
    {
    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Shooting State");
        Shoot(player);

        player.SetAnimBool("IsShooting", true);
        }

    public void UpdateState(PlayerController player)
        {
        // 一度撃ったらIdleに戻る
        player.ChangeState(player.idleState);
        }

    public void ExitState(PlayerController player)
        {
        Debug.Log("Exiting Shooting State");
        }

    private void Shoot(PlayerController player)
        {
        if (player.bulletPrefab != null && player.firePoint != null)
            {
            // マウスのワールド座標を取得
            Vector3 targetPoint = GetMouseWorldPosition(player);

            // 発射方向を計算（ターゲット - 発射地点）
            Vector3 shootDirection = (targetPoint - player.firePoint.position).normalized;

            // 弾を生成
            GameObject bullet = GameObject.Instantiate(player.bulletPrefab, player.firePoint.position, Quaternion.LookRotation(shootDirection));

            // Rigidbody で発射
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
                {
                rb.velocity = shootDirection * 10f; // 弾の速度
                }
            }
        }

    private Vector3 GetMouseWorldPosition(PlayerController player)
        {
        // カメラからマウス位置に向かうRayを作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycastが地面やオブジェクトに当たった場合、その位置をターゲットにする
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
            return hit.point;
            }
        else
            {
            // 何もヒットしなかった場合、カメラ前方の適当な地点をターゲットにする
            return ray.GetPoint(100f); // カメラから100ユニット前方
            }
        }
    }
