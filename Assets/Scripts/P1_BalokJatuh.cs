using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_BalokJatuh : MonoBehaviour {
	
	private Animator anim;		// balok's animator

	// Use this for initialization
	void Start () {

		// initialize animator
		anim = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				Debug.Log("Tap detected");
				if (raycastHit.collider.name == gameObject.name)
				{
					Debug.Log(gameObject.name + " clicked");
					anim.SetTrigger("jatuh");
				}

			}
		}

	}
}
