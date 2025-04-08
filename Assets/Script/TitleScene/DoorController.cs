using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
    {
    [SerializeField] private GameObject doorObject;
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float moveDuration = 2f;

    void OnEnable()
        {
        // GameStartScript�̃C���X�^���X��null�łȂ����m�F
        if (GameStartScript.Instance != null)
            {
            // GameStartScript����̒ʒm���󂯎��
            GameStartScript.Instance.OnStartSequenceComplete += OpenDoorAndNotify;
            }
        else
            {
            Debug.LogError("GameStartScript�̃C���X�^���X�����݂��܂���B�V�[������GameStartScript���������z�u����Ă��邩�m�F���Ă��������B");
            }
        }

    void OnDisable()
        {
        // �C�x���g�w�ǉ���
        if (GameStartScript.Instance != null)
            {
            GameStartScript.Instance.OnStartSequenceComplete -= OpenDoorAndNotify;
            }
        }

    // �h�A���J���Ēʒm�𑗂�
    void OpenDoorAndNotify()
        {
        if (doorObject != null)
            {
            StartCoroutine(MoveDoorAndNotify());
            }
        else
            {
            Debug.LogError("DoorObject���ݒ肳��Ă��܂���B");
            }
        }

    IEnumerator MoveDoorAndNotify()
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
        }
    }
