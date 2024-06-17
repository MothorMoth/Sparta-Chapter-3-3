using UnityEngine;

public class ChangeToGoldButton : MonoBehaviour
{
    private int _exchangeCost = 10;

    [SerializeField] private FadeOutPrompt _promptText;
    [SerializeField] private GameObject _goldPrefab;
    [SerializeField] private Transform _spawnPosition;

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

            for (int i = 0; i < _exchangeCost / 2; i++)
            {
                float randomX = Random.Range(-100f, 50f);
                float randomY = Random.Range(-50f, 100f);

                Vector3 randomPosition = _spawnPosition.position + new Vector3(randomX, randomY, 0f);

                Instantiate(_goldPrefab, randomPosition, Quaternion.identity, transform.root);
            }
        }

        SoundManager.Instance.PlaySFX(Sound.CLICK);
    }
}
