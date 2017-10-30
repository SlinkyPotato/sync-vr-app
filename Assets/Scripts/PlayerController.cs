using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    
    private Rigidbody rb;

    // Initialization code goes here
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Called before any physiscs calculations is called
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        
        rb.AddForce(movement * speed);
    }
}