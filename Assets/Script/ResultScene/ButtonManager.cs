using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // 前のシーン名を保存する静的変数
    private static string previousScene = "";

    // シーン遷移前に現在のシーンを記録
    public static void RecordCurrentScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void TappedButton(string button)
    {
        switch (button)
        {
            case "TitleButton":
                Debug.Log("Titleボタンが押されました");
                SceneManager.LoadScene("TitleScene");
                break;

            case "RetryButton":
                Debug.Log("Retryボタンが押されました");
                if (!string.IsNullOrEmpty(previousScene))
                {
                    SceneManager.LoadScene(previousScene);
                }
                else
                {
                    Debug.LogWarning("前のシーンが記録されていません");
                    // デフォルトで特定のシーンに遷移
                    SceneManager.LoadScene("TitleScene");
                }
                break;

            default:
                Debug.LogWarning($"不明なボタン: {button}");
                break;
        }
    }
}
