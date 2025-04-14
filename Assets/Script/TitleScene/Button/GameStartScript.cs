using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
    {
    public static GameStartScript Instance { get; private set; }

    [SerializeField] private Button startButton;

    // ✅ ボタンが押された通知
    public event Action OnStartSequenceComplete;

    void Awake()
        {
        if (Instance != null && Instance != this)
            {
       //     Destroy(gameObject);
            return;
            }
        Instance = this;
        }

    void Start()
        {
        if (startButton != null)
            {
            startButton.onClick.AddListener(OnStartButtonClicked);
            }
        else
            {
            Debug.LogError("startButtonがアタッチされていません！");
            }
        }

    void OnStartButtonClicked()
        {
        // ボタンを押した瞬間に通知を送る
        OnStartSequenceComplete?.Invoke();
        }
    }
