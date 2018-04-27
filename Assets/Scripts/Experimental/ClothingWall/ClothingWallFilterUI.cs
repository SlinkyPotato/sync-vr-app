using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingWallFilterUI : MonoBehaviour {

    private ClothingWall clothingWall;
	private CartManager cartManager;
	//indices for scrolling through cart items 
	private int left = 0;
	private int right = 2;

	// Use this for initialization
	void Start () {
        clothingWall = GetComponent<ClothingWall>();
		cartManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<CartManager> ();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnBusinessSelect() {
        clothingWall.ChangeItemCategory(Product.ItemCategory.Business);
    }

    void OnCasualSelect() {
        clothingWall.ChangeItemCategory(Product.ItemCategory.Casual);
    }

    void OnSportSelect() {
        clothingWall.ChangeItemCategory(Product.ItemCategory.Sport);
    }

    void OnCartSelect() {
		left = 0;
		right = 2;
		clothingWall.ShowCart(left, right);
    }

	void OnScrollDown() {
		left += 3;
		right += 3;
		int cartCount = 8;
		right = Mathf.Clamp (right, 2, cartCount - 1);
		left = Mathf.Clamp (left, 0, cartCount - 2);
		left = (right == 7 && right - left < 2) ? 5 : left;
		Debug.Log ("left: " + left + " right: " + right);
		clothingWall.ShowCart (left, right);
	}

	void OnScrollUp() {
		if (right - left < 2) {
			int dif = 2 - (right - left);
			right += dif;
		}
		left -= 3;
		right -= 3;
		int cartCount = 8;
		Debug.Log (right);
		right = Mathf.Clamp (right, 2, cartCount - 1);
		left = Mathf.Clamp (left, 0, cartCount - 2);
		Debug.Log ("left: " + left + " right: " + right);
		clothingWall.ShowCart (left, right);
	}
}
