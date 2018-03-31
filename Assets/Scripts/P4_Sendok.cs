using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_Sendok : MonoBehaviour {

	public Sprite full;
	public Sprite empty;

	private SpriteRenderer curr;
	private bool isdragging;			// true if dragging
	private float dist;					// distance from camera to collider
	private Vector3 offset;				// projection of touch
	private Transform toDrag;			// hit location
	private Vector3 temp;				// used to save temporary v3
	private Vector3 initPos;			// initial position

	// Use this for initialization
	void Start () {

		curr = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began) && 
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowClutterAnim) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{

					dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;

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

			isdragging = false;

		}
		
	}

	public void SetFull() {
		curr.sprite = full;
	}

	public void SetEmpty() {
		curr.sprite = empty;
	}
}
