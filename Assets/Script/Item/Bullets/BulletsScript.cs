using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsScript : MonoBehaviour
    {
    public int speed = 10;  // 初速度
    public int initialDamage = 10; // 初期ダメージ
    private Vector3 velocity;  // 進行方向と速度
    public int currentDamage; // 現在のダメージ
    private Renderer bulletRenderer;  // 弾のRenderer

    private GaugeController gaugeController; // HP管理クラス

    // 色を強調した五段階
    private readonly Color[] damageColors = new Color[] {
        new Color(0f, 1f, 1f),    // 水色
        new Color(0.5f, 1f, 0f),  // 黄緑
        new Color(1f, 1f, 0f),    // 黄色
        new Color(1f, 0f, 0f),    // 赤
        new Color(1f, 0f, 1f)     // 紫
    };

    void Start()
        {
        gaugeController = FindObjectOfType<GaugeController>(); // HP管理クラスを取得
        if (gaugeController == null)
            {
            Debug.LogError("GaugeControllerが見つかりません！");
            return;
            }

        if (gaugeController.GetCurrentHP() <= 0)
            {
            Destroy(gameObject); // HPが0なら弾を削除
            return;
            }

        velocity = transform.forward * speed; // 初速度を設定
        currentDamage = initialDamage;  // 初期ダメージの設定
        bulletRenderer = GetComponent<Renderer>();  // Rendererの取得
        ChangeBulletColor();  // 初期色の設定
        }

    void Update()
        {
        // 毎フレーム、球の位置を更新
        transform.position += velocity * Time.deltaTime;
        }

    void OnCollisionEnter(Collision collision)
        {
        Vector3 normal = collision.contacts[0].normal;

        if (collision.gameObject.CompareTag("Mirror"))
            {
            Vector3 incoming = velocity;
            Vector3 reflectDir = Vector3.Reflect(incoming.normalized, normal);
            velocity = reflectDir * speed;

            // ダメージ増加＆色変更
            currentDamage = Mathf.Min(currentDamage + 10, 50);
            ChangeBulletColor();
            }
        else
            {
            Destroy(gameObject);
            }
        }

    void ChangeBulletColor()
        {
        int colorIndex = Mathf.Min(Mathf.FloorToInt(currentDamage / 10f), damageColors.Length - 1);
        bulletRenderer.material.color = damageColors[colorIndex];
        }

    public float GetDamage()
        {
        return currentDamage;
        }
    }
