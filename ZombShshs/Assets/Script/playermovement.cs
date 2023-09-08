using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{

    Rigidbody2D rb;
    WeaponParent bulletdirection;
    WeaponParent weaponParent;
    //to get the bullet prefab for instantiation
    [SerializeField] GameObject BulletPF;
    //to get the posiiton and rotation of the bullet
    [SerializeField] Transform WeaponEnd;
    [SerializeField] Transform BulletDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletdirection = GetComponent<WeaponParent>();
        weaponParent = GetComponentInChildren<WeaponParent>();

    }

    public void Move(InputAction.CallbackContext button)
    {
        if(button.performed) //if the button for movement is clicked
        {
            Vector2 direction = button.ReadValue<Vector2>().normalized; //get the value in vector2
            rb.velocity = new Vector2(direction.x, direction.y).normalized * 5; //apply movement
    
        }
        else
        {
            rb.velocity = Vector2.zero; //if no button is clicked, stop
        }
        
    }

    public void shoot(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);

            // Calculate the direction from the bullet's position to the pointer position
            Vector2 direction = (weaponParent.PointerPosition - (Vector2)bullet.transform.position).normalized;

            // Set the bullet's velocity to move in that direction with a desired speed
            float bulletSpeed = 10f; // Adjust this speed as needed
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }









}
