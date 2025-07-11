public interface INoEyeState
{
    // 状態開始時の処理
    public abstract void EnterState(NoEyeController noEye);

    // 状態更新処理
    public abstract void UpdateState(NoEyeController noEye);
}
