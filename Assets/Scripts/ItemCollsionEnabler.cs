using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollsionEnabler : MonoBehaviour
{

    public GameObject item;
    public Transform groundCheck;
    public LayerMask whatIsGrounded;
    public float checkRadius = 0.5f;

    private bool isGrounded;
    

    private void FixedUpdate()
    {
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);

        if (this.isGrounded)
        {
            (this.item.gameObject.transform.GetChild(0)).GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
}
