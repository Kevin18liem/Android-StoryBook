﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_TriggerAnimation : MonoBehaviour {

	public string trigger;				// animation trigger
	public Animator anim;				// object's animator
	public float speed = 1.5f;			// animation speed

	// Use this for initialization
	void Start () {

		// initialize animator
		anim = GetComponent<Animator>();
		anim.speed = speed;

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && 
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowClutterAnim)
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