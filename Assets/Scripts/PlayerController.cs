using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float speed ;
    
    public Slider SpeedSlider;
    public Text scoreText;
    public Text endText;
    public Text gameOverText;
    
    public String HorizontalInput;
    public String VerticallInput;
    public String SpeedUp;
    
    public Rigidbody VehiclRigidbody;
    
    private bool hasWon = false;
    private int point = 0;
    private bool gameOver =false;
    private bool onGround = false ;

    float horizontalInput;
    float forwardInput;

    private void Start()
    {
        SpeedSlider.fillRect.gameObject.SetActive(true);
        SpeedSlider.value = speed;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis(HorizontalInput);
        forwardInput = Input.GetAxis(VerticallInput);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (transform.position.z > 550 && !hasWon)
        {
            endText.text = "THE END";
            hasWon = true;
        }
       /* if (!onGround)
        {
            gameOver = true;
        }

        if (gameOver)
            gameOverText.text = "Game Over";*/
        
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(2);
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
        
        Speed();
        
    }

    public void Speed()
    {
        if (Input.GetButtonDown(SpeedUp))
        { 
            speed += 5;
            turnSpeed += 5;
            SpeedSlider.value = speed;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
            Destroy(other.gameObject);
            point++; 
            scoreText.text = "Score: " + point;
        
        
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            onGround = true;
        }
    }*/
}
    

