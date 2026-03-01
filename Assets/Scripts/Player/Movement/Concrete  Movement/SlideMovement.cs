using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlideMovement: IMovementStrategy
{
    Rigidbody2D _rb;
    SpriteRenderer _render;
    Vector2 _movedirection = Vector2.zero;
    float _slidedamping = 1.5f;
    float _stopThreshold = 0.05f;

    public static event Action OnSlideStopped;

    public SlideMovement(Rigidbody2D rb,SpriteRenderer renderer)
    {
        _rb = rb;
        _render = renderer;
        StartUp();
    }

    public void Move()
    {
        _rb.linearVelocity = Vector2.Lerp(_rb.linearVelocity, Vector2.zero, _slidedamping * Time.fixedDeltaTime);
        if (_rb.linearVelocity.magnitude <= _stopThreshold)
        {
            OnSlideStopped?.Invoke();
        }
    }

    public void UpdateDirection(Vector2 direction)
    {
        _movedirection = direction.normalized;
    }

    void ApplySlideEffect(float holdDuration)
    {
        // if(_movedirection == Vector2.zero) return;

        float normalizedCharge = Mathf.Clamp01(holdDuration / 2f);
        float forceAmount = normalizedCharge * 20f;
        _rb.AddForce(_movedirection.normalized * forceAmount, ForceMode2D.Impulse);

        // Debug.Log(forceAmount);
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
