using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float Speed;
    public  float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Horizontal=Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position,Vector3.down * 0.8f,Color.red);
        if (Physics2D.Raycast(transform.position,Vector3.down,0.8f))
        {
            Grounded = true;
        }
        else Grounded = false;
        if (Input.GetKeyDown(KeyCode.Space)&&Grounded)
        {
            Jump();
        }
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed,Rigidbody2D.velocity.y);
    }
}
