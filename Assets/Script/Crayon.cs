using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crayon : MonoBehaviour {
	private GameObject kodeWarna;
	public string warna;
	// Use this for initialization
	void Start () {
		kodeWarna = GameObject.FindGameObjectWithTag ("swapmanager");
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					kodeWarna.GetComponent<SwipeTrail>() .KodeWarna = warna;
				}
			}
		} else if (Input.GetMouseButtonDown(0))
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					kodeWarna.GetComponent<SwipeTrail>() .KodeWarna = warna;
				}
			}
		}
	}
}
