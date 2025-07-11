using UnityEngine;

public class CanvasToggle : MonoBehaviour
    {
    public GameObject targetCanvas; // 切り替えるCanvasをセット

    void Start()
        {
        // ゲーム開始時に非表示にしておく
        if (targetCanvas != null)
            {
            targetCanvas.SetActive(false);
            }
        }

    void Update()
        {
        // Qキーで表示/非表示を切り替え
        if (Input.GetKeyDown(KeyCode.Q))
            {
            ToggleCanvas();
            }
        }

    public void ToggleCanvas()
        {
        if (targetCanvas != null)
            {
            targetCanvas.SetActive(!targetCanvas.activeSelf);
            }
        }

    public void CloseCanvas()
        {
        if (targetCanvas != null)
            {
            targetCanvas.SetActive(false);
            }
        }
    }
