using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int Gold { get; private set; }
    public int Log { get; private set; }

    public int level = 1;
    public int logGainAmount = 1;

    public override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;

        InitializeData();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeData();
    }

    private void InitializeData()
    {
        Gold = 0;
        Log = 0;
        level = 1;
        logGainAmount = 1;
    }

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
