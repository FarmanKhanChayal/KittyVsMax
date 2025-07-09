using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max : MonoBehaviour
{

    public static Max Instace;

    public float speed = 3.0f;
    
    public bool grounded = true;
    public float jumpForce;


    private Animator animation;
    private float translation;
    private Rigidbody2D rb;
    private Kitty kitty;
    private bool allowJump;





    void Start()
    {
        Instace = this;


        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        kitty = Kitty.Instance;
        translation = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
       //if (speed == 0)
       // {
       //     animation.SetTrigger("Stop");
       // }
    }

    private void FixedUpdate()
    {
        AI();
        //grounded = IsGrounded();
        PlayerTurn();
        






       

        //transform.Translate(new Vector3(translation, 0,0)*Time.deltaTime*speed);
        rb.velocity = new Vector2(translation * Time.deltaTime * speed, rb.velocity.y);

        animation.SetFloat("speed", translation == 0 ? 0 : 1);

       
    }

    private void PlayerTurn()
    {
        if (translation < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (translation > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

   

    void Jump()
    {
        //if (!grounded)
        //{
        //    return;
        //}

        Vector3 vel = rb.velocity;
        vel.y = 0;
        rb.velocity = vel;

        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Jump")
        {
            allowJump = true;
            LeftRightSwitch();
        }

        //if (collision.tag == "Tile")
        //{
        //    grounded = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Jump")
        {
            allowJump = false;
        }

        //if (collision.tag == "Tile")
        //{
        //    grounded = false;
        //}
    }

    public void SwitchDirection()
    {
        translation = translation == 1 ? -1 : 1;
    }

    void LeftRightSwitch()
    {
        if (kitty.xPos - 0.5 > transform.position.x)
        {
            translation = 1;
        }
        else if (kitty.xPos + 0.5 < transform.position.x)
        {
            translation = -1;
        }
    }

    void AI()
    {

       
        //translation = kitty.xPos - 0.5 > transform.position.x ? 1 : -1;

        if (kitty.yPos > transform.position.y && allowJump)
        {
            Jump();
        }
    }




}
