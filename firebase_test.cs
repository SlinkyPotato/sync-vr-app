using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class firebase_test : MonoBehaviour {

	private DatabaseReference dbref;

	// Use this for initialization
	void Start () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://synchrony-vr.firebaseio.com/");
		dbref = FirebaseDatabase.DefaultInstance.RootReference;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Data d = new Data ("Hello World");
			string json = JsonUtility.ToJson (d);
			dbref.Child ("messages").SetRawJsonValueAsync (json);
		}
	}
}

public class Data {

	public string message;

	public Data(string message) {
		this.message = message;
	}

}
