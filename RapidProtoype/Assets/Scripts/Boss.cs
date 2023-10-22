using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] private BoxCollider2D Arena;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Arena) {
        Debug.Log("Triggered");
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
