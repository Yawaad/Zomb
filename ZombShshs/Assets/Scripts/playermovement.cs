using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{

    Rigidbody2D rb;
    
    Weapon Weapon;
    GameObject bullet;
    private Transform characterTransform;
    //to get the bullet prefab for instantiation
   
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

        
        Weapon = GetComponentInChildren<Weapon>();
        characterTransform = transform;
        
        



    }

    private void Update()
    {
        //KnockBack();
        
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {

            if (Weapon.Instance != null)
            {
                if (Weapon.Instance.flip)
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

  


    






}
