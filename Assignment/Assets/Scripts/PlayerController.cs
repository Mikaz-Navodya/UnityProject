using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D body;
    [SerializeField]private float speed;
    private bool isJumping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2 (horizontalInput * speed, body.linearVelocityY);


        animator.SetBool("IsRunning", horizontalInput!=0);
        animator.SetBool("IsJumping", isJumping);

        //flip player when moving left right
        if (horizontalInput > 0.01f) {
            transform.localScale = new Vector3(0.3f,0.3f,1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.3f,0.3f,1);
        }
        if (Input.GetKey(KeyCode.Space)&&(isJumping==false))
        {
            Jump();
        }
     //   Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
     //   transform.position = transform.position + horizontal * Time.deltaTime;
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocityX, speed);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag=="Ground"))
        {
            isJumping = false;
        }
    }
}
