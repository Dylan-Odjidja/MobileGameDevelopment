using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HealthBar healthBar;
    public GameObject menu;

    void Start()
    {
        // Initialize the character's health to the maximum value.
        currentHealth = maxHealth;
        // Set the maximum health value for the health bar UI element.
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        // Trigger a "Hurt" animation in the Animator.
        animator.SetTrigger("Hurt");
        // Decrease the character's current health by the specified damage amount.
        currentHealth -= damage;
        // Update the health bar UI to reflect the new health value.
        healthBar.SetHealth(currentHealth);
        // Check if the character's health has dropped to or below zero.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Stop the background music
        MusicPlayer.audioSource.Stop();
        // Set the "IsAlive?" boolean parameter in the Animator to false.
        animator.SetBool("IsAlive?", false);
        // Disable this script to prevent further interactions.
        this.enabled = false;
        // Start a coroutine to handle the "You Died" process, such as displaying a menu and pausing the game.
        StartCoroutine(YouDied());
    }

    public IEnumerator YouDied()
    {
        // Wait for 2 seconds before executing the following code
        yield return new WaitForSeconds(2);
        // Activate the menu GameObject
        menu.SetActive(true);
        // Set the game's time scale to zero, effectively pausing the game.
        Time.timeScale = 0;
    }
}
