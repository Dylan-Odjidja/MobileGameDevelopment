using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Variables")]
    public Animator animator;
    public EnemyCombat enemyCombatScript;
    [Header("Targeting")]
    public GameObject player;
    private float distance;
    public float distanceBetween;
    [Header("Movement")]
    public float speed;

    void Start()
    {
        // Find the animator component
        animator = GetComponent<Animator>();
        // Find the EnemyCombat script
        enemyCombatScript = GetComponent<EnemyCombat>();
        // Find and store a reference to the player game object using the "Player" tag.
        player = GameObject.FindGameObjectWithTag("Player");
        // Set the range in which the enemy must detect the player
        distanceBetween = 8;
    }

    private void Update()
    {
        // Calculate the distance between the enemy and the player's position.
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Give the speed on the enemy to the animator so it knows when to play a running animation
        animator.SetFloat("Speed", speed);
        // Set the speed to zero if the enemy is no moving
        speed = 0;

        // Flip the enemy's sprite based on the relative positions of the enemy and the player.
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        // Check if the distance between the enemy and the player is less than a specified threshold.
        if (distance < distanceBetween)
        {
            // Set the speed to three when the player is in range
            speed = 3;
            // Move the enemy towards the player's position at a certain speed.
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
