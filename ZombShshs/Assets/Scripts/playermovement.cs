using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{

    Rigidbody2D rb;
    WeaponMovement bulletdirection;
    WeaponMovement WeaponMovement;
    GameObject bullet;
    private Transform characterTransform;
    //to get the bullet prefab for instantiation
    [SerializeField] GameObject BulletPF;
    //to get the posiiton and rotation of the bullet
    [SerializeField] Transform WeaponEnd;
    [SerializeField] Transform BulletDirection;
    [SerializeField] float Speed;
    [SerializeField] AudioSource ShootSFX;
   
     


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletdirection = GetComponent<WeaponMovement>();
        WeaponMovement = GetComponentInChildren<WeaponMovement>();
        characterTransform = transform;

    }

    private void Update()
    {
        if (WeaponMovement.Instance != null)
        {
            if (WeaponMovement.Instance.flip)
            {
                // Rotate the character 180 degrees on the Y-axis
                characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                // Reset the rotation on the Y-axis to 0 degrees
                characterTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }



    public void Move(InputAction.CallbackContext button)
    {
        if(button.performed) //if the button for movement is clicked
        {
            Vector2 direction = button.ReadValue<Vector2>().normalized; //get the value in vector2
            rb.velocity = new Vector2(direction.x, direction.y).normalized * Speed; //apply movement
    
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
             bullet = Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);

            // Play Sound Effect
            

            // Calculate the direction from the bullet's position to the pointer position
            Vector2 direction = (WeaponMovement.PointerPosition - (Vector2)bullet.transform.position).normalized;

            // Set the bullet's velocity to move in that direction with a desired speed
            float bulletSpeed = 10f; // Adjust this speed as needed
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            
            
        }

        

    }


    






}
