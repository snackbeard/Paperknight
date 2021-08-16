using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject inventoryManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Test Collsion");
        bool full = this.inventoryManager.GetComponent<InventoryManager>().addItem(collision.transform.parent.tag, collision.transform.parent.gameObject.layer);

        if (full)
        {
            Rigidbody2D rb = collision.transform.parent.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.up * 2f;
        }
        else
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }


}
