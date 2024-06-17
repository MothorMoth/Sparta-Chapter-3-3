using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    private TextMeshProUGUI _goldText;
    private TextMeshProUGUI _logText;

    public override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;

        AssignComponents();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignComponents();
    }

    private void AssignComponents()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject canvas = GameObject.FindWithTag("UI");
            _goldText = canvas.transform.Find("Top/Gold/GoldText").GetComponent<TextMeshProUGUI>();
            _logText = canvas.transform.Find("Top/Log/LogText").GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateGoldText(int amount)
    {
        _goldText.text = $"{amount}";
    }

    public void UpdateLogText(int amount)
    {
        _logText.text = $"{amount}";
    }
}
