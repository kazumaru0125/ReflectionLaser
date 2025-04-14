using UnityEngine;

public class PendulumRotation : MonoBehaviour
{
    float minAngle = -30f;  // �ŏ��p�x�i���j
    float maxAngle = 50f;   // �ő�p�x�i�E�j
    float speed = 5f;       // �X�C���O���x�i�����j

    void Update()
    {
        // ���݂�Y/Z����]��ێ�
        float currentY = transform.eulerAngles.y;
        float currentZ = transform.eulerAngles.z;

        // -1?1 �̐U��q�g�𐶐�
        float t = Mathf.Sin(Time.time * speed);

        // -1?1 �� 0?1 �ɕϊ�
        float normalizedT = (t + 1f) / 2f;

        // X���̊p�x����
        float angleX = Mathf.Lerp(minAngle, maxAngle, normalizedT);

        // X���̂ݐU��q�AY/Z���͌��̂܂�
        transform.rotation = Quaternion.Euler(angleX, currentY, currentZ);
    }
}
