using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsScript : MonoBehaviour
    {
    public int speed = 10;  // �����x
    public int initialDamage = 10; // �����_���[�W
    private Vector3 velocity;  // �i�s�����Ƒ��x
    public int currentDamage; // ���݂̃_���[�W
    private Renderer bulletRenderer;  // �e��Renderer

    private GaugeController gaugeController; // HP�Ǘ��N���X

    // �F�����������ܒi�K
    private readonly Color[] damageColors = new Color[] {
        new Color(0f, 1f, 1f),    // ���F
        new Color(0.5f, 1f, 0f),  // ����
        new Color(1f, 1f, 0f),    // ���F
        new Color(1f, 0f, 0f),    // ��
        new Color(1f, 0f, 1f)     // ��
    };

    void Start()
        {
        gaugeController = FindObjectOfType<GaugeController>(); // HP�Ǘ��N���X���擾
        if (gaugeController == null)
            {
            Debug.LogError("GaugeController��������܂���I");
            return;
            }

        if (gaugeController.GetCurrentHP() <= 0)
            {
            Destroy(gameObject); // HP��0�Ȃ�e���폜
            return;
            }

        velocity = transform.forward * speed; // �����x��ݒ�
        currentDamage = initialDamage;  // �����_���[�W�̐ݒ�
        bulletRenderer = GetComponent<Renderer>();  // Renderer�̎擾
        ChangeBulletColor();  // �����F�̐ݒ�
        }

    void Update()
        {
        // ���t���[���A���̈ʒu���X�V
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

            // �_���[�W�������F�ύX
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
