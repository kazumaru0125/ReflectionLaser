using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
    {
    public static GameStartScript Instance { get; private set; }

    [SerializeField] private Button startButton;
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float moveDuration = 2f;

    private GameObject doorObject;

    // ✅ ボタンが押された通知（ドア演出完了後）
    public event Action OnStartSequenceComplete;

    void Awake()
        {
        if (Instance != null && Instance != this)
            {
            Destroy(gameObject);
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

        doorObject = GameObject.FindWithTag("Door");
        }

    void OnStartButtonClicked()
        {
        if (doorObject != null)
            {
            StartCoroutine(MoveDoorAndNotify());
            }
        else
            {
            // ドアがないときも通知
            OnStartSequenceComplete?.Invoke();
            }
        }

    IEnumerator MoveDoorAndNotify()
        {
        Vector3 startPos = doorObject.transform.position;
        Vector3 endPos = startPos + Vector3.up * moveDistance;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
            {
            doorObject.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
            }

        doorObject.transform.position = endPos;

        // ✅ 通知を送る（シーン遷移はSceneTransitionManagerに任せる）
        OnStartSequenceComplete?.Invoke();
        }
    }
