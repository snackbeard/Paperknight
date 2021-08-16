using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    private IDictionary<string, GameObject> itemTagMapping = new Dictionary<string, GameObject>();
    public void Start()
    {
        this.itemTagMapping.Add("Item1", this.item1);
        this.itemTagMapping.Add("Item2", this.item2);
        this.itemTagMapping.Add("Item3", this.item3);
    }

    public void spawnNewWorldItem(string tag)
    {
        GameObject toSpawn = this.itemTagMapping["Item1"];
        bool facingRight = this.player.gameObject.GetComponent<PlayerMovement>().facingRight;
        (toSpawn.gameObject.transform.GetChild(0)).GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(toSpawn, player.transform.position, Quaternion.identity);
        // Instantiate(toSpawn, new Vector3(-28.2209f, 0.008237956f, 0), Quaternion.identity);

        // Vector2 direction = new Vector2(250, 150);
        /*
        if (!facingRight)
        {
            direction.x = -10;
        }
        */
        Rigidbody2D rb = toSpawn.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 100));
        Debug.Log("ItemName: " + rb.name);

        // ??
        

    }
}
