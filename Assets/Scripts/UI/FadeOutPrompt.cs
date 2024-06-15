using System.Collections;
using TMPro;
using UnityEngine;

public class FadeOutPrompt : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private float _decreaseValue = 0.01f;
    private float _decreaseRate = 0.02f;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }


    private IEnumerator FadeOut()
    {
        float alpha = 1f;
        UpdateTextColor(alpha);

        while (alpha > 0f)
        {
            alpha -= _decreaseValue;
            UpdateTextColor(alpha);

            yield return new WaitForSeconds(_decreaseRate);
        }

        gameObject.SetActive(false);
    }

    private void UpdateTextColor(float alpha)
    {
        _text.color = new Color(0.85f, 0.15f, 0.15f, alpha);
    }
}
