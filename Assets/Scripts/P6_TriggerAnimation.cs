using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P6_TriggerAnimation : MonoBehaviour {

	public string trigger;				// animation trigger
	public Animator anim;				// object's animator
	public bool trigger_allowed = true;	// true if trigger allowed
	public float speed = 1.5f;			// animation speed
	public float opTreshold = 0.5f;

	// Use this for initialization
	void Start () {

		// initialize animator
		anim = GetComponent<Animator>();
		anim.speed = speed;

	}

	// Update is called once per frame
	void Update () {

		Debug.Log (GetComponent<SpriteRenderer> ().color.a);
		if (GetComponent<SpriteRenderer> ().color.a > opTreshold) {
			if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began) && trigger_allowed) {
				Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				RaycastHit raycastHit;
				if (Physics.Raycast (raycast, out raycastHit)) {
					if (raycastHit.collider.name == gameObject.name) {
						anim.SetTrigger (trigger);
					}

				}
			} else if (Input.GetMouseButtonDown (0) && trigger_allowed) {
				Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit raycastHit;
				if (Physics.Raycast (raycast, out raycastHit)) {
					if (raycastHit.collider.name == gameObject.name) {
						anim.SetTrigger (trigger);
					}

				}
			}

		}
	}
}
