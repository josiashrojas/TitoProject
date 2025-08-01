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
    public enum SoundType
    {
        // Agregar sonidos
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

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    public void applyLowPassFilter()
    {
        BGMusicController.instance.ChangeLowPassFilter(BGMusicController.FilterOptions.ON);
    }

    public void removeLowPassFilter()
    {
        BGMusicController.instance.ChangeLowPassFilter(BGMusicController.FilterOptions.OFF);
    }
}
