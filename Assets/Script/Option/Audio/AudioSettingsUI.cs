using UnityEngine;
using UnityEngine.UI;  // UI�֘A�̖��O��Ԃ�ǉ�

public class AudioSettingsUI : MonoBehaviour
    {
    public Slider bgmSlider;   // BGM�{�����[���p�X���C�_�[
    public Slider seSlider;    // SE�{�����[���p�X���C�_�[
    public Button okButton;    // OK�{�^��

    // ������
    private void Start()
        {
        // OK�{�^���̃N���b�N�C�x���g�Ƀ��\�b�h��o�^
        okButton.onClick.AddListener(OnOKButtonPressed);

        // �����X���C�_�[�̒l�����[�h�����ݒ�ɍ��킹��
        float bgmVolume, seVolume;
        if (AudioSettingsManager.LoadSettings(out bgmVolume, out seVolume))
            {
            bgmSlider.value = bgmVolume;
            seSlider.value = seVolume;
            }
        else
            {
            // ���[�h���s���ɂ̓f�t�H���g�l�ɃZ�b�g
            bgmSlider.value = 1.0f;
            seSlider.value = 1.0f;
            }
        }

    // OK�{�^���������ꂽ�Ƃ��̏���
    private void OnOKButtonPressed()
        {
        // �X���C�_�[�̒l��ۑ�
        float bgmVolume = bgmSlider.value;
        float seVolume = seSlider.value;

        // �ݒ��ۑ�
        AudioSettingsManager.SaveSettings(bgmVolume, seVolume);

        Debug.Log("Settings saved: BGM Volume = " + bgmVolume + ", SE Volume = " + seVolume);
        }
    }
