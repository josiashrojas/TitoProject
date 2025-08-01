using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    bool jugadorEncima = false;
    [SerializeField]
    float tiempoParaDestruir = 2f;

    private void OnCoEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character") && !jugadorEncima)
        {
            jugadorEncima = true;
            print("Destruyendo..");
            Invoke("DestruirPlataforma", tiempoParaDestruir);
        }
    }

    private void DestruirPlataforma()
    {
        Destroy(gameObject);
    }
}
