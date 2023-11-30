using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Variables")]
    public Animator animator;
    public EnemyCombat enemyCombatScript;
    public EnemyHealth enemyHealthScript;
    public PlayerHealth playerHealthScript;
    [Header("Targeting")]
    public GameObject player;
    private float distance;
    public float distanceBetween;
    [Header("Movement")]
    public List<Transform> points;
    public int nextID = 0;
    private int idChangeValue = 1;
    public float speed;

    private void Reset()
    {
        Init();
    }

    void Start()
    {
        // Find the animator component
        animator = GetComponent<Animator>();
        // Find the EnemyCombat script
        enemyCombatScript = GetComponent<EnemyCombat>();
        // Find the EnemyHealth script
        enemyHealthScript = GetComponent<EnemyHealth>();
        // Find the PlayerHealth script
        playerHealthScript = GetComponent<PlayerHealth>();
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

        if (enemyHealthScript.currentHealth > 0)
        {
            if (distance > distanceBetween)
            {
                speed = 3;
                MoveToNextPoint();
            }
            // Check if the distance between the enemy and the player is less than a specified threshold.
            if (distance < distanceBetween && distance > 2)
            {
                // Set the speed to three when the player is in range
                speed = 3;
                // Move the enemy towards the player's position at a certain speed.
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            if (distance < 2 && playerHealthScript.currentHealth > 0)
            {
                enemyCombatScript.Attack();
                Debug.Log("Attacking");
            }
        }
    }

    void Init()
    {
        // Create Root object
        GameObject root = new GameObject("Enemy_" + name);

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
