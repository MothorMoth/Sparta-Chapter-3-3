using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

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
}
