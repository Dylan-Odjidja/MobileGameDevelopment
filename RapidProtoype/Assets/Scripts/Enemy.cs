using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    // Animator
    private Animator animator;
    // Set max health
    public int maxHealth = 100;
    // Current health variable
    int currentHealth;
    // Reference to waypoints
    public List<Transform> points;
    // Integer value for next point index
    public int nextID = 0;
    // Value that applies to ID for changing
    private int idChangeValue = 1;
    // Speed of movemnt
    public float speed = 3;
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;
    CapsuleCollider2D capsuleCollider;


    private void Reset()
    {
        Init();
    }

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsRunning?", false);
        animator.SetBool("IsDead?", true);
        // boxCollider.enabled = false;
        // capsuleCollider.enabled = true;
        this.enabled = false;
        Score.ScoreValue += 10;
    }

    void Init()
    {
        // Change the size of the box collider
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1.071695f, 1.408641f);
        // Set the gravity of the rigid body
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 3;
        // Change the size of the capsule collider
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.size = new Vector2(1.4756f, 0.2662713f);
        capsuleCollider.offset = new Vector2(2.256041e-08f, 0.1892504f);
        capsuleCollider.direction = CapsuleDirection2D.Horizontal;
        capsuleCollider.enabled = false;

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
        // Flip enemy transform
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
