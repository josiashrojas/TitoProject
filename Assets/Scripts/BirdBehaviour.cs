using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    Transform leftLimit;
    [SerializeField]
    Transform rightLimit;

    private Rigidbody2D rb;
    private bool movingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(speed, 0f);
            if (transform.position.x >= rightLimit.position.x)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0f);
            if (transform.position.x <= leftLimit.position.x)
                movingRight = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (leftLimit != null && rightLimit != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(leftLimit.position, rightLimit.position);
        }
    }
}
