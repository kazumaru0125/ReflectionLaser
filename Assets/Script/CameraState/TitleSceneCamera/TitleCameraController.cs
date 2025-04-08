using UnityEngine;

public class TitleCameraController : MonoBehaviour
    {
    private ITitleCameraState titleCurrentState;

    [SerializeField] private GameStartScript gameStartScript; // GameStartScriptの参照を追加

    // Start is called before the first frame update
    private void Start()
        {
        // 初期状態を設定（デフォルトカメラ）
        ChangeState(new TitleDefaultState());

        // GameStartScriptのOnStartSequenceCompleteイベントをリスン
        if (gameStartScript != null)
            {
            gameStartScript.OnStartSequenceComplete += OnStartSequenceComplete;
            }
        }

    private void OnDestroy()
        {
        if (gameStartScript != null)
            {
            gameStartScript.OnStartSequenceComplete -= OnStartSequenceComplete;
            }
        }

    private void OnStartSequenceComplete()
        {
        // ドアの演出が完了した後、カメラをズーム状態に遷移
        ChangeState(new TitleZoomState());
        }

    private void Update()
        {
        if (titleCurrentState != null)
            {
            titleCurrentState.UpdateState(this);
            }
        }

    public void ChangeState(ITitleCameraState newState)
        {
        if (titleCurrentState != null)
            {
            titleCurrentState.ExitState(this);
            }

        titleCurrentState = newState;
        titleCurrentState.EnterState(this);
        }
    }
