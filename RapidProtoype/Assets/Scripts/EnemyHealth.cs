using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Variables")]
    private Animator animator;
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // Deal damage to the enemy
        currentHealth -= damage;
        // Set a boolean parameter in the Animator to indicate that the enemy is hurt.
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        // Add score
        Score.ScoreValue += 10;
        // Destoy the game object
        Destroy(gameObject);
    }
}
