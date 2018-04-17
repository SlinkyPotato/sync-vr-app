using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class CartManager : MonoBehaviour {

	private DBManager dbManager;
	private List<CartItem> cartItems;
	private bool isInitialized = false;

	// Use this for initialization
	void Start () {
		dbManager = GetComponent<DBManager> ();
		dbManager.GetCartByCurrentUser (OnCartLoad);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem(Product product, int quantity) {
		int index = cartItems.FindIndex (i => i.id == product.materialName);
		if (index < 0) {
			cartItems.Add (new CartItem (product.materialName, quantity));
			dbManager.UpdateCartForUser (cartItems);
		}
	}
		
	public void RemoveItem(Product product) {
		int index = cartItems.FindIndex (i => i.id == product.materialName);
		if (index > 0) {
			cartItems.RemoveAt (index);
			dbManager.UpdateCartForUser (cartItems);
		}
	}

	public void OnCartLoad(DataSnapshot d) {
		cartItems = new List<CartItem> ();
		foreach (DataSnapshot item in d.Child("product_list").Children) {
			string id = item.Child ("product_id").Value.ToString();
			int quantity = int.Parse (item.Child ("quantity").Value.ToString());
			CartItem cartItem = new CartItem (id, quantity);
			cartItems.Add (cartItem);
		}
		isInitialized = true;
	}

	public bool IsInCart(Product p) {
		foreach (CartItem item in cartItems) {
			if (p.materialName.Equals (item.id)) {
				return true;
			}
		}
		return false;
	}

	public int GetQuantity(Product p) {
		foreach (CartItem item in cartItems) {
			if (p.materialName.Equals (item.id)) {
				return item.quantity;
			}
		}
		return -1;
	}

	public bool IsInitialized() {
		return isInitialized;
	}
}
