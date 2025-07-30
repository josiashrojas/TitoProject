using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    int estadoNivel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estadoNivel = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
        GameManager.Instance.Reload();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BirdNest" && estadoNivel == 0) { 
            estadoNivel = 1;
            GameManager.Instance.Blind();
        }
        if(other.tag=="Finish" && estadoNivel == 1){
            estadoNivel = 2;
            GameManager.Instance.NextLevel();
        }
    }
}
