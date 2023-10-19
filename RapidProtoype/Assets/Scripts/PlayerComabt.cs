using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComabt : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Update()
    {

    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }

            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
