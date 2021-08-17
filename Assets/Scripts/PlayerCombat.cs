using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject healthbarController;
    public int damage;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
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
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(1, 1), 0f, enemyLayers);

        // damage everyone
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit: " + enemy.name);
            enemy.GetComponent<GegnerScript>().takeDamage(this.damage);
        }

        this.onDamage(10);
    }

    void onDamage(int damage)
    {
        this.healthbarController.gameObject.GetComponent<HealthbarController>().takeDamage(damage);
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
