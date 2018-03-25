using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		print("In collision enter");
		if (other.gameObject.CompareTag("MainCamera")) {
			print("In if collision");
			SceneManager.LoadScene("NYC_Block_6");
			print("scene loaded");
		}
	}
}
