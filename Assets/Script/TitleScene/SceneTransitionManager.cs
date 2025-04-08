using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
    {
    // [SerializeField] private string nextSceneName = "SelectScene";
    [SerializeField] private GameObject openingObject;//表示させたいObject
    [SerializeField] private GameObject uiRoot; // 非表示にするUIルート

    void Start()
        {
        // GameStartScriptの通知を受け取る
        if (GameStartScript.Instance != null)
            {
            GameStartScript.Instance.OnStartSequenceComplete += HandleStartSequenceComplete;
            }
        }

    void HandleStartSequenceComplete()
        {
        Debug.Log("SceneTransitionManager：スタート処理完了、プレイヤー表示とUI非表示を実行します。");

        // playerObjectが指定されていれば表示する
        if (openingObject != null)
            {
            openingObject.SetActive(true);
            }
        else
            {
            Debug.LogWarning("指定されたプレイヤーオブジェクトが見つかりませんでした。");
            }


        // UI を非表示にする
        if (uiRoot != null)
            {
            uiRoot.SetActive(false);
            }
        else
            {
            Debug.LogWarning("UI Root が設定されていません。");
            }

        // 必要であればシーン遷移も可能
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
