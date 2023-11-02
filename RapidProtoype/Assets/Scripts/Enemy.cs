using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 20;
    int currentHealth;
    public List<Transform> points;
    public int nextID = 0;
    private int idChangeValue = 1;
    public float speed = 3;
    public GameObject player;
    private float distance;
    public float distanceBetween;
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;

    private void Reset()
    {
        Init();
    }

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        distanceBetween = 6;
    }

    private void Update()
    {
        // Find and store a reference to the player game object using the "Player" tag.
        player = GameObject.FindGameObjectWithTag("Player");
        // Calculate the distance between the enemy and the player's position.
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Calculate the direction from the enemy to the player.
        Vector2 direction = player.transform.position - transform.position;
        // Normalize the direction to get a unit vector.
        direction.Normalize();
        // Calculate the angle in degrees from the normalized direction vector.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

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
            // Set a boolean parameter in the Animator to indicate that the enemy is running.
            animator.SetBool("IsRunning?", true);
            // Move the enemy towards the player's position at a certain speed.
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            // If the player isn't near by run the "MoveToNextPoint()" function
            MoveToNextPoint();
        }
    }

    public void TakeDamage(int damage)
    {
        // Deal damage to the enemy
        currentHealth -= damage;
        // Set a boolean parameter in the Animator to indicate that the enemy is hurt.
        animator.SetTrigger("Hurt");
        // If the enemy's health reaches zero, run the "Die()" function
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Set a boolean parameter in the Animator to indicate that the enemy is running.
        animator.SetBool("IsRunning?", false);
        // Set a boolean parameter in the Animator to indicate that the enemy is dead.
        animator.SetBool("IsDead?", true);
        // GetComponent<BoxCollider2D>().enabled = false;
        Score.ScoreValue += 10;
        // Disable the script
        this.enabled = false;
    }

    void Init()
    {
        // Change the size of the box collide
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1.071695f, 1.408641f);
        // Set the gravity of the rigid body
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 3;

        // Create Root object
        GameObject root = new GameObject(name + "_Root");

        // Reset position of Root to enemy object
        root.transform.position = transform.position;

        // Set enemy object as child of root
        transform.SetParent(root.transform);

        // Create waypoints object
        GameObject waypoints = new GameObject("Waypoints");

        // Reset waypoints position to root
        // Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        // Create two points and reset thier position to waypoints object
        // Make points children of waypoint object
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);

        // Initiate points list then add the points to it
        points = new List<Transform>
        {
            p1.transform,
            p2.transform
        };
    }

    void MoveToNextPoint()
    {
        animator.SetBool("IsRunning?", true);
        // Get next point transform
        Transform goalPoint = points[nextID];

        // Flip the enemy's sprite based on the relative positions of the enemy and the player.
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        // Move the enemy
        transform.position = Vector3.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        // Check distance between enemy and point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            // Check if enemy is at the end of the line
            if (nextID == points.Count - 1)
            {
                idChangeValue = -1;
            }
            // Check if enemy is at the start of the line
            if (nextID == 0)
            {
                idChangeValue = 1;
            }
            // Apply the change on the nextID
            nextID += idChangeValue;
        }
    }
}
