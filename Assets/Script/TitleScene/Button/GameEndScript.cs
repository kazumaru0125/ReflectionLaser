using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
    {
    // �{�^����Inspector�ŃA�^�b�`����
    [SerializeField] private Button exitButton;

    void Start()
        {
        // �{�^���������ꂽ��Q�[���I��
        if (exitButton != null)
            {
            exitButton.onClick.AddListener(QuitGame);
            Debug.Log("�I���{�^���̃��X�i�[��ݒ肵�܂����B");
            }
        else
            {
            Debug.LogError("exitButton���A�^�b�`����Ă��܂���I");
            }
        }

    void QuitGame()
        {
        Debug.Log("�I���{�^����������܂����B�Q�[�����I�����܂��B");

        // Unity�G�f�B�^�[�œ���m�F�p
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �r���h��ɃQ�[�����I��
        Application.Quit();
#endif
        }
    }
