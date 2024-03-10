using UnityEngine;
using UnityEngine.Tilemaps;

public class movement : MonoBehaviour
{
    public CameraScript mainCam;

    private Rigidbody2D rb;
    bool hasDied = false;

    //private Vector2 playerTwoMovement;
    private bool isFacingRight = true;
    [SerializeField] float speed = 5f;
    [SerializeField] private bool isOnePlayer = false;

    private bool canJump = false;

    float horizontal;

    [SerializeField] float jumpForce = 2f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radius = .05f;
    [SerializeField] private LayerMask mask;

    public AudioSource jumpSound;
    public AudioSource walkSound;

    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            walkSound.volume = 1;
        }
        else
        {
            walkSound.volume = 0;
        }

        //Debug.Log(x);


        Collider2D[] col = Physics2D.OverlapCircleAll(groundCheck.position, radius, mask);
        if (col.Length > 0)
        {
            canJump = true;

        }
        else
        {
            canJump = false;
        }

        anim.SetBool("hasLanded", canJump);

        //Debug.Log(canJump);

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(
                rb.velocity.x,
                rb.velocity.y * 0.5f);
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("Jump");
    }

    private void FixedUpdate()
    {

        // if(isOnePlayer)
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetBool("isWalking", Mathf.Abs(rb.velocity.x) > 0 && GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezeRotation);
        //rb.velocity += new Vector2(playerOneMovement.x, gravity * Time.fixedDeltaTime * Time.fixedDeltaTime);

        if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Death>())
        {
            Die();
        }
    }

    public void Die()
    {
        if (!hasDied)
        {
            anim.SetTrigger("Death");
            hasDied = true;
        }
    }


}
