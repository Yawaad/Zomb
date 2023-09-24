using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class DefCharAbilities : MonoBehaviour

{

    

    //This will Help in Rotating the player
    private Transform characterTransform;
    
    
    
    //the Speed the player moves in.
    [SerializeField] float Speed;

    [SerializeField] AudioSource ShootSFX;
    //To Store the Movement Direction
    public Vector2 MovementDirection;
    //To Store the Movement Speed
    public Vector2 MovementSpeed;

   /* public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    public bool KnockFromUp;*/


    
    //Cooldown for the charachterAbilities
    [SerializeField] float CoolDown;

    //To Access the Player Health for the Healing Ability
    PlayerHealth Player;

    //Controls the Dashing ability's power
    [SerializeField] float DashPower = 5;
    
   

    //Controls the Dash Duration
    float DashCounter = 0.5f;

    //To controls the number of dashes to prevent Spamming (Has other Uses too!)
    int Dashes = 1;

    Rigidbody2D RB;

    //Controls if the Player can move or not
    bool CanMove = true;

     Weapon Weapon;
    [SerializeField] GameObject UsedWeapon;
    Weapon AttackSpeed;

    void Start()
    {

        
        
        Player = GetComponent<PlayerHealth>();
        RB = GetComponent<Rigidbody2D>();
        Weapon = GetComponent<Weapon>();

        characterTransform = transform;
        AttackSpeed =  UsedWeapon.GetComponent<Weapon>();

    }
    private void Update()
    {
        

        //KnockBack();

        //for PC
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {

            if (Weapon.Instance != null)
            {
                if (Weapon.Instance.flip)
                {
                    // Rotate the character 180 degrees on the Y-axis to look in the opposite direction (if right, it will look left etc...,)
                    characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }

            }

        }

        //For Mobile
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            //If player is moving in the positive direction(right), Look right.
            if (MovementDirection.x >= 0)
            {
                characterTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            //If player is moving in the negative direction(left), Look left.
            else if (MovementDirection.x <= 0)
            {
                characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }


        



        //If the dash ability is triggered, starts the ability.
        if (DashCounter>0 && Dashes == 0)
        {
            DashCounter-= Time.deltaTime;
            Vector3 DashDistance = MovementDirection * DashPower;
            RB.velocity = DashDistance;
            CanMove = false;
        }
        
        //when the Dash finished go back to normal movement speed and reset the ability
        if (DashCounter <= 0)
        {
            RB.velocity = MovementSpeed;
            DashCounter = 0.5f;
            Dashes = 1;
            CanMove = true;
        }
        
        
    }




    //Handles Player movement
    public void Move(InputAction.CallbackContext button)
    {
        if (button.performed && CanMove == true) //if the button for movement is clicked
        {
            MovementDirection = button.ReadValue<Vector2>(); //get the value in vector2.
            MovementSpeed = new Vector2(MovementDirection.x, MovementDirection.y).normalized * Speed; //Calculates the movement speed.
            RB.velocity = MovementSpeed;//apply movement
        }
        else
        {
            RB.velocity = Vector2.zero; //if no button is clicked, stop
        }

    }

    //Makes CoolDown for abilities
    IEnumerator ReduceCoolDown(Button button)
    {

        button.enabled = false;
        yield return new WaitForSeconds(CoolDown);
        button.enabled = true;

    }

    //Applys the cooldown.
    public void ApplyCoolDown(Button button)
    {
        StartCoroutine(ReduceCoolDown(button));
    }


    

    //The Healing Ability.
    public void Heal(Button Button)
    {
        //Prevents the ability from being treggered if the player health is full.
        if (Player.CurrentHealth != Player.MaxHealth)
        {
            //The Healing effect.
            Player.CurrentHealth += Player.MaxHealth * 0.25f;
            //Applies Cooldown.
            CoolDown = 5;
        }

        if (Player.CurrentHealth == Player.MaxHealth)
        {
            Button.enabled = false;
            CoolDown = 0.5f;
        }

        //Prevents the player's health from exceeding the max health.
        if (Player.CurrentHealth > Player.MaxHealth)
        {
            Player.CurrentHealth = Player.MaxHealth;
        }

        Debug.Log(Player.CurrentHealth);
    }

    

   
   //The Dahs Ability(the logic is in the update function. this just triggers it.)
    public void Dash()
    {
        if(DashCounter>0)
        {
            Debug.Log("Dash started");
            CoolDown = 7;
            Dashes -= 1;
            
        }

  
        
        
    }


    public void AdrinalineRush()
    {
        CoolDown = 7;
        StartCoroutine(IncreaseSpeedandShooting());
    }

    IEnumerator IncreaseSpeedandShooting()
    {
        Debug.Log("Ability started");
        Speed = Speed * 1.5f;
        AttackSpeed.ShootingRate = 0.5f;
        yield return new WaitForSeconds(3);
        Speed = 7.5f;
        AttackSpeed.ShootingRate = 1;
        Debug.Log("Ability Ended");
    }
  
}












//private void KnockBack()
//{
//    if (KBCounter > 0)
//    {
//        if (KnockFromRight == false)
//        {
//            RB.velocity = new Vector2(-KBForce, KBForce);
//        }
//        if (KnockFromRight == true)
//        {
//            RB.velocity = new Vector2(KBForce, KBForce);
//        }
//        if (KnockFromUp == false)
//        {
//            RB.velocity = new Vector2(KBForce, -KBForce);
//        }
//        if (KnockFromUp == true)
//        {
//            RB.velocity = new Vector2(KBForce, KBForce);
//        }

//        KBCounter -= Time.deltaTime;
//    }
//}



