using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crayon : MonoBehaviour {
	private GameObject kodeWarna;
	public string warna;
	public float moveDistance = 0.4f;
	public float dDist = 0.01f;
	public float moveSpeed = 4;
	public GameObject selector;

	private bool movingUp;
	private bool movingDown;
	private Vector3 target;
	private Vector3 initPos;
	private CrayonSelector crayonselector;

	// Use this for initialization
	void Start () {
		kodeWarna = GameObject.FindGameObjectWithTag ("swapmanager");
		target = new Vector3(transform.position.x, transform.position.y + moveDistance, transform.position.z);
		initPos = transform.position;
		movingDown = false;
		crayonselector = selector.GetComponent<CrayonSelector> ();
		if (crayonselector.selectedCrayon.name == gameObject.name) {
			movingUp = true;
		} else {
			movingUp = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && !movingUp && !movingDown)
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					kodeWarna.GetComponent<SwipeTrail>() .KodeWarna = warna;
					if (crayonselector.selectedCrayon.name != gameObject.name) {
						crayonselector.selectedCrayon.GetComponent<Crayon> ().resetPos ();
						crayonselector.selectedCrayon = gameObject;
						movingUp = true;

					}
				}
			}
		} else if (Input.GetMouseButtonDown(0) && !movingUp && !movingDown)
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					kodeWarna.GetComponent<SwipeTrail>() .KodeWarna = warna;
					if (crayonselector.selectedCrayon.name != gameObject.name) {
						crayonselector.selectedCrayon.GetComponent<Crayon> ().resetPos ();
						crayonselector.selectedCrayon = gameObject;
						movingUp = true;

					}
				}
			}
		}

		if (movingUp) {
			if (Vector3.Distance (transform.position, target) >= dDist) {
				transform.position = Vector3.Lerp (transform.position, target, moveSpeed *
					Time.deltaTime);
			} else {
				transform.position = target;
				movingUp = false;
			}
		}

		if (movingDown) {
			if (Vector3.Distance (transform.position, initPos) >= dDist) {
				transform.position = Vector3.Lerp (transform.position, initPos, moveSpeed *
					Time.deltaTime);
			} else {
				transform.position = initPos;
				movingDown = false;
			}
		}
	}

	public void resetPos() {
		movingDown = true;
	}

}
