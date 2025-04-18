using UnityEngine;

public class SoundManager : MonoBehaviour
    {
    public static SoundManager Instance { get; private set; }

    [Range(0f, 1f)] public float BgmVolume = 1f;
    [Range(0f, 1f)] public float SeVolume = 1f;

    public AudioSource bgmSource;
    public AudioSource[] seSources;

    void Awake()
        {
        if (Instance != null && Instance != this)
            {
            Destroy(gameObject);
            return;
            }

        Instance = this;
        DontDestroyOnLoad(gameObject); // シーンをまたいでも保持
        }

    void Update()
        {
        // 毎フレーム音量を反映（必要に応じて最適化）
        bgmSource.volume = BgmVolume;
        foreach (var se in seSources)
            {
            se.volume = SeVolume;
            }
        }

    public void SetBgmVolume(float volume)
        {
        BgmVolume = Mathf.Clamp01(volume);
        }

    public void SetSeVolume(float volume)
        {
        SeVolume = Mathf.Clamp01(volume);
        }

    public void PlaySe(AudioClip clip)
        {
        foreach (var se in seSources)
            {
            if (!se.isPlaying)
                {
                se.clip = clip;
                se.Play();
                return;
                }
            }
        }

    public void PlayBgm(AudioClip clip, bool loop = true)
        {
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
        }
    }
