using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControls : MonoBehaviour
{
    public GameObject inventoryManager;

    // Update is called once per frame
    void Update()
    {
        // Taste 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.inventoryManager.gameObject.GetComponent<InventoryManager>().switchInventorySlot(KeyCode.Alpha1);
        }
        // Taste 2
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.inventoryManager.gameObject.GetComponent<InventoryManager>().switchInventorySlot(KeyCode.Alpha2);
        }
        // Q (Drop)
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            this.inventoryManager.gameObject.GetComponent<InventoryManager>().dropItem();
        }
    }
}
