using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth;
    public GameObject healthbarController;
    public int damage;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public TextMesh damageNumber;

    private int currentHealth;

    private void Start()
    {
        this.healthbarController.gameObject.GetComponent<HealthbarController>().setMaxHealth(this.maxHealth);
        this.currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //detect enemies in attack range
        int random = Random.Range(damage - 5, damage + 5);

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(1, 1), 0f, enemyLayers);

        // damage everyone
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit: " + enemy.name);
            enemy.GetComponent<GegnerScript>().takeDamage(random);
        }

        // this.onDamage(10);
    }

    public void onDamage(int damage)
    {
        this.currentHealth = this.currentHealth - damage;
        this.healthbarController.gameObject.GetComponent<HealthbarController>().takeDamage(damage);

        /*
        #region player damage numers
        this.damageNumber.gameObject.GetComponent<TextMesh>().text = damage.ToString();
        Vector3 pos = gameObject.transform.position;
        pos.y = pos.y + 0.5f;
        TextMesh instantiated = Instantiate(this.damageNumber, pos, Quaternion.identity);

        int random = Random.Range(-2, 2);
        // Debug.Log(random);

        instantiated.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(random, 2);
        #endregion
        */

        if (currentHealth <= 0)
        {
            Debug.Log("I died");
            this.die();
        }
    }

    public void die()
    {
        gameObject.SetActive(false);
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
