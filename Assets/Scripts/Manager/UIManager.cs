using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private TextMeshProUGUI _goldText;
    private TextMeshProUGUI _logText;

    private void Awake()
    {
        GameObject canvas = GameObject.FindWithTag("UI");
        _goldText = canvas.transform.Find("Top/Gold/GoldText").GetComponent<TextMeshProUGUI>();
        _logText = canvas.transform.Find("Top/Log/LogText").GetComponent<TextMeshProUGUI>();
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
