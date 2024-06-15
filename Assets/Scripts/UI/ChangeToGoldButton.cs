using UnityEngine;

public class ChangeToGoldButton : MonoBehaviour
{
    private int _exchangeCost = 10;
    private int _exchangedCost = 1;

    [SerializeField] private GameObject _promptText;

    public void OnClickButton()
    {
        if (GameManager.Instance.Log < _exchangeCost)
        {
            if (_promptText.activeInHierarchy)
            {
                _promptText.SetActive(false);
            }

            _promptText.SetActive(true);
        }
        else
        {
            GameManager.Instance.SubtractLog(_exchangeCost);
            GameManager.Instance.AddGold(_exchangedCost);
        }
    }
}
