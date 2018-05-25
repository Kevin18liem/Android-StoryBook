using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_TriggerAnimation : MonoBehaviour {

	public string trigger;				// animation trigger
	public Animator anim;				// object's animator
	public float speed = 1.5f;			// animation speed

	private P4_SequenceManager 
		sequenceManager;

	// Use this for initialization
	void Start () {

		// initialize animator
		anim = GetComponent<Animator>();
		anim.speed = speed;

		sequenceManager = GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ();

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began) &&
			sequenceManager.allowClutterAnim) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					GetComponent<AudioSource> ().Play ();
					anim.SetTrigger (trigger);
				}

			}
		} else if ((Input.GetMouseButtonDown (0) &&
			sequenceManager.allowClutterAnim)) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					GetComponent<AudioSource> ().Play ();
					anim.SetTrigger (trigger);
				}

			}
		}
	}
}
