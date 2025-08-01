using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class IceConeBehaviour : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    BoxCollider2D boxCollider2D;
    [SerializeField]
    float fallTime = 0.5f;
    float respawnTime = 3f;
    [SerializeField]
    Vector2 myPosition;
    [SerializeField]
    GameObject picoDeHielo;

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(fallTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Start()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        myPosition= new Vector2(transform.position.x, transform.position.y);
        print(myPosition);
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(picoDeHielo, myPosition, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            StartCoroutine(DelayedAction());
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Respawn());
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
