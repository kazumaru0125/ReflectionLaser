using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageController : MonoBehaviour
    {
    public Slider BGMSlider;
    public Slider SESlider;

    public Button resetButton;  // 追加: ボタンの参照
    public float maxBGMVol = 20;

    public float maxSEVol = 20f;

    void Start()
        {
        // インスペクターで設定されているか確認
        if (BGMSlider == null)
            {
            Debug.LogError("BGMSlider がアサインされていません！");
            return;
            }

        if (resetButton == null)
            {
            Debug.LogError("resetButton がアサインされていません！");
            return;
            }

        BGMSlider.maxValue = maxBGMVol;
        BGMSlider.value = maxBGMVol * 0.5f;  // 初期値を半分に設定


        SESlider.maxValue = maxSEVol;
        SESlider.value = maxSEVol * 0.5f;

        // ボタンが押されたときにResetGageToHalfを呼び出す
        resetButton.onClick.AddListener(ResetGageToHalf);
        }

    // ゲージを半分に戻す
    public void ResetGageToHalf()
        {
        if (BGMSlider != null)
            {
            BGMSlider.value = maxBGMVol * 0.5f;
            }

        if (SESlider != null)
            {
            SESlider.value = maxSEVol * 0.5f;
            }
        }
    }
