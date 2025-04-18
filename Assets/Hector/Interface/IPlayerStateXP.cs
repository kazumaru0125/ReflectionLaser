public interface IPlayerStateXP
{
    // 状態開始時の処理
    public abstract void EnterState(PlayerControllerXP player);

    // 状態更新処理
    public abstract void UpdateState(PlayerControllerXP player);
}
