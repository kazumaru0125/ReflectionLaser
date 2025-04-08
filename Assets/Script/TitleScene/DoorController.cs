using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
    {
    [SerializeField] private GameObject doorObject;
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float moveDuration = 2f;

    void OnEnable()
        {
        // GameStartScriptのインスタンスがnullでないか確認
        if (GameStartScript.Instance != null)
            {
            // GameStartScriptからの通知を受け取る
            GameStartScript.Instance.OnStartSequenceComplete += OpenDoorAndNotify;
            }
        else
            {
            Debug.LogError("GameStartScriptのインスタンスが存在しません。シーン内にGameStartScriptが正しく配置されているか確認してください。");
            }
        }

    void OnDisable()
        {
        // イベント購読解除
        if (GameStartScript.Instance != null)
            {
            GameStartScript.Instance.OnStartSequenceComplete -= OpenDoorAndNotify;
            }
        }

    // ドアを開けて通知を送る
    void OpenDoorAndNotify()
        {
        if (doorObject != null)
            {
            StartCoroutine(MoveDoorAndNotify());
            }
        else
            {
            Debug.LogError("DoorObjectが設定されていません。");
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
