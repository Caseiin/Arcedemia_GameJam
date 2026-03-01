using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Sound Library")]
    [SerializeField] private SoundData[] _soundDataLibrary;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _loopedSfxSource;

    private Dictionary<SoundType, List<SoundData>> _soundDictionary = new();
    PlayerController _player;


    private void Awake()
    {
        // Singleton Setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        InitializeDictionary();
        ConfigureAudioSources();
    }

    private void Start()
    {
        PlayMusic(SoundType.Music);
    }


    private void Update()
    {
        if (_player.SlideMovementInstance.IsSliding)
        {
            StartLoopedSFX(SoundType.Effects);
        }
        else StopLoopedSFX();
    }


    #region Initialization

    private void InitializeDictionary()
    {
        foreach (SoundData soundData in _soundDataLibrary)
        {
            if (!_soundDictionary.ContainsKey(soundData.Type))
            {
                _soundDictionary[soundData.Type] = new List<SoundData>();
            }

            _soundDictionary[soundData.Type].Add(soundData);
        }
    }

    private void ConfigureAudioSources()
    {
        if (_musicSource != null)
            _musicSource.loop = true;

        if (_sfxSource != null)
            _sfxSource.loop = false;

        if (_loopedSfxSource != null)
            _loopedSfxSource.loop = true;
    }

    #endregion

    #region Music

    public void PlayMusic(SoundType type, bool reset = false)
    {
        if (!_soundDictionary.ContainsKey(type) || _musicSource == null)
            return;

        var sounds = _soundDictionary[type];
        if (sounds.Count == 0)
            return;

        var selected = GetRandomSound(sounds);

        if (reset)
            _musicSource.Stop();

        if (_musicSource.clip == selected.Clip && _musicSource.isPlaying)
            return;

        _musicSource.clip = selected.Clip;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        if (_musicSource != null)
            _musicSource.Stop();
    }

    #endregion

    #region One-Shot SFX

    public void PlaySFX(SoundType type)
    {
        if (!_soundDictionary.ContainsKey(type) || _sfxSource == null)
            return;

        var sounds = _soundDictionary[type];
        if (sounds.Count == 0)
            return;

        var selected = GetRandomSound(sounds);

        _sfxSource.PlayOneShot(selected.Clip);
    }

    #endregion

    #region Looped SFX (Skating, Jetpack, etc.)

    public void StartLoopedSFX(SoundType type)
    {
        if (!_soundDictionary.ContainsKey(type) || _loopedSfxSource == null)
            return;

        var sounds = _soundDictionary[type];
        if (sounds.Count == 0)
            return;

        var selected = GetRandomSound(sounds);

        if (_loopedSfxSource.clip == selected.Clip && _loopedSfxSource.isPlaying)
            return;

        _loopedSfxSource.clip = selected.Clip;
        _loopedSfxSource.Play();
    }

    public  void StopLoopedSFX()
    {
        if (_loopedSfxSource != null)
            _loopedSfxSource.Stop();
    }

    #endregion

    #region Helpers

    private SoundData GetRandomSound(List<SoundData> sounds)
    {
        return sounds[Random.Range(0, sounds.Count)];
    }

    #endregion
}