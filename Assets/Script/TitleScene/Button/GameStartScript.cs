using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
    {
    [SerializeField] private Button startButton;
    [SerializeField] private float moveDistance = 3f;   // �h�A����ɓ���������
    [SerializeField] private float moveDuration = 2f;   // ���������ԁi�b�j

    private GameObject doorObject;

    void Start()
        {
        if (startButton != null)
            {
            startButton.onClick.AddListener(OnStartButtonClicked);
            Debug.Log("�{�^���̃��X�i�[��ݒ肵�܂����B");
            }
        else
            {
            Debug.LogError("startButton���A�^�b�`����Ă��܂���I");
            }

        // Door�I�u�W�F�N�g���擾
        doorObject = GameObject.FindWithTag("Door");
        if (doorObject == null)
            {
            Debug.LogError("�^�O'Door'�̃I�u�W�F�N�g��������܂���I");
            }
        }

    void OnStartButtonClicked()
        {
        Debug.Log("�{�^����������܂����B�h�A����ɓ������܂��B");
        if (doorObject != null)
            {
            StartCoroutine(MoveDoorAndChangeScene());
            }
        else
            {
            ChangeScene(); // �h�A���Ȃ��ꍇ�͂��̂܂܃V�[���J��
            }
        }

    IEnumerator MoveDoorAndChangeScene()
        {
        Vector3 startPos = doorObject.transform.position;
        Vector3 endPos = startPos + Vector3.up * moveDistance;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
            {
            doorObject.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
            }

        doorObject.transform.position = endPos;

        ChangeScene();
        }

    void ChangeScene()
        {
        Debug.Log("�V�[����SelectScene�ɕύX���܂��B");

        if (Application.CanStreamedLevelBeLoaded("SampleScene"))
            {
            SceneManager.LoadScene("SelectScene");
            }
        else
            {
            Debug.LogError("SelectScene��Build Settings�ɒǉ�����Ă��Ȃ����A�V�[�������Ԉ���Ă��܂��B");
            }
        }
    }
