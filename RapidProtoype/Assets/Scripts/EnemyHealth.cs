using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Variables")]
    private Animator animator;
    private Rigidbody2D rb;
    private Transform ePos;
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthItem;
    public bool isAlive = true;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ePos = GetComponentInParent<Transform>();
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
            isAlive = false;
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        // Add score
        Score.scoreValue += 10;
        // Drop a health item
        Instantiate(healthItem, new Vector2(ePos.position.x, ePos.position.y + 2f), Quaternion.identity);
        // Destoy the game object
        Destroy(gameObject);
    }
}
