using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルト画面用のボタン管理クラス
/// </summary>
public class ResultButtonManager : MonoBehaviour
{
    // 前のシーン名を保存する静的変数（シーン間でも値が保持される）
    // static修飾子をつけることでクラスレベルで値を保持
    private static string previousScene = "";

    /// <summary>
    /// 現在のシーン名を記録する静的メソッド
    /// </summary>
    /// <remarks>
    /// シーン遷移前に呼び出して現在のシーン名を保存します
    /// 例: ゲームオーバー時に呼び出してリトライ可能なシーンを記録
    /// </remarks>
    public static void RecordCurrentScene()
    {
        // 現在アクティブなシーンの名前を取得
        previousScene = SceneManager.GetActiveScene().name;

        // デバッグ用ログ（必要に応じてコメントアウト解除）
        // Debug.Log($"シーン記録: {previousScene}");
    }

    /// <summary>
    /// ボタンタップ時の処理メソッド
    /// </summary>
    /// <param name="button">ボタン識別用文字列</param>
    /// <remarks>
    /// Unityエディタのボタンイベント設定で文字列引数を指定して呼び出します
    /// 例: ボタンオブジェクトのOnClickイベントにこのメソッドを設定し、
    ///     引数に"TitleButton"または"RetryButton"を指定
    /// </remarks>
    public void TappedButton(string button)
    {
        // ボタン種別で処理を分岐
        switch (button)
        {
            // タイトルボタンが押された場合
            case "TitleButton":
                Debug.Log("タイトル画面へ遷移します");

                // タイトルシーンをロード
                // 注意: "TitleScene"はビルド設定に登録されている必要があります
                SceneManager.LoadScene("TitleScene");
                break;

            // リトライボタンが押された場合
            case "RetryButton":
                Debug.Log("リトライを試みます");

                // 前シーン名が有効かチェック
                if (!string.IsNullOrEmpty(previousScene))
                {
                    // 記録されている前のシーンを再ロード
                    Debug.Log($"前シーン再読み込み: {previousScene}");
                    SceneManager.LoadScene(previousScene);
                }
                else
                {
                    // 記録がない場合のフォールバック処理
                    Debug.LogWarning("前シーンの記録がありません");

                    // タイトルシーンにフォールバック
                    // 注意: ゲーム開始直後などでpreviousSceneが空の場合に発生
                    SceneManager.LoadScene("TitleScene");
                }
                break;

            // 未定義のボタンが指定された場合
            default:
                // 不正な引数の警告ログ
                Debug.LogWarning($"不明なボタン指定: {button}");

                // エディタ上でボタン設定を間違えた場合に発生
                // 例: 引数のタイポ（"RetryButton" → "RertyButton"など）
                break;
        }
    }
}
