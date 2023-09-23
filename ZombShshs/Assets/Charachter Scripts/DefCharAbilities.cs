using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class DefCharAbilities : MonoBehaviour

{
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

   /* public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    public bool KnockFromUp;*/


    WeaponMovement WeaponMovement;
    [SerializeField] Button HealAbility;
    [SerializeField] float CoolDown;
    PlayerHealth Player;
    [SerializeField] float DashPower = 5;
    
    [SerializeField] float speed;
    float DashCounter = 0.5f;
    int Dashes = 1;
    Rigidbody2D RB;
    bool CanMove = true;
    

    void Start()
    {

        
        WeaponMovement = GetComponentInChildren<WeaponMovement>();
        Player = GetComponent<PlayerHealth>();
        RB = GetComponent<Rigidbody2D>();
        
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


        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (MovementDirection.x >= 0)
            {
                characterTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (MovementDirection.x <= 0)
            {
                characterTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }


        




        if (DashCounter>0 && Dashes == 0)
        {
            DashCounter-= Time.deltaTime;
            Vector3 DashDistance = MovementDirection * DashPower;
            RB.velocity = DashDistance;
            CanMove = false;
        }
        

        if (DashCounter <= 0)
        {
            RB.velocity = MovementSpeed;
            DashCounter = 0.5f;
            Dashes = 1;
            CanMove = true;
        }
        Debug.Log("Can Move" + CanMove );
        
    }





    public void Move(InputAction.CallbackContext button)
    {
        if (button.performed && CanMove == true) //if the button for movement is clicked
        {
            MovementDirection = button.ReadValue<Vector2>(); //get the value in vector2
            MovementSpeed = new Vector2(MovementDirection.x, MovementDirection.y).normalized * Speed; //apply movement
            RB.velocity = MovementSpeed;
        }
        else
        {
            RB.velocity = Vector2.zero; //if no button is clicked, stop
        }

    }
    public void Shoot(InputAction.CallbackContext button)
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (button.performed )
            {
                // Instantiate the bullet
                bullet = Instantiate(BulletPF, WeaponEnd.position, BulletDirection.rotation);

                // Play Sound EffectS


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


                
                

                // Set the bullet's velocity to move in that direction with a desired speed
                float bulletSpeed = 10f; // Adjust this speed as needed
                bullet.GetComponent<Rigidbody2D>().velocity = MovementDirection * bulletSpeed;
            }
        }



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

    

   
   
    public void Dash()
    {
        if(DashCounter>0)
        {
            CoolDown = 7;
            Dashes -= 1;
            
        }

  
        
        
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



