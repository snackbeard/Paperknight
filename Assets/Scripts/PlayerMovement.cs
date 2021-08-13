using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public Transform ceilingCheck;
    public Transform weaponPos;

    public float speed;
    public float sprintMultiplier;
    public float jumpForce;
    public float moveInput;
    public LayerMask whatIsGrounded;
    public float checkRadius = 0.5f;

    public int maxExtraJumps;
    private int maxJumpsCount = 0;

    private bool facingRight = true;

    private Rigidbody2D rb;

    // private bool wasSprinting = false;
    // private bool facingRight = true;
    private bool isGrounded;
    // private bool sprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);
        // Debug.Log("grounded: " + isGrounded);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * this.speed, rb.velocity.y);
        
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } 
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    // Update is called once per frame
    void Update()
    {

        // Jump
        if(isGrounded == true)
        {
            this.maxJumpsCount = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.one * jumpForce;
            // Debug.Log("Jump 1");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && this.maxJumpsCount < this.maxExtraJumps)
        {
            rb.velocity = Vector2.up * (jumpForce * 0.8f);
            this.maxJumpsCount++;
            // Debug.Log("Jump 2");
        }

        /*
        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && moveInput != 0)
        {
            this.sprinting = true;
        }
        else
        {
            this.sprinting = false;
        }
        */

        // XY Koordinaten der Maus
        Vector2 worldPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Position x: " + worldPositon.x + " | Position y: " + worldPositon.y);

        // XY Koordinaten des Players bzw. der Waffe
        Vector2 weaponPos = this.weaponPos.position;
        Debug.Log("Position x: " + weaponPos.x + " | Position y: " + weaponPos.y);
        
        // Dreieck berechnen, Winkel berechnen, Objekt rotieren bei aktion
        // beispiel mikes spiel
    }

    void Flip()
    {
        this.facingRight = !this.facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
