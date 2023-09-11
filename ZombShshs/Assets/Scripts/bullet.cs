using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
     
    private void Update()
    {
        Destroy(gameObject, 5);
 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            enemyscript Enemy =  collision.gameObject.GetComponent<enemyscript>();
            Enemy.Health -= 50;
        }

    }


}
