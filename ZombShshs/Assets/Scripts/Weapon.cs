using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{


    //Note: Both Mobile and PC have their own logic for aiming and shooting

    //To store the bullet prefab that will be used for shooting.
    [SerializeField] GameObject BulletPF;
    //to store the shooting point where the bullet will spawn in.
    [SerializeField] Transform WeaponEnd;
    //store the rotation of the weapon to make the bullet's rotation match it.
    [SerializeField] Transform BulletDirection;
    //Will be used to store the instantiated bullet in a variable to be able to use it
    GameObject bullet;

    //Time between shots
    public float ShootingRate = 1f;
    //Time when Player can shoot again
    public float Nextshoot;


    // this is to store the position of the pointer (used to aim the weapon).
    public Vector2 PointerPosition { get; set; }
    //to store the direction where the Weapon will Look.(For PC)
    Vector3 Direction;
    //to store the direction where the Weapon will Look.(For Mobile)
    Vector2 LookDirection;
    //Will be used to switch the weapon and player's rotation between left and right
    public bool flip = false;
    public static Weapon Instance { get; private set; }

    



    // Reference to an InputAction asset that provides pointer position information.
    [SerializeField] InputActionReference pointerPosition;

    // Store the current pointer input in a private variable.
    private Vector2 pointerInput;

    // A property to access the pointer input externally.
    private Vector2 PointerInput => pointerInput;


    private void Start()
    {
       
        Nextshoot = Time.time;

    }
    private void Awake()
    {
        // Set the static instance to this script's instance
        Instance = this;
        
        
    }

    private void Update()
    {

        //Makes weapon look in the direction of Crosshair (for PC)
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            // Calculate the direction from the weapon's position to the pointer position. 
            Direction = (PointerPosition - (Vector2)transform.position).normalized;

            // Set the weapon's forward direction to point in the calculated direction.
            transform.right = Direction;

            // Get the current scale of the weapon.
            Vector2 scale = transform.localScale;

            // Check the x-component of the direction to determine the weapon's orientation.
            if (Direction.x < 0)
            {
                // If the x-component is negative, flip the weapon vertically (scale it negatively on the y-axis).
                scale.y = -1;
                flip = true;
            }
            else if (Direction.x > 0)
            {
                // If the x-component is positive, keep the weapon's vertical scale positive.
                scale.y = 1;
                flip = false;
            }

            // Update the weapon's scale to apply the vertical flip if necessary.
            transform.localScale = scale;

            // Get the current pointer input and assign it to pointerInput.
            pointerInput = GetPointerInput();

            // Update the PointerPosition property of the weapon parent with the pointer input.
            PointerPosition = pointerInput;

        }





        

    }

    //this handles the shooting for all platforms
   
    public void shoot(InputAction.CallbackContext button)
    {
        //For PC
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (button.performed && Time.time >= Nextshoot)
            {
                // Instantiate the bullet
                bullet = Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);


                // Play Sound EffectS


                // Calculate the direction from the bullet's position to the pointer position
                Vector2 direction = (PointerPosition - (Vector2)bullet.transform.position).normalized;

                // Set the bullet's velocity to move in that direction with a desired speed
                float bulletSpeed = 10f; // Adjust this speed as needed
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                Nextshoot = Time.time + ShootingRate;
                

            }
        }

        //For Mobile
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (button.performed && Time.time >= Nextshoot)
            {
                bullet = Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);

                // Play Sound Effect





                // Set the bullet's velocity to move in the direction of Movement
                float bulletSpeed = 10f; // Adjust this speed as needed
                bullet.GetComponent<Rigidbody2D>().velocity = LookDirection * bulletSpeed;
                Nextshoot = Time.time + ShootingRate;

            }
        }



    }

    //function that Controls the shooting rate.
   



    //makes the weapon look in the direction of movement(For Mobile)
    public void Look(InputAction.CallbackContext button)

    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (button.performed) //if the button for movement is clicked
            {
                LookDirection = button.ReadValue<Vector2>().normalized; //get the value in vector2

            }

            Direction = new Vector2(LookDirection.x, LookDirection.y);

            if (LookDirection != Vector2.zero)
            {
                //gets the angle in degrees of the weapon
                float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.right = Direction;

                // Get the current scale of the weapon.
                Vector2 scale = transform.localScale;

                // Check the x-component of the direction to determine the weapon's orientation.
                if (Direction.x < 0)
                {
                    // If the x-component is negative, flip the weapon vertically (scale it negatively on the y-axis).
                    scale.y = -1;
                    flip = true;
                }
                else if (Direction.x > 0)
                {
                    // If the x-component is positive, keep the weapon's vertical scale positive.
                    scale.y = 1;
                    flip = false;
                }
                //Makes the weapon switch between looking left and right
                transform.localScale = scale;
            }
        }
    }


  


    public Vector2 GetPointerInput()
    {
        // Read the input value from the pointerPosition InputActionReference.
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();

        // Set the z-component of the input to the camera's near clip plane for proper conversion.
        mousePos.z = Camera.main.nearClipPlane;

        // Convert the screen position to world space and return it as the pointer input.
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
