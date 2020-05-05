using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
