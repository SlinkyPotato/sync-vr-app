using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		print("Collision detected");
		if (other.gameObject.tag.Equals("MainPlayer")) {
			SceneManager.LoadScene("test");
		}
	}
}
