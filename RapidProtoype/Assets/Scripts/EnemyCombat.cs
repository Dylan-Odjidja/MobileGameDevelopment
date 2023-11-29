using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Variables")]
    public Animator animator;
    public PlayerHealth playerHealthScript;
    public GameObject player;
    [Header("Attacking")]
    public int damage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealth>();
    }
    
    public void Attack()
    {
        
    }
}
