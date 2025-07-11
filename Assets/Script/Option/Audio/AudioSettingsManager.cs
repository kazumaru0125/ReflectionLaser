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

    // デフォルト値
    private const float DefaultBGMVolume = 1.0f;
    private const float DefaultSEVolume = 1.0f;

    // 設定をJSON形式で保存
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

    // 設定をJSONファイルから読み込み
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

    // 設定をリセット
    public static void ResetSettings()
        {
        if (File.Exists(SettingsFilePath))
            {
            File.Delete(SettingsFilePath);
            }
        }
    }
