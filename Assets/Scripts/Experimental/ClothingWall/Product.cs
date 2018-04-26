using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour {

	public enum ItemType {Top, Bottom, Shoes};
	public enum ItemCategory {Business, Casual, Sport};
	public string name = "";
	public double price;
	public ItemType type;
	public string brand;
	public ItemCategory category;
	public string materialName;
	public string gender;
	public bool isInCart;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setNameFromID(string id) {
		string[] s = id.Split (new string[] { "[" }, System.StringSplitOptions.None);
		s = s [1].Split (new string[] { "]" }, System.StringSplitOptions.None);
		string[] splitName = s[0].Split (new string[] { "_" }, System.StringSplitOptions.None);
		name = char.ToUpper (splitName [0][0]) + splitName[0].Substring (1);
		for (int i = 1; i < splitName.Length; i++) {
			name = name + " " + char.ToUpper (splitName [i][0]) + splitName [i].Substring (1);
		}
	}

	public void setCategory(int cat) {
		switch (cat) {
		case 0:
			category = ItemCategory.Business;
			break;
		case 1:
			category = ItemCategory.Casual;
			break;
		case 2:
			category = ItemCategory.Sport;
			break;
		}
	}

	public void setType(int t) {
		switch (t) {
		case 0:
			type = ItemType.Top;
			break;
		case 1:
			type = ItemType.Bottom;
			break;
		case 2:
			type = ItemType.Shoes;
			break;
		}
	}

	public void setMaterialFromID(string id) {
		materialName = id;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	public void setGender(string g) {
		gender = g;
	}

	public void setCartStatus(bool status) {
		isInCart = status;
	}
}
