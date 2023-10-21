using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public List<Transform> points;
    public int nextID = 0;
    private int idChangeValue = 1;
    public float speed = 3;

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
        // GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }

    void Init()
    {
        // Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

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
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

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
