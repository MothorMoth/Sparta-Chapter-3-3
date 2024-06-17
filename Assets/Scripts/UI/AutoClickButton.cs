using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickButton : MonoBehaviour
{
    private int _expense = 10;
    private float _autoClickTime = 10f;
    private float _maxTime;
    private float _currentTime;
    private float _delayTime = 0.25f;

    private bool _isRunningCoroutine;

    [SerializeField] private InputController _controller;
    [SerializeField] private FadeOutPrompt _promptText;
    [SerializeField] private Image _timerBar;

    private void Update()
    {
        if (_maxTime == 0) return;

        _timerBar.fillAmount = _currentTime / _maxTime;
    }

    public void OnClickButton()
    {
        if (GameManager.Instance.Gold >= _expense)
        {
            GameManager.Instance.SubtractGold(_expense);

            if (!_isRunningCoroutine)
            {
                StartCoroutine(AutoClick());
            }
            else
            {
                _maxTime += _autoClickTime;
                _currentTime += _autoClickTime;
            }
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

        SoundManager.Instance.PlaySFX(Sound.CLICK);
    }

    private IEnumerator AutoClick()
    {
        _isRunningCoroutine = true;

        _maxTime += _autoClickTime;
        _currentTime += _autoClickTime;

        while (_currentTime > 0f)
        {
            _controller.ClickEvent();

            yield return new WaitForSeconds(_delayTime);

            _currentTime -= _delayTime;
        }

        _isRunningCoroutine = false;
    }
}
