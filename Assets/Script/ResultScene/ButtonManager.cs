using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // �O�̃V�[������ۑ�����ÓI�ϐ�
    private static string previousScene = "";

    // �V�[���J�ڑO�Ɍ��݂̃V�[�����L�^
    public static void RecordCurrentScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void TappedButton(string button)
    {
        switch (button)
        {
            case "TitleButton":
                Debug.Log("Title�{�^����������܂���");
                SceneManager.LoadScene("TitleScene");
                break;

            case "RetryButton":
                Debug.Log("Retry�{�^����������܂���");
                if (!string.IsNullOrEmpty(previousScene))
                {
                    SceneManager.LoadScene(previousScene);
                }
                else
                {
                    Debug.LogWarning("�O�̃V�[�����L�^����Ă��܂���");
                    // �f�t�H���g�œ���̃V�[���ɑJ��
                    SceneManager.LoadScene("TitleScene");
                }
                break;

            default:
                Debug.LogWarning($"�s���ȃ{�^��: {button}");
                break;
        }
    }
}
