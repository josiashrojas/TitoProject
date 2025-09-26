using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundList;


    public static SoundManager instance;
    private AudioSource audioSource;
    private bool isSoundActive = true;
    public enum SoundType
    {
        FOOT_STEEP,
        JUMP
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType sound, float volume = 1)
    {
        if (isSoundActive)
        {
            instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
        }
    }

    public void applyLowPassFilter()
    {
        BGMusicController.instance.ChangeLowPassFilter(BGMusicController.FilterOptions.ON);
    }

    public void removeLowPassFilter()
    {
        BGMusicController.instance.ChangeLowPassFilter(BGMusicController.FilterOptions.OFF);
    }

    public void toggleAllSounds()
    {
        if (isSoundActive)
        {
            BGMusicController.instance.turnOffMusic();
        } else
        {
            BGMusicController.instance.turnOnMusic();
        }
        isSoundActive = !isSoundActive;
    }
    
    public void changeVolume(float level)
    {
        instance.audioSource.volume = level;
    }
}
