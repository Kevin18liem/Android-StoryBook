using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_Draggable : MonoBehaviour {

	public float dDist = 0.1f;			// distance minimum for object to be moved
	public float moveSpeed = 10;		// movement speed
	public Transform target;			// target location
	public Transform end;
	public float treshold = 0.8f;		// distance minimum for object to be snapped
	public bool moveable = false;		// true if mvoeable
	public GameObject anak;

	private bool isdragging;			// true if dragging
	private float dist;					// distance from camera to collider
	private Vector3 offset;				// projection of touch
	private Transform toDrag;			// hit location
	private Vector3 temp;				// used to save temporary v3
	private Vector3 initPos;			// initial position
	private bool moving;				// true if still on automated moving
	private bool snap;					// true if object near target
	private bool moved;					// true if reached target
	private GameObject seqManager;

	// Use this for initialization
	void Start () {

		// initialize
		isdragging = false;
		initPos = transform.position;
		moving = false;
		seqManager = GameObject.Find ("SequenceManager");

	}
	
	// Update is called once per frame
	void Update () {
		if (seqManager.GetComponent<P5_SequenceManager>().movable && !GetComponent<Animator>().enabled && !snap && !isdragging) {
			GetComponent<Animator> ().enabled = true;
		}
		if (anak.GetComponent<Animator> ().IsInTransition(0) && 
			anak.GetComponent<Animator>().GetNextAnimatorStateInfo (0).IsName("anak-idle") && transform.position.z > -0.1f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, -0.1f);
		} else {
		}

		Debug.Log (seqManager.GetComponent<P5_SequenceManager> ().movable);

		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && !moving && seqManager.GetComponent<P5_SequenceManager>().movable) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					GetComponent<Animator> ().enabled = false;
					dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;

					isdragging = true;
				}

			}
		} else if (Input.GetMouseButtonDown(0) && !moving && seqManager.GetComponent<P5_SequenceManager>().movable) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					GetComponent<Animator> ().enabled = false;
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
			temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, dist);
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
				GetComponent<Animator> ().enabled = false;
			}
			moving = true;
		} else if (isdragging && Input.GetMouseButtonUp(0)) {

			isdragging = false;

			if (Vector3.Distance (transform.position, target.position) <= treshold &&
				(anak.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("anak-idle"))) {
				snap = true;
			} else {
				snap = false;
				GetComponent<Animator> ().enabled = true;
			}
			moving = true;
		}


		if (moving) {
			if (snap) {
				if (Vector3.Distance (transform.position, target.position) >= dDist) {
					transform.position = Vector3.Lerp (transform.position, target.position, moveSpeed *
						Time.deltaTime);
				} else {
					transform.position = target.position;
					moving = false;
					moveable = false;
					anak.GetComponent<P5_Anak> ().TriggerAnimation (gameObject);
					transform.position = new Vector3 (end.position.x, end.position.y, 2);
					if (PlayerPrefs.GetString ("Musik") == "on") {
						GetComponent<AudioSource> ().Play ();
					}
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
