using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator _animator;
    PlayerController _player;
    static readonly int _idleHash = Animator.StringToHash("Idle");
    static readonly int _slideHash = Animator.StringToHash("Slide");


    void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerController>();

        InputReaderSO.OnMovementKeyReleased += PlaySlide;
        if (_player != null && _player.SlideMovementInstance != null)
        {
            _player.SlideMovementInstance.OnSlideStopped += PlayIdle;
        }
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {
        InputReaderSO.OnMovementKeyReleased -= PlaySlide;
        if (_player != null && _player.SlideMovementInstance != null)
        {
            _player.SlideMovementInstance.OnSlideStopped -= PlayIdle;
        }
    }

    void PlayIdle(){
        _animator.SetTrigger(_idleHash);
        Debug.Log("Idle Animation played");
    }  
    void PlaySlide()=> _animator.SetTrigger(_slideHash);

}

