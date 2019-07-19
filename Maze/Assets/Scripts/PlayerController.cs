using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Text scoreText;
    private Rigidbody2D rb2d;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>(); 
      score = 0; 
      
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey("escape"))
      {
         Application.Quit(); 
      }
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);    
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);   
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            
        }
    }
}
