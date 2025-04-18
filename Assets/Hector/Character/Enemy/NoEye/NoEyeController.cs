using UnityEngine;

public class NoEyeController : MonoBehaviour
{
    private INoEyeState currentState;              // 現在の状態


    void Start()
    {
        ChangeState(new StandNoEye());             // 初期状態を設定

    }

    // Update is called once per frame
    void Update()
    {
        // 現在の状態を更新
        currentState?.UpdateState(this);

    }

    // 状態を変更する
    public void ChangeState(INoEyeState newState)
    {
        currentState = newState;       // 新しい状態に切り替え
        currentState.EnterState(this); // 新しい状態の開始処理を実行
    }
}
