using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddToCart : MonoBehaviour {

    private Cart cart;
    private UserAvatar avatar;

	// Use this for initialization
	void Start () {
        cart = GameObject.Find("GameManager").GetComponent<Cart>();
        avatar = GameObject.FindWithTag("Avatar").GetComponent<UserAvatar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPurchasableClick()
    {
        GameObject textObj = EventSystem.current.currentSelectedGameObject;
        Text itemText = textObj.GetComponent<Text>();
        if(itemText.text.Equals("Remove From Cart"))
        {
            
            Purchasable item = itemText.GetComponent<Purchasable>();
            cart.remove(item);
            GameObject limb = item.itemType == Purchasable.ItemType.top ? avatar.top : avatar.bottom;
            SkinnedMeshRenderer avatarRenderer = limb.GetComponent<SkinnedMeshRenderer>();
            avatarRenderer.material = null;
            itemText.text = "Add To Cart";
        } else
        {

            Purchasable item = itemText.GetComponent<Purchasable>();
            cart.removeSimilarItems(item.itemType);
            cart.add(item);
            GameObject limb = item.itemType == Purchasable.ItemType.top ? avatar.top : avatar.bottom;
            SkinnedMeshRenderer avatarRenderer = limb.GetComponent<SkinnedMeshRenderer>();
            avatarRenderer.material = Resources.Load("Materials/" + item.materialName) as Material;
            resetItemText(item.itemType);
            itemText.text = "Remove From Cart";
        }
        
    }

    private void resetItemText(Purchasable.ItemType type)
    {
        GameObject[] labels = GameObject.FindGameObjectsWithTag("AddToCartLabel");
        foreach(GameObject g in labels) {
            if(type == g.GetComponent<Purchasable>().itemType) //reset text of items in same category as one being added to cart
            {
                Text t = g.GetComponent<Text>();
                t.text = "Add To Cart";
            }
        }
    }
}
