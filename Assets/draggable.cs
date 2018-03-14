using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class draggable : MonoBehaviour {

	private DatabaseReference dbref;

	// Use this for initialization
	void Start () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://synchrony-vr.firebaseio.com/");
		dbref = FirebaseDatabase.DefaultInstance.RootReference;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnMouseUp() {
		Debug.Log ("Clicked");
		DataObj d = new DataObj ("Hello World");
		string json = JsonUtility.ToJson (d);
		dbref.Child ("messages").SetRawJsonValueAsync (json);
		dbref.GetValueAsync().ContinueWith(task => {
				if (task.IsFaulted) {
					// Handle the error...
				}
				else if (task.IsCompleted) {
					DataSnapshot snapshot = task.Result;
					Debug.Log(snapshot.Child("messages").Child("message").Value);
					Destroy(this.gameObject);
				}
			});
	}
}
public class DataObj {

	public string message;

	public DataObj(string message) {
		this.message = message;
	}

}
