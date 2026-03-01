using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController: MonoBehaviour
{
    [SerializeField] InputReaderSO _input;
    IMovementStrategy _movementStrategy;
    Rigidbody2D _rb;
    SpriteRenderer _render;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
        _movementStrategy = new SlideMovement(_rb,_render);
    }

    void Update()
    {
        _movementStrategy.UpdateDirection(_input.Move);
    }

    void FixedUpdate()
    {
        _movementStrategy.Move();
    }

    void OnEnable()
    {
        if (_input != null) _input.EnableMap();
    }

    void OnDisable()
    {
        _movementStrategy.CleanUp();
        if (_input != null) _input.DisableMap();
    }

    void SetMovementStrategy(IMovementStrategy movementStrategy)
    {
        _movementStrategy = movementStrategy;
    }

}
