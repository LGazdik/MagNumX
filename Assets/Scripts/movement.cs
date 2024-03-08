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
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radius = .05f;

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
        //float y = Input.GetAxisRaw("Vertical");
        Debug.Log(x);
        playerOneMovement.x = x;
       // playerOneMovement.x = y;
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

       // if(Physics2D.OverlapCircle())
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
        
    }
}
