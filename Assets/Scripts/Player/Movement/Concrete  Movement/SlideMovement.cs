using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlideMovement: IMovementStrategy
{
    Rigidbody2D _rb;
    Vector2 _movedirection = Vector2.zero;
    float _slidedamping = 0.9f;

    public SlideMovement(Rigidbody2D rb)
    {
        _rb = rb;
        StartUp();
    }

    public void Move()
    {
        _rb.linearVelocity = Vector2.Lerp(_rb.linearVelocity, Vector2.zero, _slidedamping * Time.fixedDeltaTime);
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
