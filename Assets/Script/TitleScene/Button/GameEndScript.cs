using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
    {
    // ボタンをInspectorでアタッチする
    [SerializeField] private Button exitButton;

    void Start()
        {
        // ボタンが押されたらゲーム終了
        if (exitButton != null)
            {
            exitButton.onClick.AddListener(QuitGame);
            Debug.Log("終了ボタンのリスナーを設定しました。");
            }
        else
            {
            Debug.LogError("exitButtonがアタッチされていません！");
            }
        }

    void QuitGame()
        {
        Debug.Log("終了ボタンが押されました。ゲームを終了します。");

        // Unityエディターで動作確認用
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルド後にゲームを終了
        Application.Quit();
#endif
        }
    }
