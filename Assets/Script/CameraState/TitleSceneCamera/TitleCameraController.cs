using UnityEngine;

public class TitleCameraController : MonoBehaviour
    {
    private ITitleCameraState titleCurrentState;

    [SerializeField] private GameStartScript gameStartScript; // GameStartScript�̎Q�Ƃ�ǉ�

    // Start is called before the first frame update
    private void Start()
        {
        // ������Ԃ�ݒ�i�f�t�H���g�J�����j
        ChangeState(new TitleDefaultState());

        // GameStartScript��OnStartSequenceComplete�C�x���g�����X��
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
        // �h�A�̉��o������������A�J�������Y�[����ԂɑJ��
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
