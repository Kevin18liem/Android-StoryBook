using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P13_Pintu : MonoBehaviour {

	public bool allowTap = false;

	private Animator anim;
	private GameObject seqManager;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		seqManager = GameObject.Find ("SequenceManager");

	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began) && allowTap) {

			Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					anim.SetTrigger ("buka");
					seqManager.GetComponent<P13_SequenceManager> ().DoorTapped ();

					allowTap = false;
				}
			}

		} else if (Input.GetMouseButtonDown (0) && allowTap) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					anim.SetTrigger ("buka");
					seqManager.GetComponent<P13_SequenceManager> ().DoorTapped ();

					allowTap = false;
				}
			}
		}

	}

	public void AnimationDone() {
		seqManager.GetComponent<P13_SequenceManager> ().AyahMasukDone ();
	}

}
