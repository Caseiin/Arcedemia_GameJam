using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator _animator;

    static readonly int _idleHash = Animator.StringToHash("idle");
    static readonly int _slideHash = Animator.StringToHash("sliding");


    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void PlayIdle()
    {
        
    }

    void PlaySlide()
    {
        
    }
}

