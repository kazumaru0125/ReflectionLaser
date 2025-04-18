using UnityEngine;
using UnityEngine.UI;  // UI関連の名前空間を追加

public class AudioSettingsUI : MonoBehaviour
    {
    public Slider bgmSlider;   // BGMボリューム用スライダー
    public Slider seSlider;    // SEボリューム用スライダー
    public Button okButton;    // OKボタン

    // 初期化
    private void Start()
        {
        // OKボタンのクリックイベントにメソッドを登録
        okButton.onClick.AddListener(OnOKButtonPressed);

        // 初期スライダーの値をロードした設定に合わせる
        float bgmVolume, seVolume;
        if (AudioSettingsManager.LoadSettings(out bgmVolume, out seVolume))
            {
            bgmSlider.value = bgmVolume;
            seSlider.value = seVolume;
            }
        else
            {
            // ロード失敗時にはデフォルト値にセット
            bgmSlider.value = 1.0f;
            seSlider.value = 1.0f;
            }
        }

    // OKボタンが押されたときの処理
    private void OnOKButtonPressed()
        {
        // スライダーの値を保存
        float bgmVolume = bgmSlider.value;
        float seVolume = seSlider.value;

        // 設定を保存
        AudioSettingsManager.SaveSettings(bgmVolume, seVolume);

        Debug.Log("Settings saved: BGM Volume = " + bgmVolume + ", SE Volume = " + seVolume);
        }
    }
