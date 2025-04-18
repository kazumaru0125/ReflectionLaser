using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetVolumeSlider : MonoBehaviour
{
    public Slider seSlider; // © ‚±‚ê‚ª‚È‚©‚Á‚½I

    void Start()
        {
        seSlider.value = SoundManager.Instance.SeVolume;

        seSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetSeVolume(value);
        });
        }
    }
