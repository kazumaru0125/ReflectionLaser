using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ステージ選択画面でのボタン管理クラス
/// </summary>
public class SelectButtonManager : MonoBehaviour
{
    /// <summary>
    /// ボタンが押された際に呼び出されるメソッド
    /// </summary>
    /// <param name="button">ボタン識別用の文字列（ボタン名）</param>
    /// <remarks>
    /// Unityエディタのボタンイベント設定でこのメソッドを呼び出します。
    /// 引数には、"Title" や "Stage1" などの文字列を指定してください。
    /// </remarks>
    public void TappedButton(string button)
    {
        // ボタン名によって処理を分岐
        switch (button)
        {
            case "Title":
                // タイトルボタンが押された場合の処理
                Debug.Log("タイトルボタンが押されました");

                // タイトルシーンへ遷移
                // 注意: "TitleScene" はビルド設定に登録されている必要があります。
                SceneManager.LoadScene("TitleScene");
                break;

            case "Stage1":
                // ステージ1ボタンが押された場合の処理
                Debug.Log("ステージ1ボタンが押されました");

                // ステージ1のシーンへ遷移
                // 注意: "SampleScene" はビルド設定に登録されている必要があります。
                SceneManager.LoadScene("SampleScene");
                break;

            case "Stage2":
                // ステージ2ボタンが押された場合の処理
                Debug.Log("ステージ2ボタンが押されました");

                // ステージ2のシーンへ遷移（未実装）
                // TODO: ステージ2用のシーン名を設定してください。
                // SceneManager.LoadScene("");
                break;

            case "Stage3":
                // ステージ3ボタンが押された場合の処理
                Debug.Log("ステージ3ボタンが押されました");

                // ステージ3のシーンへ遷移（未実装）
                // TODO: ステージ3用のシーン名を設定してください。
                // SceneManager.LoadScene("");
                break;

            default:
                // 未定義のボタンが押された場合の警告ログ
                Debug.LogWarning($"不明なボタン: {button}");

                // エディタ上でボタン設定を間違えた場合や、タイポによるエラー時に発生します。
                break;
        }
    }
}
