using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            if (health.currentHealth < 100)
            {
                health.Heal(10);
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        transform.Rotate(0, 0, 250 * Time.deltaTime);
    }
}
