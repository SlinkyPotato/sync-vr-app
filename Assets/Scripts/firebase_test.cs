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

	public void UpdateDB(string name, int price) {
		Data d = new Data (name, price);
		string json = JsonUtility.ToJson (d);
		dbref.Child ("item").SetRawJsonValueAsync (json);
		dbref.GetValueAsync().ContinueWith(task => {
			if (task.IsFaulted) {
				// Handle the error...
			}
			else if (task.IsCompleted) {
				DataSnapshot snapshot = task.Result;
				Debug.Log(snapshot.Child("item").Child("name").Value);
				Debug.Log(snapshot.Child("item").Child("price").Value);
			}
		});
	}
}

public class Data {

	public string name;
	public int price;

	public Data(string name, int price) {
		this.name = name;
		this.price = price;
	}

}
