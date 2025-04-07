using UnityEngine;
using System;

public class Singleton : MonoBehaviour
    {
    public static Singleton Instance { get; private set; }

    // スタートボタンが押されたときに発火するイベント
    public event Action OnGameStart;

    private void Awake()
        {
        if (Instance != null && Instance != this)
            {
            Destroy(gameObject);
            return;
            }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        }

    // ボタン押下を通知する関数（GameStartScriptから呼ばれる）
    public void NotifyGameStart()
        {
        Debug.Log("Singleton: OnGameStartイベントを通知しました。");
        OnGameStart?.Invoke();
        }
    }
