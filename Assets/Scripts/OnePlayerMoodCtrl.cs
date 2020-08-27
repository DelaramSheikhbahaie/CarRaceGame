using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OnePlayerMoodCtrl : MonoBehaviour
{
    public float turnSpeed;
    public float speed ;
    
    public Slider SpeedSlider;
    public Text livesText;
    public Text levelUpText; 
    public Text gameOverText;
    public Text restartText;
    public ParticleSystem explosionParticle;
    public AudioSource crashSound;
    public String SpeedUp;
    
    public Rigidbody VehiclRigidbody;
    
    private bool hasWon = false;
    private bool gameOver=false;
    private int point = 0;
    private int lives = 3;
    

    float horizontalInput;
    float forwardInput;

    private void Start()
    {
        SpeedSlider.fillRect.gameObject.SetActive(true);
        SpeedSlider.value = speed;
    }

    void Update()
    {
        
        livesText.text = "Lives: " + lives;
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (!gameOver)
        {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            
                    transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }


        if (lives <= 0)
        {
            gameOver = true;
            gameOverText.text = "Game Over";
            restartText.text = "Press R for Restart";
        }
            
        
        if (transform.position.z > 650 && !hasWon)
        {
            levelUpText.text = "THE END";
            hasWon = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(0);
        
        Speed();
        
    }

    public void Speed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            speed += 5;
            turnSpeed += 5;
            SpeedSlider.value = speed;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        { 
            Destroy(other.gameObject);
            lives--;
            explosionParticle.Play();
            crashSound.Play();
        }
        else if(other.CompareTag("Live"))
        {
            Destroy(other.gameObject);
                    lives++;
                    
        }
       
        
    }
    
}