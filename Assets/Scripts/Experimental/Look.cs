using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

	private float rx = 0f;
	private float ry = 0f;

	public float sensitivity = 2f;

	// Use this for initialization
	void Start () {
		rx = transform.eulerAngles.x;
		ry = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		ry += sensitivity * Input.GetAxis ("Mouse X");
		rx += sensitivity * Input.GetAxis ("Mouse Y");
		rx = Mathf.Clamp (rx, -35, 50);
		transform.eulerAngles = new Vector3 (rx, ry, 0f);
	}
}
