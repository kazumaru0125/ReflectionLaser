using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButtonManager : MonoBehaviour
{
    public void TappedButton(string button)
    {
        switch (button)
        {
            case "Stage1":
                Debug.Log("�X�e�[�W1�{�^����������܂���");
                SceneManager.LoadScene("SampleScene");
                break;
            case "Stage2":
                Debug.Log("�X�e�[�W2�{�^����������܂���");
                //SceneManager.LoadScene("");
                break;
            case "Stage3":
                Debug.Log("�X�e�[�W3�{�^����������܂���");
                //SceneManager.LoadScene("");
                break;
            default:
                Debug.LogWarning($"�s���ȃ{�^��: {button}");
                break;
        }
    }
}
