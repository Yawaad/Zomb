using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DefCharAbilities : MonoBehaviour

{
    [SerializeField] Button HealAbility;
    [SerializeField] float CoolDown;
    PlayerHealth Player;
    
    [SerializeField] float DashPower = 5;
    Vector2 Direction;
    [SerializeField] float speed;
    void Start()
    {
             
            Player = GetComponent<PlayerHealth>();
            
    }

    public void ApplyCoolDown(Button button)
    {
        StartCoroutine(ReduceCoolDown(button));
    }

    IEnumerator ReduceCoolDown(Button button)
    {

        button.enabled = false;
        yield return new WaitForSeconds(CoolDown);
        button.enabled = true;

    }


    public void Heal()
    {
        if (Player.CurrentHealth != Player.MaxHealth)
        {
            
            Player.CurrentHealth += Player.MaxHealth * 0.25f;
            
            CoolDown = 5;
        }
       
        

        if(Player.CurrentHealth > Player.MaxHealth)
        {
            Player.CurrentHealth = Player.MaxHealth;
        }

        Debug.Log(Player.CurrentHealth);
    }

    

   
    public void DashDirection(InputAction.CallbackContext button)
    {
        if (button.performed) //if the button for movement is clicked
        {
            Direction = button.ReadValue<Vector2>();
        }

    }
    public void Dash()
    {
        CoolDown = 7;
        
        
        Vector3 DashDistance = Direction * DashPower;
        
        
        transform.position =  Vector2.MoveTowards(transform.position, transform.position + DashDistance, speed );
        
        
    }
   
}
