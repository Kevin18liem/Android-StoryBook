﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_Draggable : MonoBehaviour {

	public float dDist = 0.1f;			// distance minimum for object to be moved
	public float moveSpeed = 10;		// movement speed
	public Transform target;			// target location
	public Transform target2;			// target location
	public float treshold = 0.8f;		// distance minimum for object to be snapped
	public float anim_speed = 4;		// animation speed
	public bool moveable = false;		// true if mvoeable
	public GameObject succ;				// succesor

	private bool isdragging;			// true if dragging
	private float dist;					// distance from camera to collider
	private Vector3 offset;				// projection of touch
	private Transform toDrag;			// hit location
	private Vector3 temp;				// used to save temporary v3
	private Vector3 initPos;			// initial position
	private bool moving;				// true if still on automated moving
	private bool snap;					// true if object near target
	private bool snap2;					// true if object near target
	private Animator anim;				// object's animator
	private bool moved;					// true if reached target
	private P4_SequenceManager 
		sequenceManager;				// sequence manager

	// Use this for initialization
	void Start () {

		// initialize
		isdragging = false;
		initPos = transform.position;
		moving = false;
		anim = GetComponent<Animator> ();
		anim.speed = anim_speed;
		sequenceManager = GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ();

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && !moving && moveable && 				
			sequenceManager.allowClutterAnim
		) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					anim.SetTrigger ("boop");

					dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;

					isdragging = true;
				}

			}
		} else if (Input.GetMouseButtonDown(0) && !moving && moveable && 				
			sequenceManager.allowClutterAnim
		) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					anim.SetTrigger ("boop");

					dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;

					isdragging = true;
				}

			}
		}


		if (isdragging) {
			temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
				dist);
			temp = Camera.main.ScreenToWorldPoint (temp);

			transform.position = temp + offset;
		}

		if (isdragging && Input.touchCount == 1 && (Input.GetTouch (0).phase == TouchPhase.Ended ||
			Input.GetTouch (0).phase == TouchPhase.Canceled)) {

			anim.SetTrigger ("boop");
			isdragging = false;

			if (Vector3.Distance (transform.position, target.position) <= treshold) {
				snap = true;
			} else {
				snap = false;
			}

			if (Vector3.Distance (transform.position, target2.position) <= treshold) {
				snap2 = true;
				snap = false;
			} else {
				snap2 = false;
			}

			moving = true;
		} else if (isdragging && Input.GetMouseButtonUp(0)) {

			anim.SetTrigger ("boop");
			isdragging = false;

			if (Vector3.Distance (transform.position, target.position) <= treshold) {
				snap = true;
			} else {
				snap = false;
			}

			if (Vector3.Distance (transform.position, target2.position) <= treshold) {
				snap2 = true;
				snap = false;
			} else {
				snap2 = false;
			}

			moving = true;
		}


		if (moving) {
			if (snap) {
				if (Vector3.Distance (transform.position, target.position) >= dDist) {
					transform.position = Vector3.Lerp (transform.position, target.position, moveSpeed *
						Time.deltaTime);
				} else {
					GetComponent<AudioSource> ().Play ();
					transform.position = target.position;
					moving = false;
					moveable = false;
					// events
					if (succ) {

						succ.GetComponent<P4_DraggablePiring> ().moveable = true;
						succ.GetComponent<P4_DraggablePiring> ().putHintHere (succ.transform.position);
					} 
					if (gameObject.name == "PiringAyah") {
						GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowClutterAnim = true;
					}
					GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().setPlate (gameObject.name);
					GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().plateCounter++;

				}
			} else if (snap2) {
				if (Vector3.Distance (transform.position, target2.position) >= dDist) {
					transform.position = Vector3.Lerp (transform.position, target2.position, moveSpeed *
						Time.deltaTime);
				} else {
					GetComponent<AudioSource> ().Play ();

					transform.position = target2.position;
					moving = false;
					moveable = false;
					// events
					if (succ) {

						succ.GetComponent<P4_DraggablePiring> ().moveable = true;
						succ.GetComponent<P4_DraggablePiring> ().putHintHere (succ.transform.position);
					} 
					if (gameObject.name == "PiringAyah") {
						GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowClutterAnim = true;
					}
					GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().setPlate (gameObject.name);
					GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().plateCounter++;

				}
			} else {
				if (Vector3.Distance (transform.position, initPos) >= dDist) {
					transform.position = Vector3.Lerp (transform.position, initPos, moveSpeed *
						Time.deltaTime);
				} else {
					transform.position = initPos;
					moving = false;
				}
			}

		}

	}

}
