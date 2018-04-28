using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_SubHolder : MonoBehaviour {

	public bool allowClick = false;	// true if trigger allowed
	public float speed = 1;				// animation speed
	public GameObject subtitle;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) {

			Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					if (allowClick) {
						allowClick = false;
						subtitle.GetComponent<P3_Subtitles> ().FadeOut ();
					} else {
						subtitle.GetComponent<P3_Subtitles> ().setToEnd ();
					}
				}

			}
			
		} else if (Input.GetMouseButtonDown (0)) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					if (allowClick) {
						allowClick = false;
						subtitle.GetComponent<P3_Subtitles> ().FadeOut ();
					} else {
						subtitle.GetComponent<P3_Subtitles> ().setToEnd ();
					}
				}

			}
		}

	}
}
