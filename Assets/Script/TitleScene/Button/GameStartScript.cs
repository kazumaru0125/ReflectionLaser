using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
    {
    // �{�^����Inspector�ŃA�^�b�`����
    [SerializeField] private Button startButton;

    void Start()
        {
        // �{�^���������ꂽ��V�[���J��
        if (startButton != null)
            {
            startButton.onClick.AddListener(ChangeScene);
            Debug.Log("�{�^���̃��X�i�[��ݒ肵�܂����B");
            }
        else
            {
            Debug.LogError("startButton���A�^�b�`����Ă��܂���I");
            }
        }

    void ChangeScene()
        {
        Debug.Log("�{�^����������܂����B�V�[����SampleScene�ɕύX���܂��B");

        if (Application.CanStreamedLevelBeLoaded("SampleScene"))
            {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("SampleScene�ɑJ�ڂ��܂����B");
            }
        else
            {
            Debug.LogError("SampleScene��Build Settings�ɒǉ�����Ă��Ȃ����A�V�[�������Ԉ���Ă��܂��B");
            }
        }
    }
