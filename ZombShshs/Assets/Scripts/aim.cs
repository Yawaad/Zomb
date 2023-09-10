using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class aim : MonoBehaviour
{
    // Reference to an InputAction asset that provides pointer position information.
    [SerializeField] InputActionReference pointerPosition;

    // Store the current pointer input in a private variable.
    private Vector2 pointerInput;

    // A property to access the pointer input externally.
    private Vector2 PointerInput => pointerInput;

    // Reference to the WeaponParent component attached to the player.
    private WeaponParent weaponParent;

    private void Awake()
    {
        // Find and store the WeaponParent component in the player's children.
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    private void Update()
    {
        // Get the current pointer input and assign it to pointerInput.
        pointerInput = GetPointerInput();

        // Update the PointerPosition property of the weapon parent with the pointer input.
        weaponParent.PointerPosition = pointerInput;
    }

    // Function to retrieve the pointer input.
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
