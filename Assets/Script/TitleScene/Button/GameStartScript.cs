using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
    {
    [SerializeField] private Button startButton;
    [SerializeField] private float moveDistance = 3f;   // ドアを上に動かす距離
    [SerializeField] private float moveDuration = 2f;   // 動かす時間（秒）

    private GameObject doorObject;

    void Start()
        {
        if (startButton != null)
            {
            startButton.onClick.AddListener(OnStartButtonClicked);
            Debug.Log("ボタンのリスナーを設定しました。");
            }
        else
            {
            Debug.LogError("startButtonがアタッチされていません！");
            }

        // Doorオブジェクトを取得
        doorObject = GameObject.FindWithTag("Door");
        if (doorObject == null)
            {
            Debug.LogError("タグ'Door'のオブジェクトが見つかりません！");
            }
        }

    void OnStartButtonClicked()
        {
        Debug.Log("ボタンが押されました。ドアを上に動かします。");
        if (doorObject != null)
            {
            StartCoroutine(MoveDoorAndChangeScene());
            }
        else
            {
            ChangeScene(); // ドアがない場合はそのままシーン遷移
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
        Debug.Log("シーンをSelectSceneに変更します。");

        if (Application.CanStreamedLevelBeLoaded("SampleScene"))
            {
            SceneManager.LoadScene("SelectScene");
            }
        else
            {
            Debug.LogError("SelectSceneがBuild Settingsに追加されていないか、シーン名が間違っています。");
            }
        }
    }
