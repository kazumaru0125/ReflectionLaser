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

    // パーティクルのPrefabをInspectorで割り当て
    public ParticleSystem trailParticle;

    private ParticleSystem currentTrail;

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
        gaugeController = FindObjectOfType<GaugeController>();
        if (gaugeController == null)
            {
            Debug.LogError("GaugeControllerが見つかりません！");
            return;
            }

        if (gaugeController.GetCurrentHP() <= 0)
            {
            Destroy(gameObject);
            return;
            }

        velocity = transform.forward * speed;
        currentDamage = initialDamage;
        bulletRenderer = GetComponent<Renderer>();
        ChangeBulletColor();

        // パーティクルの生成
        if (trailParticle != null)
            {
            currentTrail = Instantiate(trailParticle, transform.position, Quaternion.identity, transform);
            var main = currentTrail.main;
            main.startColor = bulletRenderer.material.color;  // 弾の色と合わせる
            }
        }

    void Update()
        {
        transform.position += velocity * Time.deltaTime;
        // パーティクルが進行方向を向くようにする
        if (currentTrail != null)
            {
            currentTrail.transform.forward = velocity.normalized;
            }
        }

    void OnCollisionEnter(Collision collision)
        {
        Vector3 normal = collision.contacts[0].normal;

        if (collision.gameObject.CompareTag("Mirror"))
            {
            Vector3 incoming = velocity;
            Vector3 reflectDir = Vector3.Reflect(incoming.normalized, normal);
            velocity = reflectDir * speed;

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
        Color newColor = damageColors[colorIndex];
        bulletRenderer.material.color = newColor;

        // パーティクルの色も更新
        if (currentTrail != null)
            {
            var main = currentTrail.main;
            main.startColor = newColor;
            }
        }

    public float GetDamage()
        {
        return currentDamage;
        }
    }
