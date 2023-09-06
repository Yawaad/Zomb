using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] InputActionReference pointerPosition;

    private Vector2 pointerInput;
    private Vector2 PointerInput => pointerInput;
    private WeaponParent weaponParent;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
