using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Console.Write("Hello world!");
	}

    // Called before any physiscs calculations is called
    private void FixedUpdate() {
	    Console.Write("Hello world!");
    }
}
