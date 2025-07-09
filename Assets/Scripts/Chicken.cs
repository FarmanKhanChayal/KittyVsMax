using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{


    public bool follow = false;

    private GameObject player;
   
    void Start()
    {
        player = Kitty.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (!follow)
        {
            return;
        } else if (!player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.position = Vector2.MoveTowards
            (
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z),
                6f * Time.deltaTime
            );
           
        }
        else
        {
            transform.position = Vector2.MoveTowards
           (
              new Vector3(transform.position.x, transform.position.y, transform.position.z),
              new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z),
              6f * Time.deltaTime

           );
        }





    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            
           if ( player.transform.childCount == 0)
           {
                follow = true;
                transform.SetParent(player.transform);
           }
            

        }

        if(collision.tag == "Enemy")
        {
            follow = false;
            transform.parent = null;
        }
    }


}
