using UnityEngine;

public abstract class Point : MonoBehaviour
{
    private const float sizeX = 6.0f;
    private const float sizeY = 3.0f;

    public delegate void OnPressDelegate();
    public event OnPressDelegate OnPressEvent;

    [SerializeField] protected float _moveSpeed;

    private Vector2 _targetPosition;

    protected abstract void OnPress();

    private void Start()
    {
        Spawn();

        GenerateNewTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, _targetPosition, Time.deltaTime * _moveSpeed);

        if((Vector2)transform.position == _targetPosition)
        {
            GenerateNewTargetPosition();
        }
    }

    protected void GenerateNewTargetPosition()
    {
        _targetPosition = GetRandomPosition();
    }

    private Vector2 GetRandomPosition()
    {
        var x = Random.Range(-sizeX, sizeX);
        var y = Random.Range(-sizeY, sizeY);

        return new Vector2(x, y);
    }

    private void OnMouseDown()
    {
        OnPress();

        OnPressEvent?.Invoke();
    }

    private void Spawn()
    {
        var pos = GetRandomPosition();

        transform.position = pos;
    }
}
