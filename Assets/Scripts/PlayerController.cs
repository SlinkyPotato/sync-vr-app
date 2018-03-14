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
    public Text gameTimeText;
    
    private Rigidbody rb;
    private int score;

    private DatabaseReference dbRef;
    private GameModel gm;
    private DateTime startTime;
    private DateTime endTime;

    // Initialization code goes here
    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
        winText.text = "";
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://synchrony-vr.firebaseio.com");
        dbRef = FirebaseDatabase.DefaultInstance.GetReference("stats");
        dbRef.ValueChanged += HandleScoreChange;
        gm = new GameModel();
        startTime = DateTime.Now;
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
        } else if (other.gameObject.CompareTag("StorefrontDoor")) {
            other.gameObject.SetActive(false);
        }
    }

    void setScoreText() {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12) {
            endTime = DateTime.Now;
            winText.text = "Congratulations!";
            gm.score = 12;
            gm.didWin = true;
            gm.gameTimeSecs = endTime.Subtract(startTime).Seconds;
            string gJson = JsonUtility.ToJson(gm);
            dbRef.SetRawJsonValueAsync(gJson);
        }
    }

    void HandleScoreChange(object sender, ValueChangedEventArgs args) {
        if (args.DatabaseError != null) {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        gameTimeText.text = "Game Time: " + args.Snapshot.Child("gameTimeSecs").Value.ToString() + " seconds";
    }
}
