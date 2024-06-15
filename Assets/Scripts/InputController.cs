using System;
using TMPro;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action OnClickEvent;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TextMeshProUGUI _clickText;
    [SerializeField] private GameObject _settingPanel;

    private void Update()
    {
        if (_clickText.gameObject.activeInHierarchy)
        {
            _clickText.transform.position = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Physics2D.Raycast(mousePos, Vector2.zero, _layerMask))
        {
            if (_settingPanel.activeInHierarchy) return;

            OnClickEvent?.Invoke();
            GameManager.Instance.AddLog(GameManager.Instance.LogGainAmount);
        }
    }

    private void OnMouseOver()
    {
        if (_settingPanel.activeInHierarchy) return;

        _clickText.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        _clickText.gameObject.SetActive(false);
    }
}
