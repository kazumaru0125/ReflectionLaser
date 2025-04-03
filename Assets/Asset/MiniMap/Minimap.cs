using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
    {
    public Transform player;        // プレイヤーのTransform
    public Transform enemy;         // 敵のTransform

    public RectTransform playerIcon; // ミニマップ上のプレイヤーアイコン
    public RectTransform enemyIcon;  // ミニマップ上の敵アイコン

    public float minimapSize = 100f; // ミニマップのサイズ（スケーリング用）

    void Update()
        {
        // プレイヤー、敵のワールド座標を2D座標に変換
        Vector2 playerPos = new Vector2(player.position.x, player.position.z);
        Vector2 enemyPos = new Vector2(enemy.position.x, enemy.position.z);

        // ミニマップ内に座標をマッピング（位置のスケーリング）
        playerIcon.anchoredPosition = playerPos * minimapSize;
        enemyIcon.anchoredPosition = enemyPos * minimapSize;

        // アイコンがミニマップの境界を超えないように制限
        LimitIconPosition(playerIcon);
        LimitIconPosition(enemyIcon);
        }

    // アイコンがミニマップの境界を超えないように制限
    private void LimitIconPosition(RectTransform icon)
        {
        Vector2 pos = icon.anchoredPosition;
        pos.x = Mathf.Clamp(pos.x, -minimapSize, minimapSize);
        pos.y = Mathf.Clamp(pos.y, -minimapSize, minimapSize);
        icon.anchoredPosition = pos;
        }
    }
