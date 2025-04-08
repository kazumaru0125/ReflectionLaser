using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "SelectScene";

    void Start()
    {
        // GameStartScript�̒ʒm���󂯎��
        if (GameStartScript.Instance != null)
        {
            GameStartScript.Instance.OnStartSequenceComplete += HandleStartSequenceComplete;
        }
    }

    void HandleStartSequenceComplete()
    {
        Debug.Log("SceneTransitionManager�F�X�^�[�g���������A�V�[���J�ڂ��܂��B");

        if (Application.CanStreamedLevelBeLoaded(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError($"Scene '{nextSceneName}' ���r���h�ݒ�Ɋ܂܂�Ă��܂���B");
        }
    }

    void OnDestroy()
    {
        if (GameStartScript.Instance != null)
        {
            GameStartScript.Instance.OnStartSequenceComplete -= HandleStartSequenceComplete;
        }
    }
}
