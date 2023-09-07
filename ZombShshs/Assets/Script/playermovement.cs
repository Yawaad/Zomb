using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{

    Rigidbody2D rb;
    WeaponParent bulletdirection;

    [SerializeField] GameObject BulletPF;
    [SerializeField] Transform WeaponEnd;
    [SerializeField] Transform BulletDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletdirection = GetComponent<WeaponParent>();

    }

    public void Move(InputAction.CallbackContext button)
    {
        if(button.performed)
        {
            Vector2 direction = button.ReadValue<Vector2>().normalized;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * 5;
            Debug.Log(direction);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    public void shoot(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
           Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);
           
        }
           
    }


   
       

   
            
     
    
}
