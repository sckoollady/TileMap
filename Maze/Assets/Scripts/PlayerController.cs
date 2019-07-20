using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public GameObject Player;
    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;
    private Rigidbody2D rb2d;
    private int score;
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
      musicSource.clip = musicClipOne;
      musicSource.Play();  
      rb2d = GetComponent<Rigidbody2D>(); 
      score = 0; 
      lives = 3;
      winText.text = "";
      SetScoreText();
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
            SetScoreText();
            
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString ();
        if(score == 4)
        {
            transform.position = new Vector3(-10.77f, -13.97f,0f);
            lives = 3;
        }

        livesText.text = "Lives: " + lives.ToString ();
        if(lives == 0)
        {
            livesText.text = "You Lose...";
            Destroy(Player);
        }

        if(score >= 8)
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            winText.text = "You Win!";
        }
    }
}
