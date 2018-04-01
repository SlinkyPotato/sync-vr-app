using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform portalSource;
	public Transform portalDest;
	private Transform mainCamera;

	// Use this for initialization
	void Start () {

		mainCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 offset = mainCamera.position - portalSource.position;
		transform.position = portalDest.position + (offset);

		transform.rotation = portalDest.rotation * mainCamera.rotation;
		float angleY = Mathf.Clamp (transform.eulerAngles.y, 80, 100);
		Quaternion clampedRotation = Quaternion.Euler (transform.eulerAngles.x, angleY,
			transform.eulerAngles.z);
		transform.rotation = clampedRotation;
	}
}
