using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Awake()
    {
        InitSettingPanel();
    }

    private void InitSettingPanel()
    {
        _bgmSlider.value = SoundManager.Instance._bgmSource.volume;
        _sfxSlider.value = SoundManager.Instance._sfxSource.volume;
    }

    public void OnClickSettingButton()
    {
        _panel.SetActive(!_panel.activeInHierarchy);
        SoundManager.Instance.PlaySFX(Sound.CLICK);
    }

    public void ChangeBGMVolume()
    {
        SoundManager.Instance.SetBGMVolume(_bgmSlider.value);
    }

    public void ChangeSFXVolume()
    {
        SoundManager.Instance.SetSFXVolume(_sfxSlider.value);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene(0);
    }
}
