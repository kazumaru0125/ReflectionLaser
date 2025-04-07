using UnityEngine;
using System;

public class Singleton : MonoBehaviour
    {
    public static Singleton Instance { get; private set; }

    // �X�^�[�g�{�^���������ꂽ�Ƃ��ɔ��΂���C�x���g
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

    // �{�^��������ʒm����֐��iGameStartScript����Ă΂��j
    public void NotifyGameStart()
        {
        Debug.Log("Singleton: OnGameStart�C�x���g��ʒm���܂����B");
        OnGameStart?.Invoke();
        }
    }
