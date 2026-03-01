using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator _animator;

    static readonly int _idleHash = Animator.StringToHash("Idle");
    static readonly int _slideHash = Animator.StringToHash("Slide");


    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        InputReaderSO.OnMovementKeyPressed += PlaySlide;
    }

    void OnDisable()
    {
        InputReaderSO.OnMovementKeyPressed -= PlaySlide;
    }

    void PlayIdle()
    {
    }

    void PlaySlide()
    {
        _animator.SetTrigger(_slideHash);
    }
}

