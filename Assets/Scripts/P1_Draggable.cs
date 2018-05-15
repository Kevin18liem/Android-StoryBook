using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Draggable : MonoBehaviour {

	public float dDist = 0.1f;			// distance minimum for object to be moved
	public float moveSpeed = 10;		// movement speed
	public Transform target;			// target location
	public float treshold = 0.8f;		// distance minimum for object to be snapped
	public float anim_speed = 4;		// animation speed
	public string trigger;
	public GameObject keranjangSprite;

	private bool isdragging;			// true if dragging
	private float dist;					// distance from camera to collider
	private Vector3 offset;				// projection of touch
	private Transform toDrag;			// hit location
	private Vector3 temp;				// used to save temporary v3
	private Vector3 initPos;			// initial position
	private bool moving;				// true if still on automated moving
	private bool snap;					// true if object near target
	private bool moved;					// true if reached target
	private float time = 0;
	private bool countTime = false;
	private bool tapped = false;

	// Use this for initialization
	void Start () {

		// initialize
		isdragging = false;
		initPos = transform.position;
		moving = false;

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (moving + " " + isdragging);

		if (countTime) {
			time += Time.deltaTime;
		}

		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && !moving && !isdragging) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					GetComponent<Animator> ().enabled = false;
					countTime = true;
					dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;
					isdragging = true;
				}
			}
		} else if (Input.GetMouseButtonDown(0) && !moving && !isdragging) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					GetComponent<Animator> ().enabled = false;
					countTime = true;
					dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;
					isdragging = true;
				}
			}
		}

		if (isdragging && tapped){
			//Debug.Log(Vector3.Distance (transform.position, target.position));
			temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
				dist);
			temp = Camera.main.ScreenToWorldPoint (temp);

			transform.position = temp + offset;
		}

		if (isdragging && Input.touchCount == 1 && (Input.GetTouch (0).phase == TouchPhase.Ended ||
			Input.GetTouch (0).phase == TouchPhase.Canceled)) {

			isdragging = false;

			if (Vector3.Distance (transform.position, target.position) <= treshold) {
				snap = true;
			} else {
				snap = false;
				GetComponent<Animator> ().enabled = true;

			}
			moving = true;
			if (time <= 0.5f) {
				GetComponent<Animator> ().enabled = true;
				GetComponent<Animator> ().SetTrigger (trigger);
				GetComponent<AudioSource> ().Play ();
				moving = false;
				tapped = true;
			}
			countTime = false;
			time = 0;
		} else if (isdragging && Input.GetMouseButtonUp(0)) {

			isdragging = false;

			if (Vector3.Distance (transform.position, target.position) <= treshold) {
				snap = true;
			} else {
				snap = false;
				GetComponent<Animator> ().enabled = true;

			}
			moving = true;
			if (time <= 0.5f) {
				GetComponent<Animator> ().enabled = true;
				GetComponent<Animator> ().SetTrigger (trigger);
				GetComponent<AudioSource> ().Play ();
				moving = false;
				tapped = true;
			}
			countTime = false;
			time = 0;
		} 

		if (moving) {
			if (snap) {
				if (Vector3.Distance (transform.position, target.position) >= dDist) {
					transform.position = Vector3.Lerp (transform.position, target.position, moveSpeed *
						Time.deltaTime);
				} else {
					transform.position = target.position;
					gameObject.SetActive (false);
					keranjangSprite.SetActive (true);
					moving = false;
					// events

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
