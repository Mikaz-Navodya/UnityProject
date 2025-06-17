using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D body;
    [SerializeField]private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {   
        body.linearVelocity = new Vector2 (Input.GetAxis("Horizontal")*speed, body.linearVelocityY);
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Space))
        {body.linearVelocity=new Vector2(body.linearVelocityX, speed);
        }
     //   Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
     //   transform.position = transform.position + horizontal * Time.deltaTime;
    }
}
