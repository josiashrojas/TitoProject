using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    int speed = 4;
    [SerializeField]
    int jump = 10;
    [SerializeField]
    float coyoteTime = 0.3f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    GameObject groundCheckCircle;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    bool grounded = true;
    float coyoteTimer=1;
    float movementX;

    Rigidbody2D rigidBody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        movementX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheckCircle.transform.position, 0.1f, groundLayer);

        movementX = Input.GetAxis("Horizontal");
        if (movementX<0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementX > 0)
        {
            spriteRenderer.flipX = false;
        }
            rigidBody2D.linearVelocity = new Vector2(speed * movementX, rigidBody2D.linearVelocity.y);
        

        if (grounded)
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimer>0)
        {
            rigidBody2D.linearVelocity = new Vector2(rigidBody2D.linearVelocity.x, this.jump);
            SoundManager.instance.PlaySound(SoundManager.SoundType.JUMP);
        }
    }
    
}
