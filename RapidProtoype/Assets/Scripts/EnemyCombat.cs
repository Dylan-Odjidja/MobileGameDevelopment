using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Variables")]
    public Animator animator;
    public PlayerHealth playerHealthScript;
    public GameObject player;
    [Header("Attacking")]
    public LayerMask playerLayer;
    public int enemyDamage = 10;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealth>();
    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            // Trigger the "Attack" animation in the Animator
            animator.SetTrigger("Attack");
            // Detect enemies within the specified attack range using an OverlapCircle.
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            // Loop through all detected enemies and apply damage to them by calling their TakeDamage method.
            foreach (Collider2D player in hitPlayer)
            {
                StartCoroutine(AttackDelay());
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

    public IEnumerator AttackDelay() {
        yield return new WaitForSeconds(0.60f);
        player.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
    }
}
