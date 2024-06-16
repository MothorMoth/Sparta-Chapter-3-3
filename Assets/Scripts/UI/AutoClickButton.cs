using System.Collections;
using UnityEngine;

public class AutoClickButton : MonoBehaviour
{
    private int _expense = 10;
    private float _autoClickTime = 10f;
    private float _delayTime = 0.25f;

    private bool _isRunningCoroutine;

    [SerializeField] private InputController _controller;
    [SerializeField] private FadeOutPrompt _promptText;

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
                _autoClickTime += 10f;
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

        while (_autoClickTime > 0f)
        {
            _controller.ClickEvent();

            yield return new WaitForSeconds(_delayTime);

            _autoClickTime -= _delayTime;
        }

        _autoClickTime = 10f;
        _isRunningCoroutine = false;
    }
}
