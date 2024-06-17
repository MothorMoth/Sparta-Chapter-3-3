using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIButton : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OnClickPlay()
    {
        SoundManager.Instance.PlaySFX(Sound.CLICK);
        SceneManager.LoadScene(1);
    }

    public void OnClickSetting()
    {
        SoundManager.Instance.PlaySFX(Sound.CLICK);
        _panel.SetActive(!_panel.activeInHierarchy);
    }

    public void OnClickExit()
    {
        SoundManager.Instance.PlaySFX(Sound.CLICK);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
