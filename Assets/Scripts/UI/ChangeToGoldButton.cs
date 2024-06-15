using UnityEngine;

public class ChangeToGoldButton : MonoBehaviour
{
    private int _exchangeCost = 10;
    private int _exchangedCost = 1;

    [SerializeField] private FadeOutPrompt _promptText;

    public void OnClickButton()
    {
        if (GameManager.Instance.Log < _exchangeCost)
        {
            if (_promptText.gameObject.activeInHierarchy)
            {
                _promptText.gameObject.SetActive(false);
            }

            _promptText.gameObject.SetActive(true);
            _promptText.OnPromptText("Not Enough Log!");
        }
        else
        {
            GameManager.Instance.SubtractLog(_exchangeCost);
            GameManager.Instance.AddGold(_exchangedCost);
        }
    }
}
