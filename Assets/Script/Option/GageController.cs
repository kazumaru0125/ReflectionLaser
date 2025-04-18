using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageController : MonoBehaviour
    {
    public Slider BGMSlider;
    public Slider SESlider;

    public Button resetButton;  // �ǉ�: �{�^���̎Q��
    public float maxBGMVol = 20;

    public float maxSEVol = 20f;

    void Start()
        {
        // �C���X�y�N�^�[�Őݒ肳��Ă��邩�m�F
        if (BGMSlider == null)
            {
            Debug.LogError("BGMSlider ���A�T�C������Ă��܂���I");
            return;
            }

        if (resetButton == null)
            {
            Debug.LogError("resetButton ���A�T�C������Ă��܂���I");
            return;
            }

        BGMSlider.maxValue = maxBGMVol;
        BGMSlider.value = maxBGMVol * 0.5f;  // �����l�𔼕��ɐݒ�


        SESlider.maxValue = maxSEVol;
        SESlider.value = maxSEVol * 0.5f;

        // �{�^���������ꂽ�Ƃ���ResetGageToHalf���Ăяo��
        resetButton.onClick.AddListener(ResetGageToHalf);
        }

    // �Q�[�W�𔼕��ɖ߂�
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
