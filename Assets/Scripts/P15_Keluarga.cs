using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P15_Keluarga : MonoBehaviour {

	public GameObject subtitle;
	public bool allowPinch = false;

	private bool pinchDone = false;
	private bool isPinching = false;
	private float deltaPos;
	private Animator anim;
	private GameObject seqManager;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		seqManager = GameObject.Find ("SequenceManager");
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount == 2 && allowPinch && !pinchDone) {
			Touch touch1 = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);

			if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began) {
				deltaPos = Vector3.Distance (touch1.position, touch2.position);
				isPinching = true;
			}

			if (isPinching) {

				Debug.Log (deltaPos + " " + Vector3.Distance (touch1.position, touch2.position));

				if (((touch1.phase == TouchPhase.Ended) || (touch1.phase == TouchPhase.Canceled))
					|| ((touch2.phase == TouchPhase.Ended) || (touch2.phase == TouchPhase.Canceled))) {
					isPinching = false;
					if (Vector3.Distance (touch1.position, touch2.position) < deltaPos) {
						pinchDone = true;
						anim.SetTrigger ("peluk");
						//subtitle.GetComponent<P15_Subtitle> ().FadeOut ();

					}
				}
			}

		}

		if (Input.GetKeyDown (KeyCode.Space) && allowPinch && !pinchDone) {
			pinchDone = true;
			anim.SetTrigger ("peluk");
			//subtitle.GetComponent<P15_Subtitle> ().FadeOut ();
		}
		
	}

	public void FinishPinch() {
		seqManager.GetComponent<P15_SequenceManager> ().FinishPinch ();
	}

	public void MoveSprite() {
		Debug.Log ("move");
		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.3f, transform.position.z);
	}
	public void DisableHint() {
		seqManager.GetComponent<P15_SequenceManager> ().pinchHint.SetActive (false);
	}
}
