using UnityEditor.Callbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NormalMovement : IMovementStrategy
{
    Rigidbody2D _rb;
    SpriteRenderer _render;

    Vector2 _movedirection;
    float _movespeed = 5f;

    public NormalMovement(Rigidbody2D rb, SpriteRenderer renderer)
    {
        _rb = rb;
        _render = renderer;
    }

    public void CleanUp()
    {
        // no op
    }

    public void Move()
    {
        _rb.linearVelocity = _movedirection * _movespeed;
    }

    public void UpdateDirection(Vector2 direction)
    {
        _movedirection = direction.normalized;
    }
}
