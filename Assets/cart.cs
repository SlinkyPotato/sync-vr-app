using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "purchasable") {
			//Purchasables p = other.gameObject.GetComponent<Purchasables> ();
			//firebase_test fb = GameObject.Find ("AppManager").GetComponent<firebase_test> ();
			//fb.UpdateDB (p.name, p.price);
		}
	}
}
