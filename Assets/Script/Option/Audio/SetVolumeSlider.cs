using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetVolumeSlider : MonoBehaviour
{
    public Slider seSlider; // �� ���ꂪ�Ȃ������I

    void Start()
        {
        seSlider.value = SoundManager.Instance.SeVolume;

        seSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetSeVolume(value);
        });
        }
    }
