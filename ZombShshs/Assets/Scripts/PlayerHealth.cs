using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    /*
    Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public playermovement playermovement;

    [SerializeField] float knockbackPower = 5.0f; 

    public bool knockBackStop = false;
    [SerializeField] float knockBackStopTime = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.velocity = knockbackDirection * knockbackPower;

            TakeDamage(20);

            knockBackStop=true;
        }
    }

    private void Update()
    {
        if (!knockBackStop)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    */
}
