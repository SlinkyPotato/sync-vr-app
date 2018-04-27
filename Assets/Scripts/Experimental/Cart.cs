using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cart : MonoBehaviour {

    public List<Purchasable> cartItems = new List<Purchasable>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void add(Purchasable item)
    {
        cartItems.Add(item);
    }

    public void remove(Purchasable item)
    {
        cartItems.Remove(item);
    }

    public void removeSimilarItems(Purchasable.ItemType type)
    {
        cartItems.RemoveAll(x => x.itemType == type);
    }
}
