using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHealth : MonoBehaviour
     
{
    
     Rigidbody2D rb;

     public float MaxHealth = 100;
     public float CurrentHealth;

     public HealthBar HealthBar;
      playermovement Playermovement;

     [SerializeField] float KnockBackPower = 5.0f; 

     public bool KnockBack = false;
     [SerializeField] float KnockBackStopTime = 3f;

     void Start()
     {
         rb = GetComponent<Rigidbody2D>();
         CurrentHealth = MaxHealth;
         HealthBar.SetMaxhealth(MaxHealth);
     }


   

    

     void TakeDamage(int damage)
     {
         CurrentHealth -= damage;
         HealthBar.SetHealth(CurrentHealth);
     }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Function started"); // Add this to key parts of your script to see if they are executed.
            //TakeDamage(20);

            


            StartCoroutine(ApplyKnockBack());

            
        }
       
    }
    IEnumerator ApplyKnockBack()
    {
        Vector2 KnockBackDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(KnockBackDirection * KnockBackPower, ForceMode2D.Impulse);
        yield return new WaitForSeconds(KnockBackStopTime);
        KnockBack = false;
        rb.velocity = Vector2.zero;
        Debug.Log("Function Ended");
    }
    
    
}
