using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P15_Mobil : MonoBehaviour {

	public bool allowClick = false;
	public GameObject button;

	private Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began) && allowClick) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					anim.SetTrigger ("jalan");
					GetComponent<AudioSource> ().Play ();
				}

			}
		} else if (Input.GetMouseButtonDown (0) && allowClick) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					anim.SetTrigger ("jalan");
					GetComponent<AudioSource> ().Play ();

				}

			}
		}
			
	}

	public void FinishPage() {
		button.SetActive (true);
	}

}
