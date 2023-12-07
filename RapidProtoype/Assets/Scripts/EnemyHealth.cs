using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Variables")]
    private Animator animator;
    private Rigidbody2D rb;
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        // Deal damage to the enemy
        currentHealth -= damage;
        // Set a boolean parameter in the Animator to indicate that the enemy is hurt.
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            animator.SetBool("IsAlive?", false);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        // Add score
        Score.scoreValue += 10;
        // Destoy the game object
        Destroy(gameObject);
    }
}
