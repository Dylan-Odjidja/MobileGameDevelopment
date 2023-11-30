using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComabt : MonoBehaviour
{
    [Header("Variables")]
    public Animator animator;
    [Header("Attacking")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public float attackRate = 4f;
    float nextAttackTime = 0f;


    void Update()
    {

    }

    public void Attack()
    {
        // Check if enough time has passed since the previous attack.
        if (Time.time >= nextAttackTime)
        {
            // Trigger the "Attack" animation in the Animator
            animator.SetTrigger("Attack");
            // Detect enemies within the specified attack range using an OverlapCircle.
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // Loop through all detected enemies and apply damage to them by calling their TakeDamage method.
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
            // Update the next attack time to prevent immediate consecutive attacks based on the attack rate.
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Check if the attack point is not assigned, and return early to avoid errors.
        if (attackPoint == null)
            return;
        // Draw a wire sphere in the Unity editor to visualize the attack range.
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
