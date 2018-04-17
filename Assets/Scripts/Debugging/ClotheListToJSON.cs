using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ClotheListToJSON : MonoBehaviour {

	public string path = "Assets/Resources/clothing_id.log";

	// Use this for initialization
	void Start () {
		StreamReader reader = new StreamReader (path);
		string line = reader.ReadLine ();
		while (line != null) {
			Debug.Log (line);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
