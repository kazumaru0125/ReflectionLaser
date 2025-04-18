using System.IO;
using UnityEngine;

[System.Serializable]
public class AudioSettings
    {
    public float bgmVolume;
    public float seVolume;
    }

public class AudioSettingsManager : MonoBehaviour
    {
    private const string SettingsFilePath = "audio_settings.json";

    // �f�t�H���g�l
    private const float DefaultBGMVolume = 1.0f;
    private const float DefaultSEVolume = 1.0f;

    // �ݒ��JSON�`���ŕۑ�
    public static void SaveSettings(float bgmVolume, float seVolume)
        {
        AudioSettings settings = new AudioSettings
            {
            bgmVolume = bgmVolume,
            seVolume = seVolume
            };

        string json = JsonUtility.ToJson(settings, true);
        File.WriteAllText(SettingsFilePath, json);
        }

    // �ݒ��JSON�t�@�C������ǂݍ���
    public static bool LoadSettings(out float bgmVolume, out float seVolume)
        {
        bgmVolume = DefaultBGMVolume;
        seVolume = DefaultSEVolume;

        if (File.Exists(SettingsFilePath))
            {
            string json = File.ReadAllText(SettingsFilePath);
            AudioSettings settings = JsonUtility.FromJson<AudioSettings>(json);

            bgmVolume = settings.bgmVolume;
            seVolume = settings.seVolume;

            return true;
            }
        return false;
        }

    // �ݒ�����Z�b�g
    public static void ResetSettings()
        {
        if (File.Exists(SettingsFilePath))
            {
            File.Delete(SettingsFilePath);
            }
        }
    }
