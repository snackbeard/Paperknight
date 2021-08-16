using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerScript : MonoBehaviour
{

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    // 0 - 50 nix
    // 51 - 75
    public int item1chanceStart = 51;
    // 76 - 100
    public int item2chanceStart = 76;

    // 41 - 50
    public int item3chanceStart = 41;

    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void takeDamage(int damage)
    {
        this.currentHealth -= damage;
        Debug.Log("Took " + damage + "damage!");

        if (currentHealth <= 0)
        {
            Debug.Log("I died");
            this.die();
        }
    }

    public void die()
    {
        int random = Random.Range(0, 100);

        if (random > this.item2chanceStart)
        {
            Instantiate(this.item2, gameObject.transform.position, Quaternion.identity);
            // Debug.Log("Spawned item 2");
        }
        else if (random > this.item1chanceStart)
        {
            Instantiate(this.item1, gameObject.transform.position, Quaternion.identity);
            // Debug.Log("Spawned item 1");
        }
        else if (random > this.item3chanceStart)
        {
            Instantiate(this.item3, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

    }
}
