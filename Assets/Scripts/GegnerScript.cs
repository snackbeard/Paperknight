using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GegnerScript : MonoBehaviour
{
    public GameObject player;
    public HealthbarController healthbarController;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int damage;
    public float triggerRange = 1f;

    public TextMesh damageNumber;

    public LayerMask playerLayer;

    public Vector3 offset;

    // 76 - 100
    public GameObject item1;
    public int item1chanceStart;

    // 51 - 75
    public GameObject item2;
    public int item2chanceStart;

    // 41 - 50
    public GameObject item3;
    public int item3chanceStart;





    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = maxHealth;
        this.healthbarController.setMaxHealth(this.maxHealth);
    }

    void Update()
    {
        // move healthbar
        this.healthbarController.moveToPosition(this.transform.position + offset);

        // detect player
        float distance = Vector3.Distance(this.player.transform.position, this.transform.position);
        // TODO: bug?
        // Debug.Log("Distance: " + distance.ToString());
        if (distance <= this.triggerRange)
        {
            EnemyAttack();
        }
    }

    private void EnemyAttack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(1, 1), 0f, playerLayer);

        // damage everyone
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Hit: " + player.name);
            // this.damage verwenden
            player.GetComponent<PlayerCombat>().onDamage(this.damage);
        }
    }

    public void takeDamage(int damage)
    {
        this.damageNumber.gameObject.GetComponent<TextMesh>().text = damage.ToString();
        Vector3 pos = gameObject.transform.position;
        pos.y = pos.y + 0.5f;
        TextMesh instantiated = Instantiate(this.damageNumber, pos, Quaternion.identity);

        int random = Random.Range(-2, 2);
        Debug.Log(random);

        instantiated.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(random, 2);

        this.currentHealth -= damage;
        this.healthbarController.takeDamage(damage);
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
        Debug.Log("randomnum: " + random.ToString());

        GameObject item = null;

        if (random > this.item1chanceStart)
        {
            item = Instantiate(this.item1, gameObject.transform.position, Quaternion.identity);
            // Debug.Log("Spawned item 2");
        }
        else if (random > this.item2chanceStart)
        {
            item = Instantiate(this.item2, gameObject.transform.position, Quaternion.identity);
            // Debug.Log("Spawned item 1");
        }
        else if (random > this.item3chanceStart)
        {
            item = Instantiate(this.item3, gameObject.transform.position, Quaternion.identity);
        }

        if (item != null)
        {
            Destroy(item.gameObject.transform.GetChild(1).gameObject);
        }

        Destroy(gameObject);

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireCube(attackPoint.position, new Vector3(1f, 0.3f, 1f));
    }
}
