using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;
    private Rigidbody2D rigd;
    public Animator anim;
    public bool isground;
    // Start is called before the first frame update
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.velocity = new Vector2 (teclas * speed,rigd.velocity.y);
        
        if (teclas > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transitions", 1);
        }
        if (teclas < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transitions", 1);
        }
        if (teclas == 0)
        {
            anim.SetInteger("transitions", 0);
        }

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transitions", 3);
            isground = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.layer == 6)
        {
            isground = true;
        } 
    }
}
