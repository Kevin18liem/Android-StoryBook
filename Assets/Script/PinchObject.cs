using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchObject : MonoBehaviour {
	public GameObject objectLeft;
	public GameObject objectRight;
	public GameObject targetLeft;
	public GameObject targetRight;
	public float maxDelta = 0.1f;
	public KeyCode takeScreenshotKey;

	float distanceTouch;
	float distanceObject;
	Vector3 InitLeft;
	Vector3 InitRight;
	Vector3 InitTouchLeft;
	Vector3 InitTouchRight;
	float deltaLeft;
	float deltaRight;
	bool isDragging;
	bool move;
	public float movementSpeed=4;
	public float threshold=0.5f;
	bool reachedTarget = false;

	// Use this for initialization
	void Start () {
		InitLeft = objectLeft.transform.position;
		InitRight = objectRight.transform.position;
		distanceObject = Mathf.Abs (InitLeft.x - InitRight.x);
		isDragging = false;
		move = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (takeScreenshotKey)) {
			objectLeft.transform.position = targetLeft.transform.position;
			objectRight.transform.position = targetRight.transform.position;
		}
		if ((Input.touchCount == 2) && !isDragging && !reachedTarget) {
			if (((Input.GetTouch (0).phase == TouchPhase.Began) || (Input.GetTouch (1).phase == TouchPhase.Began))) {
				Debug.Log ("begin");
				findDirection ();
				distanceTouch = Mathf.Abs (InitTouchLeft.x - InitTouchRight.x);
				isDragging = true;
			}
		}
		if ((Input.touchCount == 2) && isDragging) {
			if (((Input.GetTouch (0).phase == TouchPhase.Moved) || (Input.GetTouch (1).phase == TouchPhase.Moved))) {
				deltaLeft = (findTouchLeft () - InitTouchLeft.x);
				deltaRight = (InitTouchRight.x - findTouchRight ());
				if (deltaLeft > 0)
				objectLeft.transform.position = new Vector3 (InitLeft.x + deltaLeft * (distanceObject / (distanceTouch + 0.01f)), InitLeft.y, InitLeft.z);
				if (deltaRight > 0)
				objectRight.transform.position = new Vector3 (InitRight.x - deltaRight * (distanceObject / (distanceTouch + 0.01f)), InitRight.y, InitRight.z);

			}
		}
		if (Input.touchCount == 2 && isDragging) {
			if (((Input.GetTouch (0).phase == TouchPhase.Ended) || (Input.GetTouch (0).phase == TouchPhase.Canceled))
			    || ((Input.GetTouch (1).phase == TouchPhase.Ended) || (Input.GetTouch (1).phase == TouchPhase.Canceled))) {
				isDragging = false;
				move = true;
			}
		}
		if (move && !isDragging) {
			if (cekDelta()) {
				if (!SnapReady()) {
					objectLeft.transform.position = Vector3.MoveTowards (
						objectLeft.transform.position, 
						targetLeft.transform.position, 
						movementSpeed * Time.deltaTime);
					objectRight.transform.position = Vector3.MoveTowards (
						objectRight.transform.position, 
						targetRight.transform.position, 
						movementSpeed * Time.deltaTime);
				} else {
					objectLeft.transform.position = targetLeft.transform.position;
					objectRight.transform.position = targetRight.transform.position;
					move = false;
					reachedTarget = true;
				}
			} else {
				if (!SnapReady ()) {
					objectLeft.transform.position = Vector3.MoveTowards (
						objectLeft.transform.position, 
						InitLeft, 
						movementSpeed * Time.deltaTime);
					objectRight.transform.position = Vector3.MoveTowards (
						objectRight.transform.position, 
						InitRight, 
						movementSpeed * Time.deltaTime);
				} else {
					objectLeft.transform.position = InitLeft;
					objectRight.transform.position = InitRight;
					move = false;
				}
			}
		}
	}

	bool cekDelta() {
		return ((Mathf.Abs (objectLeft.transform.position.x - targetLeft.transform.position.x) <= threshold)
			&& (Mathf.Abs (objectRight.transform.position.x - targetRight.transform.position.x) <= threshold));
	}
	
	bool SnapReady() {
		return ((Mathf.Abs (objectLeft.transform.position.x - targetLeft.transform.position.x) <= maxDelta)
			&& (Mathf.Abs (objectRight.transform.position.x - targetRight.transform.position.x) <= maxDelta));
	}

	bool detectPinch() {
		return(Input.GetTouch (0).phase == TouchPhase.Moved && Input.GetTouch (1).phase == TouchPhase.Moved);
	}
	void findDirection() {
		if (Input.GetTouch (0).position.x < Input.GetTouch (1).position.x) {
			InitTouchLeft = Input.GetTouch (0).position;
			InitTouchRight = Input.GetTouch (1).position;
		} else {
			InitTouchLeft = Input.GetTouch (1).position;
			InitTouchRight = Input.GetTouch (0).position;
		}
	}

	float findTouchLeft() {
		if (Input.GetTouch (0).position.x < Input.GetTouch (1).position.x) {
			return Input.GetTouch (0).position.x;
		} else {
			return Input.GetTouch (1).position.x;
		}
	}

	float findTouchRight() {
		if (Input.GetTouch (0).position.x < Input.GetTouch (1).position.x) {
			return Input.GetTouch (1).position.x;
		} else {
			return Input.GetTouch (0).position.x;
		}
	}

}
