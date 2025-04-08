using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButtonManager : MonoBehaviour
{
    public void TappedButton(string button)
    {
        switch (button)
        {
            case "Stage1":
                Debug.Log("ステージ1ボタンが押されました");
                SceneManager.LoadScene("SampleScene");
                break;
            case "Stage2":
                Debug.Log("ステージ2ボタンが押されました");
                //SceneManager.LoadScene("");
                break;
            case "Stage3":
                Debug.Log("ステージ3ボタンが押されました");
                //SceneManager.LoadScene("");
                break;
            default:
                Debug.LogWarning($"不明なボタン: {button}");
                break;
        }
    }
}
