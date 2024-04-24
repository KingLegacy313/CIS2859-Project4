using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    SpriteRenderer sprite;
    PlayerMove playerMove;

    bool right;

    void Start()
    {

        var player = GameObject.FindWithTag("Player");
        playerMove = player.GetComponent<PlayerMove>();


        if (playerMove.isRight)
        { 
            right = true; 
        }  
        else 
        { 
            right = false; 
        }//end if/else

        Destroy(gameObject, .9f);
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
                transform.position += transform.right * Time.deltaTime * speed;
                sprite.flipX = false;    
        }
        
        else
        {
                transform.position += -transform.right * Time.deltaTime * speed;
                sprite.flipX = true;  
        }

    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        Destroy(this.gameObject);
    }
    
}
