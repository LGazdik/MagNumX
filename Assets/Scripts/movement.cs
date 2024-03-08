using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 playerOneMovement;
    private Vector2 playerTwoMovement;
    private bool isFacingRight = true;
    [SerializeField] float speed = 5f;
    [SerializeField]private bool isOnePlayer = false;

    private bool canJump = false;
    [SerializeField] float jumpHeight = 2f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radius = .05f;
    [SerializeField] private LayerMask mask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
       
        //Debug.Log(x);
        playerOneMovement.x = x;

        canJump = Physics2D.OverlapCircle(groundCheck.position, radius, mask);
        Debug.Log(canJump);

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            Debug.Log("we can jujmp");
            Jump();

        }
       // playerOneMovement.x = y;
    }

    private void Jump()
    {
        Debug.Log("we are jumping");
        Debug.Log(canJump);
       // movement.y = Mathf.Sqrt(jumpHeight * -2 - rb.gravityScale;

    }

    private void FixedUpdate()
    {
       // if(isOnePlayer)
            rb.MovePosition(rb.position + playerOneMovement * speed * Time.fixedDeltaTime);
        if(playerOneMovement.x < 0 && isFacingRight)
        {
            Flip();
        }
        if (playerOneMovement.x > 0 && !isFacingRight)
        {
            Flip();
        }
        // else
        // rb.MovePosition(rb.position + playerTwoMovement * speed * Time.fixedDeltaTime);

        
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
}
