using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_DraggablePiring : MonoBehaviour {

	public float dDist = 0.1f;			// distance minimum for object to be moved
	public float moveSpeed = 10;		// movement speed
	public Transform target;			// target location
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
	private Animator anim;				// object's animator
	private bool moved;					// true if reached target
	private GameObject hint;			// the hint

	// Use this for initialization
	void Start () {

		// initialize
		isdragging = false;
		initPos = transform.position;
		moving = false;
		anim = GetComponent<Animator> ();
		anim.speed = anim_speed;
		hint = GameObject.FindGameObjectWithTag ("hint");
		if (moveable) {
			putHintHere (transform.position);
		}

	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && !moving && moveable && 				
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowPlateMove
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
					putHintHere (target.position);
					isdragging = true;
				}
			}
		}

		if (isdragging && Input.GetTouch(0).phase == TouchPhase.Moved) {
			temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
				dist);
			temp = Camera.main.ScreenToWorldPoint (temp);

			transform.position = temp + offset;
		}

		if (isdragging && (Input.GetTouch (0).phase == TouchPhase.Ended ||
		    Input.GetTouch (0).phase == TouchPhase.Canceled)) {

			anim.SetTrigger ("boop");
			isdragging = false;

			if (Vector3.Distance (transform.position, target.position) <= treshold) {
				snap = true;
			} else {
				snap = false;
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
					// events
					if (succ) {
						
						succ.GetComponent<P4_DraggablePiring> ().moveable = true;
						succ.GetComponent<P4_DraggablePiring> ().putHintHere (succ.transform.position);
					} else {
						hint.SetActive (false);
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
					hint.SetActive (true);
					transform.position = initPos;
					moving = false;
				}
			}
		}
			
	}

	public void putHintHere(Vector3 pos) {
		if (!GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowPlateMove) {
			hint.transform.position = new Vector3 (pos.x + 1, pos.y - 1.5f, 1);
		} else {
			hint.transform.position = new Vector3 (pos.x + 1, pos.y - 1.5f, initPos.z);
		}

	}

}
