using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    [SerializeField] private float speed;
    private bool isFacingLeft;
    private bool isRunning;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        StartCoroutine(FlipRight());
    }

    void Update()
    {
        if (isRunning)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (isFacingLeft)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
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
        isRunning = false;
        animator.SetBool("IsRunning?", false);
        animator.SetBool("IsDead?", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = true;
        this.enabled = false;
    }

    public IEnumerator FlipRight()
    {
        isRunning = true;
        animator.SetBool("IsRunning?", true);
        yield return new WaitForSeconds(5);
        isRunning = false;
        animator.SetBool("IsRunning?", false);
        yield return new WaitForSeconds(2);
        isFacingLeft = false;
        StartCoroutine(FlipLeft());
    }

    public IEnumerator FlipLeft()
    {
        isRunning = true;
        animator.SetBool("IsRunning?", true);
        yield return new WaitForSeconds(5);
        isRunning = false;
        animator.SetBool("IsRunning?", false);
        yield return new WaitForSeconds(2);
        isFacingLeft = true;
        StartCoroutine(FlipRight());
    }
}
