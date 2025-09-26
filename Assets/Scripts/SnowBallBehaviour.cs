using UnityEngine;

public class SnowBallBehaviour : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private bool onGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Asegura que el jugador no pueda modificar su velocidad
        rb.mass = 1000f; // masa grande para evitar influencia
    }

    void FixedUpdate()
    {
        if (onGround)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecci�n de suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }

        // Detecci�n de objeto tipo muerte
        if (collision.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Si deja de estar en el suelo, vuelve a caer
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = false;
        }
    }

    // Evita que el jugador empuje este objeto
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y); // Mantiene la velocidad fija
        }
    }
}
