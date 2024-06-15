using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private int _expense = 10;
    
    [SerializeField] private FadeOutPrompt _promptText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _expenseText;

    public void OnClickButton()
    {
        if (GameManager.Instance.Gold >= _expense)
        {
            GameManager.Instance.SubtractGold(_expense);
            GameManager.Instance.level += 1;
            GameManager.Instance.logGainAmount += 1;
            _expense += 10;
            _expenseText.text = $"{_expense}";
            _levelText.text = $"<color=yellow>Lv</color> {GameManager.Instance.level}";
        }
        else
        {
            if (_promptText.gameObject.activeInHierarchy)
            {
                _promptText.gameObject.SetActive(false);
            }

            _promptText.gameObject.SetActive(true);
            _promptText.OnPromptText("Not Enough Gold!");
        }
    }
}
