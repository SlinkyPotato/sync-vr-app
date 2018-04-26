using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingWallUI : MonoBehaviour {

	public Text name;
	public Text quantity;
	public Text price;
	public Image cartIcon;
	public GameObject clothingMesh;
	private CartManager cartManager;
	private Product product;
	private ClothingWall clothingWall;
	// Use this for initialization
	void Awake () {
		cartManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<CartManager> ();
		clothingWall = GameObject.FindGameObjectWithTag ("ClothingWall").GetComponent<ClothingWall> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateUIElements(Product p) {
		product = p;
		name.text = p.name;
		price.text = "$" + p.price;
		GameObject newMesh = Instantiate (clothingWall.GameObjectForActiveProduct (p.materialName), clothingMesh.transform.position, clothingMesh.transform.rotation) as GameObject;
		newMesh.transform.SetParent (transform);
		Destroy (clothingMesh);
		clothingMesh = newMesh;
		try {
			if (cartManager.IsInCart (p)) {
				cartIcon.sprite = Resources.Load<Sprite>("UI/icons/remove_from_cart");
				quantity.text = "" + cartManager.GetQuantity (p);
			} else {
				cartIcon.sprite = Resources.Load<Sprite>("UI/icons/add_to_cart");
				quantity.text = "1";
			}
		} catch(System.Exception e) {
			Debug.LogError (e.StackTrace);
		}
	}

	public void OnIncreaseQuantity() {
		quantity.text = "" + (int.Parse (quantity.text) + 1);
	}

	public void OnDecreaseQuantity() {
		if(int.Parse (quantity.text) > 1)
			quantity.text = "" + (int.Parse (quantity.text) - 1);
	}

	public void OnCartButtonClick() {
		if (cartManager.IsInCart (product)) {
			cartManager.RemoveItem (product);
            cartIcon.sprite = Resources.Load<Sprite>("UI/icons/add_to_cart");
        } else {
			cartManager.AddItem(product, int.Parse(quantity.text));
            cartIcon.sprite = Resources.Load<Sprite>("UI/icons/remove_from_cart");
        }
		
	}

}
