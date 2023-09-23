using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{

    Rigidbody2D rb;
    
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
    public Vector2 MovementDirection;
    public Vector2 MovementSpeed;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    public bool KnockFromUp;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        WeaponMovement = GetComponentInChildren<WeaponMovement>();
        characterTransform = transform;
        
        



    }

    private void Update()
    {
        //KnockBack();
        
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {

            if (WeaponMovement.Instance != null)
            {
                if (WeaponMovement.Instance.flip)
                {
                    // Rotate the character 180 degrees on the Y-axis
                    characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }

            }

        }


        else if  (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if(MovementDirection.x >= 0)
            {
                characterTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if(MovementDirection.x <= 0) 
            {
                characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }


        MovementSpeed = rb.velocity;
    }

    //private void KnockBack()
    //{
    //    if (KBCounter > 0)
    //    {
    //        if (KnockFromRight == false)
    //        {
    //            rb.velocity = new Vector2(-KBForce, KBForce);
    //        }
    //        if (KnockFromRight == true)
    //        {
    //            rb.velocity = new Vector2(KBForce, KBForce);
    //        }
    //        if (KnockFromUp == false)
    //        {
    //            rb.velocity = new Vector2(KBForce, -KBForce);
    //        }
    //        if (KnockFromUp == true)
    //        {
    //            rb.velocity = new Vector2(KBForce, KBForce);
    //        }

    //        KBCounter -= Time.deltaTime;
    //    }
    //}

    public void Move(InputAction.CallbackContext button)
    {
        if(button.performed) //if the button for movement is clicked
        {
            MovementDirection = button.ReadValue<Vector2>(); //get the value in vector2
            rb.velocity = new Vector2(MovementDirection.x, MovementDirection.y).normalized * Speed; //apply movement
            MovementSpeed = rb.velocity;
        }
        else
        {
            rb.velocity = Vector2.zero; //if no button is clicked, stop
        }
        
    }

    public void shoot(InputAction.CallbackContext button)
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
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

        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
             {
                if (button.performed)
                {
                    bullet = Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);

                    // Play Sound Effect


                    // Calculate the direction from the bullet's position to the pointer position
                    Vector2 direction = new Vector2 (MovementDirection.x, MovementDirection.y).normalized;

                    // Set the bullet's velocity to move in that direction with a desired speed
                    float bulletSpeed = 10f; // Adjust this speed as needed
                    bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                }
            }



    }


    






}
