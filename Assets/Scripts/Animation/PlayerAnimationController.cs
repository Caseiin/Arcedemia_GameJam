using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator _animator;
    PlayerController _player;
    static readonly int _slideHash = Animator.StringToHash("Slide");


    void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerController>();
    }

    void Update()
    {
        _animator.SetBool(_slideHash, _player.SlideMovementInstance.IsSliding);
    }

}

