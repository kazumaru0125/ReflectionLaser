using UnityEngine;

public class CanvasToggle : MonoBehaviour
    {
    public GameObject targetCanvas; // �؂�ւ���Canvas���Z�b�g

    void Start()
        {
        // �Q�[���J�n���ɔ�\���ɂ��Ă���
        if (targetCanvas != null)
            {
            targetCanvas.SetActive(false);
            }
        }

    void Update()
        {
        // Q�L�[�ŕ\��/��\����؂�ւ�
        if (Input.GetKeyDown(KeyCode.Q))
            {
            ToggleCanvas();
            }
        }

    public void ToggleCanvas()
        {
        if (targetCanvas != null)
            {
            targetCanvas.SetActive(!targetCanvas.activeSelf);
            }
        }

    public void CloseCanvas()
        {
        if (targetCanvas != null)
            {
            targetCanvas.SetActive(false);
            }
        }
    }
