using UnityEngine;

public class AttractToTarget : MonoBehaviour
{
    private Vector2 _targetPosition;
    private float _distanceThreshold = 20f;

    private int _exchangedCost = 1;

    private void Awake()
    {
        GameObject canvas = GameObject.FindWithTag("UI");
        _targetPosition = canvas.transform.Find("Top/Gold/Icon").transform.position;
        _targetPosition.x += 30f;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, _targetPosition, 2f * Time.deltaTime);

        float distanceToTarget = Vector2.Distance(transform.position, _targetPosition);
        
        if (distanceToTarget <= _distanceThreshold)
        {
            GameManager.Instance.AddGold(_exchangedCost);
            Destroy(gameObject);
        }
    }
}
