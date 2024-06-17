using System;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    BGM,
    CLICK,
    HIT
}

[Serializable]
public struct SFXClip
{
    public Sound sound;
    public AudioClip sfxClip;
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip _bgmClip;
    [SerializeField] private List<SFXClip> _sfxClips;

    public AudioSource _bgmSource;
    public AudioSource _sfxSource;

    private Dictionary<Sound, AudioClip> _soundDictionary;

    public override void Awake()
    {
        base.Awake();

        _soundDictionary = new Dictionary<Sound, AudioClip>();

        foreach (var audioClip in _sfxClips)
        {
            _soundDictionary[audioClip.sound] = audioClip.sfxClip;
        }
    }

    private void Start()
    {
        _bgmSource = gameObject.AddComponent<AudioSource>();
        _bgmSource.loop = true;

        _sfxSource = gameObject.AddComponent<AudioSource>();

        PlayBGM();
    }

    public void PlayBGM()
    {
        if (_bgmSource != null && _bgmClip != null)
        {
            _bgmSource.clip = _bgmClip;
            _bgmSource.Play();
        }
    }

    public void PlaySFX(Sound sound)
    {
        if (_sfxSource != null && _soundDictionary.TryGetValue(sound, out var clip))
        {
            _sfxSource.PlayOneShot(clip);
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (_bgmSource != null)
        {
            _bgmSource.volume = volume;
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (_sfxSource != null)
        {
            _sfxSource.volume = volume;
        }
    }
}
