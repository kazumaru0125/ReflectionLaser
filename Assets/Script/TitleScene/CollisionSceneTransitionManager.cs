using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionSceneTransitionManager : MonoBehaviour
    {
    [SerializeField] private string nextSceneName = "SelectScene"; // 遷移先のシーン名

    // 衝突検出
    void OnCollisionEnter(Collision collision)
        {
        // 衝突相手の名前をログに出力
        Debug.Log($"衝突しました！相手: {collision.gameObject.name}");

        // プレイヤーと衝突した場合の処理
        if (collision.gameObject.CompareTag("Player"))
            {
            Debug.Log("プレイヤーと衝突、シーン遷移します。");

            // シーン遷移の処理（ビルド設定にシーンが含まれているか確認）
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
                {
                SceneManager.LoadScene(nextSceneName);
                }
            else
                {
                Debug.LogError($"Scene '{nextSceneName}' がビルド設定に含まれていません。");
                }
            }
        // ドアと衝突した場合の処理
        else if (collision.gameObject.CompareTag("Door"))
            {
            Debug.Log("ドアと衝突、シーン遷移します。");

            // シーン遷移の処理（ビルド設定にシーンが含まれているか確認）
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
                {
                SceneManager.LoadScene(nextSceneName);
                }
            else
                {
                Debug.LogError($"Scene '{nextSceneName}' がビルド設定に含まれていません。");
                }
            }
        }
    }
