public class GameManager : Singleton<GameManager>
{
    public int Gold { get; private set; }
    public int Log { get; private set; }

    public int LogGainAmount { get; private set; } = 1;

    public void AddGold(int amount)
    {
        Gold += amount;
        UIManager.Instance.UpdateGoldText(Gold);
    }

    public void SubtractGold(int amount)
    {
        Gold -= amount;
        UIManager.Instance.UpdateGoldText(Gold);
    }

    public void AddLog(int amount)
    {
        Log += amount;
        UIManager.Instance.UpdateLogText(Log);
    }

    public void SubtractLog(int amount)
    {
        Log -= amount;
        UIManager.Instance.UpdateLogText(Log);
    }
}
