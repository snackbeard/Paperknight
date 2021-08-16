using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private bool[] isFullWeapons;
    private bool[] isFullCons;
    public GameObject[] weaponSlots;
    public GameObject[] consSlots;

    public GameObject gameController;

    // platzhalter
    public Text text;

    private int slot;

    public void Start()
    {
        this.slot = 0;
        this.isFullWeapons = new bool[this.weaponSlots.Length];
        this.isFullCons = new bool[this.consSlots.Length];
        Debug.Log("Slot 1 selected");
        //Instantiate(this.slotHighlightEmpty, this.weaponSlots[0].transform.position, Quaternion.identity, this.weaponSlots[0].transform.parent);
    }

    public bool addItem(string tag, int layer)
    {

        if (layer == 8)
        {
            for (int i = 0; i < this.weaponSlots.Length; i++)
            {
                if (!this.isFullWeapons[i]) 
                {
                    this.isFullWeapons[i] = true;
                    this.text.text = tag + "; " + layer.ToString();
                    Instantiate(this.text, this.weaponSlots[i].transform.position, Quaternion.identity, this.weaponSlots[i].transform);
                    return false;
                }
            }
            return true;
        }
        else
        {
            for (int i = 0; i < this.consSlots.Length; i++)
            {
                if (!this.isFullCons[i])
                {
                    this.isFullCons[i] = true;
                    this.text.tag = tag;
                    this.text.text = tag + "; " + layer.ToString();
                    Instantiate(this.text, this.consSlots[i].transform.position, Quaternion.identity, this.consSlots[i].transform);
                    return false;
                }
            }
            return true;
        }
    }

    public void switchInventorySlot(KeyCode keyCode)
    {

        switch (keyCode)
        {
            case KeyCode.Alpha1:
                // highlight slot 1
                Debug.Log("Slot 1 selected");
                this.slot = 0;
                break;

            case KeyCode.Alpha2:
                // highlight slot 2
                Debug.Log("Slot 2 selected");
                this.slot = 1;
                break;

        }
    }

    public void dropItem()
    {
        Debug.Log("Drop weapon request");
        if (this.isFullWeapons[this.slot])
        {
            Debug.Log("dropped");
            this.isFullWeapons[this.slot] = false;
            string itemTag = this.weaponSlots[this.slot].gameObject.GetComponentInChildren<Text>().tag;
            Destroy(this.weaponSlots[this.slot].gameObject.GetComponentInChildren<Text>());

            // methode zum spawnen in welt
            this.gameController.gameObject.GetComponent<GameController>().spawnNewWorldItem(itemTag);
        }
    }
}
