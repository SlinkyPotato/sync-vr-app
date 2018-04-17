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

	public string currentUser = "user1";

	// Use this for initialization
	void Awake () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://synchrony-vr.firebaseio.com/");
		dbRef = FirebaseDatabase.DefaultInstance.RootReference;
		productRef = dbRef.Child("products");
		cartRef = dbRef.Child("carts");
		userRef = dbRef.Child("users");
	}

	/*
	 * Returns products in a given category 
	 * categories: 0 -> business, 1 -> casual, 2 -> sport
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

	public void GetAllProducts(Action<DataSnapshot> handler) {
		productRef.GetValueAsync().ContinueWith(task => {
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
		id = UnityPIDToFirebase (id);
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
		cartRef.Child(currentUser + "_cart").GetValueAsync().ContinueWith(task => {
			if (task.IsFaulted) {
				Debug.LogError ("ERROR retreiving cart for " + currentUser);
			} else if (task.IsCompleted) {
				DataSnapshot snap = task.Result;
				handler(snap);
			} 
		});
	}

	public void UpdateCartForUser(List<CartItem> productList) {
		string json = JsonUtility.ToJson (productList);
		Debug.Log (json);
		cartRef.Child("carts").Child(currentUser + "_cart").Child("product_list").SetRawJsonValueAsync(json);
	}


	public void ExHandler(DataSnapshot snap) {
		Debug.Log ("HANDLED");
		Debug.Log(snap.ToString());
	}
		
	public string UnityPIDToFirebase(string id) {
		string newId = id.Replace ("[", "!");
		return newId.Replace ("]", "@");
	}
	public string FirebasePIDToUnity(string id) {
		string newId = id.Replace ("!", "[");
		return newId.Replace ("@", "]");
	}
}
