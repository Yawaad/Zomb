using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMovement : MonoBehaviour
{

    // this is to store the position of the pointer (used to aim the weapon).
    public Vector2 PointerPosition { get; set; }
    Vector3 Direction;
    public bool flip = false;
    public static WeaponMovement Instance { get; private set; }
    playermovement Player;
     Vector2 LookDirection;



    private void Awake()
    {
        // Set the static instance to this script's instance
        Instance = this;
        Player = GetComponent<playermovement>();
    }




    public void Look(InputAction.CallbackContext button)
    {
        if (button.performed) //if the button for movement is clicked
        {
            LookDirection = button.ReadValue<Vector2>().normalized; //get the value in vector2

        }

        Direction = new Vector2(LookDirection.x, LookDirection.y);
        MoveWeapon();
    }

    public void MoveWeapon()
    {
        if (LookDirection != Vector2.zero)
        {
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
            transform.localScale = scale;
        }
    }


    private void Update()
    {
        

        if (Application.platform == RuntimePlatform.WindowsPlayer )
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

        }





        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {


            MoveWeapon();

            
        }

    }
}

       

      

