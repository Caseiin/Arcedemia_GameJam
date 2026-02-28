using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundData [] _soundDataLibrary;
    Dictionary<SoundType,List<SoundData>> _soundDictionary = new();

    void InitializeDictionary()
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
}
