using UnityEngine;
using UnityEngine.UI;

public class BgmVolumeSlider: MonoBehaviour
    {
    public Slider bgmSlider; // �� ���ꂪ�Ȃ������I

    void Start()
        {
        bgmSlider.value = SoundManager.Instance.BgmVolume;

        bgmSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetBgmVolume(value);
        });
        }
    }
