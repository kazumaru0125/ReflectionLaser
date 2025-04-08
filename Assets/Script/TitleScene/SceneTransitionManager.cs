using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
    {
    // [SerializeField] private string nextSceneName = "SelectScene";
    [SerializeField] private GameObject openingObject;//�\����������Object
    [SerializeField] private GameObject uiRoot; // ��\���ɂ���UI���[�g

    void Start()
        {
        // GameStartScript�̒ʒm���󂯎��
        if (GameStartScript.Instance != null)
            {
            GameStartScript.Instance.OnStartSequenceComplete += HandleStartSequenceComplete;
            }
        }

    void HandleStartSequenceComplete()
        {
        Debug.Log("SceneTransitionManager�F�X�^�[�g���������A�v���C���[�\����UI��\�������s���܂��B");

        // playerObject���w�肳��Ă���Ε\������
        if (openingObject != null)
            {
            openingObject.SetActive(true);
            }
        else
            {
            Debug.LogWarning("�w�肳�ꂽ�v���C���[�I�u�W�F�N�g��������܂���ł����B");
            }


        // UI ���\���ɂ���
        if (uiRoot != null)
            {
            uiRoot.SetActive(false);
            }
        else
            {
            Debug.LogWarning("UI Root ���ݒ肳��Ă��܂���B");
            }

        // �K�v�ł���΃V�[���J�ڂ��\
        // SceneManager.LoadScene(nextSceneName);
        }

    void OnDestroy()
        {
        if (GameStartScript.Instance != null)
            {
            GameStartScript.Instance.OnStartSequenceComplete -= HandleStartSequenceComplete;
            }
        }
    }
