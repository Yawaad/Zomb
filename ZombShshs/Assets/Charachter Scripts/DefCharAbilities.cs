using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefCharAbilities : MonoBehaviour

{
    [SerializeField] Button HealAbility;
    [SerializeField] float CoolDown;
    PlayerHealth Player;
    void Start()
    {
        
            Player = GetComponent<PlayerHealth>();
  
    }

    // Update is called once per frame
    

    public void Heal()
    {
        if (CoolDown == 0 && Player.CurrentHealth != Player.MaxHealth)
        {
            HealAbility.enabled = true;
            Player.CurrentHealth += Player.MaxHealth * 0.25f;
            
            CoolDown = 5;
        }

        else if (CoolDown != 0)
        {
            HealAbility.enabled = false;
            CoolDown--;
            

        }

        if(Player.CurrentHealth > Player.MaxHealth)
        {
            Player.CurrentHealth = Player.MaxHealth;
        }
        Debug.Log(Player.CurrentHealth);
    }

}
