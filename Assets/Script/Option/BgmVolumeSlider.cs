using UnityEngine;
using UnityEngine.UI;

public class BgmVolumeSlider: MonoBehaviour
    {
    public Slider bgmSlider; // © ‚±‚ê‚ª‚È‚©‚Á‚½I

    void Start()
        {
        bgmSlider.value = SoundManager.Instance.BgmVolume;

        bgmSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetBgmVolume(value);
        });
        }
    }
