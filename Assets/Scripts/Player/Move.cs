using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed = 5.0f;
    public SpriteRenderer sprite;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        PlayerMove();
    }


    public void PlayerMove()
    {
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveHorizontal * playerSpeed, moveVertical * playerSpeed);

        if(moveHorizontal < 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

    }

}
