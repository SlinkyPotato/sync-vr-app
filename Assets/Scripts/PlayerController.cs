using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text scoreText;
    
    private Rigidbody rb;
    private int score;

    // Initialization code goes here
    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
    }

    // Called before any physiscs calculations is called
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        
        rb.AddForce(movement * speed);
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            score++;
            setScoreText();
        }
    }

    void setScoreText() {
        scoreText.text = "Score: " + score.ToString();        
    }
}
