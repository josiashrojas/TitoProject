using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    private bool playerOnTop = false;
    private float destroyDelay = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            // Verifica si el jugador está encima
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y < -0.5f) // el jugador cae sobre la plataforma
                {
                    if (!playerOnTop)
                    {
                        playerOnTop = true;
                        Invoke("DestroyPlatform", destroyDelay);
                    }
                    break;
                }
            }
        }
    }

    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
