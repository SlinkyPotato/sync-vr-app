using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class openable_door : MonoBehaviour {
	private double smooth = 2.0;
	private double doorAngle = 90;
	private bool isOpen = false;
	private bool enter = false;
	private Vector3 defaultRotation;
	private Vector3 openRotation;

	// Use this for initialization
	void Start () {
		defaultRotation = transform.eulerAngles;
		openRotation = new Vector3(defaultRotation.x, (float) (defaultRotation.y + doorAngle), defaultRotation.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen) {
			// Open door
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRotation, (float) (Time.deltaTime * smooth));
		}
		else {
			// Close door
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRotation, (float) (Time.deltaTime * smooth));
		}

		// Activate the door
		if (Input.GetKeyDown(KeyCode.F)) {
			print("F key pressed!");
			isOpen = !isOpen;
		}
	}

	private void OnGUI() {
		if (enter) {
			GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
		}
	}
	
	// Activate the Main function when player is near the door
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			enter = true;
		}
	}
	
	// Deactivate the Main funcdtion when player is go away from door
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			enter = false;
		}
	}
}
