using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class ClothingWall : MonoBehaviour {

	private DBManager dbManager;
	private CartManager cartManager;
	private Dictionary<string, GameObject> products;
	private List<GameObject> activeProducts;
	public GameObject display1;
	public GameObject display2;
	public GameObject display3;

	private Product.ItemCategory category = Product.ItemCategory.Business;
	private Product.ItemType type = Product.ItemType.Top;
	private string gender = "male";

	//we need the cartmanager to be setup before we do anything
	private bool didSetup = false;

    private void Awake() {
        activeProducts = new List<GameObject>();
    }

    // Use this for initialization
    void Start () {
		dbManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<DBManager>();
		cartManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<CartManager>();
	}
	
	// Update is called once per frame
	void Update () {

		//don't load and display products until we have the user's cart loaded
		if (cartManager.IsInitialized () && !didSetup) {
			dbManager.GetAllProducts (OnProductsLoad);
			didSetup = true;
		}
	}

	public void OnProductsLoad(DataSnapshot data) {
		FilterAndConvert(data);
        SetActiveProducts();
		UpdateDisplays ();
	}

    public void ChangeItemCategory(Product.ItemCategory cat) {
        category = cat;
        SetActiveProducts();
        UpdateDisplays();
    }

    public void ChangeItemType(Product.ItemType t) {
        type = t;
        SetActiveProducts();
        UpdateDisplays();
    }

	public void ShowCart(int left, int right) {
		activeProducts = new List<GameObject> ();
		for (int i = left; i <= right; i++) {
			activeProducts.Add(products [cartManager.GetIDAtIndex (i)]);
		}
		UpdateDisplays ();
    }

    void SetActiveProducts() {
        activeProducts = new List<GameObject>();
		foreach (GameObject p in products.Values)
        {
            if (MeetsFilterCriteria(p.GetComponent<Product>()))
            {
                activeProducts.Add(p);
            }
        }
    }

	void UpdateDisplays() {
		display1.GetComponent<ClothingWallUI>().UpdateUIElements (activeProducts [0].GetComponent<Product>());
		display2.GetComponent<ClothingWallUI>().UpdateUIElements (activeProducts [1].GetComponent<Product>());
		display3.GetComponent<ClothingWallUI>().UpdateUIElements (activeProducts [2].GetComponent<Product>());
	}

	//use the snapshot data to create Products and store them in a list
	void FilterAndConvert(DataSnapshot data) {
		products = new Dictionary<string, GameObject> ();
		foreach (DataSnapshot d in data.Children) {
			string id = dbManager.FirebasePIDToUnity (d.Key);
			string path = "Prefabs/Clothes/" + id;
			GameObject item = Resources.Load (path) as GameObject;
			item.AddComponent<Product> ();
			Product p = item.GetComponent<Product> ();
			p.setNameFromID (id);
			p.setMaterialFromID (id);
			p.setCategory (int.Parse(d.Child ("category").Value.ToString()));
			p.setType (int.Parse (d.Child ("type").Value.ToString ()));
			p.setPrice(double.Parse (d.Child ("price").Value.ToString ()));
			p.setGender (GetGenderFromID (d.Key));
			products.Add (id, item);

		}
	}

	private string GetGenderFromID(string id) {
		string[] split = id.Split (new string[] { "_" }, System.StringSplitOptions.None);
		return split [0].Replace(" ", "");
	}

	private bool MeetsFilterCriteria(Product p) {
		return (p.category == category && p.type == type && p.gender == gender);
	}

	public GameObject GameObjectForActiveProduct(string id) {
		foreach (GameObject prod in activeProducts) {
			if (prod.GetComponent<Product> ().materialName.Equals (id))
				return prod;
		}
		return null;
	}

}
