using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "SelectScene";

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
        Debug.Log("SceneTransitionManager：スタート処理完了、シーン遷移します。");

        if (Application.CanStreamedLevelBeLoaded(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError($"Scene '{nextSceneName}' がビルド設定に含まれていません。");
        }
    }

    void OnDestroy()
    {
        if (GameStartScript.Instance != null)
        {
            GameStartScript.Instance.OnStartSequenceComplete -= HandleStartSequenceComplete;
        }
    }
}
