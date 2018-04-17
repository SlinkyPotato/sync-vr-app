using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CartItem {
	
	public string id;
	public int quantity;

	public CartItem(string id, int quantity) {
		this.id = id;
		this.quantity = quantity;
	}

}
