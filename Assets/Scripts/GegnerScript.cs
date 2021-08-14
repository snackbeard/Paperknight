using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerScript : MonoBehaviour
{

    public GameObject item1;
    public GameObject item2;

    // 0 - 50 nix
    // 51 - 75
    public int item1chanceMax = 75;
    // 76 - 100
    public int item2chanceMax = 100;

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

        if (random > 76)
        {
            Instantiate(item2, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Spawned item 2");
        }
        else if (random > 51)
        {
            Instantiate(item1, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Spawned item 1");
        }

        Destroy(gameObject);

    }
}
