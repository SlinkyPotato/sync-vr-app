using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text scoreText;
    public Text winText;
    
    private Rigidbody rb;
    private int score;

    private DatabaseReference dbRef;
    private GameModel gm;

    // Initialization code goes here
    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
        winText.text = "";
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://synchrony-vr.firebaseio.com");
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        gm = new GameModel();
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
        if (score >= 12) {
            winText.text = "Congratulations!";
            gm.score = 12;
            gm.didWin = true;
            string gJson = JsonUtility.ToJson(gm);
            dbRef.Child("stats").SetRawJsonValueAsync(gJson);
        }
    }
}
