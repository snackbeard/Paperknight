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
        
        Debug.Log(tag);
        GameObject toSpawn = this.itemTagMapping[tag];
        bool facingRight = this.player.gameObject.GetComponent<PlayerMovement>().facingRight;
        GameObject item = Instantiate(toSpawn, player.transform.position, Quaternion.identity);
        (item.gameObject.transform.GetChild(0)).GetComponent<BoxCollider2D>().enabled = false;

        Vector2 direction = new Vector2(3, 3);
        if (!facingRight)
        {
            direction.x = -3;
        }

        item.GetComponent<Rigidbody2D>().velocity = direction;
        
        // funktioniert nicht, script mit update funktion für item welche es nach ground collision auf true setzt?
        // (item.gameObject.transform.GetChild(0)).GetComponent<BoxCollider2D>().enabled = true;
        // ??
        

    }
}
