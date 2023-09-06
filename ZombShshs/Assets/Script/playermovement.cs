using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    
    Vector3 Direction;
    [SerializeField] int speed;
    Rigidbody2D rb;
    float Xaxis;
    float Yaxis;
    [SerializeField] GameObject Bullet;
    Vector2 PlayerPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        Xaxis = Input.GetAxisRaw("Horizontal");
        Yaxis = Input.GetAxisRaw("Vertical");

       Direction =  new Vector2(Xaxis, Yaxis).normalized;

      transform.position += Direction * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        PlayerPosition = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
          GameObject Bulletspawned =   Instantiate(Bullet);
          Bulletspawned.transform.position = new Vector2(PlayerPosition.x+ 0.75f, PlayerPosition.y+ 0.13f);
            
        }
    }
}
