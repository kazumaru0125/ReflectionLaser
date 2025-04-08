using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionSceneTransitionManager : MonoBehaviour
    {
    [SerializeField] private string nextSceneName = "SelectScene"; // �J�ڐ�̃V�[����

    // �Փˌ��o
    void OnCollisionEnter(Collision collision)
        {
        // �Փˑ���̖��O�����O�ɏo��
        Debug.Log($"�Փ˂��܂����I����: {collision.gameObject.name}");

        // �v���C���[�ƏՓ˂����ꍇ�̏���
        if (collision.gameObject.CompareTag("Player"))
            {
            Debug.Log("�v���C���[�ƏՓˁA�V�[���J�ڂ��܂��B");

            // �V�[���J�ڂ̏����i�r���h�ݒ�ɃV�[�����܂܂�Ă��邩�m�F�j
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
                {
                SceneManager.LoadScene(nextSceneName);
                }
            else
                {
                Debug.LogError($"Scene '{nextSceneName}' ���r���h�ݒ�Ɋ܂܂�Ă��܂���B");
                }
            }
        // �h�A�ƏՓ˂����ꍇ�̏���
        else if (collision.gameObject.CompareTag("Door"))
            {
            Debug.Log("�h�A�ƏՓˁA�V�[���J�ڂ��܂��B");

            // �V�[���J�ڂ̏����i�r���h�ݒ�ɃV�[�����܂܂�Ă��邩�m�F�j
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
                {
                SceneManager.LoadScene(nextSceneName);
                }
            else
                {
                Debug.LogError($"Scene '{nextSceneName}' ���r���h�ݒ�Ɋ܂܂�Ă��܂���B");
                }
            }
        }
    }
