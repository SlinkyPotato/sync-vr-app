using UnityEngine;
using System.Collections;

public class grab : MonoBehaviour {
	public Transform player;
	public float throwForce = 10;
	bool beingCarried = false;
	bool beingClicked = false;

	void Update()
	{
		if(beingCarried)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log ("mouse down");
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(player.forward * throwForce);
			}
		}
		else
		{
			if(beingClicked)
			{
				GetComponent<Rigidbody>().GetComponent<Rigidbody>().isKinematic = true;
				transform.parent = player;
				beingCarried = true;
			}
		}
	}

	void OnMouseDown() {
		if (beingCarried) {
			beingClicked = false;
		} else {
			beingClicked = true;
		}

	}
}