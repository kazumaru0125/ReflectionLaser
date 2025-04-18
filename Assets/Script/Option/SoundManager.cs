using UnityEngine;

public class SoundManager : MonoBehaviour
    {
    public static SoundManager Instance { get; private set; }

    [Range(0f, 20f)] public float BgmVolume = 10f;
    [Range(0f, 20f)] public float SeVolume = 10f;

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
        DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��ێ�
        }

    void Update()
        {
        // ���t���[�����ʂ𔽉f�i�K�v�ɉ����čœK���j
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
