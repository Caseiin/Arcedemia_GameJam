using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlideMovement: IMovementStrategy
{
    Rigidbody2D _rb;
    SpriteRenderer _render;
    Vector2 _movedirection = Vector2.zero;
    float _slidedamping = 1.5f;
    float _stopThreshold = 0.01f;

    public event Action OnSlideStopped;
    bool _hasStopped = false;

    public SlideMovement(Rigidbody2D rb,SpriteRenderer renderer)
    {
        _rb = rb;
        _render = renderer;
        StartUp();
    }

    public void Move()
    {
        _rb.linearVelocity = Vector2.Lerp(_rb.linearVelocity, Vector2.zero, _slidedamping * Time.fixedDeltaTime);

        if (!_hasStopped && _rb.linearVelocity.magnitude <= _stopThreshold)
        {
            _hasStopped = true;
            OnSlideStopped?.Invoke();
            Debug.Log("Player has stopped sliding");
        }

    }

    public void UpdateDirection(Vector2 direction)
    {
        _movedirection = direction.normalized;
    }

    void ApplySlideEffect(float holdDuration)
    {
        _hasStopped = false;
        _render.flipX = _movedirection.x < 0;

        float normalizedCharge = Mathf.Clamp01(holdDuration / 2f);
        float forceAmount = normalizedCharge * 20f;
        _rb.AddForce(_movedirection.normalized * forceAmount, ForceMode2D.Impulse);

    }


    public void CleanUp()
    {
        InputReaderSO.OnChargedSlide -= ApplySlideEffect;
    }

    public void StartUp()
    {
        InputReaderSO.OnChargedSlide += ApplySlideEffect;
    }
}
