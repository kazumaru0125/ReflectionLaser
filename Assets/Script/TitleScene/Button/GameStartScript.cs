using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
    {
    // ボタンをInspectorでアタッチする
    [SerializeField] private Button startButton;

    void Start()
        {
        // ボタンが押されたらシーン遷移
        if (startButton != null)
            {
            startButton.onClick.AddListener(ChangeScene);
            Debug.Log("ボタンのリスナーを設定しました。");
            }
        else
            {
            Debug.LogError("startButtonがアタッチされていません！");
            }
        }

    void ChangeScene()
        {
        Debug.Log("ボタンが押されました。シーンをSampleSceneに変更します。");

        if (Application.CanStreamedLevelBeLoaded("SampleScene"))
            {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("SampleSceneに遷移しました。");
            }
        else
            {
            Debug.LogError("SampleSceneがBuild Settingsに追加されていないか、シーン名が間違っています。");
            }
        }
    }
