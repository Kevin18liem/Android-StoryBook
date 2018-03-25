using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_TriggerAnimation : MonoBehaviour {

	public string trigger;				// animation trigger
	public Animator anim;				// object's animator
	public bool trigger_allowed = true;	// true if trigger allowed

	// Use this for initialization
	void Start () {

		// initialize animator
		anim = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && trigger_allowed)
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					anim.SetTrigger(trigger);
				}

			}
		}

	}
}
