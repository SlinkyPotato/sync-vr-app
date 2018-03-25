using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Threading.Tasks;
using System;

public class DBManager : MonoBehaviour {

	private DatabaseReference dbRef;
	private DatabaseReference productRef;
	private DatabaseReference cartRef;
	private DatabaseReference userRef;

	private string currentUser = "user1";

	// Use this for initialization
	void Start () {
		
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://synchrony-vr.firebaseio.com/");
		dbRef = FirebaseDatabase.DefaultInstance.RootReference;
		productRef = dbRef.Child("products");
		cartRef = dbRef.Child("carts");
		userRef = dbRef.Child("users");

		GetProductByID ("p1", ExHandler);

	}

	/*
	 * Returns products in a given category 
	 * categories: 0 -> business, 1 -> sport, 2 -> casual, 3 -> beach
	 * 
	*/
	public void GetProductsByCategory(int category, Action<DataSnapshot> handler) {

		productRef.OrderByChild("category").EqualTo(category).GetValueAsync().ContinueWith(task => {

			if (task.IsFaulted) {

				Debug.LogError ("ERROR retreiving products by category");

			} else if (task.IsCompleted) {

				DataSnapshot snap = task.Result;
				handler(snap);

			} 

		});
			
	}

	/*
	 * Returns a single product given its ID
	 * 
	*/
	public void GetProductByID(string id, Action<DataSnapshot> handler) {

		productRef.Child(id).GetValueAsync().ContinueWith(task => {

			if (task.IsFaulted) {

				Debug.LogError ("ERROR retreiving products by category");

			} else if (task.IsCompleted) {

				DataSnapshot snap = task.Result;
				handler(snap);

			} 

		});

	}

	/*
	 * Returns the Cart JSON object for the current user
	 * 
	*/
	public void GetCartByCurrentUser(Action<DataSnapshot> handler) {
		
		cartRef.OrderByChild("user_id").EqualTo(currentUser).GetValueAsync().ContinueWith(task => {

			if (task.IsFaulted) {

				Debug.LogError ("ERROR retreiving products by category");

			} else if (task.IsCompleted) {

				DataSnapshot snap = task.Result;
				handler(snap);

			} 

		});

	}

	public void ExHandler(DataSnapshot snap) {
		Debug.Log ("HANDLED");
		Debug.Log(snap.Child ("name").Value);
		Debug.Log (currentUser);
	}
		

}
