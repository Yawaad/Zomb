using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    // this is to store the position of the pointer (used to aim the weapon).
    public Vector2 PointerPosition { get; set; }
    public Vector3 direction;

    private void Update()
    {
        // Calculate the direction from the weapon's position to the pointer position.
         direction = (PointerPosition - (Vector2)transform.position).normalized;

        // Set the weapon's forward direction to point in the calculated direction.
        transform.right = direction;

        // Get the current scale of the weapon.
        Vector2 scale = transform.localScale;

        // Check the x-component of the direction to determine the weapon's orientation.
        if (direction.x < 0)
        {
            // If the x-component is negative, flip the weapon vertically (scale it negatively on the y-axis).
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            // If the x-component is positive, keep the weapon's vertical scale positive.
            scale.y = 1;
        }

        // Update the weapon's scale to apply the vertical flip if necessary.
        transform.localScale = scale;
    }
}
