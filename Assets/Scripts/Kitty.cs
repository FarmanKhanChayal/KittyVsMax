using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Kitty : MonoBehaviour
{
    //public GameObject Max;

    public static Kitty Instance;
    public float speed = 3.0f;
   
    public bool  grounded = true;
    public float jumpForce;
    public GameObject Particles;


    private Animator animation;
    private float translation;
    private Rigidbody2D rb;
    private bool isDead = false;
    public  float xPos
    {
        get
        {
            return transform.position.x;
        }
    }

    public float yPos
    {
        get
        {
            return transform.position.y;
        }
    }


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
         animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
           
        }
    }

    private void FixedUpdate()
    {

       // grounded = IsGrounded();
         PlayerTurn();

        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            translation = Input.GetAxisRaw("Horizontal");
        }

        if (isDead)
        {
            //Max.GetComponent<Max>().speed = 0;
            //Max.GetComponent<Max>().jumpForce = 0;

            Max.Instace.speed = 0;
            Max.Instace.jumpForce = 0;
        }

        


         //

        //transform.Translate(new Vector3(translation, 0,0)*Time.deltaTime*speed);
        rb.velocity = new Vector2(translation*Time.deltaTime*speed,rb.velocity.y);

        animation.SetFloat("speed", translation == 0 ? 0 : 1);
    }

    public bool movingRight
    {
        get
        {
            if(translation == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void PlayerTurn()
    {
        if( translation < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if( translation > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

   

    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

       
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
           GameObject p =  Instantiate(Particles,collision.transform.position,collision.transform.rotation);
            Destroy(p,0.5f);
            Destroy(collision.gameObject);
            UIManager.Instance.IncreaseScore();
        }

        if (collision.tag == "Home")
        {
            if(transform.childCount > 0)
            {
                GameObject Chicken = transform.GetChild(0).gameObject;
                Chicken.GetComponent<Chicken>().follow = false;
                Chicken.transform.parent = null;
                Chicken.GetComponent<CircleCollider2D>().enabled = false;
                Chicken.GetComponent<ChickenRun>().enabled = true;

                StartCoroutine(ChickenDestroy(Chicken));
            }
        }
    }

    IEnumerator ChickenDestroy(GameObject Chicken)
    {
        yield return new WaitForSeconds(1);

        Chicken.SetActive(false);
        

        int ChickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
        
        if (ChickenCount == 0)
        {
            UIManager.Instance.OnLevelComplte("Level Complete");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Tile")
        {
            grounded = true;

           
        }

        if(collision.transform.tag == "Enemy")
        {
            if (isDead)
            {
                return ;
            }
            animation.SetTrigger("Death");
            UIManager.Instance.OnLevelComplte("Level Failed");
            isDead = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Tile")
        {
            grounded = false;
            
        }
    }

    public void OnRightPinterEnter()
    {
        translation = 1;
    }

    public void OnPointerExit()
    {
        translation = 0;
    }

    public void OnLeftPointerEnter()
    {
        translation = -1;
    }

    public void OnJumpPointerDown()
    {
        Jump();
    }

    
}
