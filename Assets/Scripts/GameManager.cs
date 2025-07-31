using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static  GameManager Instance {get; private set; }
    public int NivelActual;

    void Awake()
    {
        NivelActual = 0;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        NivelActual++;
        SceneManager.LoadScene(NivelActual);
    }
    public void Reload()
    {
        SceneManager.LoadScene(NivelActual);
    }

    public void FlipObject(GameObject gm)
    {
        if (gm.activeSelf)
        {
            gm.SetActive(false);
        }
        else
        {
            gm.SetActive(true);
        }
    }
}
