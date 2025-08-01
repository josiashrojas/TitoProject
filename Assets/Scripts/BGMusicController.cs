using UnityEngine;

public class BGMusicController : MonoBehaviour
{
    public static BGMusicController instance { get; private set; }
    [SerializeField]
    private AudioSource audioSource;

    public enum FilterOptions
    {
        ON,
        OFF
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLowPassFilter(FilterOptions option)
    {
        if(option == FilterOptions.ON)
        {
            instance.audioSource.bypassEffects = true;    
        } else if (option == FilterOptions.OFF)
        {
            instance.audioSource.bypassEffects = false;
        }
    }
}
