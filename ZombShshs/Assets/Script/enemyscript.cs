using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    [SerializeField] Transform PlayerPosition;
    Vector2 Direction;
    [SerializeField] float Speed;
    Rigidbody2D rb;
    public GameObject Target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPosition != null)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
            Direction = (Target.transform.position - transform.position).normalized;
            rb.velocity = Direction * Speed;

        }

        else
        {
            rb.velocity = Vector2.zero;
            Debug.Log("player not found");
        }
        
    }
}
