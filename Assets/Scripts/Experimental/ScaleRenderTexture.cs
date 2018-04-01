using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRenderTexture : MonoBehaviour {

	private Material portalMaterial;
	public Camera portalCamera;

	// Use this for initialization
	void Start () {
		portalMaterial = gameObject.GetComponent<Renderer> ().material;
		portalCamera.targetTexture = new RenderTexture (Screen.width, Screen.height, 24);
		portalMaterial.mainTexture = portalCamera.targetTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
